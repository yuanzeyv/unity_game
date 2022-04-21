using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//这是mvc框架的一个初始化
namespace MVCFrame
{
    public class Proxy
    { 
        public string Name { get{ return this.GetType().Name;} }
        private Dictionary<string, ModuleCell> ModuleList = new Dictionary<string, ModuleCell>();//每个代理下有很多个子模块
        public Proxy()
        {
        }
        //注册一个模块
        public bool RegisterModule(ModuleCell module)
        {
            if (ModuleList.ContainsKey(module.Name))
                return false;
            ModuleList.Add(module.Name, module);
            module.SetProxy(this);
            module.OnInit();
            return true ;
        }
        //动态删除一个模块到代理中(代理执行中，执行)
        public void UnRegisterModule(string moduleName)
        {
            if (ModuleList.ContainsKey(moduleName))
                return ;
            ModuleCell module = ModuleList[moduleName];
            module.OnRemove();
            ModuleList.Remove(moduleName);
        }
        //寻找一个模块 
        public T RetrieveModule<T>() where T:ModuleCell
        {
            string moduleName = typeof(T).Name;
            if (! ModuleList.ContainsKey(moduleName))
                return null;
            return ModuleList[moduleName] as T ;
        }
        //删除所有的模块
        private void DestoryAllModule()
        {
            foreach (var item in ModuleList)
                UnRegisterModule(item.Key);
        }
        public virtual void OnRigister(){}
        public virtual void OnRemove(){
            DestoryAllModule();//删除所有的模块
        }
    }
}
 