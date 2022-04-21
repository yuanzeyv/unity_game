using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class SystemMediator : BaseMediator
    { 
        public SystemMediator()
        { 
            AddHandle("OepnSystemMainUI", OepnSystemMainUIHandle);
            AddHandle("CloseSystemMainUI", CloseSystemMainUIIHandle);
            AddHandle("RefreshSystemMainUI", RefreshSystemMainUIHandle);
        }
        public virtual void OepnSystemMainUIHandle(Notifycation param)
        {   //��ȡ��UICOntrolProxy�Ĵ���
           //UIControlProxy UIControlProxy = Sys.GetFacade().RetrieveProxy<UIControlProxy>();
           //Window = UIControlProxy.LoadLayer("SystemLayer/SystemLayer");//������Լ���UI���� 
           //Script = Window.GetComponent<LayerBase>();
           //Sys.GetFacade().NotifyObserver("AdditionWindow", Window);//����һ�����Window��֪ͨ��Ϣ
        }

        public virtual void CloseSystemMainUIIHandle(Notifycation param)
        {
            //�ر��˵�ǰ�Ľ�����Ϣ
            Sys.GetFacade().NotifyObserver("DeleteWindow", this.Name);//����һ�����Window��֪ͨ��Ϣ
        }
        public virtual void RefreshSystemMainUIHandle(Notifycation param)
        {
            if (Window == null)
                return;
            SystemLayer SystemLayerScript = Window.gameObject.GetComponent<SystemLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.UpdateLayer();
        }

    }
}