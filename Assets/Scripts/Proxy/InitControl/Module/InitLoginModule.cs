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
        public string LoginAuth;//�ᱣ���¼��֤
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
            Sys.GetFacade().NotifyObserver("LoginSystemInitComplete");//����һ����ʼ����ɵ���Ϣ��Ȼ�����ͽ����˵�¼����
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
                Sys.GetFacade().RegisterProxy(proxy);//ע���������   
        } 
        void InitMediatorList()
        {
            MediatorList.Add(new LoginMediator());
            MediatorList.Add(new GameCanvasObjectMediator());
            MediatorList.Add(new TipsPopWindowMediator());
            foreach (var mediator in MediatorList)
                Sys.GetFacade().RegisterMediator(mediator);//ע���������  
        }
        void InitCommandList()
        {
            CommandList.Add(new LoginSuccess());
            CommandList.Add(new LoginSystemInitComplete());
            foreach (var command in CommandList)
                Sys.GetFacade().RegisterCommand(command);//ע���������   
        } 
    }
}