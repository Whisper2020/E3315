using System;
using System.IO.Ports;
using System.Text;

namespace PortControlDemo
{
    public class Port_Data_Send
    {
       
       
        // 串行端口对象
        private SerialPort sp;       
        // 串口接收数据委托      
        public delegate void ComReceiveDataHandler(string data);
        public ComReceiveDataHandler OnComReceiveDataHandler = null;
        // 端口名称数组   
        public string[] PortNameArr { get; set; }
        // 串口通信开启状态 
        public bool PortState { get; set; } = false;     
        // 编码类型
        public Encoding EncodingType { get; set; } = Encoding.ASCII;     
        public Port_Data_Send()
        {
            PortNameArr = SerialPort.GetPortNames();
            sp = new SerialPort();
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }     
        public void OpenPort(string portName , int boudRate = 115200, int dataBit = 8, int stopBit = 1, int timeout = 5000)
        {
            try
            {
                sp.PortName = portName;
                sp.BaudRate = boudRate;
                sp.DataBits = dataBit;
                sp.StopBits = (StopBits)stopBit;
                sp.ReadTimeout = timeout;
                sp.Open();
                PortState = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ClosePort()
        {
            try
            {
                sp.Close();
                PortState = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }  
        // 发送数据 
        public void SendData(string sendData)
        {
            try
            {
                sp.Encoding = EncodingType;
                sp.Write(sendData);
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
        // 接收数据回调用 
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[sp.BytesToRead];
            sp.Read(buffer, 0, buffer.Length);
            string str = EncodingType.GetString(buffer);
            if (OnComReceiveDataHandler != null)
            {
                OnComReceiveDataHandler(str);
            }
        }
     
    }
}
