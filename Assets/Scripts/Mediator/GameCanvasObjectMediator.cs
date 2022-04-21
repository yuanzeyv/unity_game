using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVCFrame;
using LayerSpace;
using ProxySpace;
namespace MediatorSpace
{
    public enum CanvasNodeIndex { 
        LEFT_TOP = 1,
        LEFT_CENTER = 2,
        LEFT_BOTTOM = 3,
        RIGHT_TOP = 4,
        RIGHT_CENTER = 5,
        RIGHT_BOTTOM = 6 ,
        CENTER_TOP = 7,
        CENTER = 8,
        CENTER_BOTTOM = 9,
    }
    public class AddTypeStruct {
        public CanvasNodeIndex Type;
        public Transform Trans;
        public AddTypeStruct(CanvasNodeIndex type, Transform trans)
        {
            Type = type;
            Trans = trans;
        }
    }

    public class GameCanvasObjectMediator : Mediator
    {
        GameObject RootNode;//对应的节点 
        private Dictionary<int, GameObject> LayoutNodeList = new Dictionary<int, GameObject>();//管理的节点
        private Dictionary<string, GameObject> WindowList = new Dictionary<string, GameObject>();//管理的节点
        public GameCanvasObjectMediator()
        { 
            AddHandle("AdditionCanvasObject", AdditionCanvasObjectHandle); 
        }
        void AdditionCanvasObjectHandle(Notifycation param, params object[] paramList)
        {
            AddTypeStruct obj = param.GetData<AddTypeStruct>();
            if (!LayoutNodeList.ContainsKey((int)obj.Type))
                return;
            if (!obj.Trans)
                return; 
            obj.Trans.SetParent(LayoutNodeList[(int)obj.Type].transform,false); 
        } 
        public override void OnRegister()
        {
            base.OnRegister();
            RootNode = GameObject.Find("GameCanvas");
            LayoutNodeList.Add((int)CanvasNodeIndex.LEFT_TOP      , GameObject.Find("LeftTop"));
            LayoutNodeList.Add((int)CanvasNodeIndex.LEFT_CENTER   , GameObject.Find("LeftCenter"));
            LayoutNodeList.Add((int)CanvasNodeIndex.LEFT_BOTTOM   , GameObject.Find("LeftBottom"));
            LayoutNodeList.Add((int)CanvasNodeIndex.RIGHT_TOP     , GameObject.Find("RightTop"));
            LayoutNodeList.Add((int)CanvasNodeIndex.RIGHT_CENTER  , GameObject.Find("RightCenter"));
            LayoutNodeList.Add((int)CanvasNodeIndex.RIGHT_BOTTOM  , GameObject.Find("RightBottom"));
            LayoutNodeList.Add((int)CanvasNodeIndex.CENTER_TOP    , GameObject.Find("CenterTop"));
            LayoutNodeList.Add((int)CanvasNodeIndex.CENTER        , GameObject.Find("Center"));
            LayoutNodeList.Add((int)CanvasNodeIndex.CENTER_BOTTOM , GameObject.Find("CenterBottom"));
        }
    }
}