using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using NewIOMaker.Enumeration;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    /// <summary>
    /// 지원하는 HMI 프로그램에 대한 파일 포멧 정보 클래스
    /// 해더 유무, 라인 수 , 확장자
    /// </summary>
    /// 

    public class InfoHMI
    {
        protected DataTable m_HMITag = null;
        protected DataTable m_HMIAlarm = null;
        protected DataTable m_HMIAlarmColumn = null;
        protected bool _Header = false;
        protected int _HeaderLine = 0;
        protected string _Extension = string.Empty;

        #region Intialize/Dispose

        public InfoHMI(string HMI)
        {
            InputInfoHMI(HMI);
        }

        public InfoHMI()
        {
            AddTagInfo();
            AddAlarmInfo();
            AddAlarmColumn();
        }

        #endregion

        #region Public Properites

        public bool Header
        {
            get { return _Header; }
            set { _Header = value; }
        }

        public int Line
        {
            get { return _HeaderLine; }
            set { _HeaderLine = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        public DataTable HMIinfo
        {
            get { return m_HMITag; }
            set { m_HMITag = value; }
        }

        public DataTable HMIAlarminfo
        {
            get { return m_HMIAlarm; }
            set { m_HMIAlarm = value; }
        }

        public DataTable HMIAlarmColumn
        {
            get { return m_HMIAlarmColumn; }
            set { m_HMIAlarmColumn = value; }
        }

        #endregion

        #region Public Methods

        protected void InputInfoHMI(string HMI)
        {
            if (EMCommonHMIPrograms.XP_Builder.ToString().Equals(HMI))
            {
                _Header = true;
                _HeaderLine = 3;
                _Extension = "*.csv|*.csv|*.txt|*.txt";
            }
            else
                return;
        }

        protected void AddTagInfo()
        {
            DataTable dTable = new DataTable();
            DataRow dRow;

            string sinfoRow1 = "# Tag Table Export";
            string sinfoRow2 = "# Do not edit the below 1 line. These lines contain important information.";
            string sinfoRow3 = "태그 *";

            string sinfoRow4_Column1 = "#번호";
            string sinfoRow4_Column2 = "그룹";
            string sinfoRow4_Column3 = "이름";
            string sinfoRow4_Column4 = "타입";
            string sinfoRow4_Column5 = "디바이스";
            string sinfoRow4_Column6 = "설명";
            string sinfoRow4_Column7 = "";

            dTable.Columns.Add(sinfoRow4_Column1);
            dTable.Columns.Add(sinfoRow4_Column2);
            dTable.Columns.Add(sinfoRow4_Column3);
            dTable.Columns.Add(sinfoRow4_Column4);
            dTable.Columns.Add(sinfoRow4_Column5);
            dTable.Columns.Add(sinfoRow4_Column6);
            dTable.Columns.Add(sinfoRow4_Column7);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow1;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow2;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow3;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow4_Column1;
            dRow[1] = sinfoRow4_Column2;
            dRow[2] = sinfoRow4_Column3;
            dRow[3] = sinfoRow4_Column4;
            dRow[4] = sinfoRow4_Column5;
            dRow[5] = sinfoRow4_Column6;
            dTable.Rows.Add(dRow);

            m_HMITag = dTable;
        }

        protected void AddAlarmInfo()
        {
            DataTable dTable = new DataTable();
            DataRow dRow;

            string sinfoRow1 = "# Tag Table Export";
            string sinfoRow2 = "# Do not edit the below 1 line. These lines contain important information.";
            string sinfoRow3 = "50000 알람";

            string sinfoRow4_Column1 = "3";
            string sinfoRow4_Column2 = "412";
            string sinfoRow4_Column3 = "409";
            string sinfoRow4_Column4 = "00000c0a";

            string sinfoRow5_Column1 = "#No";
            string sinfoRow5_Column2 = "한국어(대한민국)";
            string sinfoRow5_Column3 = "영어(미국)";
            string sinfoRow5_Column4 = "스페인어(스페인, 국제 정렬)";
            string sinfoRow5_Column5 = "색상";
            string sinfoRow5_Column6 = "기울임꼴";
            string sinfoRow5_Column7 = "밑줄";
            string sinfoRow5_Column8 = "취소선";
            string sinfoRow5_Column9 = "굵게";

            dTable.Columns.Add(sinfoRow5_Column1);
            dTable.Columns.Add(sinfoRow5_Column2);
            dTable.Columns.Add(sinfoRow5_Column3);
            dTable.Columns.Add(sinfoRow5_Column4);
            dTable.Columns.Add(sinfoRow5_Column5);
            dTable.Columns.Add(sinfoRow5_Column6);
            dTable.Columns.Add(sinfoRow5_Column7);
            dTable.Columns.Add(sinfoRow5_Column8);
            dTable.Columns.Add(sinfoRow5_Column9);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow1;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow2;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow3;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow4_Column1;
            dRow[1] = sinfoRow4_Column2;
            dRow[2] = sinfoRow4_Column3;
            dRow[3] = sinfoRow4_Column4;
            dTable.Rows.Add(dRow);

            dRow = dTable.NewRow();
            dRow[0] = sinfoRow5_Column1;
            dRow[1] = sinfoRow5_Column2;
            dRow[2] = sinfoRow5_Column3;
            dRow[3] = sinfoRow5_Column4;
            dRow[4] = sinfoRow5_Column5;
            dRow[5] = sinfoRow5_Column6;
            dRow[6] = sinfoRow5_Column7;
            dRow[7] = sinfoRow5_Column8;
            dRow[8] = sinfoRow5_Column9;
            dTable.Rows.Add(dRow);

            m_HMIAlarm = dTable;
        }

        protected void AddAlarmColumn()
        {
            DataTable dTable = new DataTable();

            string sinfoRow5_Column1 = "#No";
            string sinfoRow5_Column2 = "한국어(대한민국)";
            string sinfoRow5_Column3 = "영어(미국)";
            string sinfoRow5_Column4 = "스페인어(스페인, 국제 정렬)";
            string sinfoRow5_Column5 = "색상";
            string sinfoRow5_Column6 = "기울임꼴";
            string sinfoRow5_Column7 = "밑줄";
            string sinfoRow5_Column8 = "취소선";
            string sinfoRow5_Column9 = "굵게";

            dTable.Columns.Add(sinfoRow5_Column1);
            dTable.Columns.Add(sinfoRow5_Column2);
            dTable.Columns.Add(sinfoRow5_Column3);
            dTable.Columns.Add(sinfoRow5_Column4);
            dTable.Columns.Add(sinfoRow5_Column5);
            dTable.Columns.Add(sinfoRow5_Column6);
            dTable.Columns.Add(sinfoRow5_Column7);
            dTable.Columns.Add(sinfoRow5_Column8);
            dTable.Columns.Add(sinfoRow5_Column9);

            m_HMIAlarmColumn = dTable;
        }



        #endregion

        #region Private Methods

        #endregion
    }
}
