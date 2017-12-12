using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FTOPApp
{
    public class CThreadQue<T> : IDisposable
    {
 
        protected Queue<T> m_Que = null;
        protected Mutex m_Mutex;

        public int Count { get { return m_Que.Count; } }

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


    }
}
