using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Program;
//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{
    public class Mediator
    {
        Dictionary<string, Observer.ExecuteHandle> Handles = new Dictionary<string, Observer.ExecuteHandle>();
        public string Name { get { return this.GetType().Name; }} 
        public Mediator()
        { 

        }  

        //ÿ������ӵ��һ�� ��Ϣע�ắ��
        public virtual List<string> ListNotifyInitlization()
        {
            List<string> Listens = new List<string>();
            foreach (var item in Handles)
                Listens.Add(item.Key);
            return Listens;
        }
        public virtual void ExecuteHandle(Notifycation param)
        {
            if (!Handles.ContainsKey(param.GetCmd()))
                return;
            Handles[param.GetCmd()](param);
        }
        public void AddHandle(string cmdName, Observer.ExecuteHandle execute)
        {
             
            if (! MsgDef.IsExist(cmdName))
            {
                MonoBehaviour.print("��ע����Ϣ������:" + cmdName);
                return;
            }
            Handles[cmdName] = execute;
        }
        //ÿ������ע��ɹ��󣬶���һ����ʼ������
        public virtual void OnRegister()
        {
        }
        //ÿ������ע��ɹ��󣬶���һ����ʼ������
        public virtual void OnRemove()
        {
        }
    }
}
   