using System.Text;

namespace IOTL.Common.Framework
{
    public class CSocketDataByteArray : IReceiveData
    {
        private const int MAX_SOCKET_DATA_LENGTH = 4096;
        int _dataLength;
        byte[] _receiveData = new byte[MAX_SOCKET_DATA_LENGTH];

        public int Length
        {
            get { return _dataLength; }
        }

        public object ReceiveData
        {
            get { return _receiveData; }
            set {
                _receiveData = (byte[])value;
            }
        }

        public void SetReceiveData(string sData)
        {
            SetReceiveData(sData, Encoding.GetEncoding("UTF8").CodePage);
        }

        public void SetReceiveData(string sData,  int codePage)
        {
            _dataLength = sData.Length;
            System.Array.Clear(_receiveData, 0, MAX_SOCKET_DATA_LENGTH);

            if (sData.Length < MAX_SOCKET_DATA_LENGTH)
            {
                _receiveData = Encoding.GetEncoding(codePage).GetBytes(sData);
            }
        }

        public void SetReceiveDataToHex(string sData)
        {
            System.Array.Clear(_receiveData, 0, MAX_SOCKET_DATA_LENGTH);
            string hexData;
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < sData.Length;i++)
            {
                hexData = string.Format("{0:x2}", sData.Substring(i, 1));
                sb.Append(hexData);
            }

            SetReceiveData(sb.ToString());
        }

    }
}
