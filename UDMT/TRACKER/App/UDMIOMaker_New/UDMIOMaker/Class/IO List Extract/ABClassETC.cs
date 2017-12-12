using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UDMIOMaker
{
    #region EmunUI

    public enum eMainInfoTabIndex
    {
        Output,
        Debug,
    }


    public enum eTabControlForm
    {
        Import,
        Export
    }

    public enum eTabControlPLC
    {
        Logic,
        Command
    }


    public enum eFinder
    {
        Find,
        Replace
    }

    public class eFrmConvertFIO
    {
        public static string USE = "USE";
        public static string TYPE = "TYPE";
        public static string START = "START";
        public static string END = "END";
    }

    public class eFrmFIO
    {
        public static int MAXROW = 70;
        public static int MAXCOL = 24;
    }

    public class eFrmSpareAddress
    {
        public static string NUMBER = "NUMBER";
        public static string ADDRESS = "ADDRESS";
        public static string USE = "USE";
        public static string TYPE = "TYPE";
        public static string START = "START";
        public static string END = "END";
        public static string SPARE = "                          ";
        public static string USEDMAP = "...";
    }


    public class eUIOTree
    {
        public static string DEFALTPARENT = "ADDRESS";
    }

    public class eFrmModule
    {
        public static string INPUT = "IN";
        public static string OUTPUT = "OUT";
        public static string MIX = "MIX";
        public static string XYNO = "No.";
        public static string NETWORK = "Network";
        public static string SLOT = "Slot";
        public static string MODULETYPE = "I/O Type";
        public static string POINTS = "Points";
        public static string MODULENAME = "Module Name";
        public static string MODULELIST = "Module List";
        public static string DUPLICATION = "Duplication";
        public static string INFO = "Information";
        public static string INTELLIGENT = "Intelli.";
        public static string SPECIAL = "Special";
    }

    public class eFrmDummy
    {
        public static string INPUT = "IN";
        public static string OUTPUT = "OUT";
        public static string MIX = "MIX";
        public static string XYNO = "No.";
        public static string NETWORK = "Network";
        public static string SLOT = "Slot";
        public static string MODULETYPE = "I/O Type";
        public static string POINTS = "Points";
        public static string MODULENAME = "Module Name";
        public static string MODULELIST = "Module List";
        public static string DUPLICATION = "Duplication";
        public static string INFO = "Information";
        public static string INTELLIGENT = "Intelli.";
        public static string SPECIAL = "Special";
        public static string GROUP = "GROUP";
        public static string TABLE_NORMAL = "NORMAL";
        public static string TABLE_EXTEND = "EXTEND";
    }


    public class eFrmRuleBlock
    {
        public static string GROUP = "GROUP";
        public static string ACTOR = "ACTOR";
        public static string VALUE = "VALUE";

        public static string STATE = "STATE";
        public static string LEAVE = "LEAVE";
        public static string ENTER = "ENTER";

        public static string VALUE1 = "SINGLE_ACTION";
        public static string VALUE2 = "DOUBLE_ACTION";
    }

    public class eFiterOption
    {
        public static string GROUP = "Group Search";
        public static string NAME = "Name Search";
    }



    public class eUIOStatusList
    {
        public static string ADDRESSLENGTH = "ADDRESS LENGTH";
        public static string ADDRESSREDUNDANCY = "ADDRESS REDUNDANCY";
        public static string ADDRESSEMPTY = "ADDRESS EMPTY";
        public static string ADDRESSTYPE = "ADDRESS TYPE";
        public static string SYMBOLLENGTH = "SYMBOL LENGTH";
        public static string SYMBOLREDUNDANCY = "SYMBOL REDUNDANCY";
        public static string SYMBOLEMPTY = "SYMBOL EMPTY";
        public static string SYMBOLTYPE = "SYMBOL TYPE";
        public static string USEDLOGIC = "LOGIC_USED";
        public static string CHECKALL = "Check All";
    }

    public class eLIBStatusList
    {
        public static string OLDNAME_DUPLICATION = "OLDNAME REDUNDANCY";
        public static string OLDNAME_EMPTY = "OLDNAME EMPTY";
        public static string STANDARD_TYPE = "STANDARD TYPE";
        public static string STANDARD_EMPTY = "STANDARD EMPTY";
        public static string COMPOUND_NOUN = "COMPOUND NOUN";
    }

    public class eEPLStatusList
    {
        public static string KEYDUPLICATION = "KEY DUPLICATION";
        public static string KEYEMPTY = "KEY EMPTY";
        public static string TYPEERROR = "TYPE ERROR";
    }

    public class ePLCStatusList
    {
        public static string KEYDUPLICATION = "KEY DUPLICATION";
    }


    public class eUIOStatus
    {
        public static string OK = "OK";
        public static string WARNING_NOT_DEFINED_ALIAS = "별칭없음";
        public static string WARNING_NOT_USED_LOGIC = "사용안됨";
        public static string ERROR = "ERROR";
        public static string ERROR_ADDRESS_UNKNOWN = "주소타입";//"Unknown Address";
        public static string ERROR_ADDRESS_LENGTH = "주소길이";//"Length over Address";
        public static string ERROR_ADDRESS_REDUNDANCY = "주소중복";//"Redundancy Address";
        public static string ERROR_ADDRESS_EMPTY = "주소없음";//"Empty Address";

        public static string ERROR_SYMBOL_UNKNOWN = "심볼타입";//"Unknown Symbol";
        public static string ERROR_SYMBOL_LENGTH = "심볼길이";//"Length over Symbol";
        public static string ERROR_SYMBOL_REDUNDANCY = "심볼중복";//"Redundancy Symbol";
        public static string ERROR_SYMBOL_EMPTY = "심볼없음";//"Empty Symbol";
        public static string ERROR_COMMENT_REDUNDANCY = "주석중복";//"Redundancy Symbol";

    }


    public class eLIBCheckResult
    {
        public const string MATCH_ALL = "OK";
        public const string UNCHECK = "Empty";
        public const string UNMATCH_CONFIRM = "Check";
        public const string UNMATCH_NONLIBRARY = "New";
        public const string ERROR_MAX_LELVE = "Error Level";
    }




    public class eConfigRowIndex
    {
        public const string UISTYLE = "UI Style";
    }

    public class eSplit
    {
        public const char EXCELSPLIT = '˙';
        public const char LIBRARYSPLIT = '‡';
        public const string EXCELCOPY = "_C";
        public const string EXCELYELLOW = "˙．";
        public const string EXCELAQUA = "˙˘";
    }


    public class eModelRow
    {
        public const string PROJECTNAME = "Project Name";
        public const string PROJECTSITE = "Project Site";
        public const string PROJECTLINE = "Project Line";
        public const string PLCMAKER = "PLC Maker";
        public const string PLCNUMBER = "PLC Number";
        public const string LEVELSYMBOL = "Level Symbol";
        public const string ADDRESSSPLIT = ".";
        public const string EXCELIMPORTPATH = "Excel Import Path";
        public const string TEMPSPLIT = "     ;";
        public const string ABIORULE = "I/O Range 0 ~ 9999 Over";
        public const string LIBRARYEXCEPTION = "Exception Symbol";
    }


    public class eModelColumn
    {
        public const int KEY = 0;
        public const int VALUE = 1;
    }

    public class eLevelSplit
    {
        public const string UNDERBAR = "'_' Under Bar";
        public const string SPACE = "' ' Space";
    }


    public class eColumnWidth
    {
        public const int MIN = 2;
        public const int DEFALT = 50;
        public const int ID = 50;
        public const int SYMBOLNAME = 220;
        public const int UIONAME = 220;
        public const int TAG = 40;
        public const int DATATYPE = 40;
        public const int ADDRESS = 70;
        public const int ADDRESSTEMP = 70;
        public const int BLOCK = 70;
        public const int UPDATETIME = 150;
        public const int COMMENT = 220;
        public const int EPLANMACRO = 400;
        public const int DATACHECK = 70;
    }


    public class eColorSpareAddress
    {
        public static Color BLOCKMAX = Color.SteelBlue;
        public static Color BLOCKEMPTY = Color.LightBlue;
        public static Color BLOCKONEMORE = Color.LightSkyBlue;
        public static Color SPARE = Color.Khaki;
    }

    public class eColorFilterCell
    {
        public static Color NOTSET = Color.Empty;
        public static Color SKIPROW = Color.LightSlateGray;

        public static Color HEADBLOCK = Color.RoyalBlue;
        public static Color NETWORK = Color.Turquoise;
        public static Color INFO = Color.Violet;
        public static Color MODULE = Color.MediumSeaGreen;
        public static Color SYMBOLNAMECOL = Color.LightGreen;
        public static Color ADDRESSCOL = Color.LightSkyBlue;
        public static Color TAGCOL = Color.Khaki;
        public static Color DATATYPE = Color.MediumSeaGreen;
        public static Color COMMENT = Color.Thistle;
        public static Color SHEET = Color.MistyRose;
    }

    public class eColorUIOTable
    {
        public static Color HEADUIO = Color.WhiteSmoke;
    }


    public class eColorCheckCell
    {
        public static Color NEW = Color.IndianRed;
        public static Color CHANGED = Color.Orange;
        public static Color REGISTER = Color.LightGreen;
    }

    public class eColorComment
    {
        public static Color EMPTY = Color.Empty;
        public static Color NEEDCONFIRM = Color.IndianRed;
        public static Color CONVERED = Color.Blue;
    }

    public class eColorModuleCell
    {
        public static Color USED = Color.LightGoldenrodYellow;
        public static Color DUPLICATION = Color.PaleVioletRed;
        public static Color NOTSET = Color.Empty;
    }

    public class eColorLibrary
    {
        public static Color OLDNAME = Color.PaleVioletRed;
        public static Color STANDARDNAME = Color.LightGreen;
        public static Color ERRORROW = Color.LightGoldenrodYellow;
        public static Color COMMENT = Color.Empty;
    }

    public class eColorEplan
    {
        public static Color MAINKEY = Color.MediumTurquoise;
        public static Color SUBKEY = Color.LightGreen;
        public static Color SUBOPTION = Color.LightYellow;
        public static Color EPLANMACRO = Color.Plum;
        public static Color SYMBOLNAMECOL = Color.LightGreen;
        public static Color ADDRESSCOL = Color.LightSkyBlue;
        public static Color ERRORROW = Color.LightGoldenrodYellow;
        public static Color TAGCOL = Color.Khaki;
    }

    public class eColorPLC
    {
        public static Color Description = Color.MediumTurquoise;

    }


    public class eFilterSplitItem
    {
        public static string NOTSET = "NOTSET";
        public static string HEADROW = "HEADROW";
        public static string SKIPROW = "SKIPROW";
        public static string HEADADDRESSCOL = "HEADADDRESS";
        public static string SYMBOLNAMECOL = "SYMBOLNAME";
        public static string ADDRESSCOL = "ADDRESS";
        public static string TAGCOL = "TAG";
        public static string DATATYPE = "DATATYPE";
        public static string COMMENT = "COMMENT";
        public static string HEADBLOCK = "HEADBLOCK";
        public static string NETWORK = "NETWORK";
        public static string INFO = "INFO";
        public static string MODULECARD = "MODULECARD";
    }

    public class eTableControl
    {
        public static string ORG = "SPLIT_";
        public static string FORM = "FORM_";
        public static string TEMPLATE = "Template";
        public static string MAP = "MAP";
        public static string COVER = "COVER";
        public static string SPARE = "-SP-";
        public static string INFO = "STATION INFORMATION";
        public static string MODULE = "PLC-MODULE";
        public static string NET = "NET";
    }


    public class eExportFormat
    {
        public static string EPLAN = "EPlan";
        public static string SIEMENS = "SIEMENS";
        public static string AB = "AB";
        public static string MITSUBISHI = "MITSUBISHI";
    }

    public class eFormSheet_Siemens
    {
        public static int MODULECOUNT_INSHEET_IO = 8;
        public static int MODULECOUNT_INSHEET_DUMMY = 2;
        public static int MODULECOUNT_INSHEET_LINK = 2;
        public static int MODULECOUNT_INSHEET_TIMECOUNT = 2;
        public static int BLOCKCOUNT_INMODULE_IO = 4;
        public static int BLOCKCOUNT_INMODULE_DUMMY = 5;
        public static int BLOCKCOUNT_INMODULE_LINK = 5;
        public static int BLOCKCOUNT_INMODULE_TIMECOUNT = 5;
    }

    public class eFormSheet_AB_ALIAS
    {
        public static int MODULECOUNT_INSHEET_IO = 1;
        public static int MODULECOUNT_INSHEET_DUMMY = 1;
        public static int MODULECOUNT_INSHEET_LINK = 1;
        public static int MODULECOUNT_INSHEET_TIMECOUNT = 1;
        public static int BLOCKCOUNT_INMODULE_IO = 2;
        public static int BLOCKCOUNT_INMODULE_DUMMY = 2;
        public static int BLOCKCOUNT_INMODULE_LINK = 2;
        public static int BLOCKCOUNT_INMODULE_TIMECOUNT = 5;
    }

    public class eFormSheet_AB_COMMENT
    {
        public static int MODULECOUNT_INSHEET_IO = 2;
        public static int MODULECOUNT_INSHEET_DUMMY = 4;
        public static int MODULECOUNT_INSHEET_LINK = 4;
        public static int MODULECOUNT_INSHEET_TIMECOUNT = 2;
        public static int BLOCKCOUNT_INMODULE_IO = 2;
        public static int BLOCKCOUNT_INMODULE_DUMMY = 1;
        public static int BLOCKCOUNT_INMODULE_LINK = 1;
        public static int BLOCKCOUNT_INMODULE_TIMECOUNT = 5;
    }


    public class eFormSheet_MelsecDeveloper
    {
        public static int MODULECOUNT_INSHEET_IO = 4;
        public static int MODULECOUNT_INSHEET_DUMMY = 2;
        public static int MODULECOUNT_INSHEET_LINK = 2;
        public static int MODULECOUNT_INSHEET_TIMECOUNT = 2;
        public static int BLOCKCOUNT_INMODULE_IO = 2;
        public static int BLOCKCOUNT_INMODULE_DUMMY = 5;
        public static int BLOCKCOUNT_INMODULE_LINK = 4;
        public static int BLOCKCOUNT_INMODULE_TIMECOUNT = 5;
    }

    public class eFormSheet_MelsecWorks2
    {
        public static int MODULECOUNT_INSHEET_IO = 4;
        public static int MODULECOUNT_INSHEET_DUMMY = 2;
        public static int MODULECOUNT_INSHEET_LINK = 2;
        public static int MODULECOUNT_INSHEET_TIMECOUNT = 2;
        public static int BLOCKCOUNT_INMODULE_IO = 2;
        public static int BLOCKCOUNT_INMODULE_DUMMY = 5;
        public static int BLOCKCOUNT_INMODULE_LINK = 4;
        public static int BLOCKCOUNT_INMODULE_TIMECOUNT = 5;
    }

    public class eFrmMainTab
    {
        public static string ORG = "Original";
        public static string UIO = "IO Data";
        public static string FIO = "Files";
        public static string LIB = "Library";
        public static string EPL = "EPlan";
        public static string MODEL = "Model Data";
        public static string PLC = "PLC";
    }

    public class eListType
    {
        public const string ALL = "ALL_LIST";
        public const string IO = "IO_LIST";
        public const string DUMMY = "DUMMY_LIST";
        public const string LINK = "LINK_LIST";
        public const string TIMECOUNT = "T&COUNT_LIST";
        public const string SYMBLOL = "SYMBOL_LIST";
        public const string EPLAN = "EPLAN_LIST";
        public const string OPC = "OPC_LIST";
        public const string LOGIC = "LOGIC_LIST";
    }

    public class eLIBRARYTypeID
    {
        public static string CLEAR = "CLEAR";
        public static string GROUP = "GROUP";
        public static string DEVICE = "DEVICE";
        public static string STATE = "STATE";
    }

    public class eEPlanUSE
    {
        public static string USE = "TRUE";
        public static string NOTUSE = "FALSE";
        public static string DEFUALTUSE = "TRUE(DEFUALT_USE)";
        public static string IN = "IN";
        public static string OUT = "OUT";
        public static string INOUT = "INOUT";
    }

    public class eSiemensDP
    {
        public static string DPSUBSYSTEM = "DPSUBSYSTEM ";
        public static string DPADDRESS = ", DPADDRESS ";
        public static string SLOT = ", SLOT ";
        public static string RACKSLOT = "RACKSLOT";
        public static string ADDRESS = "ADDRESS";
        public static string IOTYPE = "IOTYPE";
        public static string BYTESIZE = "BYTESIZE";
    }

    #endregion
}
