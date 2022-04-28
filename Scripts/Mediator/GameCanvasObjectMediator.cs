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
        public BaseMediator Mediator;
        public Transform Object;
        public AddTypeStruct(BaseMediator mediator, CanvasNodeIndex type, Transform obj)
        {
            Type = type;
            Object = obj;
            Mediator = mediator;
        }
    }

    public class GameCanvasObjectMediator : Mediator
    {
        Transform RootNode;//对应的节点 
        private Dictionary<string, List<AddTypeStruct>> MediatorManagerList = new Dictionary<string, List<AddTypeStruct>>();//管理的节点 
        private Dictionary<CanvasNodeIndex, Transform> LayoutNodeList = new Dictionary<CanvasNodeIndex, Transform>();
        public GameCanvasObjectMediator()
        {
            AddHandle("AdditionCanvasObject", AdditionCanvasObjectHandle);
            AddHandle("DeleteCanvasObject", DeleteCanvasObjectHandle);
        }
        void CloseAllLayer()
        {
            foreach(var temp in MediatorManagerList)
            {
                Sys.GetFacade().NotifyObserver(temp.Value[0].Mediator.CloseLayerNotifyName,0);//发送关闭界面的消息 
            }
        }
        public override void OnRemove()
        {
            base.OnRemove();
            CloseAllLayer();
        }
        void DeleteCanvasObjectHandle(Notifycation param)
        { 
            var mediator = param.GetData<BaseMediator>(1);
            var obj = param.GetData<Transform>(1); 
            if (mediator == null || obj == null)
            {
                Debug.LogError("传入到界面管理的参数有误(删除)");
                return;
            }
            var mediatorName = mediator.GetType().Name;
            if (!MediatorManagerList.ContainsKey(mediatorName))
                return;
            List<AddTypeStruct> objList = MediatorManagerList[mediatorName]; 
            for(int index = 0; index < objList.Count; index ++)
            {
                if ( objList[index].Object == obj )
                {
                    objList.RemoveAt(index);
                    break;
                }
            }
            if (objList.Count == 0)
                MediatorManagerList.Remove(mediatorName); 
        }
        void AdditionCanvasObjectHandle(Notifycation param)
        { 
            var mediator = param.GetData<BaseMediator>(1);
            var obj = param.GetData<Transform>(2);
            CanvasNodeIndex type = param.GetData<CanvasNodeIndex>(3);
            if (mediator == null || obj == null) {
                Debug.LogError("传入到界面管理的参数有误");
                return;
            }
            AddTypeStruct typeObj = new AddTypeStruct(mediator, type, obj);
            if (!MediatorManagerList.ContainsKey(mediator.GetType().Name))
                MediatorManagerList[mediator.GetType().Name] = new List<AddTypeStruct>();
            MediatorManagerList[mediator.GetType().Name].Add(typeObj);
            obj.transform.SetParent(LayoutNodeList[type],false);   
        } 
        public override void OnRegister()
        {
            base.OnRegister();
            RootNode = GameObject.Find("GameCanvas").transform;
            LayoutNodeList.Add(CanvasNodeIndex.LEFT_TOP      , RootNode.Find("LeftTop"));
            LayoutNodeList.Add(CanvasNodeIndex.LEFT_CENTER   , RootNode.Find("LeftCenter"));
            LayoutNodeList.Add(CanvasNodeIndex.LEFT_BOTTOM   , RootNode.Find("LeftBottom"));
            LayoutNodeList.Add(CanvasNodeIndex.RIGHT_TOP     , RootNode.Find("RightTop"));
            LayoutNodeList.Add(CanvasNodeIndex.RIGHT_CENTER  , RootNode.Find("RightCenter"));
            LayoutNodeList.Add(CanvasNodeIndex.RIGHT_BOTTOM  , RootNode.Find("RightBottom"));
            LayoutNodeList.Add(CanvasNodeIndex.CENTER_TOP    , RootNode.Find("CenterTop"));
            LayoutNodeList.Add(CanvasNodeIndex.CENTER        , RootNode.Find("Center"));
            LayoutNodeList.Add(CanvasNodeIndex.CENTER_BOTTOM , RootNode.Find("CenterBottom"));
        }
    }
}