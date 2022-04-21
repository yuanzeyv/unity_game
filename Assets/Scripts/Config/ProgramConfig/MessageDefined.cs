using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Config
{
    namespace Program
    { 
        public class MsgDef
        {
            private static MsgDef InstanceObj;
            private Dictionary<string, string> Message = new Dictionary<string, string>();//窗口列表
            public static bool IsExist(string name)//判断消息是否存在
            {
                return Instance().Message.ContainsKey(name);
            } 
            public static MsgDef Instance()
            {
                if (InstanceObj == null)
                    InstanceObj = new MsgDef();
                return InstanceObj;
            }
            public static string Get(string msgName)
            {
                if (MsgDef.Instance().Message.ContainsKey(msgName))
                    return null;
                return MsgDef.Instance().Message[msgName];
            }
            private MsgDef()
            {
                InitMessageDef();
            }
            public void InitMessageDef()
            {
                Message["SystemInitComplete"] = "SystemInitComplete"; //系统初始化完成消息
                Message["NetDataInitSuccessCommand"] = "NetDataInitSuccessCommand";//网络数据初始化成功的消息

                Message["OpenLoginUI"] = "OpenLoginUI";
                Message["CloseLoginUI"] = "CloseLoginUI";

                Message["AdditionCanvasObject"] = "AdditionCanvasObject";//主界面节点注册


                Message["AdditionSystemObject"] = "AdditionSystemObject";//3D节点注册
                Message["DeleteSystemObject"] = "DeleteSystemObject";//3D节点反注册



                Message["OpenPlayerInfomationLayer"] = "OepnPlayerInfomationLayer";//主界面节点注册
                Message["ClosePlayerInfomationLayer"] = "ClosePlayerInfomationLayer";//主界面节点注册
                Message["RefreshPlayerInfomationLayer"] = "RefreshPlayerInfomationLayer";//主界面节点注册 

                //主界面时间注册
                Message["OepnTimeLayer"] = "OepnTimeLayer";//主界面节点注册
                Message["CloseTimeLayer"] = "CloseTimeLayer";//主界面节点注册
                Message["RefreshTimeLayer"] = "RefreshTimeLayer";//主界面节点注册  

                Message["OepnSystemMainUI"] = "OepnSystemMainUI";//打开主界面
                Message["CloseSystemMainUI"] = "CloseSystemMainUI";//关闭主界面
                Message["RefreshSystemMainUI"] = "RefreshSystemMainUI";//刷新主界面信息


                Message["OepnTipsLayerUI"] = "OepnTipsLayerUI";//Tips界面的打开
                Message["CloseTipsLayerUI"] = "CloseTipsLayerUI";//Tips界面的关闭
                Message["RefreshTipsLayerUI"] = "RefreshTipsLayerUI";//Tips界面的刷新
                 

                Message["OepnBambooHallChooseLayer"] = "OepnBambooHallChooseLayer";//打开接竹竿大厅界面
                Message["OepnBambooHallChooseLayer"] = "OepnBambooHallChooseLayer";//关闭接竹竿大厅界面
                Message["RefreashBambooHallChooseLayer"] = "RefreashBambooHallChooseLayer";//刷新接竹竿大厅的界面


                //command 的区域
                Message["LoginSuccess"] = "LoginSuccess";//登录成功后的命令
                Message["NetConnectSuccess"] = "NetConnectSuccess";//连接消息服务器成功
                Message["NetDisconnectSuccess"] = "NetDisconnectSuccess";//消息服务器断开连接



            }
        }
    } 
}
