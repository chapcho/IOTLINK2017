using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDMOptimizer
{
    public static class CShowMessage
    {
        private static FrmMessageBox m_frmMessage = new FrmMessageBox();
        private static Thread m_thread = null;
        private static bool m_bFinish = false;
        private static bool m_bHold = false;
        private static string m_sLargeText = "";
        private static string m_sSmallText = "";
        private delegate void CloseCallback();
        private delegate void ShowFormCallback(bool bHold);


        public static void ShowForm(string sLargeText, string sSmallText, bool bHold = true)
        {
            if (m_thread == null)
            {
                //m_frmWait.UpdateString(sLargeText, sSmallText, sProgressText, bHold);
                m_sLargeText = sLargeText;
                m_sSmallText = sSmallText;
                m_bHold = bHold;
                m_thread = new Thread(ThreadFunction);
                m_thread.SetApartmentState(ApartmentState.STA);
                m_thread.Start();
            }
            else
            {
                m_bHold = bHold;
                if (m_frmMessage != null)
                    m_frmMessage.UpdateString(sLargeText, sSmallText, bHold);
            }

        }

        public static void CloseForm()
        {
            if (m_thread.IsAlive)
            {
                try
                {
                    FrmWatting frmWait = (FrmWatting)IsFormOpened(typeof(FrmWatting));

                    if (frmWait.InvokeRequired)
                    {
                        CloseCallback cbClose = new CloseCallback(CloseForm);
                        frmWait.Invoke(cbClose);
                    }
                    else
                    {
                        frmWait.Close();
                        frmWait.Dispose();
                        frmWait = null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                m_bFinish = true;
                m_thread = null;
                
            }
        }

        public static void UpdateText(string sLargeText, string sSmallText)
        {
            if (m_frmMessage == null) return;
            if (m_thread.IsAlive && m_frmMessage.IsOpenForm)
            {
                m_frmMessage.UpdateString(sLargeText, sSmallText, m_bHold);
            }
        }

        private static void ThreadFunction()
        {
            //ShowForm(m_bHold);
            FrmMessageBox frmMessage = new FrmMessageBox();
            frmMessage.UpdateString(m_sLargeText, m_sSmallText, m_bHold);
            m_frmMessage = frmMessage;
            //frmMessage.
            if (m_bHold)
                frmMessage.ShowDialog();
            else
                frmMessage.Show();
            
            while (!m_bFinish)
            {
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(10);
            }
            frmMessage.Close();
            m_bFinish = false;
        }

        private static Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
        }

    }
}
