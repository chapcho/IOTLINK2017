using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTL.Common.Remote;

namespace IOTL.WCF.EventHandler
{
    public class MyServiceCallBack : ServiceCallBack, IMyServiceCallBack
    {

        #region Member Variables

        public event UEventHandlerCommStart UEventReceiveCommStart;
        public event UEventHandlerCommStop UEventReceiveCommStop;
        public event UEventHandlerTagList UEventReceiveTagList;
        public event UEventHandlerEmergTagList UEventReceiveEmergTagList;
        public event UEventHandlerCollectorList UEventReceiveCollectorList;
        public event UEventHandlerRecipeTagList UEventReceiveRecipeTagList;
        public event UEventHandlerAddTagList UEventReceiveAddTagList;
        public event UEventHandlerRemoveTagList UEventReceiveRemoveTagList;

        public event UEventHandlerProjectinfo UEventReceiveProjectInfo;
        public event UEventHandlerLadderViewTagList UEventReceiveLadderViewTagList;

        #endregion


        #region Intialize/Dispose

        public MyServiceCallBack()
        {

        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        /// <summary>
        /// Server -> Client
        /// </summary>
        /// <param name="saData"></param>
        public void ReceiveCommStart(string[] saData)
        {
            if (UEventReceiveCommStart != null)
                UEventReceiveCommStart(this, saData);
        }

        public void ReceiveAddTagList(string[] saData)
        {
            if (UEventReceiveAddTagList != null)
                UEventReceiveAddTagList(this, saData);
        }

        public void ReceiveRemoveTagList(string[] saData)
        {
            if (UEventReceiveRemoveTagList != null)
                UEventReceiveRemoveTagList(this, saData);
        }

        public void ReceiveRecipeTagList(string[] saData)
        {
            if (UEventReceiveRecipeTagList != null)
                UEventReceiveRecipeTagList(this, saData);
        }

        public void ReceiveProjectInfo(string[] saData)
        {
            if (UEventReceiveProjectInfo != null)
                UEventReceiveProjectInfo(this, saData);
        }

        public void ReceiveLadderViewTagList(string[] saData)
        {
            if (UEventReceiveLadderViewTagList != null)
                UEventReceiveLadderViewTagList(this, saData);
        }

        /// <summary>
        /// Server -> Client
        /// </summary>
        /// <param name="saData"></param>
        public void ReceiveCommStop(string[] saData)
        {
            if (UEventReceiveCommStop != null)
                UEventReceiveCommStop(this, saData);
        }

        /// <summary>
        /// Server -> Client
        /// </summary>
        /// <param name="saData"></param>
        public void ReceiveTagList(string[] saData)
        {
            if (UEventReceiveTagList != null)
                UEventReceiveTagList(this, saData);
        }

        /// <summary>
        /// Server -> Client
        /// </summary>
        /// <param name="saData"></param>
        public void ReceiveEmergTagList(string[] saData)
        {
            if (UEventReceiveEmergTagList != null)
                UEventReceiveEmergTagList(this, saData);
        }

        /// <summary>
        /// Server -> Client
        /// </summary>
        /// <param name="saData"></param>
        public void ReceiveCollectorList(string[] saData)
        {
            if (UEventReceiveCollectorList != null)
                UEventReceiveCollectorList(this, saData);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
