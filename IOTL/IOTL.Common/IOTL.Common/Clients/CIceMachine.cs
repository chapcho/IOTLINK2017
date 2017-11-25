using IOTL.Common.Framework;

namespace IOTL.Common.Clients
{
    public class CIceMachine : IClient, IDescribable, IManager
    {
        // 제빙기 정보(인터페이스)
        private string _iceMachineName = "";
        private string _clientDescription = ConstantDef.IOTL_ICEMACHINE_CLIENT;
        // 제빙기 담당자 정보(인터페이스)
        private string _managerName = "";
        private string _managerContact = "";
        private string _managerEMail = "";
        private string _managerCorp = "";
        // 
        private string _ipAddr = "";


        #region 상속받은 인터페이스 메서드 구현

        // string IClient.ClientName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ClientName
        {
            get { return _iceMachineName; }
            set { _iceMachineName = value; }
        }
        // string IDescribable.Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description
        {
            get { return _clientDescription; }
            set { _clientDescription = value; }
        }

        // string IManager.ManagerName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ManagerName
        {
            get { return _managerName; }
            set { _managerName = value; }
        }
        // string IManager.ManagerContact { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ManagerContact
        {
            get { return _managerContact; }
            set { _managerContact = value; }
        }
        // string IManager.ManagerEMail { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ManagerEMail
        {
            get { return _managerEMail; }
            set { _managerEMail = value; }
        }
        // string IManager.ManagerCorp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ManagerCorp
        {
            get { return _managerCorp; }
            set { _managerCorp = value; }
        }

        #endregion

        public string IpAddr
        {
            get { return _ipAddr; }
            set => _ipAddr = value;
        }
    }
}
