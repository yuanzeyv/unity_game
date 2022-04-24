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
        GameObject RootNode;//��Ӧ�Ľڵ� 
        private Dictionary<string, GameObject> WindowList = new Dictionary<string, GameObject>();//����Ľڵ�
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
                MonoBehaviour.print("���" + obj.name + "����ڵ�ʧ��");
                return;
            }
            obj.transform.parent = RootNode.transform;
            WindowList.Add(obj.name, obj);
            MonoBehaviour.print("���" + obj.name + "����ڵ�ɹ�");
        }
        void DeleteCanvasObjectHandle(Notifycation param, params object[] paramList)
        {
            string name = param.GetData<string>();
            if (WindowList.ContainsKey(name))
            {
                MonoBehaviour.print("ɾ��" + name + "�ڵ�ʧ��");
                return;
            }
            GameObject.Destroy(WindowList[name]);
            WindowList.Remove(name);
        }
        //ע����ʼ��
        public override void OnRegister()
        { 
            base.OnRegister();
            RootNode = GameObject.Find("GameControl");
        }
    }
}