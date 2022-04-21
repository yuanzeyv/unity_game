//通知的基类  
//这是mvc框架的一个初始化
namespace MVCFrame
{
    public class Command:Notify
    { 
        private string SystemName;//关联的系统模块名称 
        private string ObserverCmd;//通知的类型 
        public string Cmd { get { return ObserverCmd;}}//通知的类型
        public string SysName { get { return SystemName; } }
        public Command()
        {
        }
        public void InitalizeCommand(string sysName, string cmdName)
        {
            SystemName = sysName;
            ObserverCmd = cmdName;
        }
        public virtual  void Excute(Notifycation data)
        { 
        }
    }

    public class SimpleCommand:Command
    {  
        public delegate void ExecuteHandle(Command command, Notifycation param);
        private ExecuteHandle SimpleExecute;
        public SimpleCommand(ExecuteHandle execute)
        {
            SimpleExecute = execute;
        }
        public override void Excute(Notifycation data)
        {
            SimpleExecute(this,data);
        }
    }
}

