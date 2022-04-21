//这是mvc框架的一个初始化
namespace MVCFrame
{
    class Sys
    {
        private string SystemName = "MainClient";
        private Facade SystemFacade;
        private static Sys InstanceObj;
        public static Sys Instance{
            get
            {
                if (InstanceObj == null)
                    InstanceObj = new Sys();
                return InstanceObj;
            }
        } 
        public static Facade GetFacade()
        {
            return Instance.SystemFacade;
        }
        private Sys()
        {
            SystemFacade = Facade.Instance(SystemName); 
        }   
    }
}