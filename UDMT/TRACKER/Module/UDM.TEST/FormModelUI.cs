using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UDM.Common;
using UDM.Converter;
using UDM.General;
using UDM.General.Csv;
using UDM.Model;
using UDM.UDLImport;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using UDM.ModelTemplate.Cylinder;
using UDM.ModelTemplate.Robot;
using UDM.General.Serialize;
using DevExpress.XtraTreeList.Nodes;
using SharpSimulator.Core.Xmls;
using SharpCommon.Utilities;
using SharpSimulator.Core.MVCs;


namespace UDM.TEST
{
    public partial class FormModelUI : Form
    {

        private CSimModel m_cSimModel = new CSimModel("New Project");
        private GridHitInfo _3DTaskGridInfo = null;

        public FormModelUI()
        {
            InitializeComponent();

            exGridSymbol.DragOver += exGridSymbol_DragOver;
            exGridSymbol.MouseMove += exGridSymbol_MouseMove;
            exGridSymbol.MouseDown += exGridSymbol_MouseDown;

            exGridTask.DragOver += exGridTask_DragOver;
            exGridTask.MouseMove += exGridTask_MouseMove;
            exGridTask.MouseDown += exGridTask_MouseDown;
            exGridViewTask.RowCellClick += exGridViewTask_RowCellClick;

            propertyModel.CellValueChanged += propertyModel_CellValueChanged;
            groupControl1.CustomButtonClick += groupControl1_CustomButtonClick;
            groupControl2.CustomButtonClick += groupControl2_CustomButtonClick;
            splitContainerControl4.Resize += splitContainerControl4_Resize;

            xtraTabControl2.CustomHeaderButtonClick += xtraTabControl2_CustomHeaderButtonClick;
        }

        void exGridViewTask_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            
        }

        void splitContainerControl4_Resize(object sender, EventArgs e)
        {
            double HeightSize = splitContainerControl4.Height * 0.8;
            splitContainerControl4.SplitterPosition = (int)HeightSize;
        }

        void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if ("Open" == e.Button.Properties.Caption)
                OpenXml();

