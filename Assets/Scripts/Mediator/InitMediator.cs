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
        Sys.GetFacade().RegisterMediator(new GameObjectMediator());//��ʼ���ڵ����
        Sys.GetFacade().RegisterMediator(new GameCanvasObjectMediator());//��ʼ��cancas�ڵ����  

        Sys.GetFacade().RegisterMediator(new PlayerInfomationMediator());//�û����Խ���
        Sys.GetFacade().RegisterMediator(new TimeMediator());//�û����Խ���
        Sys.GetFacade().RegisterMediator(new TipsMediator ());//Tips Mediator

        Sys.GetFacade().RegisterMediator(new LoginMediator());//ע��������� 
        Sys.GetFacade().RegisterMediator(new SystemMediator());//ע���������
        Sys.GetFacade().RegisterMediator(new TipsPopWindowMediator());//������ʾ����
        

        Sys.GetFacade().RegisterMediator(new BambooHallChooseMediator());//ע��������� 
    }
}

