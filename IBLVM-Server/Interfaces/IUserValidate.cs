﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLVM_Server.Interfaces
{
	/// <summary>
	/// 사용자의 인증 정보의 유효성 검증을 제공합니다.
	/// </summary>
	public interface IUserValidate
	{
		/// <summary>
		/// 식별자-비밀번호 기반의 사용자 인증 정보의 유효성을 검증합니다.
		/// </summary>
		/// <param name="id">사용자의 식별자입니다.</param>
		/// <param name="password">사용자의 비밀번호입니다.</param>
		/// <returns>유효한 인증 정보일 경우 true, 그렇지 않으면 false 입니다.</returns>
		bool Validate(string id, string password);
	}
}
