using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Program;
using ModuleCellSpace;
using System;
//�����֪ͨ�Ĳ���
namespace MVCFrame
{
    public class Facade
    {
        public static Dictionary<string, Facade> InstanceMap = new Dictionary<string, Facade>();
        private string MultitonKey;
        //MVC����
        private Model ModelObj;
        private View ViewObj;
        private Control ControlObj;
        //���캯�����ڳ�ʼ�� ��Ӧ��MVC����
        private Facade(string multitonKey)
        {
            MultitonKey = multitonKey;
            ModelObj = Model.Instance(MultitonKey);
            ViewObj = View.Instance(MultitonKey);
            ControlObj = Control.Instance(MultitonKey);
        }

        public bool RegisterProxy(Proxy moduleProxy)//ע��һ������
        {
            return ModelObj.RegisterProxy( moduleProxy);
        }
        public Proxy RetrieveProxy(string systemName) //��ѯһ������
        {
            return ModelObj.RetrieveProxy(systemName);
        }
        public T RetrieveProxy<T>() where T : Proxy//��ѯһ������
        {
            return RetrieveProxy(typeof(T).Name) as T;
        } 

        public T RetrieveModule<T>(string systemName) where T :ModuleCell//��ѯһ������
        {
            Proxy proxy = RetrieveProxy(systemName);
            if (proxy == null)
                return null;
            return proxy.RetrieveModule<T>() as T; 
        }
        public void UnRegisterProxy(string systemName)//ɾ��һ������
        {
            ModelObj.UnRegisterProxy(systemName);
        } 
        public bool RegisterCommand(Command command)//ע��һ������
        {
            return ControlObj.RegisterCommand(command.GetType().Name, command);
        }  
        public Command RetrieveCommand(string controlName)//��ѯһ������
        {
            return ControlObj.RetrieveCommand(controlName);
        } 
        public void UnregisterCommand( string controlName)//��ע��һ������
        {
            ControlObj.UnregisterCommand(controlName);
        }

        public bool RegisterObserver(string cmdName, Observer.ExecuteHandle execute)//ע��һ���۲���
        {
            return ViewObj.RegisterObserver( cmdName, execute); 
        } 
        public void UnregisterObserver(string cmdName)//��ע��һ���۲���
        {
            ViewObj.UnregisterObserver(cmdName); 
        }

        public bool RegisterMediator(Mediator mediator)//ע��һ������
        {
            return ViewObj.RegisterMediator( mediator);
        }
        public void UnRegisterMediator( string mediatorName)//��ע��һ������
        {
            ViewObj.UnRegisterMediator(mediatorName);
        }  
        public Mediator RetrieveMediator(string viewName)//��ѯһ������
        {
           return ViewObj.RetrieveMediator( viewName);
        }
        public void NotifyObserver(string cmdName, object data = null, params object[] list)//����һ���¼�֪ͨ
        {
            if (!MsgDef.IsExist(cmdName))
            {
                MonoBehaviour.print(cmdName + "Ҫ���͵���Ϣ������");
                return;
            }
            Notifycation notifycation = new Notifycation(cmdName, data);
            ViewObj.NotifyObserver(cmdName, notifycation, list);
        }
        public void SyncNotifyObserver(string cmdName, object data = null, params object[] list)//�����첽֪ͨ������һ֮֡������
        {
            if (!MsgDef.IsExist(cmdName))
            {
                MonoBehaviour.print(cmdName + "Ҫ���͵���Ϣ������");
                return;
            }
            Sys.GetFacade().RetrieveModule<SyncNotifyModule>("SyncNotifyContorlProxy").PushMessage(cmdName,data,list); 
        }
        public static bool HasCore(string multitonKey)//��ѯ��ǰ��MVC����Ƿ����
        {
            return InstanceMap.ContainsKey(multitonKey);
        } 
       public static void RemoveCore(string multitonKey)//ɾ��һ������
       {
           InstanceMap.Remove(multitonKey);
           Model.RemoveModel(multitonKey);
           Control.RemoveControl(multitonKey);
           View.RemoveView(multitonKey);
       } 
        public static Facade Instance(string InstanceKey)//��ȡ��һ����۵�ʵ��
        {
            if (!InstanceMap.ContainsKey(InstanceKey))
                InstanceMap[InstanceKey] = new Facade(InstanceKey);
            return InstanceMap[InstanceKey];
        }
    }
}