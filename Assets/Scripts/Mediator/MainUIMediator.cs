using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class MainUIMediator : Mediator
    {
        GameObject RootNode;//对应的节点 
        private Dictionary<string, GameObject> WindowList = new Dictionary<string, GameObject>();//管理的节点
        public MainUIMediator()
        {
            AddHandle("AdditionMainUIObject", AdditionCanvasObjectHandle);
            AddHandle("DeleteMainUIObject", DeleteCanvasObjectHandle);
        }
        void AdditionCanvasObjectHandle(Notifycation param, params object[] paramList)
        {
            GameObject obj = param.GetData<GameObject>();
            if (WindowList.ContainsKey(obj.name))
            {
                GameObject.Destroy(obj);
                MonoBehaviour.print("添加" + obj.name + "界面节点失败");
                return;
            }
            obj.transform.parent = RootNode.transform;
            WindowList.Add(obj.name, obj);
            MonoBehaviour.print("添加" + obj.name + "界面节点成功");
        }
        void DeleteCanvasObjectHandle(Notifycation param, params object[] paramList)
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
        //注册后初始化
        public override void OnRegister()
        { 
            base.OnRegister();
            RootNode = GameObject.Find("GameControl");
        }
    }
}