//�����֪ͨ�Ĳ���
namespace MVCFrame
{
    public class Notifycation
    { 
        private string CmdName;//��Ϣ��ID
        private object Data;//֪ͨ������
        public string GetCmd()
        {
            return CmdName;
        } 
        public T GetData<T>()
        {
            return  (T)Data;
        }
        public Notifycation(string _cmd, object _data)
        { 
            CmdName = _cmd;
            Data = _data;
        }
    }
}