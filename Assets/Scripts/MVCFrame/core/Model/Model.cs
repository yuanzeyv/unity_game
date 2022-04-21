using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{
    class Model
    {
        //ģ���ʵ����Ϣ
        private static Dictionary<string, Model> InstanceMap = new Dictionary<string, Model>();      
        private string MultitonKey; 
        Dictionary<string, Proxy> ModuleList = new Dictionary<string, Proxy>(); 
        public static Model Instance(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey)) 
                InstanceMap[multitonKey] = new Model(multitonKey); 
            return InstanceMap[multitonKey];
        }
        private Model(string multitonKey)
        {
            MultitonKey = multitonKey;  
        } 

        //ע��һ������
        public bool RegisterProxy(Proxy moduleProxy)
        { 
            ModuleList[moduleProxy.Name] = moduleProxy;//��ӵ������б�  
            moduleProxy.OnRigister();  
            return true;
        }

        //�жϵ�ǰ�����Ƿ����
        public Proxy RetrieveProxy(string proxyName)
        {
            if (!ModuleList.ContainsKey(proxyName))
                return null;
            return ModuleList[proxyName];
        } 
        //ȡ��ע��һ������
        public void UnRegisterProxy(string proxyName)
        {
            Proxy proxy = RetrieveProxy(proxyName);
            if (proxy == null)
                return; 
            proxy.OnRemove();
            ModuleList.Remove(proxyName); 
        }  
        public void DestoryModel()
        {
            foreach(var item in ModuleList) 
                UnRegisterProxy(item.Key);
            InstanceMap.Remove(MultitonKey);
        }
        //ɾ�����е�ģ��
        public static void RemoveModel(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                return;
            Instance(multitonKey).DestoryModel();
        }
    }
}
