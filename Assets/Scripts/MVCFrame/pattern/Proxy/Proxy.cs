using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{
    public class Proxy
    { 
        public string Name { get{ return this.GetType().Name;} }
        private Dictionary<string, ModuleCell> ModuleList = new Dictionary<string, ModuleCell>();//ÿ���������кܶ����ģ��
        public Proxy()
        {
        }
        //ע��һ��ģ��
        public bool RegisterModule(ModuleCell module)
        {
            if (ModuleList.ContainsKey(module.Name))
                return false;
            ModuleList.Add(module.Name, module);
            module.SetProxy(this);
            module.OnInit();
            return true ;
        }
        //��̬ɾ��һ��ģ�鵽������(����ִ���У�ִ��)
        public void UnRegisterModule(string moduleName)
        {
            if (ModuleList.ContainsKey(moduleName))
                return ;
            ModuleCell module = ModuleList[moduleName];
            module.OnRemove();
            ModuleList.Remove(moduleName);
        }
        //Ѱ��һ��ģ�� 
        public T RetrieveModule<T>() where T:ModuleCell
        {
            string moduleName = typeof(T).Name;
            if (! ModuleList.ContainsKey(moduleName))
                return null;
            return ModuleList[moduleName] as T ;
        }
        //ɾ�����е�ģ��
        private void DestoryAllModule()
        {
            foreach (var item in ModuleList)
                UnRegisterModule(item.Key);
        }
        public virtual void OnRigister(){}
        public virtual void OnRemove(){
            DestoryAllModule();//ɾ�����е�ģ��
        }
    }
}
 