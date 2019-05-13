﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLVM_Library.Enums
{
	/// <summary>
	/// 패킷의 타입을 나타내는 열거형입니다.
	/// </summary>
	public enum PacketType : short
	{
		/// <summary>
		/// 핸드셰이크 시작을 나타냅니다.
		/// </summary>
		Hello = 0,

		/// <summary>
		/// 핸드셰이크 과정에서 서버측에서 클라이언트에게 보내는 키 응답입니다.
		/// </summary>
		ServerKeyResponse,

		/// <summary>
		/// 핸드셰이크 과정에서 클라이언트에서 서버에게 보내는 키 응답입니다.
		/// </summary>
		ClientKeyResponse,

		/// <summary>
		/// 암호화에 사용되는 초기화 벡터 교환에 대한 요청입니다.
		/// </summary>
		IVChangeReqeust,

        /// <summary>
        /// 암호화에 사용되는 초기화 벡터 교환에 대한 응답입니다.
        /// </summary>
        IVChangeResponse,

		/// <summary>
		/// 클라이언트가 서버에 로그인함을 나타냅니다.
		/// </summary>
		ClientLoginRequest,

		/// <summary>
		/// 서버에서 클라이언트 측에 로그인 결과를 알림을 나타냅니다.
		/// </summary>
		ServerLoginResponse,

        /// <summary>
        /// 서버에서 요청한 BitLocker 볼륨에 대한 응답을 나타냅니다.
        /// </summary>
		ClientBitLockersResponse,

        /// <summary>
        /// 서버에서 클라이언트에게 BitLocker 볼륨 목록에 대한 요청을 나타냅니다.
        /// </summary>
		ServerBitLockersRequest,

		/// <summary>
		/// 서버에서 클라이언트의 BitLocker 볼륨의 잠금 해제 명렁을 나타냅니다.
		/// </summary>
        ServerBitLockerUnlockCommand,

		/// <summary>
		/// 서버에서 클라이언트의 BitLocker 볼륨의 잠금 명령을 나타냅니다.
		/// </summary>
        ServerBitLockerLockCommand,

		/// <summary>
		/// 클라이언트에서 서버의 명령 실행 여부에 대한 응답을 나타냅니다.
		/// </summary>
        ClientBitLockerCommandResponse,

		/// <summary>
		/// 서버에서 클라이언트의 드라이브 목록 요청을 나타냅니다.
		/// </summary>
        ServerDrivesRequest,

		/// <summary>
		/// 클라이언트에서 서버의 드라이브 목록 요청에 대한 응답을 나타냅니다.
		/// </summary>
        ClientDrivesResponse,

		/// <summary>
		/// 클라이언트에서 서버에 디바이스 목록 요청을 나타냅니다.
		/// </summary>
        ClientDevicesRequest,

		/// <summary>
		/// 서버에서 클라이언트의 디바이스 목록 요청에 대한 응답을 나타냅니다.
		/// </summary>
        ServerDevicesResponse
    }
}
