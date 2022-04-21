//通知的基类  
//这是mvc框架的一个初始化
namespace MVCFrame
{                                                                                                    
    public class Observer
    {
        public delegate void ExecuteHandle(Notifycation param, params object[] paramList);
        private string ObserverCmd;//通知的类型
        private ExecuteHandle ObserverCallback;//一个回调函数

        public string Cmd { get { return ObserverCmd; } }//通知的类型 
        public ExecuteHandle Execute { get { return ObserverCallback; } }

        public Observer(string cmdName, ExecuteHandle callBack)
        {
            ObserverCmd = cmdName;
            ObserverCallback = callBack;
        } 
    }
}

