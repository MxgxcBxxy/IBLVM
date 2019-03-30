﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLVM_Libaray.Interfaces
{
	public interface IPacketFactory
	{
		IPacket CreateClientHello();

		IPacket CreateServerKeyResponse(byte[] cryptoKey);

		byte[] MagicBytes { get; }

		int PacketSize { get; }
	}
}
