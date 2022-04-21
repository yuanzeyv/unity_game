//这个是通知的参数
namespace MVCFrame
{
    public class Notify
    { 
        public Facade facadeObj;
        public Notify()
        {
        } 
        //初始化Notify
        public void InitalizationNotify(string multitonKey)
        { 
            facadeObj = Facade.Instance(multitonKey);
        }
        public void SendNotify( string cmdName, object _data)
        {
            facadeObj.NotifyObserver( cmdName, _data);
        }
    }
}