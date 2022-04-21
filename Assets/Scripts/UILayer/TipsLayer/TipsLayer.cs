using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsLayer:LayerBase
{
    public Transform ModuleCell_Text;
    public Transform Transform;
    private Queue<Transform> unUsePool = new Queue<Transform>();//对象缓冲池子 
    private Queue<string> AddQueue = new Queue<string>();
    private Queue<Transform> TipsQueue = new Queue<Transform>();

    // 创建15个池子对象
    private void CreatePool()
    {
        for(int i = 0; i < 15 ; i++)
        {
            Transform obj = GameObject.Instantiate(ModuleCell_Text, Transform, false);
            unUsePool.Enqueue(obj); 
        }
    }

    private void Start()
    {
        CreatePool(); 
    }

    void JudgeCanAdd()
    {
        if (AddQueue.Count > 0 && unUsePool.Count > 0)//如果当前可以添加，并且当前未使用对象池有对象
        { 
            if (!(TipsQueue.Count > 0 && TipsQueue.ToArray()[TipsQueue.Count - 1].localPosition.y < -260))
            {
                Transform obj = unUsePool.Dequeue();
                string str = AddQueue.Dequeue();
                obj.gameObject.SetActive(true);
                Text text = obj.GetComponent<Text>();
                text.text = str;
                TipsQueue.Enqueue(obj);
            } 
        }
    }
    void MoveAllUseTrans()
    {
        foreach (var item in TipsQueue)
        {
            Text text = item.GetComponent<Text>();
            Vector3 pos = item.localPosition;
            Color color = text.color;
            float percent = (Mathf.Abs((Mathf.Lerp(pos.y, 0.0f, 0.3f))) / 330);//(300 / 2 ) 
            float offset = percent * Time.deltaTime * 1.5f ; 
            pos.y += offset * 330 ;
            item.localPosition = pos;
            color.a -= (offset * 0.95f);
            text.color = color;
        } 
        if (TipsQueue.Count != 0)
        {
            Transform firstItem = TipsQueue.Peek();
            if (firstItem && firstItem.localPosition.y >= -75)
            {
                Transform obj = TipsQueue.Dequeue();
                obj.gameObject.SetActive(false); 
                obj.transform.localPosition = new Vector3(0, -330, 0);//初始化当前的对象位置
                Text text = obj.GetComponent<Text>();
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                unUsePool.Enqueue(obj);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        JudgeCanAdd();
        MoveAllUseTrans();
    }
    //书信界面
    override public void RefreshAssignLayer(int index, object param)
    { 
        AddQueue.Enqueue(param as string); 
    }
}
