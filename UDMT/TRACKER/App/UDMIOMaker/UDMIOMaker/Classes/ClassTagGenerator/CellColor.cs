using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    [Serializable]
    public class CellColor
    {
        protected int _Row;
        protected string _Column;
        protected Color _Color;

        #region Initialize/Dispose

        public CellColor()
        {
            this._Row = -1;
            this._Column = string.Empty;
            this._Color = Color.Empty;
        }

        #endregion

        #region Public Properties

        public int SelectRow
        {
            get { return _Row; }
            set { _Row = value; }
        }

        public string SelectColumn
        {
            get { return _Column; }
            set { _Column = value; }
        }

        public Color SelectColor
        {
            get { return _Color; }
            set { _Color = value; }
        }

        #endregion

    }
}
