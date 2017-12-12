using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple.UserControls
{
    public partial class UCUserDeviceS : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Varialbes

        protected List<CUserDevice> m_lstUserDevice = new List<CUserDevice>();

        #endregion


        #region Initialize

        public UCUserDeviceS()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        #endregion


        #region Public Method

        public void Clear()
        {
            pnlView.Controls.Clear();

            pnlView.Refresh();
        }

        public void RefreshValue()
        {
            for (int i = 0; i < pnlView.Controls.Count; i++)
            {
                UCUserDevice cDevice = (UCUserDevice) pnlView.Controls[i];
                cDevice.RefreshData();
            }
        }

        public void SetDevice(List<CUserDevice> lstDevice)
        {
            m_lstUserDevice = lstDevice;
            for (int i = 0; i < m_lstUserDevice.Count; i++)
            {
                AddControl(m_lstUserDevice[i]);
            }
            SetAutoLocation();
            pnlView.Refresh();
        }

        #endregion

        private void SetAutoLocation()
        {
            int iCount = pnlView.Controls.Count;
            int iBaseWidth = pnlView.Size.Width;
            if (iCount == 0) return;

            Size UserDeviceSize = pnlView.Controls[0].Size;

            pnlView.Controls[0].Location = new Point(0, 0);

            int iX = 0;
            int iY = 0;

            for (int i = 1; i < iCount; i++)
            {
                if (iBaseWidth < iX + UserDeviceSize.Width)
                {
                    iY += UserDeviceSize.Height;
                    iX = 0;
                }
                else
                    iX += UserDeviceSize.Width;
                Point iNextLocaition = new Point(iX, iY);
                pnlView.Controls[i].Location = iNextLocaition;
            }
        }

        private void AddControl(CUserDevice cUserDevice)
        {
            try
            {
                UCUserDevice ucDevice = new UCUserDevice();
                ucDevice.UserDevice = cUserDevice;
                ucDevice.SetInitial();

                pnlView.Controls.Add(ucDevice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
    }
}
