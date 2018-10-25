using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageManager
{
    public class DeviceMessage : AbstractMessage
    {
        /// <summary>
        /// 
        /// </summary>
        private string id;
        private string body;
        private bool isValid = true;
        private DateTime dateTimeOn;
        private static int length = 3;

        public override string ID => id;

        public override string Body => body;

        public override bool IsValid => isValid;

        public override DateTime DateTimeOn => dateTimeOn;

        public override int Length => length;

        static int GetLength()
        {
            return length;
        }

        public DeviceMessage(Byte[] rawMessage, DateTime dateTimeMessage):base(rawMessage)
        {
            id = GetId();
            body = GetBody();
            isValid = IsMessageValid();

            dateTimeOn = dateTimeMessage;

        }

        private string GetId()
        {
            return GetRawMessage()[0].ToString();
        }

        private string GetBody()
        {
            return GetRawMessage()[1].ToString();
        }

        private bool CheckSumIsValid()
        {
            return (GetRawMessage()[2] == (GetRawMessage()[0] ^ GetRawMessage()[1]) );
           
        }
        private bool IdIsValid()
        {
            Byte messageId = GetRawMessage()[0];
            Byte minVal = 0x41;
            Byte maxVal = 0x5A;

            return (messageId >= minVal && messageId <= maxVal);
        }

        private bool IsMessageValid()
        {
            return (IdIsValid() && CheckSumIsValid());
        }

    }
}
