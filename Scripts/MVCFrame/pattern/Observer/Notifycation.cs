//�����֪ͨ�Ĳ���
namespace MVCFrame
{
    public class Notifycation
    { 
        private string CmdName;//��Ϣ��ID 
        private object[] ParamList = new object[0];
        public string GetCmd()
        {
            return CmdName;
        } 
        public T GetData<T>(int index)//�±�1��ʼ
        {
            index--;
            if (ParamList[index] == null)
                throw new System.Exception(string.Format("({0}:{1})ָ���±����ݲ�����",CmdName,index + 1 )); 
            return (T)ParamList[index];
        }
        public Notifycation(string _cmd, params object[] paramList)
        { 
            CmdName = _cmd;
            ParamList = paramList;
        }
    }
}