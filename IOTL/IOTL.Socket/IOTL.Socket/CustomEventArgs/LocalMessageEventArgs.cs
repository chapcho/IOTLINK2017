using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IOTL.Socket.Type;

namespace IOTL.Socket.CustomEventArgs
{
	/// <summary>
	/// 메시지 이벤트용 형식입니다.
	/// </summary>
	public class LocalMessageEventArgs : EventArgs
	{
        /// <summary>
        /// 메시지
        /// </summary>

        public string sessionID = "";
		public string Message = "";
        public byte[] receiveData = null;
		/// <summary>
		/// 메시지 타입
		/// </summary>
		public typeLocal Icon = typeLocal.None;

		/// <summary>
		/// 메시지 설정
		/// </summary>
		/// <param name="strMsg"></param>
		/// <param name="typeIcon"></param>
		public LocalMessageEventArgs(string strMsg, typeLocal typeIcon)
		{
            this.sessionID = "None";
            this.Message = strMsg;
			this.Icon = typeIcon;
		}

        public LocalMessageEventArgs(string sessionID, string strMsg, byte[] rcvBuf)
        {
            this.sessionID = sessionID;
            this.Message = strMsg;
            this.receiveData = rcvBuf;
        }

        public LocalMessageEventArgs(string strMsg, byte[] rcvBuf)
        {
            this.sessionID = "None";
            this.Message = strMsg;
            this.receiveData = rcvBuf;
        }

        public LocalMessageEventArgs()
		{
			this.Message = "";
			this.Icon = typeLocal.None;
		}
	}
}
