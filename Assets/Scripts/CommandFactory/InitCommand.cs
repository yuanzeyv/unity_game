using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using CommandSpace;

class InitCommand
{
    private static InitCommand InstanceObj;
    public static InitCommand GetInstance()
    {
        if (InstanceObj == null)
            InstanceObj = new InitCommand();
        return InstanceObj;
    }
    private InitCommand(){}
    public void LoginInCommand()
    {
        
        Sys.GetFacade().RegisterCommand(new NetConnectSuccess());///�������ӳɹ��� ���� 
        Sys.GetFacade().RegisterCommand(new NetDisconnectSuccess()); //����Ͽ����ӵ�����
        Sys.GetFacade().RegisterCommand(new SystemInitComplete()); //����Ͽ����ӵ����� 
        Sys.GetFacade().RegisterCommand(new LoginSuccess()); //��¼�ɹ�������
        Sys.GetFacade().RegisterCommand(new NetDataInitSuccessCommand()); //������Ϣ��ʼ�����ʱ��������Ϣ
    }
}
