using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Program;
//这是mvc框架的一个初始化
namespace MVCFrame
{
    public class Mediator
    {
        Dictionary<string, Observer.ExecuteHandle> Handles = new Dictionary<string, Observer.ExecuteHandle>();
        public string Name { get { return this.GetType().Name; }} 
        public Mediator()
        { 

        }  

        //每个代理拥有一个 消息注册函数
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
                MonoBehaviour.print("此注册消息不存在:" + cmdName);
                return;
            }
            Handles[cmdName] = execute;
        }
        //每个代理注册成功后，都有一个初始化函数
        public virtual void OnRegister()
        {
        }
        //每个代理注册成功后，都有一个初始化函数
        public virtual void OnRemove()
        {
        }
    }
}
   