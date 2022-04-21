using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using LightJson;
using System;
using Config;
using Config.Program; 
public class MsgCell
{
    public int IsStart;
    public int LenData;
    public byte[] LenArray;
    public byte[] Data;
    public int Offset;
    int status;
    public MsgCell()
    {
        IsStart = 0;
        LenArray = new byte[2];
    }
    public void InitData()
    {
        IsStart = -1;
        Offset = 0;
        Data = new byte[LenData];
    }
    public bool IsComplete()
    {
        return Offset == LenData;
    }
    public int NeedResidueNumber()
    {
        return LenData - Offset;
    }
    //加入头
    public void AddHead(byte[] msg, ref int startIndex, int len)
    {
        if (startIndex >= len)
            return;
        if (IsStart == -1)
            return;
        if (IsStart == 2)
        {
            //解析当前需要的长度 
            byte temp = LenArray[0];
            LenArray[0] = LenArray[1];
            LenArray[1] = temp;
            LenData = BitConverter.ToUInt16(LenArray, 0);//首先校验当前数组的长度 
            InitData();//初始化当前的数据
            return;
        }
        LenArray[IsStart] = msg[startIndex];
        IsStart += 1;
        startIndex += 1;
        AddHead(msg, ref startIndex, len);
    }
    public int AddData(byte[] msg, ref int startIndex, int len)
    {
        if (startIndex >= len) //长度直接出现了错误
            return -1;
        int needNum = NeedResidueNumber();//获取到当前需要多少个
        if (needNum == 0)
            return 0;
        int ownerNum = len - startIndex;//获取到当前有多少个
        int copyNum = ownerNum > needNum ? needNum : ownerNum;//获取到当前可以加入几个  
        Array.Copy(msg, startIndex, Data, Offset, copyNum);
        startIndex += copyNum;
        Offset += copyNum;
        return copyNum;
    }

}

public class NetWorkMsgUtil
{
    public AnalysisObj AnalysisVar;
    static public int MemorySize = 1024 * 1024 * 3;//一个3MB的网络空间   
    MsgCell NowCell = null;
    Queue<MsgCell> MsgList = new Queue<MsgCell>();
    public byte[] Buffer = new byte[MemorySize];
    public NetWorkMsgUtil()
    {
        AnalysisVar = new AnalysisObj();
    }

    //添加数据到缓冲区
    public void RecordMsg(byte[] msg, int len)
    {   //当前开始的位置
        int startIndex = 0;
        while (true)
        {
            if (NowCell == null)
                NowCell = new MsgCell();
            NowCell.AddHead(msg, ref startIndex, len);//首先判断当前的数据信息 
            if (NowCell.AddData(msg, ref startIndex, len) == -1)
            {
                break;
            }
            if (NowCell.IsComplete())
            {
                MsgList.Enqueue(NowCell);
                NowCell = null;
            }
        }
    }

    //开始解析
    public List<MessageStruct> AnalysisMsg()
    {
        List<MessageStruct> ret;
        AnalysisVar.AnalysisFunc(MsgList, out ret);
        return ret;
    }

    public string PackMsg(string str)
    {
        return AnalysisVar.PackMsg(str);
    }
}

