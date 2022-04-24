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
        
        Sys.GetFacade().RegisterCommand(new NetConnectSuccess());///网络连接成功的 命令 
        Sys.GetFacade().RegisterCommand(new NetDisconnectSuccess()); //网络断开连接的命令
        Sys.GetFacade().RegisterCommand(new SystemInitComplete()); //网络断开连接的命令 
        Sys.GetFacade().RegisterCommand(new LoginSuccess()); //登录成功的命令
        Sys.GetFacade().RegisterCommand(new NetDataInitSuccessCommand()); //数据信息初始化完成时的数据信息
    }
}
