using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDMEnergyViewer
{
    public enum emFunctionCode:byte
    {
        /// <summary>
        /// Read Digitl Output
        /// </summary>
        ReadDO = 1,
        /// <summary>
        /// Read Digitl Input
        /// </summary>
        ReadDI = 2,
        /// <summary>
        /// Read Data
        /// </summary>
        ReadData = 3,
        /// <summary>
        /// Control DO
        /// </summary>
        Control = 5,
        /// <summary>
        /// Preset Multiple registers
        /// </summary>
        Preset = 16
    }
}
