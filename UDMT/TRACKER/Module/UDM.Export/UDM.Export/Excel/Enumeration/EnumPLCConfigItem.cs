using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UDM.Export
{
    #region PLC

    public class ePLC_MAKER
    {
        public const string SIEMENS = "SIEMENS [Step7]";
        public const string AB_ALIAS = "AB PLC [Logix 5000 (Alias)]";
        public const string AB_COMMENT = "AB PLC [Logix 5000 (Comment)]";
        public const string MITSUBISHI_DEVELOPER = "MITSUBISHI PLC [GX Developer]";
        public const string MITSUBISHI_WORKS2 = "MITSUBISHI PLC [GX Works2]";
        public const string MITSUBISHI_WORKS3 = "MITSUBISHI PLC [GX Works3]";
    }

    public class ePLC_SYMBOLLENGTH
    {
        public const int SIEMENS = 24;
        public const int AB = 40;
        public const int MITSUBISHI_DEVELOPER = 32;
        public const int MITSUBISHI_WORKS2 = 32;
    }

    public class ePLC_BLOCKLENGTH
    {
        public const int SIEMENS = 5;
        public const int AB = 6;
        public const int MITSUBISHI_DEVELOPER = 5;
        public const int MITSUBISHI_WORKS2 = 5;
    }


    public class eADDRESS_DATATYPE
    {
        public const string SPARE = "SPARE";
        public const string USE = "USE";
        public const string BIT = "BOOL";
        public const string WORD_SIGNED = "INT";
        public const string WORD_UNSIGNED = "WORD";
        public const string DWORD_SIGNED = "DINT";
        public const string DWORD_UNSIGNED = "DWORD";
        public const string TIMER = "TIMER";
        public const string COUNTER = "COUNTER";
        public const string DB = "DB";

        public const string ARRAY16_BIT = "ARRAY [0..15] OF BOOL";
        public const string ARRAY32_BIT = "ARRAY [0..31] OF BOOL";
        public const string ARRAY64_BIT = "ARRAY [0..63] OF BOOL";
        public const string ARRAY16_WORD_SIGNED = "ARRAY [0..15] OF INT";
        public const string ARRAY32_WORD_SIGNED = "ARRAY [0..31] OF INT";
        public const string ARRAY64_WORD_SIGNED = "ARRAY [0..63] OF INT";
        public const string ARRAY16_WORD_UNSIGNED = "ARRAY [0..15] OF WORD";
        public const string ARRAY32_WORD_UNSIGNED = "ARRAY [0..31] OF WORD";
        public const string ARRAY64_WORD_UNSIGNED = "ARRAY [0..63] OF WORD";
        public const string ARRAY16_DWORD_SIGNED = "ARRAY [0..15] OF DINT";
        public const string ARRAY32_DWORD_SIGNED = "ARRAY [0..31] OF DINT";
        public const string ARRAY64_DWORD_SIGNED = "ARRAY [0..63] OF DINT";
        public const string ARRAY16_DWORD_UNSIGNED = "ARRAY [0..15] OF DWORD";
        public const string ARRAY32_DWORD_UNSIGNED = "ARRAY [0..31] OF DWORD";
        public const string ARRAY64_DWORD_UNSIGNED = "ARRAY [0..63] OF DWORD";
    }

    public class ePLC_SLOT
    {
        public const string BASE00 = "BASE";
        public const string EXTEND01 = "EXT1";
        public const string EXTEND02 = "EXT2";

        public const int BASE00_MAX = 20;
        public const int EXTEND01_MAX = 20;
        public const int EXTEND02_MAX = 20;
    }

    #region SIEMENS

    public class eADDRESS_SPARE_SIEMENS
    {
        public static int MAXIO = 8191; //3E7 (HEXA)
        public static int MAXIO_EXTEND = 9999; //1FFF (HEXA)

        public static int MAXDUMMY = 999;//3E7 (HEXA)
        public static int MAXDUMMY_EXTEND = 9999;//270F (HEXA)
    }

    public class eADDRESS_TYPE_SIEMENS
    {
        public const string INPUT = "I";
        public const string OUTPUT = "Q";

        public const string TYPEIO = "I;Q";
        public const string TYPEDUMMY = "M";
        public const string TYPELINK = "DB";
        public const string TYPETIMER = "T";
        public const string TYPECOUNT = "C";

        public const string LISTALL = "I;Q;M;T;C;DB";
        public const string HEXABITLIST = "";
        public const string WORDLIST = "IW;QW;MW;DB";
        public const string HEXABLCOKLIST = "";

        public const string DOTLIST = "I;Q;M";
    }

    public class eSymbolColumn_SIEMENS
    {
        public const string SYMBOL = "SYMBOL";
        public const string ADDRESS = "ADDRESS";
        public const string DATATYPE = "DATATYPE";
        public const string COMMENT = "COMMENT";

        public const string DEFAULT = "SYMBOL TABLE(IOMAKER).sdf";
    }


    public class eADDRESS_DATATYPE_SIEMENS
    {
        public const string SPARE = "SPARE";
        public const string USE = "USE";
        public const string BIT = "BOOL";
        public const string WORD_SIGNED = "INT";
        public const string WORD_UNSIGNED = "WORD";
        public const string DWORD_SIGNED = "DINT";
        public const string DWORD_UNSIGNED = "DWORD";
        public const string TIMER = "TIMER";
        public const string COUNTER = "COUNTER";
        public const string DB = "DB";

        public const string ARRAY16_BIT = "ARRAY [0..15] OF BOOL";
        public const string ARRAY32_BIT = "ARRAY [0..31] OF BOOL";
        public const string ARRAY64_BIT = "ARRAY [0..63] OF BOOL";
        public const string ARRAY16_WORD_SIGNED = "ARRAY [0..15] OF INT";
        public const string ARRAY32_WORD_SIGNED = "ARRAY [0..31] OF INT";
        public const string ARRAY64_WORD_SIGNED = "ARRAY [0..63] OF INT";
        public const string ARRAY16_WORD_UNSIGNED = "ARRAY [0..15] OF WORD";
        public const string ARRAY32_WORD_UNSIGNED = "ARRAY [0..31] OF WORD";
        public const string ARRAY64_WORD_UNSIGNED = "ARRAY [0..63] OF WORD";
        public const string ARRAY16_DWORD_SIGNED = "ARRAY [0..15] OF DINT";
        public const string ARRAY32_DWORD_SIGNED = "ARRAY [0..31] OF DINT";
        public const string ARRAY64_DWORD_SIGNED = "ARRAY [0..63] OF DINT";
        public const string ARRAY16_DWORD_UNSIGNED = "ARRAY [0..15] OF DWORD";
        public const string ARRAY32_DWORD_UNSIGNED = "ARRAY [0..31] OF DWORD";
        public const string ARRAY64_DWORD_UNSIGNED = "ARRAY [0..63] OF DWORD";
    }


    

    #endregion

    #region AB

    public class eADDRESS_SPARE_AB
    {
        public static int MAXIO = 1299;
        public static int MAXIO_EXTEND = 99999;

        public static int MAXDUMMY = 1299;//3E7 (HEXA)
        public static int MAXDUMMY_EXTEND = 12999;//270F (HEXA)
    }


    public class eADDRESS_TYPE_AB
    {
        public const string INPUT = "I";
        public const string OUTPUT = "O";

        public const string TYPEIO = "I;O";
        public const string TYPEDUMMY = "B;H";
        public const string TYPELINK = "N";
        public const string TYPETIMER = "T";
        public const string TYPECOUNT = "C";
        public const string TYPESPCIAL = "S";

        public const string LISTALL = "I;O;B;H;S;N;T;C";
        public const string WORDLIST = "T;C";
        public const string HEXABITLIST = "";
        public const string HEXABLCOKLIST = "";

        public const string DOTLIST = "I;O;B;N;H";
    }

    public class eSymbolColumn_AB
    {
        public const string TYPE = "TYPE";
        public const string SCOPE = "SCOPE";
        public const string NAME = "NAME";
        public const string DESCRIPTION = "DESCRIPTION";
        public const string DATATYPE = "DATATYPE";
        public const string SPECIFIER = "SPECIFIER";
        public const string ATTRIBUTES = "ATTRIBUTES";
        
        public const string DEFAULT = "SYMBOL TABLE(IOMAKER).csv";
    }



    public class eADDRESS_DATATYPE_AB
    {
        public const string SPARE = "SPARE";
        public const string USE = "USE";
        public const string BIT = "BOOL";
        public const string WORD_SIGNED = "INT";
        public const string WORD_UNSIGNED = "INT";
        public const string DWORD_SIGNED = "DINT";
        public const string DWORD_UNSIGNED = "DINT";
        public const string TIMER = "TIMER";
        public const string COUNTER = "COUNTER";

        public const string ARRAY16_BIT = "ARRAY [0..15] OF BOOL";
        public const string ARRAY32_BIT = "ARRAY [0..31] OF BOOL";
        public const string ARRAY64_BIT = "ARRAY [0..63] OF BOOL";
        public const string ARRAY16_WORD_SIGNED = "ARRAY [0..15] OF INT";
        public const string ARRAY32_WORD_SIGNED = "ARRAY [0..31] OF INT";
        public const string ARRAY64_WORD_SIGNED = "ARRAY [0..63] OF INT";
        public const string ARRAY16_WORD_UNSIGNED = "ARRAY [0..15] OF WORD";
        public const string ARRAY32_WORD_UNSIGNED = "ARRAY [0..31] OF WORD";
        public const string ARRAY64_WORD_UNSIGNED = "ARRAY [0..63] OF WORD";
        public const string ARRAY16_DWORD_SIGNED = "ARRAY [0..15] OF DINT";
        public const string ARRAY32_DWORD_SIGNED = "ARRAY [0..31] OF DINT";
        public const string ARRAY64_DWORD_SIGNED = "ARRAY [0..63] OF DINT";
        public const string ARRAY16_DWORD_UNSIGNED = "ARRAY [0..15] OF DWORD";
        public const string ARRAY32_DWORD_UNSIGNED = "ARRAY [0..31] OF DWORD";
        public const string ARRAY64_DWORD_UNSIGNED = "ARRAY [0..63] OF DWORD";
    }

    public class eERROR_AB
    {
        public const string TAG_BASE_EMPTY = "Tag Empty";
        public const string TAG_DATATYPE_EMPTY = "Tag DataType Empty";
        public const string TAG_DATATYPE_USERDATA = "Not Support User Data Type";
        public const string TAG_DATATYPE_NODEMULTI = "Not Support Multi Node";
        public const string TAG_DATATYPE_NODESIZE = "Not Support Big Node Size";
        public const string TAG_UNUSED = "Tag unused for Alias";
        public const string ALIAS_TYPE_SPECIALBIT = "Alias Used for Special Bit";
        public const string ALIAS_TYPE_DOUBLE = "Alias Used for another Alias";
        public const string ALIAS_NODE_SIZE = "Alias Used for Limited Node";
        public const string ALIAS_NUMBERING = "I/O Numbering Rule";
        public const string ALIAS_FOR_CANNOT_FIND = "Can't Find Alias for";
    }

    public class eTAG_GROUP_AB
    {
        public const string TAG = "TAG";
        public const string ALIAS = "ALIAS";
        public const string COMMENT = "COMMENT";
    }



    #endregion
    
    #region MITSUBISHI

    public class eADDRESS_DATATYPE_MITSUBISHI
    {
        public const string SPARE = "SPARE";
        public const string USE = "USE";
        public const string BIT = "BOOL";
        public const string WORD_SIGNED = "INT";
        public const string WORD_UNSIGNED = "WORD";
        public const string DWORD_SIGNED = "DINT";
        public const string DWORD_UNSIGNED = "DWORD";

        public const string ARRAY16_BIT = "ARRAY [0..15] OF BOOL";
        public const string ARRAY32_BIT = "ARRAY [0..31] OF BOOL";
        public const string ARRAY64_BIT = "ARRAY [0..63] OF BOOL";
        public const string ARRAY16_WORD_SIGNED = "ARRAY [0..15] OF INT";
        public const string ARRAY32_WORD_SIGNED = "ARRAY [0..31] OF INT";
        public const string ARRAY64_WORD_SIGNED = "ARRAY [0..63] OF INT";
        public const string ARRAY16_WORD_UNSIGNED = "ARRAY [0..15] OF WORD";
        public const string ARRAY32_WORD_UNSIGNED = "ARRAY [0..31] OF WORD";
        public const string ARRAY64_WORD_UNSIGNED = "ARRAY [0..63] OF WORD";
        public const string ARRAY16_DWORD_SIGNED = "ARRAY [0..15] OF DINT";
        public const string ARRAY32_DWORD_SIGNED = "ARRAY [0..31] OF DINT";
        public const string ARRAY64_DWORD_SIGNED = "ARRAY [0..63] OF DINT";
        public const string ARRAY16_DWORD_UNSIGNED = "ARRAY [0..15] OF DWORD";
        public const string ARRAY32_DWORD_UNSIGNED = "ARRAY [0..31] OF DWORD";
        public const string ARRAY64_DWORD_UNSIGNED = "ARRAY [0..63] OF DWORD";

        public const string TIMER = "Timer";
        public const string COUNTER = "Counter";
    }

    
    #region MITSUBISHI_DEVELOPER


    public class eADDRESS_SPARE_MITSUBISHI_DEVELOPER
    {
        public static int MAXIO = 511; //1FF (HEXA)
        public static int MAXIO_EXTEND = 4095; //FFF (HEXA)

        public static int MAXDUMMY = 999;//3E7 (HEXA)
        public static int MAXDUMMY_EXTEND = 9999;//270F (HEXA)
    }

 

    public class eADDRESS_TYPE_MITSUBISHI_DEVELOPER
    {
        public const string INPUT = "X";
        public const string OUTPUT = "Y";

        public const string TYPEIO = "X;Y";
        public const string TYPEDUMMY = "M;D;L;R;ZR";
        public const string TYPELINK = "B;W";
        public const string TYPETIMER = "T";
        public const string TYPECOUNT = "C";

        public const string LISTALL = "X;Y;M;L;D;B;W;T;C;R;ZR";
        public const string WORDLIST = "D;W";
        public const string HEXABITLIST = "X;Y;B;W";
        public const string HEXABLCOKLIST = "X;Y;B;W";

        public const string DOTLIST = "";
    }


    public class eSymbolColumn_GXDEVELOPER
    {
        public const string DEVICE = "Device";
        public const string LABEL = "Label";
        public const string COMMENT = "Comment";

        public const string DEFAULT = "COMMENT(IOMAKER).csv";
    }


    #endregion

    #region MITSUBISHI_WORKS2

    public class eADDRESS_SPARE_MITSUBISHI_WORKS2
    {
        public static int MAXIO = 511; //1FF (HEXA)
        public static int MAXIO_EXTEND = 4095; //FFF (HEXA)

        public static int MAXDUMMY = 999;//3E7 (HEXA)
        public static int MAXDUMMY_EXTEND = 39321;//9999 (HEXA)
    }


    public class eADDRESS_TYPE_MITSUBISHI_WORKS2
    {
        public const string INPUT = "X";
        public const string OUTPUT = "Y";

        public const string TYPEIO = "X;Y";
        public const string TYPEDUMMY = "M;L";
        public const string TYPELINK = "B;W;D";
        public const string TYPETIMER = "T";
        public const string TYPECOUNT = "C";

        public const string LISTALL = "X;Y;M;L;D;B;W;T;C";
        public const string WORDLIST = "W;D";
        public const string HEXABITLIST = "X;Y;B;W;D";
        public const string HEXABLCOKLIST = "X;Y;B;W";

        public const string DOTLIST = "W;D";
    }


    public class eSymbolColumnGXWorks
    {
        public const string CLASS = "Class";
        public const string LABELNAME = "Label Name";
        public const string DATATYPE = "Data Type";
        public const string CONSTANT = "Constant";
        public const string DEVICE = "Device";
        public const string ADDRESS = "Address";
        public const string COMMENT = "Comment";
        public const string REMARK = "Remark";
        public const string RELATIONWITHSYSTEMLABEL = "Relation with System Label";
        public const string SYSTEMLABELNAME = "System Label Name";
        public const string ATTRIBUTE = "Attribute";

        public const string DEFAULT = "Global_Vars(IOMAKER).csv";
    }


    public class eSymbolColumnOPC
    {
        public const string TAGNAME = "Tag Name";
        public const string ADDRESS = "Address";
        public const string DATATYPE = "Data Type";
        public const string RESPECTDATATYPE = "Respect Data Type";
        public const string CLIENTACCESS = "Client Access";
        public const string SCANRATE = "Scan Rate";
        public const string RAWLOW = "Raw Low";
        public const string RAWHIGH = "Raw High";
        public const string SCALEDLOW = "Scaled Low";
        public const string SCALEDHIGH = "Scaled High";
        public const string SCALEDDATATYPE = "Scaled Data Type";
        public const string CLAMPLOW = "Clamp Low";
        public const string CLAMPHIGH = "Clamp High";
        public const string ENGUNITS = "Eng Units";
        public const string DESCRIPTION = "Description";

        public const string DEFAULT = "Device1(IOMAKER).csv";
    }


    #endregion


    #endregion


    #endregion

    #region ConfigLine

    public class eLocal_Number
    {
        public const string MASTER = "MASTER";
        public const string LOCAL01 = "LOCAL01";
        public const string LOCAL02 = "LOCAL02";
        public const string LOCAL03 = "LOCAL03";
        public const string LOCAL04 = "LOCAL04";
        public const string LOCAL05 = "LOCAL05";
        public const string LOCAL06 = "LOCAL06";
        public const string LOCAL07 = "LOCAL07";
        public const string LOCAL08 = "LOCAL08";
        public const string LOCAL09 = "LOCAL09";
    }

    #endregion
}
