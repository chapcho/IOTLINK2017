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
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;


namespace NewIOMaker.Classes.ClassTagGenerator
{
    /// <summary>
    /// PLC를 Open하는 클래스 
    /// </summary>
    /// 
    public class OpenPLC
    {
        protected DataTable _dbPLC = new DataTable();

        protected string _PLCType = string.Empty;
        protected string _PLCPath = string.Empty;
        protected string _Extension = string.Empty;

        protected bool _Header = false;
        protected int _Line = 0;

        #region Intialize/Dispose

        public OpenPLC(string PLCType)
        {
            _PLCType = PLCType;

            FileOpen();
        }

        #endregion

        #region Public Properites

        public string PLCType
        {
            get { return _PLCType; }
            set { _PLCType = value; }
        }

        public string PLCPath
        {
            get { return _PLCPath; }
            set { _PLCPath = value; }
        }

        public bool Header
        {
            get { return _Header; }
            set { _Header = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        public DataTable dbPLC
        {
            get { return _dbPLC; }
            set { _dbPLC = value; }
        }

        #endregion

        #region Public Methods

        protected void FileOpen()
        {

            OpenFileDialog odlg = new OpenFileDialog();

            InfoPLC infoPlc = new InfoPLC(_PLCType);

            _Extension = infoPlc.Extension;

            odlg.Filter = _Extension;

            _Header = infoPlc.Header;
            _Line = infoPlc.Line;

            if (odlg.ShowDialog() == DialogResult.OK)
            {
                _PLCPath = odlg.FileName;
            }
            else
                return;
        
        }


        #endregion

    }


}
