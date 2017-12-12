using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace UDM.UI.DevGrid
{
    public delegate void UEventHandlerDevGridDoubleClick(object sender, DataRow e);
    public delegate void UEventHandlerDevGridRowCellClick(object sender, DataRow e);
}
