using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiBuild
{
    public partial class UCArchSelector : UserControl
    {
        public event UEventHandlerClick UEventClick = null;

        public UCArchSelector()
        {
            InitializeComponent();
        }

        public UCArchSelector(string imagePath, string sTitle,string sDesc)
        {
            SetImageName(imagePath);
            SetTitle(sTitle);
            SetDesc(sDesc);
        }

        public void SetImageName(String imagePath)
        {
            this.pictureBox1.ImageLocation = imagePath;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string GetImagePath()
        {
            return this.pictureBox1.ImageLocation;
        }

        public void SetTitle(String strTitle)
        {
            this.txtTitle.Text = strTitle;
        }

        public String GetTitle()
        {
            return this.txtTitle.Text;
        }

        public void SetDesc(String strDesc)
        {
            this.textDesc.Text = this.txtTitle.Text + "\r\n" + strDesc;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (UEventClick != null)
                UEventClick(sender.ToString(), "Image");
        }

        private void textDesc_Click(object sender, EventArgs e)
        {
            if (UEventClick != null)
                UEventClick(sender.ToString(), "Desc");
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            if (UEventClick != null)
                UEventClick(sender.ToString(), "Title");
        }
    }
}
