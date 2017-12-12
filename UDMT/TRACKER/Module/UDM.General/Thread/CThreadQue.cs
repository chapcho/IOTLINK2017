using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UDM.General.Threading
{
    public class CThreadQue<T> : IDisposable
    {
        #region Member Variables

        protected Queue<T> m_Que = null;
        protected Mutex m_Mutex;

        #endregion


        #region Intialize/Dispose

        public CThreadQue()
        {
            m_Que = new Queue<T>();
            m_Mutex = new Mutex();
        }

        public void Dispose()
        {
            if (m_Mutex != null)
                m_Mutex.Close();

            if (m_Que != null)
                m_Que.Clear();
        }

        #endregion


        #region Public Properties

        public int Count
        {
            get { return m_Que.Count; }
        }

        #endregion


        #region Public Methods

        public void EnQue(T t)
        {
            m_Mutex.WaitOne();

            m_Que.Enqueue(t);

            m_Mutex.ReleaseMutex();
        }

        public T DeQue()
        {
            T t = default(T);

            m_Mutex.WaitOne();

            if (m_Que.Count > 0)
            {
                t = m_Que.Dequeue();
            }

            m_Mutex.ReleaseMutex();

            return t;
        }

        public void Clear()
        {
            if (m_Mutex.SafeWaitHandle.IsClosed) return;
            else
            {
                m_Mutex.WaitOne();

                m_Que.Clear();

                m_Mutex.ReleaseMutex();
            }
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
