﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Security.Cryptography;

using IBLVM_Library.Interfaces;
using IBLVM_Library.Models;
using IBLVM_Library;

using IBLVM_Server.Enums;
using IBLVM_Server.Interfaces;
using IBLVM_Library.Exceptions;

using IBLVM_Library.Enums;

using SecureStream;

namespace IBLVM_Server.Handlers
{
	class ClientLoginHandler : IPacketHandler
	{
		private readonly ISession session;

		public ClientLoginHandler(ISession session)
		{
			this.session = session;
		}

		public bool Handle(IPacket header, IIBLVMSocket socket)
		{
			if (header.Type == PacketType.ClientLoginRequest)
			{
                Utils.PacketValidation(socket.Status, (int)SocketStatus.Connected, header.GetPayloadSize());

                IPayload<IAccount> packet = socket.PacketFactory.CreateClientLoginRequest(null, null, socket.CryptoProvider.CryptoStream);
				packet.ParsePayload(header.GetPayloadSize(), socket.GetSocketStream());

				bool isSuccess = session.Login(packet.Payload.Id, packet.Payload.Password);
				IPacket response = socket.PacketFactory.CreateServerLoginResponse(isSuccess);
				Utils.SendPacket(socket.GetSocketStream(), response);

				if (!isSuccess)
					throw new InvalidAuthorizationDataException();
				
				socket.Status = (int)SocketStatus.LoggedIn;
				return true;
			}

			return false;
		}
	}
}
