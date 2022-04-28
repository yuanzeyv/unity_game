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
<<<<<<< HEAD
        public string CmdName; 
        public object[] List;
        public SyncDataCell(string cmdName , params object[] list)
        {
            CmdName = cmdName; 
=======
        public string CmdName;
        public object Data;
        public object[] List;
        public SyncDataCell(string cmdName, object data = null, params object[] list)
        {
            CmdName = cmdName;
            Data = data;
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
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
<<<<<<< HEAD
            Sys.GetFacade().NotifyObserver(cell.CmdName,cell.List);
=======
            Sys.GetFacade().NotifyObserver(cell.CmdName,cell.Data,cell.List);
>>>>>>> b23e7a4f415aa4e1e531cb8433c539ec3ab83bb1
        }
    }
}