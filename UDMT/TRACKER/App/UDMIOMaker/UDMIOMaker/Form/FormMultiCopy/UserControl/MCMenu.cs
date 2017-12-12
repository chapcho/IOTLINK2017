using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Event.EventMultiCopy;

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCMenu : DevExpress.XtraEditors.XtraUserControl
    {

        protected MCOP _Operation;
        protected MCKey _Key;
        protected MCKeyList _KeyList;
        protected CMessage _cMessage = new CMessage();

        public event delMultiCopyRunorStop EventRunAfter;
        public event delMultiCopyRunorStop EventStopAfter;

        #region Initialize/Dispose

        public MCMenu()
        {
            InitializeComponent();

            this.Load += Control_MultiCopy_Main_Load;
            this.btnRun.ElementClick += btnRun_ElementClick;
            this.btnStop.ElementClick += btnStop_ElementClick;
        }

        void btnStop_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            EventRunAfter();
        }

        void btnRun_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            EventStopAfter();
        }

        void Control_MultiCopy_Main_Load(object sender, EventArgs e)
        {
            
            _Key = new MCKey(this);
            _KeyList = new MCKeyList(_Key);

            _Operation = new MCOP(this, _KeyList);

            dockPanel1.Controls.Add(_KeyList);
            dockPanel2.Controls.Add(_Key);
            this.Controls.Add(_Operation);

            _KeyList.Dock = DockStyle.Fill;
            _Key.Dock = DockStyle.Fill;
            _Operation.Dock = DockStyle.Fill;

        }


        #endregion

        #region Public Methods


        #region Run Menu

        #endregion

        #endregion

    }
}
