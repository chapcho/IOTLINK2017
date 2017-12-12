using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public static class CModbusCRC16Checker
    {
        public static void CalculateCRC(byte[] pByte, int nNumberOfBytes, out byte hi, out byte lo)
        {
            ushort sum;
            CalculateCRC(pByte, nNumberOfBytes, out sum);
            lo = (byte)(sum & 0xFF);
            hi = (byte)((sum & 0xFF00) >> 8);
        }

        private static void CalculateCRC(byte[] pByte, int nNumberOfBytes, out ushort pChecksum)
        {
            int nBit;
            ushort nShiftedBit;
            pChecksum = 0xFFFF;

            for (int nByte = 0; nByte < nNumberOfBytes; nByte++)
            {
                pChecksum ^= pByte[nByte];
                for (nBit = 0; nBit < 8; nBit++)
                {
                    if ((pChecksum & 0x1) == 1)
                    {
                        nShiftedBit = 1;
                    }
                    else
                    {
                        nShiftedBit = 0;
                    }
                    pChecksum >>= 1;
                    if (nShiftedBit != 0)
                    {
                        pChecksum ^= 0xA001;
                    }
                }
            }
        }
    }
}
