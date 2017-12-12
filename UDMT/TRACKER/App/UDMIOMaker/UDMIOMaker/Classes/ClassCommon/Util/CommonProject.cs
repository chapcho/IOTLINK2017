using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General.Serialize;
using UDM.Common;
using UDM.General.Csv;
using System.Data;
using System.IO;
using NewIOMaker.Classes.ClassTagGenerator;
using System.Drawing;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    [Serializable]

    public class CommonProject
    {
        protected CTagS _cTags;
        protected DataTable _PLC = null;
        protected DataTable _HMI = null;
        protected DataTable _Log = null;
        protected DataTable _Alarm = null;
        protected DataTable _KeyDB = null;


        protected Dictionary<string, List<string>> _dicKey = new Dictionary<string, List<string>>();
        protected List<CellColor> _CellColor = new List<CellColor>();
        protected Color[] _Color = new Color[3];

        protected EMPLCMaker _PLCType;

        protected string _Skin = string.Empty;
        protected string _Path = string.Empty;
        protected string _BackupDate = string.Empty;

        #region Initialize/Dispose

        public CommonProject()
        {

        }

        public void Dispose()
        {

        }

        #endregion

        #region Public Properties

        public Dictionary<string, List<string>> DicKey
        {
            get { return _dicKey; }
            set { _dicKey = value; }
        }

        public string Skin
        {
            get { return _Skin; }
            set { _Skin = value; }
        }

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        public DataTable PLC
        {
            get { return _PLC; }
            set { _PLC = value; }
        }
        public DataTable HMI
        {
            get { return _HMI; }
            set { _HMI = value; }
        }

        public DataTable Log
        {
            get { return _Log; }
            set { _Log = value; }
        }

        public DataTable KeyDB
        {
            get { return _KeyDB; }
            set { _KeyDB = value; }
        }

        public List<CellColor> CellColor
        {
            get { return _CellColor; }
            set { _CellColor = value; }
        }

        public EMPLCMaker PLCType
        {
            get { return _PLCType; }
            set { _PLCType = value; }
        }

        public CTagS cTags
        {
            get { return _cTags; }
            set { _cTags = value; }
        }

        public Color[] Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public string BackupDate
        {
            get { return _BackupDate; }
            set { _BackupDate = value; }
        }

        #endregion

        #region Public Methods

        public void Save(string sSavePath)
        {

        }

        public void Open(string sSavePath)
        {

        }

        #endregion

        #region Privat Methods

        #endregion
    }
}
