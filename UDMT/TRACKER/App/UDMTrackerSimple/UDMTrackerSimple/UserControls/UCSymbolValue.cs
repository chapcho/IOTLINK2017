using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;

namespace UDMTrackerSimple
{
    public partial class UCSymbolValue : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iSplitPos = 0;
        private int m_iUserSplitPos = 0;
        public UCSymbolValue()
        {
            InitializeComponent();
        }

        public UCRobotCycle RobotCycle
        {
            get { return ucRobotCycle; }
            set { ucRobotCycle = value; }
        }

        public DevExpress.XtraGrid.GridControl CollectGrid
        {
            get { return grdRuntimeValue; }
            set { grdRuntimeValue = value; }
        }

        public DevExpress.XtraGrid.GridControl UserAllGrid
        {
            get { return grdUserAll;}
            set { grdUserAll = value; }
        }

        public DevExpress.XtraGrid.GridControl UserWordGrid
        {
            get { return grdUserDevice;}
            set { grdUserDevice = value; }
        }


        private void grvUserAll_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName != "DetailViewShow") return;
                CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
                if (cUser == null) return;
                if (cUser.DataType == EMDataType.Bool)
                {
                    cUser.DetailViewShow = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvUserAll_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName != "DetailViewShow") return;
                CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
                if (cUser == null) return;
                if (cUser.DataType != EMDataType.Bool)
                {
                    if (cUser.DetailViewShow != (bool)e.Value)
                    {
                        cUser.DetailViewShow = (bool)e.Value;

                        grdUserDevice.DataSource =
                            CMultiProject.UserDeviceS.Values.Where(
                                b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
                        grdUserDevice.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvUserAll_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    e.Info.DisplayText = e.RowHandle.ToString();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvRuntimeValue_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    e.Info.DisplayText = e.RowHandle.ToString();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }


        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }

        private void sptUserDeivce_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iUserSplitPos = sptUserDeivce.SplitterPosition;
                sptUserDeivce.SplitterPosition = 0;
            }
            else
                sptUserDeivce.SplitterPosition = m_iUserSplitPos;
        }


    }
}
