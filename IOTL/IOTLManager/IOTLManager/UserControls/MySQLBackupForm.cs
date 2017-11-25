using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTLManager.UserControls
{
    public partial class MySQLBackupForm : Form
    {
        private string conString = string.Empty;

        public MySQLBackupForm()
        {
            InitializeComponent();
            ConfigureBackupDialog();
        }


        public MySQLBackupForm(string conString)
        {
            InitializeComponent();
            this.conString = conString;
            ConfigureBackupDialog();
        }

        private void ConfigureBackupDialog()
        {
            this.folderBrowserDialog1.ShowNewFolderButton = true;
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;

            btnDbBackup.Enabled = false;
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.folderBrowserDialog1.ShowDialog();

            if(dr == DialogResult.OK)
            {
                this.txtTargetPath.Text = this.folderBrowserDialog1.SelectedPath;
                btnDbBackup.Enabled = true;
            }
        }

        private void btnDBRestore_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();

            if(dr == DialogResult.OK)
            {
                string backupFile = this.openFileDialog1.FileName;

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(conString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(backupFile);
                                conn.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
            }
        }

        private void btnDbBackup_Click(object sender, EventArgs e)
        {
            string file = this.txtTargetPath.Text + "\\IOTLDBBackup" + DateTime.Now.ToString("yyyyMMddhhmm") + ".sql";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
            finally
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
