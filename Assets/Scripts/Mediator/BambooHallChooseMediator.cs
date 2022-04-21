using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public class BambooMediator : Mediator
    {
        Transform Window; 
        public BambooMediator()
        {
            AddHandle("OepnBambooHallChooseLayer", OepnBambooHallChooseLayerHandle);
            AddHandle("CloseBambooHallChooseLayer", CloseBambooHallChooseLayerHandle);
            AddHandle("RefreashBambooHallChooseLayer", RefreashBambooHallChooseLayer);
        }
        public virtual void OepnBambooHallChooseLayerHandle(Notifycation param)
        {   //��ȡ��UICOntrolProxy�Ĵ���
            //UIControlProxy UIControlProxy = Sys.GetFacade().RetrieveProxy<UIControlProxy>();
            //Window = UIControlProxy.LoadLayer("Bamboo/HallChoose/HallChoosePlane");//������Լ���UI����
            //Window.name = this.Name;
            //Sys.GetFacade().NotifyObserver("AdditionWindow", Window);//����һ�����Window��֪ͨ��Ϣ
        }

        public virtual void CloseBambooHallChooseLayerHandle(Notifycation param)
        {
            //�ر��˵�ǰ�Ľ�����Ϣ
            Sys.GetFacade().NotifyObserver("DeleteWindow", this.Name);//����һ�����Window��֪ͨ��Ϣ
        }
        public virtual void RefreashBambooHallChooseLayer(Notifycation param)
        {
            if (Window == null)
                return;
            BambooChooseLayer SystemLayerScript = Window.gameObject.GetComponent<BambooChooseLayer>();//��ȡ�� ��¼���� 
            SystemLayerScript.UpdateLayer();
        }
    }
}