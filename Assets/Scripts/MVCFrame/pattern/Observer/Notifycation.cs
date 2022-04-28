//这个是通知的参数
namespace MVCFrame
{
    public class Notifycation
    { 
        private string CmdName;//消息的ID 
        private object[] ParamList = new object[0];
        public string GetCmd()
        {
            return CmdName;
        } 
        public T GetData<T>(int index)//下标1开始
        {
            index--;
            if (ParamList[index] == null)
                throw new System.Exception(string.Format("({0}:{1})指定下标数据不存在",CmdName,index + 1 )); 
            return (T)ParamList[index];
        }
        public Notifycation(string _cmd, params object[] paramList)
        { 
            CmdName = _cmd;
            ParamList = paramList;
        }
    }
}