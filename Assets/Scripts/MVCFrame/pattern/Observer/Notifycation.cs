//这个是通知的参数
namespace MVCFrame
{
    public class Notifycation
    { 
        private string CmdName;//消息的ID
        private object Data;//通知的数据
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