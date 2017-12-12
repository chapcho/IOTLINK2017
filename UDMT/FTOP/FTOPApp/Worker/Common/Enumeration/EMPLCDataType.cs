using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public enum EMPLCDataType
    {
        None,
        Bool,
        Byte,
        Word,
        DWord,
        Block,

        //For Siemens 150921
        Any,
        Int,
        DInt,
        Real,
        Timer,
        Time,
        Counter,
        Char,
        String,
        S5Time,
        Date,
        Time_Of_Day,
        Date_And_Time,
        UserDefDataType,
        // For Siemens 150921

        // For AB 150916
        SInt,
        Control,
        Message,
        // For AB 150916

        //Yokogawa
        Float
    }
}
