﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

using IBLVM_Library;
using IBLVM_Library.Interfaces;
using IBLVM_Library.Models;

using IBLVM_Server.Interfaces;
using IBLVM_Server.Enums;
using System.Net;

namespace IBLVM_Server
{
	/// <summary>
	/// 클라이언트 소켓에 대한 응답 처리를 위한 클래스입니다.
	/// </summary>
	class ClientHandler : IIBLVMSocket, IDisposable
	{
		#region IIBLVMSocket Implements
		public int Status { get; set; } = (int)SocketStatus.Uninitialized;

		public CryptoProvider CryptoProvider { get; set; } = new CryptoProvider();

		public IPacketFactory PacketFactory { get; private set; }

		public NetworkStream GetSocketStream() => socketStream;
		#endregion

		public Thread Thread { get; private set; }

		public event Action<ClientHandler> OnHandlerDisposed = (a) => { };

		private readonly NetworkStream socketStream;
		private readonly ServerHandlerChain chain;
		private readonly Socket socket;
		private readonly IDeviceController deviceController = new DeviceController();
		private byte[] buffer;

		public ClientHandler(Socket socket, ISession session, IPacketFactory packetFactory)
		{
			this.socket = socket;
			this.PacketFactory = packetFactory;

			buffer = new byte[packetFactory.PacketSize * 2];
			socketStream = new NetworkStream(socket);
			chain = new ServerHandlerChain(this, session, deviceController, packetFactory);
			chain.OnClientLoggedIn += OnClientLoggedIn;
		}

		public void Start()
		{
            Thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Utils.ReadFull(socketStream, buffer, PacketFactory.PacketSize);
                        IPacket header = PacketFactory.ParseHeader(buffer);
                        chain.DoHandle(header);
                    }
                    catch (Exception)
                    {
						Dispose();
						if (socket.Connected)
							throw;

						return;
                    }
                }
            })
            {
                Name = string.Format("IBLVM Client handler [{0}]", socket.RemoteEndPoint.ToString())
            };
            Thread.Start();
		}

        public void GetBitLockerVolumes()
        {
            IPacket packet = PacketFactory.CreateServerBitLockersReqeust();
            Utils.SendPacket(socketStream, packet);
        }

		#region Handler event hooks
		private void OnClientLoggedIn(IAuthInfo authInfo)
		{
			if (authInfo.Type == IBLVM_Library.Enums.ClientType.Device)
				deviceController.AddDevice(authInfo.Account.Id, new Device((IPEndPoint)socket.RemoteEndPoint, authInfo));
		}
		#endregion

		#region IDisposable Implements
		public void Dispose()
		{
			if (socket.Connected)
			{
				socket.Disconnect(false);
				socket.Dispose();

				socketStream.Close();
			}
			
			CryptoProvider.Dispose();
			buffer = null;

			OnHandlerDisposed(this);
		}
		#endregion
	}
}
