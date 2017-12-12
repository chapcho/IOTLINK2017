using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME.DataStruct
{
    // PLCContact 클래스
    public class PLCContact<T>
    {
        private List<PLCContact<T>> _neighbers;
        private List<int> _weights;
        private int _step;

        public T Data { get; set; }

        public PLCContact()
        {
        }

        public PLCContact(T value, int step)
        {
            this.Data = value;
            this._step = step;
        }

        public int Step
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
            }
        }

        public List<PLCContact<T>> Neighbers
        {
            get
            {
                _neighbers = _neighbers ?? new List<PLCContact<T>>();
                return _neighbers;
            }
        }

        public List<int> Weights
        {
            get
            {
                _weights = _weights ?? new List<int>();
                return _weights;
            }
        }
    }

    // PLCNode 클래스
    public class PLCNode<T>
    {
        public List<PLCContact<T>> _nodeList;

        public PLCNode()
        {
            _nodeList = new List<PLCContact<T>>();
        }

        public PLCContact<T> AddNode(T data,int step)
        {
            PLCContact<T> n = new PLCContact<T>(data,step);
            _nodeList.Add(n);
            return n;
        }

        public PLCContact<T> AddNode(PLCContact<T> node)
        {
            _nodeList.Add(node);
            return node;
        }

        public void AddEdge(PLCContact<T> from, PLCContact<T> to, int weight)
        {
            from.Neighbers.Add(to);
            from.Weights.Add(weight);
            to.Weights.Add(weight);
        }

        internal void DebugPrintLinks()
        {
            foreach (PLCContact<T> graphNode in _nodeList)
            {
                if (graphNode.Weights[0] == 0) Console.Write(graphNode.Data);
                foreach (var n in graphNode.Neighbers)
                {
                    string s = graphNode.Data + " - " + n.Data;
                    Console.WriteLine(s);
                }
            }
        }
    }
}
