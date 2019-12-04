using System;
using System.Collections.Generic;
using PureMVC;

namespace TheDispatcher
{
    public interface IDispatcher
    {
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        void AddListener(int type, EventListenerDelegate listener);

        /// <summary>
        /// 自定义添加事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="listener"></param>
        void AddListener(string name, EventListenerDelegate listener);

        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        void RemoveListener(int type, EventListenerDelegate listener);

        /// <summary>
        /// 移除自定义事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        void RemoveListener(string type, EventListenerDelegate listener);

        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="evt"></param>
        void SendMessage(Message evt);

        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param"></param>
        void SendMessage(int type, params System.Object[] param);

        void Brocast(string name);
        /// <summary>
        /// 自定义
        /// </summary>
        /// <param name="name"></param>
        /// <param name="param"></param>
        void Brocast(string name, params System.Object[] param);

        /// <summary>
        /// 清除事件
        /// </summary>
        void Clear();
    }
}
