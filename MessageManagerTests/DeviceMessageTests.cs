using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MessageManager.Tests
{
    [TestClass()]
    public class DeviceMessageTests
    {
        [TestMethod()]
        public void MessageIsValidTestValid()
        {
            var validRawMessage = new byte[] { 0x42, 0x0C, 0x4E };
            var invalidIdRawMessage = new byte[] { 0x40, 0xFF, 0xBF };
            var invalidSumRawMessage = new byte[] { 0x42, 0x0C, 0x11 };

            var validMessage = new DeviceMessage(validRawMessage, DateTime.Now);
            var invalidIdMessage = new DeviceMessage(invalidSumRawMessage, DateTime.Now);
            var invalidSumMessage = new DeviceMessage(invalidIdRawMessage, DateTime.Now);
                     

            Assert.IsFalse(invalidSumMessage.IsValid);
            Assert.IsFalse(invalidIdMessage.IsValid);
            Assert.IsTrue(validMessage.IsValid);


        }
    }
}