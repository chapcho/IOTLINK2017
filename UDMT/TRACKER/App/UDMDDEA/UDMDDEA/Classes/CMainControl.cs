using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.DDEA;
using System.Windows.Forms;
using UDM.General.Serialize;
using UDM.Monitor.Plc.Source.OPC;
using UDM.Monitor.Plc.Source;
using UDM.Common;
using UDM.Monitor.Plc.Source.LS;

namespace UDMDDEA
{
    [Serializable]
    public class CMainControl
    {
        #region Member Veriables

        protected string m_sProjectName = "";
        protected EMCollectMode m_emCollectMode = EMCollectMode.Wait;
        protected bool m_bPlcConfigTest = true;
        protected List<string> m_lstDDEAFailAddress = null;
        protected string m_sUpmSavePath = "";
        protected CDDEAProject m_cDDEAProject = null;           // save 3
        protected CDDEASymbolS m_cReciveDDEASymbolS = new CDDEASymbolS();

        protected COPCConfig m_cOPCConfig = new COPCConfig();
        protected CLsConfig m_cLsConfig = new CLsConfig();
        protected EMSourceType m_emCollectType = EMSourceType.OPC;
        protected EMPLCMaker m_emPlcMaker = EMPLCMaker.Siemens;

        #endregion


        #region Initialize

        public CMainControl()
        {
            if (m_cDDEAProject == null) m_cDDEAProject = new CDDEAProject("Create");
            else m_cDDEAProject.Clear();
        }

        #endregion


        #region Properties

        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }

        public CDDEAProject DDEAProject
        {
            get { return m_cDDEAProject; }
            set { m_cDDEAProject = value; }
        }

        public CDDEASymbolS ReceiveDDEASymbolS
        {
            get { return m_cReciveDDEASymbolS; }
            set { m_cReciveDDEASymbolS = value; }
        }

        public EMCollectMode CollectMode
        {
            get { return m_emCollectMode; }
            set { m_emCollectMode = value; }
        }

        public bool PLCConfigTest
        {
            get { return m_bPlcConfigTest; }
            set { m_bPlcConfigTest = value; }
        }

        public List<string> DDEAFailAddress
        {
            get { return m_lstDDEAFailAddress; }
            set { m_lstDDEAFailAddress = value; }
        }

        public string UpmSaveFilePath
        {
            get { return m_sUpmSavePath; }
            set { m_sUpmSavePath = value; }
        }

        public COPCConfig OpcConfig
        {
            get { return m_cOPCConfig; }
            set { m_cOPCConfig = value; }
        }

        public CLsConfig LsConfig
        {
            get { return m_cLsConfig; }
            set { m_cLsConfig = value; }
        }

        public EMSourceType ConnectType
        {
            get { return m_emCollectType; }
            set { m_emCollectType = value; }
        }

        public EMPLCMaker PlcMaker
        {
            get { return m_emPlcMaker; }
            set { m_emPlcMaker = value; }
        }

        #endregion


        #region Public Method

        public bool CreateMainControl()
        {
            if (m_cDDEAProject == null) m_cDDEAProject = new CDDEAProject("Create");
            else                        m_cDDEAProject.Clear();

            return true;
        }

        public void Clear()
        {
            if (m_cDDEAProject != null)
                m_cDDEAProject.Clear();

            m_sProjectName = "";
        }

        public bool Open(string sPath)
        {
            bool bOK = true;

            Clear();

            CPackSerializer<CMainControl> serializerMainControl = new CPackSerializer<CMainControl>();
            CMainControl cMainControl = serializerMainControl.Read(sPath);

            serializerMainControl.Dispose();
            serializerMainControl = null;

            if (cMainControl != null)
            {
                Clone(cMainControl);
            }
            else
                bOK = false;

            return bOK;
        }

        public bool Save(string sPath)
        {
            bool bOK = true;

            CPackSerializer<CMainControl> serializerMainControl = new CPackSerializer<CMainControl>();
            bOK = serializerMainControl.Write(sPath, this);
            serializerMainControl.Dispose();
            serializerMainControl = null;

            return bOK;
        }

        private void Clone(CMainControl cMainControl)
        {
            if (cMainControl.DDEAProject != null)
                m_cDDEAProject = cMainControl.DDEAProject;

            this.ProjectName = cMainControl.ProjectName;
            this.CollectMode = cMainControl.CollectMode;
            this.PLCConfigTest = cMainControl.PLCConfigTest;
            this.DDEAFailAddress = cMainControl.DDEAFailAddress;
            this.UpmSaveFilePath = cMainControl.UpmSaveFilePath;
            this.ReceiveDDEASymbolS = cMainControl.ReceiveDDEASymbolS;
        }

        #endregion

    }
}
