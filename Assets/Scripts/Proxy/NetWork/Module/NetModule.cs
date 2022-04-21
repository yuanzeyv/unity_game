using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
namespace ModuleCellSpace
{
    public class NetModule : ModuleCell
    {
        public delegate void NexExecuteHandle(MessageStruct param);
        public NetWorkUtil NetUtil = new NetWorkUtil();//һ�����繤���� 
        public Dictionary<uint, NexExecuteHandle> MsgHandleMap = new Dictionary<uint, NexExecuteHandle>();
        //��ʼ��������
        public bool Connect()
        {
            return NetUtil.Connect();
        }
        public bool IsConnect()
        {
            return NetUtil.IsConnect();
        }
        public void DisConnect()
        {
            NetUtil.DisConnect();
        }
        public void InitSocketPort(int port, string addr, string name)
        {
            NetUtil.InitSocketPort(port, addr, name); 
        }
        public void RegisterNetHandle(string cmd, NexExecuteHandle handle)
        {
            if (!NetMsg.MsgDef.ContainsKey(cmd))
            {
                Debug.LogWarning(string.Format("ע�������Ϣ({0})ִ��ʧ��,ԭ������Ϣ��������������Ϣ�б���", cmd));
                return;
            }
            uint MsgID = NetMsg.MsgDef[cmd];//��ȡ����Ϣ������ID
            if (MsgHandleMap.ContainsKey(MsgID))
            {
                Debug.LogWarning(string.Format("������Ϣ({0})�ظ�ע��,�����߼�", cmd)); 
            }
            MsgHandleMap[MsgID] = handle;
        }
        public void UnregisterNetHandle(string cmd)
        { 
            if (!NetMsg.MsgDef.ContainsKey(cmd))
            {
                Debug.LogWarning(string.Format("��ע�������Ϣ({0})ִ��ʧ��,ԭ������Ϣ��������������Ϣ�б���",cmd));
                return;
            }
            uint MsgID = NetMsg.MsgDef[cmd];//��ȡ����Ϣ������ID
            if (!MsgHandleMap.ContainsKey(MsgID))
            {
                Debug.LogWarning(string.Format("��ע�������Ϣ({0})ִ��ʧ��,ԭ������Ϣδע�������������", cmd));
                return;
            }
            MsgHandleMap.Remove(MsgID);
        }
        //���ⲿ��һ��ÿ�� 60�ε�ʱ�ӣ����е��ñ����� 
        public void NetMsgExecuteStepHandle()
        {
            if (!NetUtil.CanGetMsg())//��������״̬�²Ż�������
                return; 
            List<MessageStruct> msgList = NetUtil.GetNetWorkMsg();//��ȡ��������Ϣ�б� 
            Facade facade = Sys.GetFacade();
            NetMsg netObj = NetMsg.Instance();
            foreach (var msg in msgList)
            { 
                if (NetMsg.NetIDDef.ContainsKey(msg.msgID) && MsgHandleMap.ContainsKey(msg.msgID)) 
                    MsgHandleMap[msg.msgID](msg); 
                else 
                    MonoBehaviour.print("��Ϣû�б�ʵ��" + msg.msgID); 
            }
        }
    }
} 