            else if ("Save" == e.Button.Properties.Caption)
                SaveXml();
        }

        void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            PropertyBinding();
        }

        void propertyModel_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {

            //if((bool)e.Value == true)
            //{
            //    ucModelTree.UCTreeList.ExpandAll();
            //    return;
            //}


            ucModelTree.Clear();
            ucModelTree.SimModel = m_cSimModel;
            ucModelTree.ReloadTree();          
        }

        void ucModelTree_UCEventFocusedModeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            CSimDevice CurrentDevice = e.Node.Tag as CSimDevice;

            propertyModel.SelectedObject = CurrentDevice;
        }

        void exGridTask_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = exGridViewTask.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                _3DTaskGridInfo = hitInfo;
        }

        void exGridTask_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _3DTaskGridInfo != null && _3DTaskGridInfo.InDataRow)
            {

                List<string> lst3dTask = new List<string>();
                foreach (int iRow in exGridViewTask.GetSelectedRows())
                {
                    string task = (string)exGridViewTask.GetRowCellValue(iRow, "UniqueName");
                    lst3dTask.Add(task);
                }

                exGridViewTask.GridControl.DoDragDrop(lst3dTask, DragDropEffects.All);

                _3DTaskGridInfo = null;
            }
        }

        void exGridTask_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void exGridSymbol_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = exGridViewSymbol.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                _3DTaskGridInfo = hitInfo;
        }

        void exGridSymbol_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _3DTaskGridInfo != null && _3DTaskGridInfo.InDataRow)
            {

                List<string> lst3dTask = new List<string>();
                foreach (int iRow in exGridViewSymbol.GetSelectedRows())
                {
                    string task = (string)exGridViewSymbol.GetRowCellValue(iRow, "Address");
                    lst3dTask.Add(task);
                }

                exGridViewSymbol.GridControl.DoDragDrop(lst3dTask, DragDropEffects.All);

                _3DTaskGridInfo = null;
            }
        }

        void exGridSymbol_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #region Event Mehtods

        private void OpenXml()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files (*.iomx)|*.iomx|All files (*.*)|*.*";

            ofd.ShowDialog();
            if (ofd.FileName == null)
                return;

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(ofd.FileName);

            OpenXMltoTextbox(XmlDoc, ofd.FileName);
        }

        private void SaveXml()
        {
            CSimModel cSimModel = m_cSimModel;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML files (*.iomx)|*.iomx|All files (*.*)|*.*";
            sfd.ShowDialog();
            if (sfd.FileName == null)
                return;

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            SimXmlWriter writer = SimXmlWriter.Create(sfd.FileName, null, null, null, null, null, null);

            XmlDoc.AppendChild(cSimModel.ToXml(writer));

            XmlDoc.Save(sfd.FileName);
        }

        private void PropertyBinding()
        {
            object[] objects = new object[m_cSimModel.lstSimDevice.Count];

            //foreach (CSimDevice Device in m_cSimModel.lstSimDevice)

            for (int i = 0; i < m_cSimModel.lstSimDevice.Count;i++ )
            {
                objects[i] = m_cSimModel.lstSimDevice[i];
            }

            propertyModel.SelectedObjects = objects;
            
        }

        private void OpenXMltoTextbox(XmlDocument DXML, string path)
        {
            XDocument doc = XDocument.Parse(DXML.InnerXml);

            richTextBox1.Text = doc.ToString();

            string Token = "(<|>)";
            string UserToken = "(Model|Device|Logic|Track|SimTask|Label)";
            Regex rex = new Regex(Token);
            Regex Userrex = new Regex(UserToken);

            MatchCollection mc = rex.Matches(richTextBox1.Text);
            MatchCollection userMc = Userrex.Matches(richTextBox1.Text);
            int StartCursorPosition = richTextBox1.SelectionStart;

            foreach(Match m in mc)
            {
                int startIndex = m.Index;
                int stopIndex = m.Length;

                richTextBox1.Select(startIndex, stopIndex);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.SelectionStart = StartCursorPosition;
                richTextBox1.SelectionColor = Color.DarkBlue;
            }
            foreach (Match user in userMc)
            {
                int startIndex = user.Index;
                int stopIndex = user.Length;

                richTextBox1.Select(startIndex, stopIndex);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.SelectionStart = StartCursorPosition;
                richTextBox1.SelectionColor = Color.DarkBlue;
            }

        }

        private void button_Import_PLC_Click(object sender, EventArgs e)
        {
            DataTable dbSymbol = new DataTable();

            dbSymbol.Columns.Add("Address");
            dbSymbol.Columns.Add("Name");

            DataTable dbTask = new DataTable();

            dbTask.Columns.Add("UniqueName");
            dbTask.Columns.Add("Name");
            dbTask.Columns.Add("TaskType");

            InputData(dbSymbol, dbTask);
        }

        private void InputData(DataTable symbol, DataTable task)
        {
            for(int i=0; i< 16 ; i++)
            {
                DataRow drSymbol = symbol.NewRow();
                drSymbol["Name"] = "Test Symbol Input : " + i;
                drSymbol["Address"] = "X" + i;

                symbol.Rows.Add(drSymbol);
            }

            for (int i = 0; i < 6; i++)
            {
                DataRow drSymbol = symbol.NewRow();
                drSymbol["Name"] = "Test Symbol Output : " + i;
                drSymbol["Address"] = "Y" + i;

                symbol.Rows.Add(drSymbol);
            }

            for (int i = 0; i < 20; i++)
            {
                DataRow drtask = task.NewRow();
                drtask["UniqueName"] = "/worker0" + i + ":j24:Right_Arm_90";
                drtask["Name"] = "Right_Arm_90";
                drtask["TaskType"] = "JointMotion";

                task.Rows.Add(drtask);
            }

            for (int i = 0; i < 6; i++)
            {
                DataRow drtask = task.NewRow();
                drtask["UniqueName"] = "Attach" + i;
                drtask["Name"] = "Attach or Detach";
                drtask["TaskType"] = "Add Motion";

                task.Rows.Add(drtask);
            }

            for (int i = 0; i < 6; i++)
            {
                DataRow drtask = task.NewRow();
                drtask["UniqueName"] = "Detach" + i ;
                drtask["Name"] = "Attach or Detach";
                drtask["TaskType"] = "Add Motion";

                task.Rows.Add(drtask);
            }

            exGridTask.DataSource = task;
            exGridSymbol.DataSource = symbol;
        }

        private void button_Logic_Click(object sender, EventArgs e)
        {
            try
            {
                ucLibraryTree.CreateTree();

                TreeListNode trnGroup = null;
                trnGroup = ucLibraryTree.AddGroup("Cylinder");
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder1)).Logic);
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder2)).Logic);
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder3)).Logic);
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder4)).Logic);
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Single, EMCylinderSub.SolenoidCylinder1)).Logic);
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelCylinder(EMCylinder.Single, EMCylinderSub.SolenoidCylinder1)).Logic);

                trnGroup = ucLibraryTree.AddGroup("Robot");
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelRobot(EMRobot.Welding, EMRobotSub.WorkStep1).Logic));
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelRobot(EMRobot.Welding, EMRobotSub.WorkStep2).Logic));
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelRobot(EMRobot.Handling, EMRobotSub.WorkStep1).Logic));
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelRobot(EMRobot.Handling, EMRobotSub.WorkStep2).Logic));
                ucLibraryTree.AddGroupSub(trnGroup, (new CModelRobot(EMRobot.Handling, EMRobotSub.WorkStep3).Logic));

             //  trnGroup = ucLibraryTree.AddGroup("CarType");
             //  ucLibraryTree.AddGroupSub(trnGroup, "CarType_1", new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder1));
             //  ucLibraryTree.AddGroupSub(trnGroup, "CarType_2", new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder2));
             //  ucLibraryTree.AddGroupSub(trnGroup, "CarType_3", new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder3));
             //  ucLibraryTree.AddGroupSub(trnGroup, "CarType_4", new CModelCylinder(EMCylinder.Multi, EMCylinderSub.SolenoidCylinder4));
             //
             //  trnGroup = ucLibraryTree.AddGroup("Sensor");
             //  ucLibraryTree.AddGroupSub(trnGroup, "SensorNormal", new CModelRobot(EMRobot.Welding, EMRobotSub.WorkStep1));
             //  ucLibraryTree.AddGroupSub(trnGroup, "SensorInverse",new CModelRobot(EMRobot.Welding, EMRobotSub.WorkStep2));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void button_CreateDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucModelTree.SimModel == null)
                {
                    MessageBox.Show("Please create Project!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ucLibraryTree.NodeFocused == null || !(ucLibraryTree.NodeFocused.Tag is CLogic))
                {
                    MessageBox.Show("Please select library!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CLogic cLogic = ucLibraryTree.NodeFocused.Tag as CLogic;
                List<CSimDevice> lstDevice = new List<CSimDevice>();
                foreach (string sDevice in textBox_Device.Lines)
                {
                    if (sDevice == string.Empty)
                        continue;

                    CSimDevice cSimDevice = new CSimDevice(sDevice);
                    cSimDevice.Logic = cLogic.Clone() as CLogic;
                    cSimDevice.UpdateAllowTrack();

                    lstDevice.Add(cSimDevice);
                }

                ucModelTree.CreateDeive(lstDevice);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            if (ucModelTree.SimModel != null && DialogResult.No == MessageBox.Show("Clear All Device ??", "UDM Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            ucModelTree.Clear();

            m_cSimModel = new CSimModel("New Project");

            ucModelTree.SimModel = m_cSimModel;
            ucModelTree.ReloadTree();
            ucModelTree.UEventUpdateDevice += ucModelTree_UEventUpdateDevice;
        }

        private void ucModelTree_UEventUpdateDevice(object sender, CSimDevice cSimDevice)
        {

        }

        private void button_CreateDeviceGrid_Click(object sender, EventArgs e)
        {
            if (ucModelTree.SimModel == null)
            {
                MessageBox.Show("Please create Project!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ucLibraryTree.NodeFocused == null || !(ucLibraryTree.NodeFocused.Tag is CLogic))
            {
                MessageBox.Show("Please select library!!", "UDM Solution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CLogic cLogic = ucLibraryTree.NodeFocused.Tag as CLogic;
            List<CSimDevice> lstDevice = new List<CSimDevice>();
            CTag cTag = null;

            //foreach (int iRow in ucModelGrid.GridView.GetSelectedRows())
            //{
            //    cTag = (CTag)ucModelGrid.GridView.GetRow(iRow);

            //    if (cTag == null)
            //        continue;

            //    string sDeviceName = cTag.Name;
            //    if (cTag.Name.Contains(' '))
            //        sDeviceName = sDeviceName.Replace(cTag.Name.Split(' ')[cTag.Name.Split(' ').Length - 1], string.Empty).TrimEnd(' ');
            //    else if (cTag.Name.Contains('_'))
            //        sDeviceName = sDeviceName.Replace(cTag.Name.Split('_')[cTag.Name.Split('_').Length - 1], string.Empty).TrimEnd('_');

            //    CSimDevice cSimDevice = new CSimDevice(sDeviceName);
            //    cSimDevice.Logic = cLogic.Clone() as CLogic;
            //    AutoCylinderMapping(cSimDevice, cTag);
            //    cSimDevice.UpdateAllowTrack();


            //    lstDevice.Add(cSimDevice);
            //}

            ucModelTree.CreateDeive(lstDevice);
        }


        #endregion


        #region Private Methods

        private bool AutoCylinderMapping(CSimDevice cSimDevice, CTag cTag)
        {
            //if (cTag.DataType != EMDataType.Bool)
            //    return false;
            //if (!cTag.Address.Contains('.'))
            //    return false;

            //string sHead = cTag.Address.Substring(0, 1);
            //int nByte = Convert.ToInt32(cTag.Address.Replace(sHead, string.Empty).Split('.')[0]);
            //int nBitNext = Convert.ToInt32(cTag.Address.Split('.')[1]) + 1;
            //if (nBitNext % 8 == 0)
            //    nByte++;

            //string sAddress = string.Format("{0}{1}.{2}", sHead, nByte, nBitNext % 8);

            //CTag cTagNext = null;
            //foreach (CTag cTagTemp in m_cSimModel.TagS.Values)
            //{
            //    if (cTagTemp.Address == sAddress)
            //    {
            //        cTagNext = cTagTemp;
            //        break;
            //    }
            //}

            //CTrack cTrackADV = cSimDevice.Logic.TrackS.First().Value;
            //CTrack cTrackRTN = cSimDevice.Logic.TrackS.Last().Value;

            //if (cTag != null) cTrackADV.Fire.SetTag(cTag);
            //if (cTagNext != null) cTrackRTN.Fire.SetTag(cTagNext);

            return true;
        }

        #endregion

        #region  Add

        void xtraTabControl2_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            if (ucModelTree.UCTreeList.Columns[4].Visible == false)
                ucModelTree.UCTreeList.Columns[4].Visible = true;
            else
                ucModelTree.UCTreeList.Columns[4].Visible = false;
            
        }

        #endregion

    }

}