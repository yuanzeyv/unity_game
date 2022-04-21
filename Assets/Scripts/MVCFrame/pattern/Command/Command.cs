//֪ͨ�Ļ���  
//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{
    public class Command:Notify
    { 
        private string SystemName;//������ϵͳģ������ 
        private string ObserverCmd;//֪ͨ������ 
        public string Cmd { get { return ObserverCmd;}}//֪ͨ������
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

