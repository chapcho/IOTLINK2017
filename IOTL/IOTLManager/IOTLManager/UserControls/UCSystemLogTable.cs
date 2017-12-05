using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTLManager.UserControls
{
    public partial class UCSystemLogTable : UserControl
    {

        private DataTable m_dbTable;
        private int m_iMaxRow = 500;

        private delegate void AddMessageCallBack(DateTime dtTime, string sSender, string sMessage);

        public UCSystemLogTable()
        {
            InitializeComponent();

            CreateTableScheme();

            exDataGrid.DataSource = m_dbTable;

        }

        private void CreateTableScheme()
        {
            if (m_dbTable == null)
                m_dbTable = new DataTable();

            m_dbTable.Rows.Clear();
            m_dbTable.Columns.Clear();

            string sField;
            for (int i = 0; i < exDataGrid.Columns.Count; i++)
            {
                sField = exDataGrid.Columns[i].Name;
                m_dbTable.Columns.Add(sField);

            }
        }

        public void AddMessage(DateTime dtTime, string sSender, string sMessage)
        {
            try
            {
                if(this.InvokeRequired)
                {
                    AddMessageCallBack cbMessageCallBack = new AddMessageCallBack(AddMessage);
                    this.Invoke(cbMessageCallBack, new object[] { dtTime, sSender, sMessage });
                }
                else
                {
                    string sTime = dtTime.ToString("yyyy/MM/dd HH:mm:ss.fff");

                    DataRow dbRow = m_dbTable.NewRow();
                    dbRow[colTime.Name] = (string)sTime;
                    dbRow[colSender.Name] = (string)sSender;
                    dbRow[colMessage.Name] = (string)sMessage;

                    m_dbTable.Rows.Add(dbRow);

                    if (m_dbTable.Rows.Count > m_iMaxRow)
                        m_dbTable.Rows.RemoveAt(0);

                    
                    // DataGridView의 최근 추가한 Row가 표시되도록 하는 방법
                    // https://stackoverflow.com/questions/13621260/autoscroll-in-datagridview

                    int i_NotDisplayableRowCount = exDataGrid.RowCount - exDataGrid.DisplayedRowCount(false); // false means partial rows are not taken into acount
                    if (i_NotDisplayableRowCount > 0)
                        exDataGrid.FirstDisplayedScrollingRowIndex = i_NotDisplayableRowCount;

                    exDataGrid.Refresh();

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

            exDataGrid.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void exDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cell을 DblClick 했을때 셀을 내용을 상세하게 표시한다.

            string receiveTime = exDataGrid[0, e.RowIndex].Value.ToString();
            string caller = exDataGrid[1, e.RowIndex].Value.ToString();
            string dataMessage = exDataGrid[2, e.RowIndex].Value.ToString();

            MessageBox.Show(receiveTime + " : " + dataMessage, caller, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void copyClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = exDataGrid.SelectedRows;
            StringBuilder sb = new StringBuilder();

            try
            {
                foreach (DataGridViewRow dr in rows)
                {
                    string addMessage = string.Empty;
                    for (int i = 0; i < dr.Cells.Count; i++)
                    {
                        addMessage = string.Format(" {0},", dr.Cells[i].Value.ToString());
                        sb.Append(addMessage);
                    }
                    addMessage = string.Format("\r\n");
                    sb.Append(addMessage);
                }

                Clipboard.SetText(sb.ToString());
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
        }
    }
}
