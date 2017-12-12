using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Log;

namespace UDM.Flow
{
    public class CFlowItemComparer : IComparer<CFlowItem>
    {
        public int Compare(CFlowItem x, CFlowItem y)
        {
            if (x.TimeNodeS.Count == 0 && y.TimeNodeS.Count == 0)
                return 0;

            if (y.TimeNodeS.Count == 0)
                return -1;

            if (x.TimeNodeS.Count == 0)
                return 1;


            CTimeNode cActNode1 = GetAcitveNode(x.TimeNodeS);
            CTimeNode cActNode2 = GetAcitveNode(y.TimeNodeS);

            if (cActNode1 == null && cActNode2 == null)
                return 0;
            else if (cActNode1 == null)
                return 1;
            else if (cActNode2 == null)
                return -1;

            if (x.TimeNodeS.IsBoolType && y.TimeNodeS.IsBoolType == false)
                return -1;
            else if (x.TimeNodeS.IsBoolType == false && y.TimeNodeS.IsBoolType)
                return 1;

            if (cActNode1.Start == cActNode2.Start)
                return 0;
            else if (cActNode1.Start > cActNode2.Start)
                return 1;
            else
                return -1;
        }

        private CTimeNode GetAcitveNode(CTimeNodeS cNodeS)
        {
            CTimeNode cNode = null;

            for (int i = 0; i < cNodeS.Count; i++)
            {
                if (cNodeS[i].Value != 0)
                {
                    cNode = cNodeS[i];
                    break;
                }
            }

            return cNode;
        }
    }
}
