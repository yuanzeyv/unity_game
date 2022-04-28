using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using Config.Program;
using MediatorSpace; 
class InitMediator
{
    private static InitMediator InstanceObj;
    public static InitMediator GetInstance()
    {
        if (InstanceObj == null)
            InstanceObj = new InitMediator();
        return InstanceObj;
    }
    private InitMediator()
    {
    }
    public void LoginInMediator()
    {
        Sys.GetFacade().RegisterMediator(new GameObjectMediator());//初始化节点管理
        Sys.GetFacade().RegisterMediator(new GameCanvasObjectMediator());//初始化cancas节点管理  

        Sys.GetFacade().RegisterMediator(new PlayerInfomationMediator());//用户属性界面
        Sys.GetFacade().RegisterMediator(new TimeMediator());//用户属性界面
        Sys.GetFacade().RegisterMediator(new TipsMediator ());//Tips Mediator

        Sys.GetFacade().RegisterMediator(new SystemMediator());//注册这个代理
        
        Sys.GetFacade().RegisterMediator(new BambooHallChooseMediator());//大厅选择界面代理 
        Sys.GetFacade().RegisterMediator(new BambooHallMediator());//大厅界面代理 
        Sys.GetFacade().RegisterMediator(new BambooTableMediator());//大厅界面代理 
    }
}

