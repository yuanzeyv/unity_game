using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class GameObjectMediator : Mediator
    {
        GameObject RootNode;//对应的节点 
        private Dictionary<string, GameObject> WindowList = new Dictionary<string, GameObject>();//管理的节点
        public GameObjectMediator()
        {
            AddHandle("AdditionSystemObject", AdditionObjectHandle);
            AddHandle("DeleteSystemObject", DeleteObjectHandle);
        }
        public virtual void AdditionObjectHandle(Notifycation param, params object[] paramList)
        {
            GameObject obj = param.GetData<GameObject>();
            if (WindowList.ContainsKey(obj.name))
            {
                GameObject.Destroy(obj);
                MonoBehaviour.print("添加" + obj.name + "节点失败");
                return;
            }
            obj.transform.parent = RootNode.transform;
            WindowList.Add(obj.name, obj);
            MonoBehaviour.print("添加" + obj.name + "节点成功");
        }
        public virtual void DeleteObjectHandle(Notifycation param, params object[] paramList)
        {
            string name = param.GetData<string>();
            if (WindowList.ContainsKey(name))
            { 
                MonoBehaviour.print("删除" + name + "节点失败");
                return;
            }
            GameObject.Destroy(WindowList[name]);
            WindowList.Remove(name); 
        }
        public override void OnRegister()
        {
            base.OnRegister();
            RootNode = GameObject.Find("GameControl");
        }
    }
}