using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System.Net;
using System.Net.Sockets; 
using System.Threading;
using System.Text; 
using MVCFrame; 
using System;
using Config.Program; 
public class NetWorkUtil
{
    private int Port;//当前的端口
    private string Addr;//当前要监听的地址
    private string Name;//登录需要用到的用户名
    private Socket SocketSend = null;//客户端的socket 
    Thread ReadThread;//处理消息的线程 
    private static readonly object Lock = new object();//针对数据的互斥锁
    private List<MessageStruct> MsgVector = new List<MessageStruct>();//存储消息的数组
    private NetWorkMsgUtil AnalysisObject = new NetWorkMsgUtil();//消息解析钩子 
    public void InitSocketPort(int port, string addr,string name)
    {
        Port = port;
        Addr = addr;
        Name = name;
    }
    public bool IsConnect()
    {
        return  SocketSend != null && SocketSend.Connected ;//如果连接成功  
    }
    //开始连接网络
    public bool Connect()
    {
        if (!ConnectSocket())
            return false; //连接失败
        this.Write(System.Text.Encoding.Default.GetBytes(Name));//发送登录验证     
        StartThread();
        Sys.GetFacade().NotifyObserver("NetConnectSuccess");
        return true;//连接成功
    }
    //断开网络连接
    public void DisConnect()
    {
        if (!IsConnect())//如果连接成功 
            return;
        SocketSend.Close();
    }
    //当前是否有效
    public bool CanGetMsg()
    {
        return MsgVector.Count > 0;
    } 
    //初始化网络
    public bool ConnectSocket()
    {
        SocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  
        IPEndPoint point = new IPEndPoint(IPAddress.Parse(Addr), Port); 
        try
        {
            SocketSend.Connect(point);
        }catch {}   
        return SocketSend.Connected;
    }
    public bool StartThread()
    {
        ReadThread = new Thread(Received);
        ReadThread.IsBackground = true;
        ReadThread.Start(); 
        return true;
    }
   
    //获取到当前的消息信息
    public List<MessageStruct> GetNetWorkMsg()
    {
        List<MessageStruct> retMsgVector = new List<MessageStruct>();
        lock (Lock)
        {
            retMsgVector.AddRange(MsgVector.GetRange(0, MsgVector.Count));
            MsgVector.Clear();
        }
        return retMsgVector;
    } 
    void Received()
    {
        byte[] buffer = new byte[8192];
        while (true)
        { 
            if (!SocketSend.Connected) //socket不存在了
                break; 
            try
            { 
                int len = SocketSend.Receive(buffer, 4096, SocketFlags.None);
                if (len == 0)
                    break; 
                AnalysisObject.RecordMsg(buffer, len);///将这个字符串记录在 解析对象中去 
                List<MessageStruct> msgTable = AnalysisObject.AnalysisMsg(); //计息当 前字符串 
                if (msgTable.Count > 0)
                {
                    lock (Lock)
                    {
                        MsgVector.AddRange(msgTable);
                    }
                }
            }
            catch (Exception e)
            {
                MonoBehaviour.print(e.Message);
            }
        } 
        //断开连接后，两个状态需要重置
        ReadThread = null;
        SocketSend = null;
        //发送断开连接的消息
        Sys.GetFacade().SyncNotifyObserver("NetDisconnectSuccess");
    }
    public void SendMessage(string msgName, int param1 = 0, long param2 = 0, int param3 = 0, int param4 = 0, string data = "")
    {   
        if (!NetMsg.MsgDef.ContainsKey(msgName)){
            MonoBehaviour.print("当前想要发送的消息或许没有注册");
            return;
        }
        uint msgID = NetMsg.MsgDef[msgName]; 
        WriteNetMsg(msgID, param1, param2, param3, param4, data);
    }
    //发送消息 
    public void WriteNetMsg(uint msgID, int param1 = 0, long param2 = 0, int param3 = 0, int param4 = 0, string data = "")
    {
        int sendLength = 0;
        List<byte[]> byteArr = new List<byte[]>();
        byteArr.Add(BitConverter.GetBytes(msgID));
        byteArr.Add(BitConverter.GetBytes(param1));
        byteArr.Add(BitConverter.GetBytes(param2));
        byteArr.Add(BitConverter.GetBytes(param3));
        byteArr.Add(BitConverter.GetBytes(param4));
        byteArr.Add(BitConverter.GetBytes(data.Length));
        byteArr.Add(Encoding.UTF8.GetBytes(data));
        //获取到长度
        foreach (var item in byteArr)
        {
            sendLength += item.Length;
        }
        byte[] sendBuffer = new byte[sendLength];
        int tempLength = 0;
        //获取到长度
        foreach (var item in byteArr)
        {
            item.CopyTo(sendBuffer, tempLength);
            tempLength += item.Length;
        }
        Write(sendBuffer);
    }
    public void Write(byte[] data)
    {
        if (SocketSend == null) 
            return; 
        byte[] sendBuffer = new byte[2 + data.Length];
        byte[] len = BitConverter.GetBytes(data.Length);
        sendBuffer[0] = len[1];
        sendBuffer[1] = len[0];
        Array.Copy(data, 0, sendBuffer, 2, data.Length);
        SocketSend.Send(sendBuffer);
    }
}  