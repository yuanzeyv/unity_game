using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using LightJson;
using System;
using Config.Program;
 
//主要功能就是向外抛出几个方法，用来进行数据解析
public class AnalysisObj
{
    public virtual void AnalysisFunc(Queue<MsgCell> MsgList, out List<MessageStruct> ret)
    {
        ret = new List<MessageStruct>();
        while (MsgList.Count > 0)
        {
            MsgCell tempCell = MsgList.Peek();//查询第一个 
            if (tempCell == null || !tempCell.IsComplete())//判断是否完成了
                break;
            MsgList.Dequeue();
            ret.Add(new MessageStruct(tempCell.Data));
        }
    }
    //打包消息
    public string PackMsg(string str)
    {
        return string.Format("{0:D8}{1}", short.Parse(str.Length.ToString()), str);
    }
}

