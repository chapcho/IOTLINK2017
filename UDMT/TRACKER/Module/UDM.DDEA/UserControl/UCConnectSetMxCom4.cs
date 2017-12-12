using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace UDM.DDEA
{
    public partial class UCConnectSetMxCom4 : UserControl
    {
        #region Member Variables

        protected int m_iSelectedIndex = -1;
        protected CDDEAConfigMS m_cConfig = null;

        #endregion


        #region Initialize

        public UCConnectSetMxCom4()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public int SelectedIndex
        {
            get { return m_iSelectedIndex; }
            set { m_iSelectedIndex = value; }
        }

        public CDDEAConfigMS Config
        {
            get { return m_cConfig; }
            set
            {
                m_cConfig = value;
                if (m_cConfig != null)
                    ShowRadioGroup();
            }
        }

        #endregion


        #region Private Method

        private void ShowRadioGroup()
        {
            if (radioMxCom4List.Properties.Items.Count > 0)
                radioMxCom4List.Properties.Items.Clear();

            m_iSelectedIndex = m_cConfig.MxCom4SelectedIndex;

            foreach (var who in m_cConfig.MxCom4SettingList)
            {
                RadioGroupItem rGroupItem = new RadioGroupItem(who.Value.ConnectionNumber, "");
                //if (who.Value.Comment != "")
                //    rGroupItem.Description = who.Value.ConnectionNumber.ToString() + "( " + who.Value.Comment + " )";
                //else
                    rGroupItem.Description = who.Value.Name + "      ";

                radioMxCom4List.Properties.Items.Add(rGroupItem);
            }
            radioMxCom4List.SelectedIndex = m_iSelectedIndex;
        }

        #endregion

        private void UCConnectSetMxCom4_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            int iResult = 0;
            iResult = axActWizard.OpenWizard(0, 0);
            if (iResult == 1)
            {
                MessageBox.Show("설정이 변경되었습니다.");

                bool bOK = m_cConfig.CreateMxCom4();
                if (bOK == false) return;
                ShowRadioGroup();
            }
        }

        private void radioMxCom4List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_iSelectedIndex != (int)radioMxCom4List.Properties.Items[radioMxCom4List.SelectedIndex].Value)
            {
                m_iSelectedIndex = (int)radioMxCom4List.Properties.Items[radioMxCom4List.SelectedIndex].Value;
                m_cConfig.MxCom4SelectedIndex = m_iSelectedIndex;
            }
        }
    }
}
