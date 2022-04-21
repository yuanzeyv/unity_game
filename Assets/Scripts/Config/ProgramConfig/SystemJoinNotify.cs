using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    namespace Program
    {
        enum SYSTEM_ID
        {
            PokerSystem = 3,
        };
        public class SystemJoinNotify
        {
            private static SystemJoinNotify InstanceObj;
            public static SystemJoinNotify Instance()
            {
                if (InstanceObj == null)
                    InstanceObj = new SystemJoinNotify();
                return InstanceObj;
            }
            private Dictionary<int, string> SystemMsg = new Dictionary<int, string>();
            public static Dictionary<int, string> GetSystemMsg { get { return Instance().SystemMsg; } }
            public SystemJoinNotify()
            {
                SystemMsg[(int)SYSTEM_ID.PokerSystem] = "OepnBambooHallChooseLayer";
            }

        }
    }
}