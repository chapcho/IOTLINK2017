using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiBuild
{
    public partial class Form1 : Form
    {
        private String[] arrArchSelection = new string[10];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Loading(object sender, EventArgs e)
        {
            // 주택구조 선택 옵션을 생성한다.

            InitializeSelection();
        }

        private void InitializeSelection()
        {
            #region ### 주택구조 선택
            // 주택구조 경량목구조
            this.StructureSelect1A.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180828.jpg");
            this.StructureSelect1A.SetTitle("경량목구조");
            this.StructureSelect1A.SetDesc("규격 : \r\n경량의 목재를 사용하는 방식으로 기둥역할을 하는 스터드가 건축물의 하중을 분산하여 견디는 벽체중심구조 \r\n(ex 북미식 목조주택)");
            this.StructureSelect1A.UEventClick += StructureSelect1_UEventClick;

            // 주택구조 스틸구조
            this.StructureSelect1B.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180828_3.jpg");
            this.StructureSelect1B.SetTitle("스틸구조");
            this.StructureSelect1B.SetDesc("스틸구조는 단일구조이므로, 2X8 규격으로 산출되지 않음\r\n\r\n규격 :\r\n 기둥. 서가래.장선등의 구조재를 아연강관으로 규격화 하여 시공\r\n 첨부) 구조외에 시공법은 목조주택과 동일 *중요 * 스틸구조는 단일구조이므로,2X8 규격으로 산출이 안됨을 알려드립니다.!");
            this.StructureSelect1B.UEventClick += StructureSelect2_UEventClick;
            #endregion

            #region ### 주택구조재 선택
            // 주택구조재 2X6
            this.StructureSelect2A.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.jpg");
            this.StructureSelect2A.SetTitle("2X6");
            this.StructureSelect2A.SetDesc("2X6");
            this.StructureSelect2A.UEventClick += StructureSelect3_UEventClick;

            this.StructureSelect2B.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.jpg");
            this.StructureSelect2B.SetTitle("2X8");
            this.StructureSelect2B.SetDesc("2X8");
            this.StructureSelect2B.UEventClick += StructureSelect4_UEventClick;
            #endregion

            #region ## 층고 선택
            this.StructureSelect3A.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.png");
            this.StructureSelect3A.SetTitle("2,400<1층>");
            this.StructureSelect3A.SetDesc("2미터40센치미터(1층기준)");
            this.StructureSelect3A.UEventClick += StructureSelect3A_UEventClick;

            this.StructureSelect3B.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.png");
            this.StructureSelect3B.SetTitle("2,700<1층>");
            this.StructureSelect3B.SetDesc("2미터70센치미터(1층기준)");
            this.StructureSelect3B.UEventClick += StructureSelect3B_UEventClick; ;

            this.StructureSelect3C.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.png");
            this.StructureSelect3C.SetTitle("3,000<1층>");
            this.StructureSelect3C.SetDesc("3미터(1층기준)");
            this.StructureSelect3C.UEventClick += StructureSelect3C_UEventClick; ;
            #endregion

            #region ## 주택스타일
            this.StructureSelect4A.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180828_00.jpg");
            this.StructureSelect4A.SetTitle("모던스타일");
            this.StructureSelect4A.SetDesc("모던 스타일은 선과 면이 명확한 건축양식을 말합니다. 현대적인 선과 직사각형 또는 정사각형만으로 구성함으로써 심플한 디자인의 멋을 느낄 수 있습니다.");
            this.StructureSelect4A.UEventClick += StructureSelect4A_UEventClick;

            this.StructureSelect4B.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180828_01.bmp");
            this.StructureSelect4B.SetTitle("클래식스타일");
            this.StructureSelect4B.SetDesc("클래식에는 고전적,모범적,전통적,고상한 등의 의미가 있습니다. 유럽의 고전적인 분위기가 돋보이는 것으로 바로크,로코코,신고전 양식에서 보여지는 여유와 전통미가 느껴지는 주택 스타일입니다.");
            this.StructureSelect4B.UEventClick += StructureSelect4B_UEventClick;

            this.StructureSelect4C.SetImageName("D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180828_03.jpg");
            this.StructureSelect4C.SetTitle("모임스타일");
            this.StructureSelect4C.SetDesc("모임지붕을 얹는 컨셉으로 동양적인 간결한 여백의 미를 중요시하는 단정한 이미지 스타일을 말합니다.");
            this.StructureSelect4C.UEventClick += StructureSelect4C_UEventClick;
            #endregion
        }

        private void StructureSelect4C_UEventClick(string sender, string option)
        {
            this.picSel4.ImageLocation = this.StructureSelect4C.GetImagePath();
            this.picSel4.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(3, "주택스타일:" + this.StructureSelect4C.GetTitle());
        }

        private void StructureSelect4B_UEventClick(string sender, string option)
        {
            this.picSel4.ImageLocation = this.StructureSelect4B.GetImagePath();
            this.picSel4.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(3, "주택스타일:" + this.StructureSelect4B.GetTitle());
        }

        private void StructureSelect4A_UEventClick(string sender, string option)
        {
            this.picSel4.ImageLocation = this.StructureSelect4A.GetImagePath();
            this.picSel4.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(3, "주택스타일:" + this.StructureSelect4A.GetTitle());
        }

        private void StructureSelect3C_UEventClick(string sender, string option)
        {
            this.picSel3.ImageLocation = "D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20190210_01.jpg";
            this.picSel3.SizeMode = PictureBoxSizeMode.AutoSize;
            RegenerateSelectionState(2, "층고:" + this.StructureSelect3C.GetTitle());
        }

        private void StructureSelect3B_UEventClick(string sender, string option)
        {
            this.picSel3.ImageLocation = "D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20190210_01.jpg";
            this.picSel3.SizeMode = PictureBoxSizeMode.AutoSize;
            RegenerateSelectionState(2, "층고:" + this.StructureSelect3B.GetTitle());
        }

        private void StructureSelect3A_UEventClick(string sender, string option)
        {
            this.picSel3.ImageLocation = "D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20190210_01.jpg";
            this.picSel3.SizeMode = PictureBoxSizeMode.AutoSize;
            RegenerateSelectionState(2, "층고:" + this.StructureSelect3A.GetTitle());
        }

        private void StructureSelect4_UEventClick(string sender, string option)
        {
            this.picSel2.ImageLocation = "D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.png";
            this.picSel2.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(1, "구조재규격:" + this.StructureSelect2B.GetTitle());
        }

        private void StructureSelect3_UEventClick(string sender, string option)
        {
            this.picSel2.ImageLocation = "D:\\chapcho\\IOTLink\\GitRoot\\ArchBuild\\ArchiBuild\\ArchiBuild\\image\\20180430.png";
            this.picSel2.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(1, "구조재규격:" + this.StructureSelect2A.GetTitle());
        }

        private void StructureSelect2_UEventClick(string sender, string option)
        {
            this.picSel1.ImageLocation = this.StructureSelect1B.GetImagePath();
            this.picSel1.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(0, "구조:" + this.StructureSelect1B.GetTitle());
        }

        private void StructureSelect1_UEventClick(string sender, string option)
        {
            this.picSel1.ImageLocation = this.StructureSelect1A.GetImagePath();
            this.picSel1.SizeMode = PictureBoxSizeMode.StretchImage;
            RegenerateSelectionState(0, "구조:"+this.StructureSelect1A.GetTitle());
        }

        private void RegenerateSelectionState(int index, string msg)
        {
            String selectionMessage = "";
            for(int i = index + 1; i < arrArchSelection.Length;i++)
            {
                if(!string.IsNullOrEmpty(arrArchSelection[i]))
                {
                    // DialogResult dr = MessageBox.Show(arrArchSelection[i] + " >> 다시 선택하시겠습니까?", "확인", MessageBoxButtons.OKCancel);
                    // if(dr == DialogResult.OK)
                    {
                        arrArchSelection[i] = "";
                    }
                }
                
            }
            arrArchSelection[index] = msg;

            for(int i = 0; i < arrArchSelection.Length && !string.IsNullOrEmpty(arrArchSelection[i]);i++)
            {
                if (i > 0) selectionMessage += " >> ";
                selectionMessage += arrArchSelection[i];
            }
            this.lblSelection.Text = selectionMessage;
        }
    }
}
