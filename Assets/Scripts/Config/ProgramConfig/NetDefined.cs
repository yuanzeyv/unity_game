using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ok网络模式用监视者模式

namespace Config
{
    namespace Program
    {
        public class NetMsg
        {
            private static NetMsg InstanceObj;

            private Dictionary<string, uint> NetMessage = new Dictionary<string, uint>();//窗口列表

            private Dictionary<uint, string> NetIDMessage = new Dictionary<uint, string>();//窗口列表
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
                NetMessage["Net_LoginSystem"]       = 1;   //登入系统
                NetMessage["Net_LoginOutSystem"]    = 2;//登出系统
                NetMessage["Net_RequestSystemList"] = 3; //请求系统消息 
                NetMessage["Net_SystemInitSuccess"] = 4;//登录成功的消息

                NetMessage["Net_Request_HallList"]  = 100;//请求大厅详细信息
                NetMessage["Net_EnterHall"]         = 101;//进入大厅
                NetMessage["Net_LeaveHall"]         = 102;// 离开大厅
                NetMessage["Net_EnterTable"]        = 103;// 进入桌子
                NetMessage["Net_LeaveTable"]        = 104; //离开桌子
                NetMessage["Net_PlayerReady"]       = 105;//玩家准备
                NetMessage["Net_PlayerUnready"]     = 106;//玩家未准备
                NetMessage["Net_PlayerStand"]       = 107;//玩家观战
                NetMessage["Net_StartGame"]         = 108;//房主开始游戏
                NetMessage["Net_EnterGame"]         = 109;//玩家进入游戏
                NetMessage["Net_LeaveGame"]         = 110;//玩家离开游戏
                NetMessage["Net_TableAllInfo"]      = 111;//请求桌子下的所有信息
                NetMessage["Net_ChangeMaster"]      = 112;//更换房主  
                NetMessage["Net_Request_HallInfo"]  = 113;//更换房主 



                //玩家信息区域
                NetMessage["Net_Request_PlayerInfo"] = 200;//登录成功后的命令

                //时间管理器
                NetMessage["Net_Heartbeat"] = 300;//登录成功后的命令
                NetMessage["Net_Request_Heartbeat"] = 301;//主动请求时间信息

            }
            
        }

    }
}
      