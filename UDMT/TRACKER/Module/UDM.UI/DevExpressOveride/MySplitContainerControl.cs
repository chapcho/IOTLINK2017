using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI
{
    public class MySplitContainerControl : SplitContainerControl
    {
        public MySplitContainerControl() : base() { }
        protected override SplitContainerViewInfo CreateContainerInfo()
        {
            return new MySplitContainerViewInfo(this);

        }
    }

    public class MySplitContainerViewInfo : SplitContainerViewInfo
    {
        private const int MySplitterSize = 10;

        public MySplitContainerViewInfo(SplitContainerControl container) : base(container) { }

        protected override int GetSplitterSize() { return MySplitterSize; }
    }

}
