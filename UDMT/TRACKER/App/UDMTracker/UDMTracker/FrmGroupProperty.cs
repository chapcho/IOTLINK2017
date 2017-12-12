using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Project;

namespace UDMTracker
{
    public partial class FrmGroupProperty : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        protected CGroup m_cGroup = null;		

        #endregion


        #region Initialize/Dispose

        public FrmGroupProperty()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return ucGroupProperty.Editable; }
            set { ucGroupProperty.Editable = value; }
        }

        public CGroup Group
        {
            get { return m_cGroup; }
            set { m_cGroup = value;  }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

		protected CGroup CreateViewGroupProperty(CGroup cGroup)
		{
			CGroup cGroupView = new CGroup();
			if (cGroup == null)
				return cGroupView;

			cGroupView.Key = cGroup.Key;
			cGroupView.Name = cGroup.Name;
			cGroupView.CycleStartConditionS.AddRange(cGroup.CycleStartConditionS);
			cGroupView.CycleEndConditionS.AddRange(cGroup.CycleEndConditionS);
			cGroupView.Recipe = cGroup.Recipe;
			cGroupView.Product = cGroup.Product;
			cGroupView.MaxCycleTime = cGroup.MaxCycleTime;
            cGroupView.KeySymbolS = cGroup.KeySymbolS;

			return cGroupView;
		}

		protected void ApplyGroupProperty(CGroup cGroupView)
		{
			if (m_cGroup == null || cGroupView == null)
				return;

			m_cGroup.CycleStartConditionS.Clear();
			m_cGroup.CycleEndConditionS.Clear();
			m_cGroup.CycleStartConditionS.AddRange(cGroupView.CycleStartConditionS);
			m_cGroup.CycleEndConditionS.AddRange(cGroupView.CycleEndConditionS);
			m_cGroup.Recipe = cGroupView.Recipe;
			m_cGroup.Product = cGroupView.Product;
			m_cGroup.MaxCycleTime = cGroupView.MaxCycleTime;
		}

        #endregion


        #region Event Methods

        private void FrmGroupProperty_Load(object sender, EventArgs e)
        {
			CGroup cGroupView = CreateViewGroupProperty(m_cGroup);
			ucGroupProperty.Group = cGroupView;
			ucGroupProperty.ShowProperty();
        }

		private void btnOK_Click(object sender, EventArgs e)
		{
			ApplyGroupProperty(ucGroupProperty.Group);

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        #endregion
    }
}