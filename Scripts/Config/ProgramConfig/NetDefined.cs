using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ok����ģʽ�ü�����ģʽ

namespace Config
{
    namespace Program
    {
        public class NetMsg
        {
            private static NetMsg InstanceObj;

            private Dictionary<string, uint> NetMessage = new Dictionary<string, uint>();//�����б�

            private Dictionary<uint, string> NetIDMessage = new Dictionary<uint, string>();//�����б�
            public static Dictionary<string, uint> MsgDef
            {
                get { return Instance().NetMessage; }
            }
            public static Dictionary<uint, string> NetIDDef
            {
                get { return Instance().NetIDMessage; }
            } 
            public static NetMsg Instance()
            {
                if (InstanceObj == null)
                    InstanceObj = new NetMsg();
                return InstanceObj;
            }  
            private NetMsg()
            {
                InitMsgDefined();
                InitIDMsgDefined();
            }
            private void InitIDMsgDefined()
            {
                foreach (var item in NetMessage)
                {
                    NetIDMessage[item.Value] = item.Key;
                }
            }
            public void InitMsgDefined()
            {
                NetMessage["Net_LoginSystem"]       = 1;   //����ϵͳ
                NetMessage["Net_LoginOutSystem"]    = 2;//�ǳ�ϵͳ
                NetMessage["Net_RequestSystemList"] = 3; //����ϵͳ��Ϣ 
                NetMessage["Net_SystemInitSuccess"] = 4;//��¼�ɹ�����Ϣ

                NetMessage["Net_Request_HallList"]  = 100;//���������ϸ��Ϣ
                NetMessage["Net_EnterHall"]         = 101;//�������
                NetMessage["Net_LeaveHall"]         = 102;// �뿪����
                NetMessage["Net_EnterTable"]        = 103;// ��������
                NetMessage["Net_LeaveTable"]        = 104; //�뿪����
                NetMessage["Net_PlayerReady"]       = 105;//���׼��
                NetMessage["Net_PlayerUnready"]     = 106;//���δ׼��
                NetMessage["Net_PlayerStand"]       = 107;//��ҹ�ս
                NetMessage["Net_StartGame"]         = 108;//������ʼ��Ϸ
                NetMessage["Net_EnterGame"]         = 109;//��ҽ�����Ϸ
                NetMessage["Net_LeaveGame"]         = 110;//����뿪��Ϸ
                NetMessage["Net_TableAllInfo"]      = 111;//���������µ�������Ϣ
                NetMessage["Net_ChangeMaster"]      = 112;//��������  
                NetMessage["Net_Request_HallInfo"]  = 113;//�������� 



                //�����Ϣ����
                NetMessage["Net_Request_PlayerInfo"] = 200;//��¼�ɹ��������

                //ʱ�������
                NetMessage["Net_Heartbeat"] = 300;//��¼�ɹ��������
                NetMessage["Net_Request_Heartbeat"] = 301;//��������ʱ����Ϣ

            }
            
        }

    }
}
      