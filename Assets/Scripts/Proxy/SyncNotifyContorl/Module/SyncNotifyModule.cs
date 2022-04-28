using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJson;
using MVCFrame;
using Config.Program;
using ProxySpace;
using UnityEngine.UI;
namespace ModuleCellSpace
{
    public class SyncDataCell {
        public string CmdName; 
        public object[] List;
        public SyncDataCell(string cmdName , params object[] list)
        {
            CmdName = cmdName; 
            List = list;
        }
    }

    public class SyncNotifyModule : ModuleCell
    { 
        public Queue<SyncDataCell> ImageList = new Queue<SyncDataCell>();
        public void PushMessage(string cmdName, object data = null, params object[] list)
        {
            ImageList.Enqueue(new SyncDataCell(cmdName, data, list));
        }
        public SyncDataCell PopMessage()
        {
            if (ImageList.Count == 0)
                return null;
            return ImageList.Dequeue();
        }
        public override void OnInit()
        { 
        } 
        public void Tick()
        {
            SyncDataCell cell = PopMessage();
            if ( cell == null )
                return; 
            Sys.GetFacade().NotifyObserver(cell.CmdName,cell.List);
        }
    }
}