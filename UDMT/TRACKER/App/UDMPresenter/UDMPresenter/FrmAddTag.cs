using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.DDEA;
using UDM.Common;

namespace UDMPresenter
{
    public partial class FrmAddTag : DevExpress.XtraEditors.XtraForm
    {
        private string m_sChannel = "";

        public FrmAddTag()
        {
            InitializeComponent();
        }

        public string Channel
        {
            set { m_sChannel = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sAddress = txtAddress.Text.ToUpper();
            if (sAddress == "")
            {
                MessageBox.Show("Address가 입력되지 않았습니다.");
                return;
            }
            string sKey = "";

            //주소가 생성가능한지 확인
            try
            {
                EMDataType emType = CCommonUtil.ToDataType(cmbDataType.SelectedItem.ToString());
                int iAddressCount = 1;
                bool bDot = false;
                if (sAddress.Contains("."))
                {
                    emType = EMDataType.Bool;
                    bDot = true;
                }
                else
                {
                    if (emType == EMDataType.DWord)
                        iAddressCount = 2;
                }
                sKey = string.Format("{0}.{1}[{2}]", m_sChannel, sAddress, iAddressCount);

                CDDEASymbol cSymbol = new CDDEASymbol(sKey, false);
                bool bOK = cSymbol.CreateMelsecDDEASymbol(sAddress);
                if (bOK == false) return;
                bool bHexa = cSymbol.CheckAddressHexa(sAddress);
                int iCommentCount = 1;
                int iAddressMinor = cSymbol.AddressMinor - 1;
                int iAddressMajor = cSymbol.AddressMajor;

                for (int i = 0; i < spnAddCount.Value * iAddressCount; i++)
                {
                    string sCreateAddress = "";

                    if (bDot && iAddressMinor >= 15)
                    {
                        iAddressMinor = 0;
                        iAddressMajor++;
                    }
                    else
                        iAddressMinor++;
                    if (emType == EMDataType.DWord && cSymbol.AddressHeader != "D" && cSymbol.AddressHeader != "W") continue;
                    if (bHexa)
                    {
                        if (bDot)
                            sCreateAddress = string.Format("{0}{1:x}.{2:x}", cSymbol.AddressHeader, iAddressMajor, iAddressMinor);
                        else
                            sCreateAddress = string.Format("{0}{1:x}", cSymbol.AddressHeader, iAddressMajor + i);
                    }

                    else
                    {
                        if (bDot)
                        {
                            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC)
                            {
                                if (cSymbol.AddressHeader == "W" || cSymbol.AddressHeader == "SW")
                                    sCreateAddress = string.Format("{0}{1:x}.{2}", cSymbol.AddressHeader, iAddressMajor, iAddressMinor);
                                else
                                    sCreateAddress = string.Format("{0}{1}.{2}", cSymbol.AddressHeader, iAddressMajor, iAddressMinor);
                            }
                            else
                            {
                                if (cSymbol.AddressHeader == "W" || cSymbol.AddressHeader == "SW")
                                    sCreateAddress = string.Format("{0}{1:x}.{2:x}", cSymbol.AddressHeader, iAddressMajor, iAddressMinor);
                                else
                                    sCreateAddress = string.Format("{0}{1}.{2:x}", cSymbol.AddressHeader, iAddressMajor, iAddressMinor);
                            }
                        }
                        else
                            sCreateAddress = string.Format("{0}{1}", cSymbol.AddressHeader, iAddressMajor + i);
                    }
                    sCreateAddress = sCreateAddress.ToUpper();
                    sKey = string.Format("{0}.{1}[{2}]", m_sChannel, sCreateAddress, iAddressCount);

                    CTag cTag = new CTag();
                    cTag.Key = sKey;
                    cTag.Address = sCreateAddress;
                    if (emType != EMDataType.DWord)
                        cTag.DataType = cSymbol.DataType;
                    else
                        cTag.DataType = emType;
                    if (txtComment.Text == "")
                        cTag.Description = "";
                    else
                        cTag.Description = txtComment.Text + iCommentCount.ToString();
                    cTag.Channel = m_sChannel;
                    cTag.Size = iAddressCount;
                    if (CProjectManager.SelectedProject.TagS.ContainsKey(sKey) == false)
                    {
                        CProjectManager.SelectedProject.TagS.Add(cTag);
                        iCommentCount++;
                    }
                    if (emType == EMDataType.DWord) i++;
                }
                CProjectManager.UpdateView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("생성할 수 없습니다.  " + ex.Message);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}