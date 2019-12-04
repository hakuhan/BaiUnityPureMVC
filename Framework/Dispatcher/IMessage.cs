namespace TheDispatcher
{
    public interface IMessage
    {

        /// <summary>
        /// 事件类型
        /// </summary>
        int Type { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 发送者
        /// </summary>
        System.Object Sender { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        System.Object[] Params { get; set; }

        System.Object Body { get; set; }

        /// <summary>
        /// 转化字符串
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
