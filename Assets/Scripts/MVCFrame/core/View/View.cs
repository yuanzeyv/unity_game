using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
namespace MVCFrame
{ 
    public class View
    {  
        private static Dictionary<string, View> InstanceMap = new Dictionary<string, View>();
        private string MultitonKey; 
        Dictionary<string, Mediator>ViewList; 
        Dictionary<string, List<Observer>> ObserverList; //模块名 监听对象名 observer名
        private View(string multitonKey)
        {
            MultitonKey = multitonKey;
            ViewList = new Dictionary<string, Mediator>();
            ObserverList =new Dictionary<string, List<Observer>>();
        }      
        public bool RegisterMediator( Mediator mediator)
        { 
            mediator.OnRegister();
            ViewList[mediator.Name] = mediator;
            foreach (var cmdName in mediator.ListNotifyInitlization())
                RegisterObserver(cmdName, mediator.ExecuteHandle);
            return true;
        } 
        public Mediator RetrieveMediator(string mediatorName)
        {
            if (!ViewList.ContainsKey(mediatorName))
                return null; 
            return ViewList[mediatorName];
        } 

        //注册一个observer
        public bool RegisterObserver(string cmdName, Observer.ExecuteHandle execute)
        { 
            if (!ObserverList.ContainsKey(cmdName))
                ObserverList[cmdName] = new List<Observer>();
            ObserverList[cmdName].Add(new Observer(cmdName, execute));
            return true;
        } 
        //反注册一个observer
        public void UnregisterObserver(string cmdName, Observer.ExecuteHandle execute = null)
        {
            if (!ObserverList.ContainsKey(cmdName))
                return;
            if (execute == null) 
                ObserverList.Remove(cmdName); 
            else
            {
                foreach (var item in ObserverList[cmdName])
                {
                    if (cmdName == item.Cmd && execute == item.Execute)
                    {
                        ObserverList[cmdName].Remove(item);
                        if(ObserverList[cmdName].Count == 0)
                            ObserverList.Remove(cmdName);
                    }
                }
            }     
        } 
        public void UnRegisterMediator(string mediatorName)
        { 
            if (!ViewList.ContainsKey(mediatorName))
                return; 
            foreach (var cmdName in ViewList[mediatorName].ListNotifyInitlization())
                UnregisterObserver(cmdName, ViewList[mediatorName].ExecuteHandle);
            ViewList[mediatorName] = null;
            ViewList.Remove(mediatorName); 
        }  
        public void NotifyObserver(string cmdName,Notifycation data, params object[] list)
        { 
            if (!ObserverList.ContainsKey(cmdName))
                return;
            foreach(var item in ObserverList[cmdName])
            {
                item.Execute(data, list);
            }
        }
        public static View Instance(string InstanceKey)
        {
            if (!InstanceMap.ContainsKey(InstanceKey))
                InstanceMap[InstanceKey] = new View(InstanceKey);
            return InstanceMap[InstanceKey];
        }

        public void DestoryView()
        {
            foreach (var item in ViewList)
            {
                    UnRegisterMediator(item.Key);
            }
        }
        //删除所有的模块
        public static void RemoveView(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                return;
            Instance(multitonKey).DestoryView();
            InstanceMap.Remove(multitonKey);
        }
    }
}
