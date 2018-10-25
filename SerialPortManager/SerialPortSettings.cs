using System.IO.Ports;
using System.ComponentModel;


namespace SerialPortManager
{

    /// <summary>
    /// Настройки  
    /// </summary>
    public class SerialPortSettings : INotifyPropertyChanged
    {

        #region Fields

        string portName;
        int baudRate;
        Parity parity;
        int dataBits;
        StopBits stopBits;

        #endregion

        #region Properties
        /// <summary>
        /// Port name
        /// </summary>
        public string PortName
        {
            get { return portName; }
            set
            {
                if (!portName.Equals(value))
                {
                    portName = value;
                    RaisePropertyChangedEvent("PortName");
                }
            }
        }


        /// <summary>
        /// Baud rate
        /// </summary>
        public int BaudRate
        {
            get { return baudRate; }
            set
            {
                if (baudRate != value)
                {
                    baudRate = value;
                    RaisePropertyChangedEvent("BaudRate");
                }
            }
        }

        /// <summary>
        /// Parity 
        /// </summary>
        public Parity Parity
        {
            get { return parity; }
            set
            {
                if (parity != value)
                {
                    parity = value;
                    RaisePropertyChangedEvent("Parity");
                }
            }
        }
        /// <summary>
        /// Data bits value
        /// </summary>
        public int DataBits
        {
            get { return dataBits; }
            set
            {
                if (dataBits != value)
                {
                    dataBits = value;
                    RaisePropertyChangedEvent("DataBits");
                }
            }
        }
        /// <summary>
        /// Stop bits value
        /// </summary>
        public StopBits StopBits
        {
            get { return stopBits; }
            set
            {
                if (stopBits != value)
                {
                    stopBits = value;
                    RaisePropertyChangedEvent("StopBits");
                }
            }
        }

        #endregion

        #region Collections

        string[] portNameCollection;
        int[] baudRateCollection;
        Parity[] parityCollection;
        int[] dataBitsCollection;
        StopBits[] stopBitsCollection;

        public SerialPortSettings()
        {
            InitCollections();
            InitSettings();
        }
        
        public SerialPortSettings(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            InitCollections();
            PortName = portName;
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
        }
        #endregion

        #region Initialization
        private void InitCollections()
        {
            portNameCollection = InitPortNames();
            baudRateCollection = InitBaudRateCollection();
            parityCollection = InitParityCollection();
            dataBitsCollection = InitBitsCollection();
            stopBitsCollection = InitstopBitsCollection();
        }

        private void InitSettings()
        {
            portName = portNameCollection[0]; //portNameCollection.FirstOrDefault(); //portNameCollection[1];
            baudRate = 9600;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;

        }

        private StopBits[] InitstopBitsCollection()
        {
            return new StopBits[] { StopBits.One, StopBits.OnePointFive, StopBits.Two};
        }

        private int[] InitBitsCollection()
        {
            return new int[] { 5, 6, 7, 8 };
        }

        private Parity[] InitParityCollection()
        {
            return new Parity[] { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
        }

        private int[] InitBaudRateCollection()
        {
            return new int[] {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000 , 256000};
        }

        private string[] InitPortNames()
        {
            return SerialPort.GetPortNames();
        }
        #endregion

       

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
