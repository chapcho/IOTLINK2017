using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMPLCLogicAnalyzer
{
    public partial class UCPLCDataGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private CDoubleCoilDataS m_cDoubleCoilS = null;
        private string m_sPLCInfoData = "";
        public event UEventHandlerDoubleCoilLadderView UEventDoubleCoilLadderView = null;

        #endregion


        #region Iniitialize

        public UCPLCDataGrid()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CDoubleCoilDataS DoubleCoilDataS
        {
            get { return m_cDoubleCoilS; }
            set { m_cDoubleCoilS = value; }
        }

        public string PLCInfo
        {
            get { return m_sPLCInfoData; }
            set { m_sPLCInfoData = value; }
        }

        #endregion

        private void UCPLCDataGrid_Load(object sender, EventArgs e)
        {
            grpMain.Text = m_sPLCInfoData;
        }

        private void btnLadderView_Click(object sender, EventArgs e)
        {
            int iRowHandle = grvData.FocusedRowHandle;
            if (iRowHandle < 0)
                return;

            object obj = grvData.GetRow(iRowHandle);

            if (obj.GetType() != typeof(CDoubleCoilData))
                return;

            CDoubleCoilData cData = (CDoubleCoilData)obj;
            if (cData == null) return;

            string sKey = cData.TagKey;
            if (m_cDoubleCoilS.ContainsKey(sKey) == false)
                return;
            List<CStep> lstStep = new List<CStep>();
            foreach (CDoubleCoilData coil in m_cDoubleCoilS[sKey])
            {
                lstStep.Add(coil.Step);
            }

            if (UEventDoubleCoilLadderView != null)
            {
                UEventDoubleCoilLadderView(sender, sKey, lstStep);
            }
        }

        public void RefreshData()
        {
            if (m_cDoubleCoilS == null)
            {
                //MessageBox.Show("정보가 없습니다.");
                return;
            }
            
            List<CDoubleCoilData> lstTotalDoubleCoilData = new List<CDoubleCoilData>();
            grpMain.Text = m_sPLCInfoData;
            grdData.DataSource = null;

            foreach (var who in m_cDoubleCoilS)
            {
                List<CDoubleCoilData> lstData = who.Value;
                lstTotalDoubleCoilData.AddRange(lstData);
            }

            if (lstTotalDoubleCoilData.Count > 0)
            {
                grdData.DataSource = lstTotalDoubleCoilData;
            }

            grdData.RefreshDataSource();
        }
    }
}
