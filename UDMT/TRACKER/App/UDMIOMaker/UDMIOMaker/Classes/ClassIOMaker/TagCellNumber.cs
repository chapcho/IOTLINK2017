using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Docking2010.Dragging;

namespace NewIOMaker
{
    public class TagCellNumber
    {
        //Cover
        public int symbol = 4;
        public int logic = 5;
        public int symbolandlogic = 6;

        public int contact = 11;
        public int coil = 12;
        public int contactandcoil = 13;

        public int count = 4;
        public int dateRow = 38;
        public int dataColumn = 6;
        public int UserLogicCount = 18;

        //Contents
        public int nameRow = 2;
        public int nameColumn = 1;

        public int menuRow = 4;
        public int contentsAddress = 1;
        public int contentsSymbol = 2;
        public int contentsMemory = 3;
        public int contentsContact = 4;
        public int contentsLogic = 5;
        public int contentsUser = 6;

        public int startRow = 5;
        public int endRow = 43;
        public int size = 39;
        public int otherSize = 43;

        public TagCellNumber()
        {
            
        }

        public void NewStart()
        {
            startRow = 5;
        }
    }
}
