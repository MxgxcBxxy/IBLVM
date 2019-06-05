﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBLVM_Library.Interfaces;
using IBLVM_Library.Handlers;
using IBLVM_Library;

namespace IBLVM_Management
{
	class ManagerHandlerChain
	{
		private readonly PacketHandlerChain chain;

		public ManagerHandlerChain(IIBLVMSocket socket)
		{
			chain = new PacketHandlerChain(socket);
			chain.AddHandler(new IVChangeRequestHandler());
			chain.AddHandler(new IVChangeResponseHandler());
			chain.AddHandler(new ServerKeyResponseHandler());
			chain.AddHandler(new ServerLoginResponseHandler());
        }

		public bool DoHandle(IPacket header) => chain.DoHandle(header);
	}
}
