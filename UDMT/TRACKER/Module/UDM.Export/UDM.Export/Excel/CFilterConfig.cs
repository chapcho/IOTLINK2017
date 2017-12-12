using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace UDM.Export
{
    public class CCell
    {
        private Point POINT = new Point();
        public CCell(int col, int row)
        {
            POINT = new Point(col, row);
        }
        public int COL { get { return POINT.X; } set { POINT.X = value; } }
        public int ROW { get { return POINT.Y; } set { POINT.Y = value; } }
    }

    public class CFilterGridIndex
    {
        #region Fields

        public List<int> SKIPROW = new List<int> { };
        public List<int> SYMBOLNAMECOL = new List<int> { };
        public List<int> ADDRESSCOL = new List<int> { };
        public List<int> TAGCOL = new List<int> { };
        public List<int> DATATYPE = new List<int> { };
        public List<int> COMMENT = new List<int> { };

        public List<Point> BLOCK = new List<Point> { };
        public List<Point> NETWORK = new List<Point> { };
        public List<Point> MODULECARD = new List<Point> { };
        public List<Point> INFO = new List<Point> { };

        #endregion

        #region Constructors

        public CFilterGridIndex()
        {
        }

        public CFilterGridIndex(CFilterGridIndex FilterGridIndex)
        {
            SKIPROW = new List<int>(FilterGridIndex.SKIPROW.ToArray());
            SYMBOLNAMECOL = new List<int>(FilterGridIndex.SYMBOLNAMECOL.ToArray());
            ADDRESSCOL = new List<int>(FilterGridIndex.ADDRESSCOL.ToArray());
            TAGCOL = new List<int>(FilterGridIndex.TAGCOL.ToArray());
            DATATYPE = new List<int>(FilterGridIndex.DATATYPE.ToArray());
            COMMENT = new List<int>(FilterGridIndex.COMMENT.ToArray());

            BLOCK = new List<Point>(FilterGridIndex.BLOCK.ToArray());
            NETWORK = new List<Point>(FilterGridIndex.NETWORK.ToArray());
            MODULECARD = new List<Point>(FilterGridIndex.MODULECARD.ToArray());
            INFO = new List<Point>(FilterGridIndex.INFO.ToArray());
        }

        #endregion

        #region Export Format

        public void SetMapIOFormat(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { };
            SYMBOLNAMECOL = new List<int> { 2, 5 };
            ADDRESSCOL = new List<int> { 1, 4 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetMapDummyFormat(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { };
            SYMBOLNAMECOL = new List<int> { 2, 5, 8, 11 };
            ADDRESSCOL = new List<int> { 1, 4, 7, 10 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetIo8Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 3, 37, 38, 39, 40, 41, 42, 43, 44 };
            ADDRESSCOL = new List<int> { 1, 6, 11, 16 };
            SYMBOLNAMECOL = new List<int> { 3, 8, 13, 18 };
            TAGCOL = new List<int> { 4, 9, 14, 19 };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(5, 4), new Point(10, 4), new Point(15, 4), 
                new Point(0, 12), new Point(5, 12), new Point(10, 12), new Point(15, 12), 
                new Point(0, 20), new Point(5, 20), new Point(10, 20), new Point(15, 20), 
                new Point(0, 28), new Point(5, 28), new Point(10, 28), new Point(15, 28) };
            NETWORK = new List<Point> { new Point(0, 2), new Point(5, 2), new Point(10, 2), new Point(15, 2) };
            MODULECARD = new List<Point> { new Point(2, 2), new Point(7, 2), new Point(12, 2), new Point(17, 2) };
            INFO = new List<Point> { new Point(0, 1), new Point(5, 1), new Point(10, 1), new Point(15, 1) };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetIo16Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 3, 37, 38, 39, 40, 41, 42, 43, 44 };
            ADDRESSCOL = new List<int> { 1, 6, 11, 16 };
            SYMBOLNAMECOL = new List<int> { 3, 8, 13, 18 };
            TAGCOL = new List<int> { 4, 9, 14, 19 };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(5, 4), new Point(10, 4), new Point(15, 4), new Point(0, 20), new Point(5, 20), new Point(10, 20), new Point(15, 20) };
            NETWORK = new List<Point> { new Point(0, 2), new Point(5, 2), new Point(10, 2), new Point(15, 2) };
            MODULECARD = new List<Point> { new Point(2, 2), new Point(7, 2), new Point(12, 2), new Point(17, 2) };
            INFO = new List<Point> { new Point(0, 1), new Point(5, 1), new Point(10, 1), new Point(15, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetIo32FormatForAbComment(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 3, 36, 37, 38, 39, 40, 41, 42, 43, 44 };
            ADDRESSCOL = new List<int> { 1, 6, 11, 16 };
            COMMENT = new List<int> { 3, 8, 13, 18 };
            SYMBOLNAMECOL = new List<int> { 4, 9, 14, 19 };
            DATATYPE = new List<int> { };
            TAGCOL = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(5, 4), new Point(10, 4), new Point(15, 4) };
            NETWORK = new List<Point> { new Point(0, 2), new Point(10, 2) };
            MODULECARD = new List<Point> { new Point(2, 2), new Point(12, 2) };
            INFO = new List<Point> { new Point(0, 1), new Point(10, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetIo32Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2, 3 };
            ADDRESSCOL = new List<int> { 1 };
            SYMBOLNAMECOL = new List<int> { 3 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(0, 36) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetDummy8Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2 };
            ADDRESSCOL = new List<int> { 1, 5 };
            SYMBOLNAMECOL = new List<int> { 3, 7 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 3), new Point(0, 11), new Point(0, 19), new Point(0, 27), new Point(0, 35), 
                                      new Point(4, 3), new Point(4, 11), new Point(4, 19), new Point(4, 27), new Point(4, 35) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1), new Point(4, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetDummy10Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2 };
            ADDRESSCOL = new List<int> { 1, 5 };
            SYMBOLNAMECOL = new List<int> { 3, 7 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 3), new Point(0, 13), new Point(0, 23), new Point(0, 33), new Point(0, 43), new Point(4, 3), new Point(4, 13), new Point(4, 23), new Point(4, 33), new Point(4, 43) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1), new Point(4, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetDummy16Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2 };
            ADDRESSCOL = new List<int> { 1, 5 };
            SYMBOLNAMECOL = new List<int> { 3, 7 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 3), new Point(0, 19), new Point(0, 35), new Point(0, 51), new Point(4, 3), new Point(4, 19), new Point(4, 35), new Point(4, 51) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1), new Point(4, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }


        public void SetDummy32FormatForAbComment(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2 };
            ADDRESSCOL = new List<int> { 1, 6, 11, 16 };
            SYMBOLNAMECOL = new List<int> { 4, 9, 14, 19 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { 3, 8, 13, 18 };

            BLOCK = new List<Point> { new Point(0, 3), new Point(5, 3), new Point(10, 3), new Point(15, 3) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { new Point(2, 2), new Point(12, 2) };
            INFO = new List<Point> { new Point(0, 1), new Point(5, 1), new Point(10, 1), new Point(15, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }



        public void SetDummy32Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2, 3 };
            ADDRESSCOL = new List<int> { 1 };
            SYMBOLNAMECOL = new List<int> { 3 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(0, 36) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1) };


            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }


        public void SetTimeCount10Format(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2, 3 };
            ADDRESSCOL = new List<int> { 1 };
            SYMBOLNAMECOL = new List<int> { 3 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { new Point(0, 4), new Point(0, 14), new Point(0, 24), new Point(0, 34), new Point(0, 44) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1) };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }


        public void SetTimeCount10FormatForAbComment(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2 };
            ADDRESSCOL = new List<int> { 1, 6 };
            SYMBOLNAMECOL = new List<int> { 4, 9 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { 3, 8 };

            BLOCK = new List<Point> { new Point(0, 3), new Point(0, 13), new Point(0, 23), new Point(0, 33), new Point(0, 43), new Point(5, 3), new Point(5, 13), new Point(5, 23), new Point(5, 33), new Point(5, 43) };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { new Point(0, 1), new Point(5, 1) };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        #endregion

        #region Import Format

        public void SetImportDefault(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39 };
            ADDRESSCOL = new List<int> { 1 };
            SYMBOLNAMECOL = new List<int> { 0 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatSiemens(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { };
            ADDRESSCOL = new List<int> { 1 };
            SYMBOLNAMECOL = new List<int> { 0 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { 2 };
            COMMENT = new List<int> { 3 };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatAB(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            ADDRESSCOL = new List<int> { 5 };
            SYMBOLNAMECOL = new List<int> { 2 };
            TAGCOL = new List<int> { 0 };
            DATATYPE = new List<int> { 4 };
            COMMENT = new List<int> { 3};

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatMelsecDeveloper(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0 };
            ADDRESSCOL = new List<int> { 0 };
            SYMBOLNAMECOL = new List<int> { 2 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatMelsecWorks2(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 1 };
            ADDRESSCOL = new List<int> { 4 };
            SYMBOLNAMECOL = new List<int> { 1 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { 2 };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { };
            INFO = new List<Point> { };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        #endregion

        #region Import Format Template

        public void SetImportFormatTemplateSiemens(int nShiftUpDown, int nShiftLeftRight)
        {
            SetIo8Format(nShiftUpDown, nShiftLeftRight);
        }

        public void SetImportFormatTemplateSiemensDYK3(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 3, 36, 37, 38, 39, 40, 41, 42, 43, 44 };
            ADDRESSCOL = new List<int> { 2, 6, 10, 14 };
            SYMBOLNAMECOL = new List<int> { 1, 5, 9, 13 };
            TAGCOL = new List<int> { 3, 7, 11, 15 };
            DATATYPE = new List<int> { };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { new Point(0, 2), new Point(4, 2), new Point(8, 2), new Point(12, 2) };
            INFO = new List<Point> {/* new Point(4, 1)*/ };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatTemplateAB(int nShiftUpDown, int nShiftLeftRight)
        {
            SKIPROW = new List<int> { 0, 2, 3 };
            ADDRESSCOL = new List<int> { 7 };
            SYMBOLNAMECOL = new List<int> { 4 };
            TAGCOL = new List<int> { };
            DATATYPE = new List<int> { 6 };
            COMMENT = new List<int> { };

            BLOCK = new List<Point> { };
            NETWORK = new List<Point> { };
            MODULECARD = new List<Point> { new Point(3, 4), new Point(3,36) };
            INFO = new List<Point> { new Point(1, 1) };

            ShiftUpDown(nShiftUpDown);
            ShiftLeftRight(nShiftLeftRight);
        }

        public void SetImportFormatTemplateABCommentDummy(int nShiftUpDown, int nShiftLeftRight)
        {
            SetDummy32FormatForAbComment(nShiftUpDown, nShiftLeftRight);
        }

        public void SetImportFormatTemplateABCommentIO(int nShiftUpDown, int nShiftLeftRight)
        {
            SetIo32FormatForAbComment(nShiftUpDown, nShiftLeftRight);
        }

        public void SetImportFormatTemplateABCommentTimeCount(int nShiftUpDown, int nShiftLeftRight)
        {
            SetTimeCount10FormatForAbComment(nShiftUpDown, nShiftLeftRight);
        }

        public void SetImportFormatTemplateMelsecDeveloper(int nShiftUpDown, int nShiftLeftRight)
        {
            SetIo16Format(nShiftUpDown, nShiftLeftRight);
        }

        public void SetImportFormatTemplateMelsecWorks2(int nShiftUpDown, int nShiftLeftRight)
        {
            SetIo16Format(nShiftUpDown, nShiftLeftRight);
        }

        #endregion

        #region Public Methods

        public void ShiftUpDown(int nShift)
        {
            ShiftCell(SKIPROW, nShift);
            ShiftPoint(BLOCK, 0, nShift);
            ShiftPoint(NETWORK, 0, nShift);
            ShiftPoint(MODULECARD, 0, nShift);
            ShiftPoint(INFO, 0, nShift);
        }

        public void ShiftLeftRight(int nShift)
        {
            ShiftCell(SYMBOLNAMECOL, nShift);
            ShiftCell(ADDRESSCOL, nShift);
            ShiftCell(TAGCOL, nShift);
            ShiftCell(DATATYPE, nShift);
            ShiftCell(COMMENT, nShift);
            ShiftPoint(BLOCK, nShift, 0);
            ShiftPoint(NETWORK, nShift, 0);
            ShiftPoint(MODULECARD, nShift, 0);
            ShiftPoint(INFO, nShift, 0);
        }


        public Dictionary<string, string> GetFilterArray(Dictionary<string, string> DataSetConfig, string strSheet, string strControl)
        {
            DataSetConfig[strControl + eFilterSplitItem.SKIPROW] += MakeFilterArray(SKIPROW) + "-";
            DataSetConfig[strControl + eFilterSplitItem.SYMBOLNAMECOL] += MakeFilterArray(SYMBOLNAMECOL) + "-";
            DataSetConfig[strControl + eFilterSplitItem.ADDRESSCOL] += MakeFilterArray(ADDRESSCOL) + "-";
            DataSetConfig[strControl + eFilterSplitItem.TAGCOL] += MakeFilterArray(TAGCOL) + "-";
            DataSetConfig[strControl + eFilterSplitItem.DATATYPE] += MakeFilterArray(DATATYPE) + "-";
            DataSetConfig[strControl + eFilterSplitItem.COMMENT] += MakeFilterArray(COMMENT) + "-";
            DataSetConfig[strControl + eFilterSplitItem.HEADBLOCK] += MakeFilterArrayPoint(BLOCK) + "-";
            DataSetConfig[strControl + eFilterSplitItem.NETWORK] += MakeFilterArrayPoint(NETWORK) + "-";
            DataSetConfig[strControl + eFilterSplitItem.INFO] += MakeFilterArrayPoint(INFO) + "-";
            DataSetConfig[strControl + eFilterSplitItem.MODULECARD] += MakeFilterArrayPoint(MODULECARD) + "-";

            return DataSetConfig;
        }

        public void SetFilterSplitArray(string strKey, string strSplit, int nSheet, string strControl)
        {
            if (strSplit == string.Empty || strSplit == ".")
                return;
            if (strSplit.Split('-').Length <= nSheet)
                return;

            string strSplitSheet = strSplit.Split('-')[nSheet];

            List<string> arrSplit = PlcHelper.SplitListString(strSplitSheet, ";", true);

            if (strKey == strControl + eFilterSplitItem.SYMBOLNAMECOL)
                foreach (string strVal in arrSplit)
                    SYMBOLNAMECOL.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.ADDRESSCOL)
                foreach (string strVal in arrSplit)
                    ADDRESSCOL.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.TAGCOL)
                foreach (string strVal in arrSplit)
                    TAGCOL.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.DATATYPE)
                foreach (string strVal in arrSplit)
                    DATATYPE.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.COMMENT)
                foreach (string strVal in arrSplit)
                    COMMENT.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.SKIPROW)
                foreach (string strVal in arrSplit)
                    SKIPROW.Add(Int32.Parse(strVal));
            if (strKey == strControl + eFilterSplitItem.HEADBLOCK)
                foreach (string strVal in arrSplit)
                    BLOCK.Add(new Point(Int32.Parse(strVal.Split('*')[0]), Int32.Parse(strVal.Split('*')[1])));
            if (strKey == strControl + eFilterSplitItem.NETWORK)
                foreach (string strVal in arrSplit)
                    NETWORK.Add(new Point(Int32.Parse(strVal.Split('*')[0]), Int32.Parse(strVal.Split('*')[1])));
            if (strKey == strControl + eFilterSplitItem.MODULECARD)
                foreach (string strVal in arrSplit)
                    MODULECARD.Add(new Point(Int32.Parse(strVal.Split('*')[0]), Int32.Parse(strVal.Split('*')[1])));
            if (strKey == strControl + eFilterSplitItem.INFO)
                foreach (string strVal in arrSplit)
                    INFO.Add(new Point(Int32.Parse(strVal.Split('*')[0]), Int32.Parse(strVal.Split('*')[1])));
        }

        #endregion

        #region Privates Methods

        private void ShiftCell(List<int> listItem, int nShift)
        {
            for (int n = 0; n < listItem.Count; n++)
                listItem[n] = listItem[n] + nShift;
        }

        private void ShiftPoint(List<Point> listItem, int nShiftX, int nShiftY)
        {
            for (int n = 0; n < listItem.Count; n++)
            {
                Point p = listItem[n];
                p.X = listItem[n].X + nShiftX;
                p.Y = listItem[n].Y + nShiftY;
                listItem[n] = p;
            }
        }

        private string MakeFilterArray(List<int> listItem)
        {
            string strArray = string.Empty;
            for (int n = 0; n < listItem.Count; n++)
                strArray += listItem[n].ToString() + ";";

            return strArray.TrimEnd(';');
        }

        private string MakeFilterArrayPoint(List<Point> listItem)
        {
            string strArray = string.Empty;
            for (int n = 0; n < listItem.Count; n++)
            {
                strArray += listItem[n].X.ToString() + "*" + listItem[n].Y.ToString() + ";";
            }

            return strArray.TrimEnd(';');
        }

        #endregion

    }

}
