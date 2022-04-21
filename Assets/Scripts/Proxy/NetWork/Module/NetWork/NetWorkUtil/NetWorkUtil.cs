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
    private int Port;//��ǰ�Ķ˿�
    private string Addr;//��ǰҪ�����ĵ�ַ
    private Socket SocketSend = null;//�ͻ��˵�socket
    Thread ReadThread;//������Ϣ���߳� 
    private static readonly object Lock = new object();//������ݵĻ�����
    private List<MessageStruct> MsgVector = new List<MessageStruct>();//�洢��Ϣ������
    private NetWorkMsgUtil AnalysisObject = new NetWorkMsgUtil();//��Ϣ��������
    public NetWorkUtil()
    {
    }
    public void InitSocketPort(int port, string addr)
    {
        Port = port;
        Addr = addr;
    }
    //��ʼ��������
    public bool ConnectSocket(int port, string addr ,string name)
    {   
        InitSocketPort(port, addr);
        if (!InitSocket())
            return false; //����ʧ��
        this.Write(System.Text.Encoding.Default.GetBytes(name));//���͵�¼��֤     
        StartThread();
        return true;//���ӳɹ�
    } 
    //��ʼ������
    public bool InitSocket()
    {
        SocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        IPEndPoint point = new IPEndPoint(IPAddress.Parse(Addr), Port);
        try
        {
            SocketSend.Connect(point);
        }
        catch {}   
        return SocketSend.Connected;
    }
    public bool StartThread()
    {
        ReadThread = new Thread(Received);
        ReadThread.IsBackground = true;
        ReadThread.Start();
        return true;
    }
    public void DisConnect()
    { 
        ReadThread.Abort();
        ReadThread.Join();
        Sys.GetFacade().NotifyObserver("NetDisconnectSuccess");
    }
   
    //��ȡ����ǰ����Ϣ��Ϣ
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
    //����ǰ�Ƿ�����Ϣ
    public bool TryGetMsg()
    {
        return MsgVector.Count > 0;
    }
    void Received()
    {
        byte[] buffer = new byte[8000];
        while (true)
        {
            try
            {
                int len = SocketSend.Receive(buffer, 4096, SocketFlags.None);
                if (len == 0)
                    break;
                AnalysisObject.RecordMsg(buffer, len);///������ַ�����¼�� ����������ȥ 
                List<MessageStruct> msgTable = AnalysisObject.AnalysisMsg(); //��Ϣ�� ǰ�ַ��� 
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
        //���ͶϿ����ӵ���Ϣ
        Sys.GetFacade().NotifyObserver("NetDisconnectSuccess");
    }
    public void SendMessage(string msgName, int param1 = 0, int param2 = 0, int param3 = 0, int param4 = 0, string data = "")
    {   
        if (!NetMsg.MsgDef.ContainsKey(msgName))
        {
            MonoBehaviour.print("��ǰ��Ҫ���͵���Ϣ����û��ע��");
            return;
        }
        uint msgID = NetMsg.MsgDef[msgName]; 
        WriteNetMsg(msgID, param1, 0, 0, param4, data);
    }
    //������Ϣ 
    public void WriteNetMsg(uint msgID, int param1 = 0, int param2 = 0, int param3 = 0, int param4 = 0, string data = "")
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
        //��ȡ������
        foreach (var item in byteArr)
        {
            sendLength += item.Length;
        }
        byte[] sendBuffer = new byte[sendLength];
        int tempLength = 0;
        //��ȡ������
        foreach (var item in byteArr)
        {
            item.CopyTo(sendBuffer, tempLength);
            tempLength += item.Length;
        }
        Write(sendBuffer);
    }
    public void Write(byte[] data)
    {
        byte[] sendBuffer = new byte[2 + data.Length];
        byte[] len = BitConverter.GetBytes(data.Length);
        sendBuffer[0] = len[1];
        sendBuffer[1] = len[0];
        Array.Copy(data, 0, sendBuffer, 2, data.Length);
        SocketSend.Send(sendBuffer);
    }
}





