//֪ͨ�Ļ���  
//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{                                                                                                    
    public class Observer
    {
        public delegate void ExecuteHandle(Notifycation param, params object[] paramList);
        private string ObserverCmd;//֪ͨ������
        private ExecuteHandle ObserverCallback;//һ���ص�����

        public string Cmd { get { return ObserverCmd; } }//֪ͨ������ 
        public ExecuteHandle Execute { get { return ObserverCallback; } }

        public Observer(string cmdName, ExecuteHandle callBack)
        {
            ObserverCmd = cmdName;
            ObserverCallback = callBack;
        } 
    }
}

