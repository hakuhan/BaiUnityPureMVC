using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC;

namespace TheDispatcher
{
    public delegate void EventListenerDelegate(Message evt);
    public class Dispatcher : Singleton<Dispatcher>, IDispatcher
    {

        private System.Collections.Generic.Dictionary<int, EventListenerDelegate> events = new System.Collections.Generic.Dictionary<int, EventListenerDelegate>();
        private System.Collections.Generic.Dictionary<string, EventListenerDelegate> custom_events = new System.Collections.Generic.Dictionary<string, EventListenerDelegate>();

        /// <summary>
        /// 公共事件 添加
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void AddListener(int type, EventListenerDelegate listener)
        {
            if (listener == null)
            {
                UnityEngine.Debug.LogWarning("AddListener :listener 为空");
                return;
            }

            EventListenerDelegate myListener = null;
            events.TryGetValue(type, out myListener);
            events[type] = (EventListenerDelegate)System.Delegate.Combine(myListener, listener);
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void AddListener(string type, EventListenerDelegate listener)
        {
            if (type == "") { UnityEngine.Debug.LogWarning("AddListener:type 为空"); }
            if (listener == null)
            {
                UnityEngine.Debug.LogWarning("AddListener :listener 为空");
                return;
            }

            EventListenerDelegate myListener = null;
            custom_events.TryGetValue(type, out myListener);
            custom_events[type] = (EventListenerDelegate)System.Delegate.Combine(myListener, listener);
        }

        /// <summary>
        /// 公共事件 移除
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void RemoveListener(int type, EventListenerDelegate listener)
        {
            if (listener == null)
            {
                UnityEngine.Debug.LogWarning("AddListener :listener 为空");
                return;
            }

            events[type] = (EventListenerDelegate)System.Delegate.Remove(events[type], listener);
        }


        /// <summary>
        /// 自定义事件 移除
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public void RemoveListener(string type, EventListenerDelegate listener)
        {
            if (listener == null)
            {
                UnityEngine.Debug.LogWarning("AddListener :listener 为空");
                return;
            }

            custom_events[type] = (EventListenerDelegate)System.Delegate.Remove(custom_events[type], listener);
        }

        public void Clear()
        {
            events.Clear();
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="evt"> Message消息体</param>
        public void SendMessage(Message evt)
        {
            EventListenerDelegate listenerDelegate;
            if (events.TryGetValue(evt.Type, out listenerDelegate))
            {
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("SendMessage :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

        public void SendMessage(int type, params System.Object[] param)
        {
            EventListenerDelegate listenerDelegate;
            if (events.TryGetValue(type, out listenerDelegate))
            {
                Message evt = new Message(type, param);
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("SendMessage :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

        public void Brocast(string type, params System.Object[] param)
        {
            EventListenerDelegate listenerDelegate;
            if (custom_events.TryGetValue(type, out listenerDelegate))
            {
                Message evt = new Message(type, param);
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("Brocast :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

        public void Brocast(string type, object sender, System.Object body)
        {
            EventListenerDelegate listenerDelegate;
            if (custom_events.TryGetValue(type, out listenerDelegate))
            {
                //判断是否个单个参数《？？？？？》
                bool type2 = body.GetType().IsArray;
                Message evt = new Message(type, sender, body);
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("Brocast :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

        public void Brocast(string type, object sender, System.Object[] param)
        {
            EventListenerDelegate listenerDelegate;
            if (custom_events.TryGetValue(type, out listenerDelegate))
            {
                Message evt = new Message(type, sender, param);
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("Brocast :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

        public void Brocast(string type)
        {
            EventListenerDelegate listenerDelegate;
            if (custom_events.TryGetValue(type, out listenerDelegate))
            {
                Message evt = new Message(type);
                try
                {
                    if (listenerDelegate != null)
                    {
                        listenerDelegate(evt);
                    }
                }
                catch (System.Exception o)
                {
                    UnityEngine.Debug.LogWarning("Brocast :" + evt.Type.ToString() + "   " + o.Message + "   " + o.StackTrace);
                }
            }
        }

    }
}
