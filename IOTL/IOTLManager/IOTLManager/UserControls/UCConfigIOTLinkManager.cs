﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOTL.Project;
using IOTL.Common.Serialize;

namespace IOTLManager.UserControls
{
    public partial class UCConfigIOTLinkManager : UserControl
    {
        private CProject cProject = new CProject();

        public UCConfigIOTLinkManager()
        {
            InitializeComponent();
        }

        private void btnCompServerLogFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "*.cfg||(*.cfg)";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("...");
            }
        }

        private bool ValidationServerConfig()
        {
            bool bRet = false;

            bRet = true;

            if(!bRet)
            {
                MessageBox.Show("설정 정보를 확인하세요!");
            }
            return bRet;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if(!ValidationServerConfig())
            {
                return;
            }

            CProject _localSetting = new CProject();

            _localSetting.CompServerIPAddress = this.txtCompServerIPAddress.Text;
            _localSetting.CompServerTcpPort = Convert.ToUInt16(this.txtCompServerPort.Text);
            _localSetting.CompServerInitialDatabaseName = this.txtCompServerDBName.Text;
            _localSetting.CompServerDBLoginUserId = this.txtCompServerDBUserID.Text;
            _localSetting.CompServerDBLoginUserPw = this.txtCompServerDBUserPw.Text;

            SaveCompServerSetting(Application.StartupPath, _localSetting);

        }

        private bool SaveCompServerSetting(string configSavePath, CProject localSetting)
        {
            bool bOK = false;
            NetSerializer cSerializer = new NetSerializer();

            try
            {
                bOK = cSerializer.Write(configSavePath, localSetting);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bOK;
        }
    }
}
