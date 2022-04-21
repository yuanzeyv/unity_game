using MVCFrame;
using System.Collections.Generic;
using Config.Program;
using UnityEngine;

//����mvc��ܵ�һ����ʼ��
namespace MVCFrame
{
    //һ�� ϵͳ���� ���ܻ��ж�� BaseModule 
    public class ModuleCell
    {
        //�뵱ǰģ�����Ĵ���
        public Proxy RelavancyProxy;
        //��ǰģ�鱻���������
        public string Name { get { return this.GetType().Name; } }
        public ModuleCell()
        { 
        }
        public void SetProxy(Proxy relavancyProxy)
        {
            RelavancyProxy = relavancyProxy;
        }
        public virtual void OnInit()
        {
        }
        //��ʼ��������Ϣ���� 
        public virtual void OnRemove()
        {
        }
    }
}
