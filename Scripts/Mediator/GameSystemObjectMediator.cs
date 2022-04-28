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
        GameObject RootNode;//��Ӧ�Ľڵ� 
        private Dictionary<string, GameObject> WindowList = new Dictionary<string, GameObject>();//�����Ľڵ�
        public GameObjectMediator()
        {
            AddHandle("AdditionSystemObject", AdditionObjectHandle);
            AddHandle("DeleteSystemObject", DeleteObjectHandle);
        }
        public virtual void AdditionObjectHandle(Notifycation param)
        {
            GameObject obj = param.GetData<GameObject>(1);
            if (WindowList.ContainsKey(obj.name))
            {
                GameObject.Destroy(obj);
                MonoBehaviour.print("����" + obj.name + "�ڵ�ʧ��");
                return;
            }
            obj.transform.parent = RootNode.transform;
            WindowList.Add(obj.name, obj);
            MonoBehaviour.print("����" + obj.name + "�ڵ�ɹ�");
        }
        public virtual void DeleteObjectHandle(Notifycation param)
        {
            string name = param.GetData<string>(1);
            if (WindowList.ContainsKey(name))
            { 
                MonoBehaviour.print("ɾ��" + name + "�ڵ�ʧ��");
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