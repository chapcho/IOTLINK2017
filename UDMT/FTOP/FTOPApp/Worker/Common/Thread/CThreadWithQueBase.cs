﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FTOPApp
{
    public abstract class CThreadWithQueBase<T> : IDisposable
    {

        protected bool m_bRun = false;
        protected Thread m_Thread = null;
        protected CThreadQue<T> m_cQue = null;
        protected int m_iMaxQueSize = 100000;

        public bool IsRunning { get { return m_bRun; } }

        public CThreadWithQueBase()
        {
            m_cQue = new CThreadQue<T>();
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

            if (m_cQue != null)
            {
                m_cQue.Clear();
                m_cQue.Dispose();
            }
        }

        public bool EnQue(T t)
        {
            bool bOK = true;

            if (m_cQue.Count < m_iMaxQueSize)
                m_cQue.EnQue(t);
            else
                bOK = false;

            return bOK;
        }

        public void ClearQue()
        {
            m_cQue.Clear();
        }

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
            bool bOK = true;

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

                m_cQue.Clear();

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

        protected abstract bool BeforeRun();
        protected abstract bool AfterRun();
        protected abstract bool BeforeStop();
        protected abstract bool AfterStop();
        protected abstract void DoThreadWork();



    }
}