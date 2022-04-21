using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text; 
using System;
namespace Config
{
    namespace Program {
        //这个类负责网络的连接 与消息的保存
        public class MessageStruct
        {
            public uint msgID;
            public int param1;
            public int param2;
            public int param3;
            public int param4;
            public uint len;
            public string data;
            public MessageStruct(byte[] msg)
            {
                
                msgID = BitConverter.ToUInt32(msg, 0); //msgID; 
                param1 = BitConverter.ToInt32(msg, 4); //param1;
                param2 = BitConverter.ToInt32(msg, 8); //param2;
                param3 = BitConverter.ToInt32(msg, 12);//param3;
                param4 = BitConverter.ToInt32(msg, 16);//param4;
                len = BitConverter.ToUInt32(msg, 20);//len;
                data = System.Text.Encoding.UTF8.GetString(msg, 24, (int)len);
            }
        }
    }  
}