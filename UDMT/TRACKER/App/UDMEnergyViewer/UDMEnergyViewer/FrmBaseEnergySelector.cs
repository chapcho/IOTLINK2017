using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.UI.TimeChart;
using UDM.Log;
using DevExpress.XtraCharts;

namespace UDMEnergyViewer
{
    public partial class FrmBaseEnergySelector : DevExpress.XtraEditors.XtraForm
    {
        private float m_fBaseEnergy = 0;
        private CMeterUnit m_cMeterUnit = null;
        private CRowItem m_cRowItem = null;
        private bool m_bOK = false;
        private List<double> m_lstValue = new List<double>();
        private List<double> m_lstTime = new List<double>();

        Cursor defCursor;
        bool bdragging = false;
        XYDiagram diagram;
        ConstantLine line;

        #region Initialize/Dispose

        public FrmBaseEnergySelector()
        {
            InitializeComponent();
        }

        public float BaseEnergy
        {
            get { return m_fBaseEnergy; }
            set { m_fBaseEnergy = value; }
        }

        public CMeterUnit MeterUnit
        {
            get { return m_cMeterUnit; }
            set { m_cMeterUnit = value; }
        }

        public CRowItem SelectedItem
        {
            get { return m_cRowItem; }
            set { m_cRowItem = value; }
        }

        public bool IsOK
        {
            get { return m_bOK; }
        }

        #endregion

        private void InitInformation()
        {
            txtEnergyUnit.EditValue = m_cMeterUnit.Key;
        }

        private void InitSeriesTree()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colSeriesItem", "Item");
            cColumn.IsReadOnly = true;
            ucSeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMin", "Min");
            cColumn.IsReadOnly = true;
            ucSeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMax", "Max");
            cColumn.IsReadOnly = true;
            ucSeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesColor", "Color");
            cColumn.IsReadOnly = false;
            cColumn.Editor = exEditorColor;
            ucSeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesScale", "Scale");
            cColumn.IsReadOnly = false;
            ucSeriesTree.ColumnS.Add(cColumn);

            ucSeriesTree.BeginUpdate();
            {
                ucSeriesTree.ItemS.Add(m_cRowItem);
            }
            ucSeriesTree.EndUpdate();
        }

        private void InitChart()
        {
            SeriesPoint cPoint;
            CTimeLogS cUnitLogS = m_cMeterUnit.LogS;
            DateTime dtFrom = cUnitLogS.GetFirstTimeLog().Time;
            DateTime dtTo = cUnitLogS.GetLastLog().Time;

            dtpkFrom.EditValue = dtFrom;
            dtpkTo.EditValue = dtTo;
            
            EnergyChart.Series["Energy Consumption"].Points.Clear();

            for(int i = 0 ; i < cUnitLogS.Count ; i++)
            {
                double X = cUnitLogS[i].Time.Subtract(dtFrom).TotalMilliseconds;
                double Y = (double)cUnitLogS[i].FValue;
                cPoint = new SeriesPoint(X, new double[] { Y });

                EnergyChart.Series["Energy Consumption"].Points.Add(cPoint);
            }
        }

        private void InitConstantLine()
        {
            double dMin = double.Parse(m_cRowItem.Values.GetValue(1).ToString());
            double dMax = double.Parse(m_cRowItem.Values.GetValue(2).ToString());

            double dMiddle = (dMin + dMax) / 2;

            line.AxisValue = m_fBaseEnergy;
            txtBaseEnergy.EditValue = line.AxisValue.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_fBaseEnergy = float.Parse(txtBaseEnergy.EditValue.ToString());
            m_bOK = true;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            m_bOK = false;
            this.Close();
        }

        private void FrmBaseEnergySelector_Load(object sender, EventArgs e)
        {
            this.diagram = EnergyChart.Diagram as XYDiagram;
            this.line = this.diagram.AxisY.ConstantLines.GetConstantLineByName("BaseEnergyLine");

            InitInformation();
            InitSeriesTree();
            InitChart();
            InitConstantLine();
        }

        private void EnergyChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (diagram == null)
                return;

            DiagramCoordinates coords = diagram.PointToDiagram(e.Location);

            if (!coords.IsEmpty && line.AxisValue is double &&
                !coords.NumericalValue.Equals((double)line.AxisValue))
            {
                bdragging = true;
                EnergyChart.Capture = true;
                SetCursor();
            }
        }

        private void EnergyChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (bdragging)
            {
                DiagramCoordinates coords = diagram.PointToDiagram(e.Location);
                line.AxisValue = coords.NumericalValue;
                txtBaseEnergy.EditValue = line.AxisValue;
            }
            else
            {
                bdragging = false;
                EnergyChart.Capture = false;
            }
        }

        private void EnergyChart_MouseUp(object sender, MouseEventArgs e)
        {
            if (diagram == null)
                return;

            if (bdragging && (e.Button & MouseButtons.Left) == 0)
            {
                bdragging = false;
                EnergyChart.Capture = false;
            }

            DiagramCoordinates coords = diagram.PointToDiagram(e.Location);
            if (coords.IsEmpty)
                RestoreCursor();
            else
            {
                //if (bdragging)
                //    line.AxisValue = coords.NumericalArgument;

                if (coords.NumericalValue.Equals((double)line.AxisValue))
                    SetCursor();
                else
                    RestoreCursor();
            }
        }

        private void SetCursor()
        {
            if (defCursor == null)
                defCursor = Cursor.Current;
            Cursor.Current = Cursors.VSplit;
        }

        private void RestoreCursor()
        {
            if (defCursor != null)
            {
                Cursor.Current = defCursor;
                defCursor = null;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}