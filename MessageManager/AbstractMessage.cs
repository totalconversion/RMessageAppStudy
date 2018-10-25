using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageManager
{
    public abstract class AbstractMessage
    {
        private Byte[] rawMessage;
        public abstract int Length { get; }
        public abstract string ID { get;}
        public abstract string Body { get; }
        public abstract bool IsValid { get; }
        public abstract DateTime DateTimeOn { get; }

        public Byte[] GetRawMessage()
        {
            return rawMessage;
        }

 
        protected AbstractMessage(Byte[] rawMessage)
        {
            if (rawMessage.Length == Length)
            {
                this.rawMessage = rawMessage;
            }
        }

    }
}
