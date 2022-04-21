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
    //����ͷ
    public void AddHead(byte[] msg, ref int startIndex, int len)
    {
        if (startIndex >= len)
            return;
        if (IsStart == -1)
            return;
        if (IsStart == 2)
        {
            //������ǰ��Ҫ�ĳ��� 
            byte temp = LenArray[0];
            LenArray[0] = LenArray[1];
            LenArray[1] = temp;
            LenData = BitConverter.ToUInt16(LenArray, 0);//����У�鵱ǰ����ĳ��� 
            InitData();//��ʼ����ǰ������
            return;
        }
        LenArray[IsStart] = msg[startIndex];
        IsStart += 1;
        startIndex += 1;
        AddHead(msg, ref startIndex, len);
    }
    public int AddData(byte[] msg, ref int startIndex, int len)
    {
        if (startIndex >= len) //����ֱ�ӳ����˴���
            return -1;
        int needNum = NeedResidueNumber();//��ȡ����ǰ��Ҫ���ٸ�
        if (needNum == 0)
            return 0;
        int ownerNum = len - startIndex;//��ȡ����ǰ�ж��ٸ�
        int copyNum = ownerNum > needNum ? needNum : ownerNum;//��ȡ����ǰ���Լ��뼸��  
        Array.Copy(msg, startIndex, Data, Offset, copyNum);
        startIndex += copyNum;
        Offset += copyNum;
        return copyNum;
    }

}

public class NetWorkMsgUtil
{
    public AnalysisObj AnalysisVar;
    static public int MemorySize = 1024 * 1024 * 3;//һ��3MB������ռ�   
    MsgCell NowCell = null;
    Queue<MsgCell> MsgList = new Queue<MsgCell>();
    public byte[] Buffer = new byte[MemorySize];
    public NetWorkMsgUtil()
    {
        AnalysisVar = new AnalysisObj();
    }

    //������ݵ�������
    public void RecordMsg(byte[] msg, int len)
    {   //��ǰ��ʼ��λ��
        int startIndex = 0;
        while (true)
        {
            if (NowCell == null)
                NowCell = new MsgCell();
            NowCell.AddHead(msg, ref startIndex, len);//�����жϵ�ǰ��������Ϣ 
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

    //��ʼ����
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

