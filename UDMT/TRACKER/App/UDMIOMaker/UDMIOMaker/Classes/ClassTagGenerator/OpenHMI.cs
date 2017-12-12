using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using NewIOMaker.Enumeration;
using NewIOMaker.Classes.ClassTagGenerator;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    /// <summary>
    /// HMI Open 클래스
    /// 타입, 경로, 해더 , 라인 등 정보 확인
    /// </summary>
    /// 
    public class OpenHMI
    {
        protected DataTable _dbHMI = new DataTable();

        protected string _HMIType = string.Empty;
        protected string _HMIPath = string.Empty;

        protected bool _Header = false;
        protected int _Line = 0;

        #region Intialize/Dispose

        public OpenHMI(string HMIType)
        {
            _HMIType = HMIType;

            FileOpen();
        }

        #endregion

        #region Public Properites

        public string HMIType
        {
            get { return _HMIType; }
            set { _HMIType = value; }
        }

        public string HMIPath
        {
            get { return _HMIPath; }
            set { _HMIPath = value; }
        }

        public bool Header
        {
            get { return _Header; }
            set { _Header = value; }
        }

        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        #endregion

        #region Public Methods

        protected void FileOpen()
        {
            OpenFileDialog odlg = new OpenFileDialog();

            InfoHMI infoHmi = new InfoHMI(_HMIType);

            odlg.Filter = infoHmi.Extension;

            _Header = infoHmi.Header;
            _Line = infoHmi.Line;

            if (odlg.ShowDialog() == DialogResult.OK)
            {
                _HMIPath = odlg.FileName;
            }
            else
                return;
        }

        #endregion
    }
}
