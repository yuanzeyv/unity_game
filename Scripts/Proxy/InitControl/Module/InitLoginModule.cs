using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MVCFrame;
using ProxySpace;
using MediatorSpace;
using CommandSpace;
using Config.Program;
using LightJson; 
namespace ModuleCellSpace
{
    public class InitLoginModule : ModuleCell
    {
        List<Proxy> ProxyList = new List<Proxy>();
        List<Mediator> MediatorList = new List<Mediator>();
        List<Command> CommandList = new List<Command>();
        public string LoginAuth;//会保存登录验证
        override public void OnInit()
        {
            InitLoginData();
        }
        override public void OnRemove()
        {
        }
        public void InitLoginData()
        {
            InitProxyList();
            InitMediatorList();
            InitCommandList(); 
            Sys.GetFacade().NotifyObserver("LoginSystemInitComplete");//发送一个初始化完成的消息，然后程序就进入了登录界面
        }
        public void CleanLoginData()
        {
            foreach (var proxy in ProxyList)
                Sys.GetFacade().UnRegisterProxy(proxy.Name);
            foreach (var mediator in MediatorList)
                Sys.GetFacade().UnRegisterMediator(mediator.Name);
            foreach (var Command in CommandList)
                Sys.GetFacade().UnregisterCommand(Command.Name); 
        }
        void InitProxyList()
        {
            ProxyList.Add(new LoginProxy());
            foreach (var proxy in ProxyList)
                Sys.GetFacade().RegisterProxy(proxy);//注册这个代理   
        } 
        void InitMediatorList()
        {
            MediatorList.Add(new LoginMediator());
            MediatorList.Add(new GameCanvasObjectMediator());
            MediatorList.Add(new TipsPopWindowMediator());
            foreach (var mediator in MediatorList)
                Sys.GetFacade().RegisterMediator(mediator);//注册这个代理  
        }
        void InitCommandList()
        {
            CommandList.Add(new LoginSuccess());
            CommandList.Add(new LoginSystemInitComplete());
            foreach (var command in CommandList)
                Sys.GetFacade().RegisterCommand(command);//注册这个代理   
        } 
    }
}