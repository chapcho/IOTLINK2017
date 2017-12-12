using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDM.General.ThreadEx
{
    public abstract class CThreadBase : IDisposable
    {
        #region Member Variables

        protected bool m_bRun = false;
        protected Thread m_Thread = null;

        #endregion


        #region Initialize/Dispose

        public CThreadBase()
        {

        }

        public void Dispose()
        {
            if (m_Thread != null)
            {
                if (m_Thread.ThreadState != ThreadState.Stopped)
                {
                    m_Thread.Abort();
                }
            }
        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        #endregion


        #region Public Methods

        public bool Run()
        {
            bool bOK = true;

            try
            {
                bOK = BeforeRun();

                if (bOK == false)
                    return false;

                if (m_Thread != null && m_Thread.ThreadState != ThreadState.Stopped)
                {
                    m_Thread.Abort();

                    m_Thread = null;
                }


                m_Thread = new Thread(new ThreadStart(DoThreadWork));

                m_bRun = true;

                m_Thread.Start();

                bOK = AfterRun();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                m_bRun = false;
                bOK = false;
            }

            return bOK;
        }

        public bool Stop()
        {
            bool bOK = false;

            try
            {
                bOK = BeforeStop();

                if (bOK == false)
                    return false;

                m_bRun = false;

                if (m_Thread != null && m_Thread.ThreadState == ThreadState.Running)
                {
                    m_Thread.Join();

                    while (m_Thread.IsAlive)
                    {
                        m_Thread.Abort();
                    }

                    m_Thread = null;
                }

                bOK = AfterStop();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                m_bRun = false;
                bOK = false;
            }

            return bOK;
        }

        #endregion


        #region Private Methods

        protected abstract bool BeforeRun();
        protected abstract bool AfterRun();
        protected abstract bool BeforeStop();
        protected abstract bool AfterStop();
        protected abstract void DoThreadWork();

        #endregion
    }
}
