using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace UDMTrackerSimple
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, ref int extrainfo);
        private int info = 0;
        private const int VK_ESCAPE = 0x1B;

        private string m_sFixpasswordPath = Application.StartupPath + "\\AdministratorPassword.txt";

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Adminpassword = "";
            string Inputpassword = "";
            bool filecheck = false;

            filecheck = AdminPassword();
            if (filecheck)
            {
                Adminpassword = ReadAdminPassword();
                Inputpassword = txtPassword.Text;
                if (Adminpassword.Equals(Inputpassword))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.No;
                    MessageBox.Show("Password가 일치하지 않습니다.");
                }
            }
            else
            {
                if (File.Exists(m_sFixpasswordPath) == true)
                {
                    WriteAdminPassword();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.No;
                    MessageBox.Show("Password가 생성되지 않았습니다.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Dispose(false);
        }

        private bool AdminPassword()
        {
            try
            {//처음 File이 없을때 File 생성
                if (File.Exists(m_sFixpasswordPath) == false)
                {
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        FileStream stream = File.Create(m_sFixpasswordPath);
                        stream.Dispose();
                        stream = null;
                        return false;
                    }
                    else
                    { 
                        MessageBox.Show("Password가 null이거나 공백문자가 포함되어있습니다.");
                        return false;
                    }
                }
                else return true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                return false;
            }
        }

        private void WriteAdminPassword()
        {
            //처음 Password가 없을때 생성된 Password를 저장
            StreamWriter writer = new StreamWriter(m_sFixpasswordPath);
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                writer.WriteLine(txtPassword.Text);
            }
            else MessageBox.Show("Password가 null이거나 공백문자가 포함되어있습니다.");
            writer.Dispose();
            writer = null;
        }

        private string ReadAdminPassword()
        {
            //Open된 file에 Password가 있다면 Password를 반환
            StreamReader reader = new StreamReader(m_sFixpasswordPath);
            string sLine = "";
            while ((sLine = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(sLine))
                {
                    reader.Dispose();
                    reader = null;
                    return sLine;
                }
                else
                {
                    MessageBox.Show("Password에 공백 문자가 포함되어 있습니다.");
                    return null;
                }
            }
            reader.Dispose();
            reader = null;
            return null;
        }

//         private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
//         {
//             if (e.KeyChar == Convert.ToChar(Keys.Enter))
//                 btnLogin_Click(sender, e);
//         }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(this, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                btnLogin_Click(this, EventArgs.Empty);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            keybd_event(VK_ESCAPE, 0, 0x00, ref info);
            keybd_event(VK_ESCAPE, 0, 0x02, ref info);
        }
    }
}