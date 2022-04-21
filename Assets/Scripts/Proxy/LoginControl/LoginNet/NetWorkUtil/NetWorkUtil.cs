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
  
//这个类负责网络的连接 与消息的保存
public class LoginNetModule
{
    private int Port;
    private string Addr;
    private Socket SocketObj = null;//客户端的socket  
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
    //发送消息
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

    //验证
    public string Verify(string server, string account, string password)
    {
        Connect();//首先连接
        WriteLine(Base64Encoder.Encoder.GetEncoded(encode_token(server, account, password)));//将所有信息转换为 base64 然后发送给服务器
        string loginServerRet = ReadLine(); //读取当前登录信息
                                            // int ret = int.Parse(loginServerRet.Substring(0, 3)); 
        Close();
        return loginServerRet;
    }
}

