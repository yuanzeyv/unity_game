using MVCFrame;
using System.Collections.Generic;
using Config.Program;
using UnityEngine;

//这是mvc框架的一个初始化
namespace MVCFrame
{
    //一个 系统代理 可能会有多个 BaseModule 
    public class ModuleCell
    {
        //与当前模块管理的代理
        public Proxy RelavancyProxy;
        //当前模块被赋予的名称
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
        //初始化网络消息监听 
        public virtual void OnRemove()
        {
        }
    }
}
