using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;

namespace UDM.Ladder
{
    public partial class FrmLadderDiagram : Form
    {
        public EditorBrand Brand { get { return ucLadderStep.Brand; } set { ucLadderStep.Brand = value; } }
        public CStep Step { get { return ucLadderStep.Step; } set { ucLadderStep.Step = value; } }
        public CTimeLogS SymbolLogS { get { return ucLadderStep.SymbolLogS; } set { ucLadderStep.SymbolLogS = value; } }
        public Dictionary<ITagComposable, CLadderCell> ItemLadderCell { get { return ucLadderStep.ItemLadderCell; } }
        public bool AutoSize { get { return ucLadderStep.AutoSizeParent; } set { ucLadderStep.AutoSizeParent = value; } }

        public FrmLadderDiagram()
        {
            InitializeComponent();
        }

        public FrmLadderDiagram(CStep cStep, CTimeLogS cSymbolLogS, EditorBrand eBrand)
            : this(cStep,cSymbolLogS)
        {
            ucLadderStep.Brand = eBrand;
            ucLadderStep.AutoSizeParent = true;
        }

        public FrmLadderDiagram(CStep cStep, CTimeLogS cSymbolLogS)
            : this()
        {
            ucLadderStep.Step = cStep;
            ucLadderStep.SymbolLogS = cSymbolLogS;
        }
    }
}