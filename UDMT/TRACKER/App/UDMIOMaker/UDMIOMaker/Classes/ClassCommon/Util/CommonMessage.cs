using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    public class CommonMessage
    {
        #region Initialize/Dispose

        public CommonMessage() { }

        #endregion

        #region Message

        #region Common

        public bool Quit()
        {
            if (XtraMessageBox.Show("Are you sure you want to Quit?", "Information!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }

        public void Preparing()
        {
            XtraMessageBox.Show("     On The Anvil.. ", "Information !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);

            
        }

        #endregion

        #region IOMaker


        #endregion

        #region TageGenerator

        public void DifferentType()
        {
            XtraMessageBox.Show("     Different types.. ", "Error !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
        }

        public void FileLoadFail()
        {
            XtraMessageBox.Show("     File Load Fail.. ", "Error !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
        }

        public bool Clear()
        {
            if (XtraMessageBox.Show("Are you sure you want to Clear?", "Information !!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }

        public void XYSupport()
        {
            XtraMessageBox.Show("     Only X or Y Address Support.. ", "Information !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }

        public void InuseFile()
        {
            XtraMessageBox.Show("     The file is already in use.. \n\nPlease try again to close the file.. ", "Error !!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button1);
        }

        public void SDFsetting()
        {
            XtraMessageBox.Show("     The SDF file settings are required.. ", "Warning !!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1);
        }

        public void HMILoad()
        {
            XtraMessageBox.Show("     Please load the HMI Files.. ", "Caution !!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button1);
        }

        public void SiemensMain()
        {
            XtraMessageBox.Show("     Please load the AWL file after loading SDF file ", "Warning !!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button1);
        }

        public void ConvertDifferType()
        {
            XtraMessageBox.Show("Different types.. \n\n No Word Types are supported..", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool bInsertBitOK()
        {
            if (XtraMessageBox.Show("Are you sure you want to Insert?", "Insert Bit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }

        public bool bReallyConvert()
        {
            if (XtraMessageBox.Show("Are you sure you want to Convert?", "Convertor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }

        public bool bReallyRestore()
        {
            if (XtraMessageBox.Show("Are you sure you want to Convert?", "Convertor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }

        public void SaveOK(bool bSave)
        {
            if (bSave)
            {
                XtraMessageBox.Show("Project is saved!!", "IOMaker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Fail to save project file!!", "IOMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Information(string Version)
        {
            XtraMessageBox.Show("    Copyright (C) 2014 \n\nIOMaker Version " + Version + "\n\n    UDMTek Co.. Ltd.", "IOMaker 정보",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
        }

        public void OnTheAnvil()
        {
            XtraMessageBox.Show("    On the anvil.... ", "IOMaker", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void NotSupport()
        {
            XtraMessageBox.Show("Not Supported..", "IOMaker 정보",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
        }

        public void AlarmLoad()
        {
            XtraMessageBox.Show("     Please load the Alarm List.. ", "Caution !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
        }

        public void HMIEditON()
        {
            XtraMessageBox.Show("     HMI Edit ON !!", "Caution !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
        }

        public void HMIEditOFF()
        {
            XtraMessageBox.Show("     HMI Edit OFF !!", "Caution !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
        }

        #endregion

        #region MultiCopy

        public void Run()
        {
            XtraMessageBox.Show("     MultiCopy On.. ", "Runing !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }

        public void Stop()
        {
            XtraMessageBox.Show("     MultiCopy Off.. ", "Stop !!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }

        public void RegistConform()
        {
            XtraMessageBox.Show("The Key has been registered...");
        }

        public void KeyClickConform()
        {
            XtraMessageBox.Show("Please select the Key...");
        }



        #endregion

        #endregion
    }
}
