using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是mvc框架的一个初始化
namespace MVCFrame
{
    class Model
    {
        //模块的实例信息
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

        //注册一个代理
        public bool RegisterProxy(Proxy moduleProxy)
        { 
            ModuleList[moduleProxy.Name] = moduleProxy;//添加到名字列表  
            moduleProxy.OnRigister();  
            return true;
        }

        //判断当前代理是否存在
        public Proxy RetrieveProxy(string proxyName)
        {
            if (!ModuleList.ContainsKey(proxyName))
                return null;
            return ModuleList[proxyName];
        } 
        //取消注册一个代理
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
        //删除所有的模块
        public static void RemoveModel(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                return;
            Instance(multitonKey).DestoryModel();
        }
    }
}
