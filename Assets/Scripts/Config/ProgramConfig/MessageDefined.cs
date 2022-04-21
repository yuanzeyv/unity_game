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
            private Dictionary<string, string> Message = new Dictionary<string, string>();//�����б�
            public static bool IsExist(string name)//�ж���Ϣ�Ƿ����
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
                Message["SystemInitComplete"] = "SystemInitComplete"; //ϵͳ��ʼ�������Ϣ
                Message["NetDataInitSuccessCommand"] = "NetDataInitSuccessCommand";//�������ݳ�ʼ���ɹ�����Ϣ
                Message["SystemTimeDifferenceValue"] = "SystemTimeDifferenceValue";//ϵͳʱ��ĸ���

                Message["OpenLoginUI"] = "OpenLoginUI";
                Message["CloseLoginUI"] = "CloseLoginUI";

                Message["AdditionCanvasObject"] = "AdditionCanvasObject";//������ڵ�ע��


                Message["AdditionSystemObject"] = "AdditionSystemObject";//3D�ڵ�ע��
                Message["DeleteSystemObject"] = "DeleteSystemObject";//3D�ڵ㷴ע��



                Message["OpenPlayerInfomationLayer"] = "OepnPlayerInfomationLayer";//������ڵ�ע��
                Message["ClosePlayerInfomationLayer"] = "ClosePlayerInfomationLayer";//������ڵ�ע��
                Message["RefreshPlayerInfomationLayer"] = "RefreshPlayerInfomationLayer";//������ڵ�ע�� 

                //������ʱ��ע��
                Message["OepnTimeLayer"] = "OepnTimeLayer";//������ڵ�ע��
                Message["CloseTimeLayer"] = "CloseTimeLayer";//������ڵ�ע��
                Message["RefreshTimeLayer"] = "RefreshTimeLayer";//������ڵ�ע��  

                Message["OepnSystemMainUI"] = "OepnSystemMainUI";//��������
                Message["CloseSystemMainUI"] = "CloseSystemMainUI";//�ر�������
                Message["RefreshSystemMainUI"] = "RefreshSystemMainUI";//ˢ����������Ϣ


                Message["OepnTipsLayerUI"] = "OepnTipsLayerUI";//Tips����Ĵ�
                Message["CloseTipsLayerUI"] = "CloseTipsLayerUI";//Tips����Ĺر�
                Message["RefreshTipsLayerUI"] = "RefreshTipsLayerUI";//Tips�����ˢ�� 


                //command ������
                Message["LoginSuccess"] = "LoginSuccess";//��¼�ɹ��������
                Message["NetConnectSuccess"] = "NetConnectSuccess";//������Ϣ�������ɹ�
                Message["NetDisconnectSuccess"] = "NetDisconnectSuccess";//��Ϣ�������Ͽ�����

                //�����Ϣ
                Message["MouseState"] = "MouseState";//��¼�ɹ��������
                Message["KeyState"] = "KeyState";//��¼�ɹ��������

                //tipspopWindow 
                Message["OepnTipsWindowLayerUI"] = "OepnTipsWindowLayerUI";//��
                Message["CloseTipsWindowLayerUI"] = "CloseTipsWindowLayerUI";//�ر�
                Message["RefreshTipsWindowLayerUI"] = "RefreshTipsWindowLayerUI";//ˢ��

                //��������ѡ�� 
                Message["OepnBambooHallChooseLayer"] = "OepnBambooHallChooseLayer";//��
                Message["CloseBambooHallChooseLayer"] = "CloseBambooHallChooseLayer";//�ر�
                Message["RefreashBambooHallChooseLayer"] = "RefreashBambooHallChooseLayer";//ˢ��
            }
        }
    } 
}
