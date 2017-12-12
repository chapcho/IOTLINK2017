using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SmartEnergyVision
{
    public partial class UCMonoImage : System.Windows.Forms.PictureBox
    {

        #region Member Variables

        protected Bitmap m_imgData = null;
        protected Color m_cImageColor = Color.White;

        #endregion


        #region Initialize/Dispose

        public UCMonoImage()
        {
            InitializeComponent();
        }

        public UCMonoImage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public new Bitmap Image
        {
            get {return m_imgData;}
            set {SetImage(value);}
        }
        public Color ImageColor
        {
            get {return m_cImageColor;}
            set { SetImageColor(value); }
        }

        public ImageLayout ImageLayout
        {
            get {return this.BackgroundImageLayout;}
            set {this.BackgroundImageLayout= value;}
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void SetImage(Bitmap imgData )
        {
            m_imgData = imgData;            
            SetImage();
        }

        private void SetImageColor(Color cImageColor )
        {
            if(m_imgData == null)
                return;

            m_cImageColor = cImageColor;
            SetImage();
        }

        private void SetImage()
        {
            if (m_imgData == null)
            {
                this.BackgroundImage = null;
                this.Refresh();
                return;
            }

            Color cPxOrg;
            Color cPxConv;
            Bitmap imgConvert = new Bitmap(m_imgData);
            for (int i = 0; i < m_imgData.Width; i++)
            {
                for (int j = 0; j < m_imgData.Height; j++)
                {
                    cPxOrg = m_imgData.GetPixel(i, j);
                    cPxConv = Color.FromArgb(cPxOrg.A, m_cImageColor.R, m_cImageColor.G, m_cImageColor.B);
                    imgConvert.SetPixel(i, j, cPxConv);
                }
            }

            this.BackgroundImage = imgConvert;
            this.Refresh();
        }

        #endregion


        #region Event Methods


        #endregion
    }
}
