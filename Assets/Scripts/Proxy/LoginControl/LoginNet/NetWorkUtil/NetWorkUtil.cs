using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using LightJson;
using MVCFrame;
using System;
using Tool;
  
//����ฺ����������� ����Ϣ�ı���
public class LoginNetModule
{
    private int Port;
    private string Addr;
    private Socket SocketObj = null;//�ͻ��˵�socket  
    IPEndPoint Point;
    public LoginNetModule(int port, string addr)
    {
        Port = port;
        Addr = addr;
    }
    public bool Connect()
    {
        SocketObj = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Point = new IPEndPoint(IPAddress.Parse(Addr), Port); 
        SocketObj.Connect(Point); 
        return SocketObj.Connected;
    }
    public string ReadLine()
    {
        byte[] buffer = new byte[1024];
        int len = SocketObj.Receive(buffer);
        System.IO.StringReader sr = new System.IO.StringReader(System.Text.Encoding.Default.GetString(buffer));
        return sr.ReadLine();
    }
    public void Close()
    {
        SocketObj.Close();
    }
    //������Ϣ
    public void Write(string data)
    {
        SocketObj.Send(Encoding.UTF8.GetBytes(data));
    }
    public void WriteLine(string data)
    {
        Write(data + "\n");
    }
    private string encode_token(string server, string user, string pass)
    {
        return string.Format("{0}@{1}:{2}",
            Base64Encoder.Encoder.GetEncoded(user),
            Base64Encoder.Encoder.GetEncoded(server),
            Base64Encoder.Encoder.GetEncoded(pass));
    }

    //��֤
    public string Verify(string server, string account, string password)
    {
        Connect();//��������
        WriteLine(Base64Encoder.Encoder.GetEncoded(encode_token(server, account, password)));//��������Ϣת��Ϊ base64 Ȼ���͸�������
        string loginServerRet = ReadLine(); //��ȡ��ǰ��¼��Ϣ
                                            // int ret = int.Parse(loginServerRet.Substring(0, 3)); 
        Close();
        return loginServerRet;
    }
}

