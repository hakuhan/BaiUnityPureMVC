namespace TheDispatcher
{
    public class Message : IMessage
    {
        public int Type { get; set; }

        public string Name { get; set; }

        public System.Object Body { get; set; }

        public System.Object[] Params { get; set; }

        public System.Object Sender { get; set; }

        public System.Action Callback { get; set; }
        public override string ToString()
        {
            string arg = null;
            if (Params != null)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    if ((Params.Length > 1 && Params.Length - 1 == i) || Params.Length == 1)
                    {
                        arg += Params[i];
                    }
                    else
                    {
                        arg += Params[i] + " , ";
                    }
                }
            }

            if (Name != "")
            {
                return "Event-->> Type: " + Name + " [ sender:" + ((Sender == null) ? "null" : Sender.ToString()) + " ] " + " [params: " + ((arg == null) ? "null" : arg.ToString()) + " ] ";
            }
            else
            {
                return Type + " [ " + ((Sender == null) ? "null" : Sender.ToString()) + " ] " + " [ " + ((arg == null) ? "null" : arg.ToString()) + " ] ";
            }
        }

        public Message Clone()
        {
            return new Message(Type, Params, Sender);
        }

        public Message(int type)
        {
            Type = type;
        }

        public Message(int type, System.Action callback)
        {
            Type = type;
            Callback = callback;
        }

        public Message(string name, object body)
        {
            Name = name;
            Body = body;
        }

        public Message(int type, params System.Object[] param)
        {
            Type = type;
            Params = param;
        }

        public Message(int type, System.Object sender, params System.Object[] param)
        {
            Type = type;
            Params = param;
            Sender = sender;
        }

        public Message(string evt)
        {
            Name = evt;
        }

        public Message(string evt, params System.Object[] param)
        {
            Name = evt;
            Params = param;
        }

        public Message(string evt, System.Object sender, System.Object body)
        {
            Name = evt;
            Body = body;
            Sender = sender;
        }

        public Message(string evt, System.Object sender, System.Object[] param)
        {
            Name = evt;
            Params = param;
            Sender = sender;
        }
    }


}
