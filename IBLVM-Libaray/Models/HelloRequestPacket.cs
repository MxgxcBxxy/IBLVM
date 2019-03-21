﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLVM_Libaray.Interfaces;

namespace IBLVM_Libaray.Models
{
	sealed class HelloRequestPacket : BasePacket
	{
		public HelloRequestPacket() : base(Enums.PacketType.Hello) { }

		public override Stream GetPayloadStream() => null;
	}
}