using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVCFrame
{
    class Control
    {
        //模块的实例信息
        private static Dictionary<string, Control> InstanceMap = new Dictionary<string, Control>() ; 
        private string MultitonKey;
        Dictionary<string, Command> CommandList = new Dictionary<string, Command>(); 
        public static Control Instance(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                InstanceMap[multitonKey] = new Control(multitonKey);
            return InstanceMap[multitonKey];
        }
        private Control(string multitonKey)
        {
            MultitonKey = multitonKey; 
        }
         
        public void ExcuteCommand(Notifycation data)
        { 
            Command command = CommandList[data.GetCmd()]; 
            command.Excute(data);
        }
        //注册一个代理
        public bool RegisterCommand(Command command)
        {
            string cmdName = command.GetType().Name;
            Sys.GetFacade().RegisterObserver(cmdName, this.ExcuteCommand);
            command.InitalizeCommand(cmdName);
            CommandList[cmdName] = command; 
            return true;
        } 
        //判断当前代理是否存在
        public Command RetrieveCommand(string cmdName)
        {
            return CommandList[cmdName];
        }


        //取消注册一个代理
        public void UnregisterCommand(string cmdName)
        {
            //首先查询是否存在当前的命令
            if (CommandList[cmdName] == null)
                return;
            Sys.GetFacade().UnregisterObserver(cmdName,CommandList[cmdName].Excute);
            CommandList[cmdName] = null; 
        }

        public void DestoryControl()
        {
            foreach (var item in CommandList)
            {
                UnregisterCommand(item.Key);
            }
        }
        //删除所有的模块
        public static void RemoveControl(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                return;
            Instance(multitonKey).DestoryControl();
            InstanceMap.Remove(multitonKey);
        }
    }
}
