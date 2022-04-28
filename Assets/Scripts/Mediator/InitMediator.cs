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

<<<<<<< HEAD
        Sys.GetFacade().RegisterMediator(new SystemMediator());//ע���������
        
        Sys.GetFacade().RegisterMediator(new BambooHallChooseMediator());//����ѡ�������� 
        Sys.GetFacade().RegisterMediator(new BambooHallMediator());//����������� 
        Sys.GetFacade().RegisterMediator(new BambooTableMediator());//����������� 
=======
        Sys.GetFacade().RegisterMediator(new LoginMediator());//ע��������� 
        Sys.GetFacade().RegisterMediator(new SystemMediator());//ע���������
        Sys.GetFacade().RegisterMediator(new TipsPopWindowMediator());//������ʾ����
        
        Sys.GetFacade().RegisterMediator(new BambooHallChooseMediator());//����ѡ�������� 
        Sys.GetFacade().RegisterMediator(new BambooHallMediator());//����������� 
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
    }
}

