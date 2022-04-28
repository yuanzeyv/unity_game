using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
using ProxySpace;
namespace ModuleCellSpace
{
    public class PlayerInfoModule : ModuleCell
    {
        JsonValue PlayerInfo;
        public JsonValue CheckPlayerInfo { get { return PlayerInfo; } }

        public PlayerInfoModule()
        {
        } 
        public override void OnInit()
        {
            NetModule NetModule = Sys.GetFacade().RetrieveModule<NetModule>("NetWorkProxy");
            NetModule.RegisterNetHandle("Net_Request_PlayerInfo", NetRequestPlayerInfoHandle);//���յ�������Ϣ��ʱ���ִ�� ������� 
            NetModule.RegisterNetHandle("Net_SystemInitSuccess", NetSystemInitSuccessHandle);//���յ�������Ϣ��ʱ���ִ�� ������� 
        } 
        public void NetRequestPlayerInfoHandle(MessageStruct data)
        {
            PlayerInfo = LightJson.Serialization.JsonReader.Parse(data.data); 
        }
        public void NetSystemInitSuccessHandle(MessageStruct data)
        { 
            Sys.GetFacade().NotifyObserver("NetDataInitSuccessCommand"); //����һ��������Ϣ��ʼ����ɵ�����
        }
    }
} 