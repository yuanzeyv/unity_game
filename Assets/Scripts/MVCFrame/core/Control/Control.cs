using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVCFrame
{
    class Control
    {
        //ģ���ʵ����Ϣ
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
        //ע��һ������
        public bool RegisterCommand(Command command)
        {
            string cmdName = command.GetType().Name;
            Sys.GetFacade().RegisterObserver(cmdName, this.ExcuteCommand);
            command.InitalizeCommand(cmdName);
            CommandList[cmdName] = command; 
            return true;
        } 
        //�жϵ�ǰ�����Ƿ����
        public Command RetrieveCommand(string cmdName)
        {
            return CommandList[cmdName];
        }


        //ȡ��ע��һ������
        public void UnregisterCommand(string cmdName)
        {
            //���Ȳ�ѯ�Ƿ���ڵ�ǰ������
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
        //ɾ�����е�ģ��
        public static void RemoveControl(string multitonKey)
        {
            if (!InstanceMap.ContainsKey(multitonKey))
                return;
            Instance(multitonKey).DestoryControl();
            InstanceMap.Remove(multitonKey);
        }
    }
}
