using System;
using System.IO.Ports;

namespace SerialPortManager
{
    public class RecievedMessageEventArgs : EventArgs
    {
        public RecievedMessageEventArgs(byte[] rawData)
        {
            RawData = rawData;
        }
        public byte[] RawData;
    }
    /// <summary>
    /// Класс для прослушивания com-порта
    /// </summary>
    public class SerialPortListener : IDisposable
    {
        #region Fields

        private SerialPort serialPort;
        private SerialPortSettings serialPortSettings;

        private bool isListening = false;
        public SerialPortListener()
        {
            serialPortSettings = new SerialPortSettings(); 
        }

        public SerialPortListener(String serialPortName) : this()
        {
            this.serialPortSettings.PortName = serialPortName;
        }
        public SerialPortListener(SerialPortSettings serialPortSettings)
        {
            this.serialPortSettings = serialPortSettings;
        }

        public bool IsListening => isListening;

        #endregion

        #region Events

        public event EventHandler<RecievedMessageEventArgs> RawMessageRecieved;

        public override string ToString()
        {
            return "Port: " + serialPortSettings.PortName + " Listening: " + IsListening;
        }

        void serialPortSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           //TDOO dynamic property collections lists renew 
        }


        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
            byte[] data = new byte[serialPort.BytesToRead];
            if (serialPort.Read(data, 0, serialPort.BytesToRead) == 0)
                return;
            if (RawMessageRecieved != null)
            {
                
                RawMessageRecieved(this, new RecievedMessageEventArgs(data));
            }
        }

        /// <summary>
        ///  Открываем порт с настройками
        /// </summary>
        public void Start()
        {
            if (serialPort != null && serialPort.IsOpen)
                serialPort.Close();

            serialPort = new SerialPort(
                serialPortSettings.PortName,
                serialPortSettings.BaudRate,
                serialPortSettings.Parity,
                serialPortSettings.DataBits,
                serialPortSettings.StopBits);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            try
            {
                serialPort.Open();
                isListening = true;
            }
            catch (System.UnauthorizedAccessException e)
            {
                isListening = false;
                //throw;
            }
            finally
            {
                //
            }
        }

        /// <summary>
        /// Закрываем порт
        /// </summary>
        public void Stop()
        {
            serialPort.Close();
        }

        public void Dispose()
        {
           if (serialPort != null)
            {
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
            }
        }


        #endregion

    }
}
