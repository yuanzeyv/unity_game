using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using LightJson;
using System;
using Config.Program;
 
//��Ҫ���ܾ��������׳����������������������ݽ���
public class AnalysisObj
{
    public virtual void AnalysisFunc(Queue<MsgCell> MsgList, out List<MessageStruct> ret)
    {
        ret = new List<MessageStruct>();
        while (MsgList.Count > 0)
        {
            MsgCell tempCell = MsgList.Peek();//��ѯ��һ�� 
            if (tempCell == null || !tempCell.IsComplete())//�ж��Ƿ������
                break;
            MsgList.Dequeue();
            ret.Add(new MessageStruct(tempCell.Data));
        }
    }
    //�����Ϣ
    public string PackMsg(string str)
    {
        return string.Format("{0:D8}{1}", short.Parse(str.Length.ToString()), str);
    }
}

