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
        {   //获取到UICOntrolProxy的代理
            //UIControlProxy UIControlProxy = Sys.GetFacade().RetrieveProxy<UIControlProxy>();
            //Window = UIControlProxy.LoadLayer("Bamboo/HallChoose/HallChoosePlane");//代理可以加载UI界面
            //Window.name = this.Name;
            //Sys.GetFacade().NotifyObserver("AdditionWindow", Window);//发送一个添加Window的通知消息
        }

        public virtual void CloseBambooHallChooseLayerHandle(Notifycation param)
        {
            //关闭了当前的界面信息
            Sys.GetFacade().NotifyObserver("DeleteWindow", this.Name);//发送一个添加Window的通知消息
        }
        public virtual void RefreashBambooHallChooseLayer(Notifycation param)
        {
            if (Window == null)
                return;
            BambooChooseLayer SystemLayerScript = Window.gameObject.GetComponent<BambooChooseLayer>();//获取到 登录代理 
            SystemLayerScript.UpdateLayer();
        }
    }
}