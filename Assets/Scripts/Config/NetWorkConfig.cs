using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Config
{
    public class NetWorkConfig
    {
        private static NetWorkConfig _instance = null;
        public int Port { get; }
        public string ServerAddr { get; } 

        private NetWorkConfig()
        {
            ServerAddr = "39.103.201.92";
            Port = 8888;
        }
        public static NetWorkConfig Instance()
        {
            if (_instance == null)
                _instance = new NetWorkConfig();
            return _instance;
        }

    }
}
