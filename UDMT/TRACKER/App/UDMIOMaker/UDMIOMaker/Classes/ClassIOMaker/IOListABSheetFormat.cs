using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker
{
    public class IOListABSheetFormat
    {
        //bas sheet
        public static int ROWSTART_I = 5;
        public static int ROWSTART_Q = 37;

        public static int COLNUMBERING = 2;
        public static int COlTYPE = 3;
        public static int COlSCOPE = 4;
        public static int COlSYMBOLNAME = 5;
        public static int COlDESCRIPTION = 6;
        public static int COlDATATYPE = 7;
        public static int COlSPECIFIER = 8;



        //map sheet
        public static int MAPROWSTART = 3;
        public static int MAPROWEND = 66;

        public static int MAPDUMMYROWSTART = 3;
        public static int MAPDUMMYROWEND = 35;

        public static int MAPCOLSOLT_1 = 2;
        public static int MAPCOLADDRESS_1 = 3;
        public static int MAPCOLDESCRIPTION_1 = 4;
        public static int MAPCOLSOLT_2 = 5;
        public static int MAPCOLADDRESS_2 = 6;
        public static int MAPCOLDESCRIPTION_2 = 7;
        public static int MAPCOLSOLT_3 = 8;
        public static int MAPCOLADDRESS_3 = 9;
        public static int MAPCOLDESCRIPTION_3 = 10;
        public static int MAPCOLSOLT_4 = 11;
        public static int MAPCOLADDRESS_4 = 12;
        public static int MAPCOLDESCRIPTION_4 = 13;

        public static int MAPSHEETITEMCOUNT = 64;
        public static int MAPSHEETITEMCOUNTDUMMY = 128;

        public static int defaultSize = 69 ; // I 32 + Q32
    }
}
