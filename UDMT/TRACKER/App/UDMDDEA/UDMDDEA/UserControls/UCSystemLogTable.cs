using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UDMDDEA
{
    public partial class UCSystemLogTable : UserControl
    {
        #region Member Variables

        private DataTable m_dbTable = new DataTable();
        private int m_iMaxRow = 50;
        private delegate void AddMessageCallBack(DateTime dtTime, string sSender, string sMessage);

        #endregion


        #region Initialize/Dispose

        public UCSystemLogTable()
        {
            InitializeComponent();

            CreateTableScheme();

            exGridMain.DataSource = m_dbTable;
        }

        #endregion


        #region Public Methods

        public void AddMessage(DateTime dtTime, string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AddMessageCallBack cbAddMessage = new AddMessageCallBack(AddMessage);
                    this.Invoke(cbAddMessage, new object[] { dtTime, sSender, sMessage });
                }
                else
                {
                    if (m_dbTable != null)
                    {
                        string sTime = dtTime.ToString("yy/MM/dd HH:mm:ss.fff");

                        DataRow dbRow = m_dbTable.NewRow();
                        dbRow[colTime.FieldName] = (string)sTime;
                        dbRow[colSender.FieldName] = (string)sSender;
                        dbRow[colMessage.FieldName] = (string)sMessage;

                        m_dbTable.Rows.Add(dbRow);

                        if (m_dbTable.Rows.Count > m_iMaxRow)
                            m_dbTable.Rows.RemoveAt(0);
                        else
                            exGridView.MakeRowVisible(m_dbTable.Rows.Count);
                        
                        exGridMain.Refresh();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }            
        }

        public void Clear()
        {
            if (m_dbTable != null)
                m_dbTable.Clear();

            exGridMain.Refresh();
        }

        #endregion


        #region Private Methods

        private void CreateTableScheme()
        {
            if (m_dbTable == null)
                m_dbTable = new DataTable();

            m_dbTable.Rows.Clear();
            m_dbTable.Columns.Clear();

            string sField;
            for (int i = 0; i < exGridView.Columns.Count; i++)
            {
                sField = exGridView.Columns[i].FieldName;
                m_dbTable.Columns.Add(sField);
            }
        }

        #endregion


        #region Event Methods

        private void UCMessageLog_Load(object sender, EventArgs e)
        {
                        
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion
    }
}
