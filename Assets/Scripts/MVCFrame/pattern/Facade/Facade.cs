using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Program;
using ModuleCellSpace;
using System;
//这个是通知的参数
namespace MVCFrame
{
    public class Facade
    {
        public static Dictionary<string, Facade> InstanceMap = new Dictionary<string, Facade>();
        private string MultitonKey;
        //MVC对象
        private Model ModelObj;
        private View ViewObj;
        private Control ControlObj;
        //构造函数用于初始化 对应的MVC对象
        private Facade(string multitonKey)
        {
            MultitonKey = multitonKey;
            ModelObj = Model.Instance(MultitonKey);
            ViewObj = View.Instance(MultitonKey);
            ControlObj = Control.Instance(MultitonKey);
        }

        public bool RegisterProxy(Proxy moduleProxy)//注册一个代理
        {
            return ModelObj.RegisterProxy( moduleProxy);
        }
        public Proxy RetrieveProxy(string systemName) //查询一个代理
        {
            return ModelObj.RetrieveProxy(systemName);
        }
        public T RetrieveProxy<T>() where T : Proxy//查询一个代理
        {
            return RetrieveProxy(typeof(T).Name) as T;
        } 

        public T RetrieveModule<T>(string systemName) where T :ModuleCell//查询一个代理
        {
            Proxy proxy = RetrieveProxy(systemName);
            if (proxy == null)
                return null;
            return proxy.RetrieveModule<T>() as T; 
        }
        public void UnRegisterProxy(string systemName)//删除一个代理
        {
            ModelObj.UnRegisterProxy(systemName);
        } 
        public bool RegisterCommand(Command command)//注册一个命令
        {
            return ControlObj.RegisterCommand(command.GetType().Name, command);
        }  
        public Command RetrieveCommand(string controlName)//查询一个命令
        {
            return ControlObj.RetrieveCommand(controlName);
        } 
        public void UnregisterCommand( string controlName)//反注册一个命令
        {
            ControlObj.UnregisterCommand(controlName);
        }

        public bool RegisterObserver(string cmdName, Observer.ExecuteHandle execute)//注册一个观察者
        {
            return ViewObj.RegisterObserver( cmdName, execute); 
        } 
        public void UnregisterObserver(string cmdName)//反注册一个观察者
        {
            ViewObj.UnregisterObserver(cmdName); 
        }

        public bool RegisterMediator(Mediator mediator)//注册一个代理
        {
            return ViewObj.RegisterMediator( mediator);
        }
        public void UnRegisterMediator( string mediatorName)//反注册一个代理
        {
            ViewObj.UnRegisterMediator(mediatorName);
        }  
        public Mediator RetrieveMediator(string viewName)//查询一个代理
        {
           return ViewObj.RetrieveMediator( viewName);
        }
        public void NotifyObserver(string cmdName, object data = null, params object[] list)//发送一个事件通知
        {
            if (!MsgDef.IsExist(cmdName))
            {
                MonoBehaviour.print(cmdName + "要发送的消息不存在");
                return;
            }
            Notifycation notifycation = new Notifycation(cmdName, data);
            ViewObj.NotifyObserver(cmdName, notifycation, list);
        }
        public void SyncNotifyObserver(string cmdName, object data = null, params object[] list)//发送异步通知，在下一帧之后运行
        {
            if (!MsgDef.IsExist(cmdName))
            {
                MonoBehaviour.print(cmdName + "要发送的消息不存在");
                return;
            }
            Sys.GetFacade().RetrieveModule<SyncNotifyModule>("SyncNotifyContorlProxy").PushMessage(cmdName,data,list); 
        }
        public static bool HasCore(string multitonKey)//查询当前的MVC外观是否存在
        {
            return InstanceMap.ContainsKey(multitonKey);
        } 
       public static void RemoveCore(string multitonKey)//删除一个核心
       {
           InstanceMap.Remove(multitonKey);
           Model.RemoveModel(multitonKey);
           Control.RemoveControl(multitonKey);
           View.RemoveView(multitonKey);
       } 
        public static Facade Instance(string InstanceKey)//获取到一个外观的实例
        {
            if (!InstanceMap.ContainsKey(InstanceKey))
                InstanceMap[InstanceKey] = new Facade(InstanceKey);
            return InstanceMap[InstanceKey];
        }
    }
}