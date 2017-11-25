using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTL.Common.Util
{
    public partial class SplashWnd : Form
    {

        /// 
        /// 스플래쉬 닫을 때 true로 세팅하는 값
        /// 출처: http://withsoju.tistory.com/601
        private static bool isCloseCall = false;
        /// 
        /// 값이 true 이면 창이 닫히지 않음.
        /// 
        private bool cannotClose = true;

        public SplashWnd()
        {
            InitializeComponent();

            // this.Opacity = 0.7f;

            Sender = Application.CompanyName.ToString();
            Message = "로딩중...";
        }

        public string Sender
        {
            get { return this.lblCaller.Text; }
            set { this.lblCaller.Text = value; }
        }

        public string Message
        {
            get { return this.lblWaitMessage.Text; }
            set { this.lblWaitMessage.Text = value; }
        }

        /// 
        /// 사용자가 ALT+F4 등의 키로 닫는 걸 방지
        /// 
        /// 
        protected override void OnClosing(CancelEventArgs e)
        {
            if (cannotClose)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        /// 
        /// 스플래쉬 띄우기
        /// 
        public static void SplashShow()
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
            Control mainWindow = Control.FromHandle(process.MainWindowHandle);

            isCloseCall = false;
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadShowWait));
            thread.Start(new object[] { mainWindow });

            
        }

        /// 
        /// 스플래쉬 닫기
        /// 
        /// 스플래쉬를 닫은 후 맨 앞으로 가져올 폼
        public static void SplashClose(Form formFront)
        {
            //Thread의 loop 를 멈춘다.
            isCloseCall = true;

            //주어진 폼을 맨 앞으로
            SetForegroundWindow(formFront.Handle);
            formFront.BringToFront();
        }

        /// 
        /// 이 메서드를 호출해야만 창이 닫힌다.
        /// 
        public void CloseForce()
        {
            //OnClose 에서 닫힐 수 있도록 세팅
            cannotClose = false;
            this.Close();
        }

        /// 
        /// 윈도우를 맨 앞으로 가져오기 위한 Win32 API 메서드
        /// 
        /// 윈도우 핸들
        /// 
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// 
        /// 스플래쉬를 띄우기 위한 Parameterized Thread Method
        /// 
        /// 메인 윈도(위치를 잡기 위해)
        private static void ThreadShowWait(object obj)
        {
            object[] objParam = obj as object[];
            SplashWnd splashWnd = new SplashWnd();
            Control mainWindow = objParam[0] as Control;

            if (mainWindow != null)
            {
                //메인 윈도를 알 때에는 메인 윈도의 중앙
                splashWnd.StartPosition = FormStartPosition.Manual;
                splashWnd.Location = new Point(
                    mainWindow.Location.X + (mainWindow.Width - splashWnd.Width) / 2,
                    mainWindow.Location.Y + (mainWindow.Height - splashWnd.Height) / 2);
            }
            else
            {
                //메인 윈도를 모를 땐 스크린 중앙
                splashWnd.StartPosition = FormStartPosition.CenterScreen;
            }

            splashWnd.Show();
            splashWnd.BringToFront();

            //닫기 명령이 올 때 가지 0.01 초 단위로 루프
            while (!isCloseCall)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

            //닫는다.
            if (splashWnd != null)
            {
                splashWnd.CloseForce();
                splashWnd = null;
            }
        }

    }
}
