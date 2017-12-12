using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDMTrackerSimple
{
    public static class CShowWaitForm
    {
        private static FrmWatting m_frmWait = new FrmWatting();
        private static Thread m_thread = null;
        private static bool m_bFinish = false;
        private static bool m_bHold = false;
        private static string m_sLargeText = "";
        private static string m_sSmallText = "";
        private static string m_sProgressText = "";
        private delegate void CloseCallback();
        private delegate void ShowFormCallback(bool bHold);


        public static void ShowForm(string sLargeText, string sSmallText, string sProgressText,bool bHold)
        {
            if (m_thread == null)
            {
                //m_frmWait.UpdateString(sLargeText, sSmallText, sProgressText, bHold);
                m_sLargeText = sLargeText;
                m_sSmallText = sSmallText;
                m_sProgressText = sProgressText;
                m_bHold = bHold;
                m_thread = new Thread(ThreadFunction);
                m_thread.SetApartmentState(ApartmentState.STA);
                m_thread.Start();
            }
            else
            {
                m_bHold = bHold;
                if (m_frmWait != null)
                    m_frmWait.UpdateString(sLargeText, sSmallText, sProgressText, bHold);
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

        public static void UpdateText(string sLargeText, string sSmallText, string sProgressText)
        {
            if (m_frmWait == null) return;
            if (m_thread.IsAlive && m_frmWait.IsOpenForm)
            {
                m_frmWait.UpdateString(sLargeText, sSmallText, sProgressText, m_bHold);
            }
        }

        private static void ThreadFunction()
        {
            //ShowForm(m_bHold);
            FrmWatting frmWait = new FrmWatting();
            frmWait.UpdateString(m_sLargeText, m_sSmallText, m_sProgressText, m_bHold);
            m_frmWait = frmWait;

            if (m_bHold)
                frmWait.ShowDialog();
            else
                frmWait.Show();
            
            while (!m_bFinish)
            {
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(10);
            }
            frmWait.Close();
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
