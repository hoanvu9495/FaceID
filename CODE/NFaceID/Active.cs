using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Windows;
using System.Threading;
using System.IO;
using System.Net.Sockets;
//using lib;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace NFaceID
{
    public class Active
    {
        //call native c

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AT_init( out IntPtr ptr);

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendOrderLicense(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String ip, int port);

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void generate_key(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String str, out IntPtr key);

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getCPUKey(IntPtr ptr, out IntPtr key);

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ActiveKey(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String key);

        [DllImport("NRMonitor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int checkLicense(IntPtr ptr);

        public IntPtr m_active = new IntPtr();
        public Active()  // contructor
        {
            AT_init(out m_active);
        }
        ~Active()  // destructor
        {
            // cleanup statements...
        }
        public bool SendOrderLicense( String ip, int port, List<string> message)
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            try
            {
                clientSocket.Connect(ip, port);
                // clientSocket.
                Stream stm = clientSocket.GetStream();
                string s = "";
                for (int i = 0; i < message.Count; i++)
                {
                    s += message[i] + "$";
                }
                //byte[] outStream = System.Text.Encoding.ASCII.GetBytes(s);
                byte[] outStream = Encoding.Unicode.GetBytes(s);
                stm.Write(outStream, 0, outStream.Length);                                    
                //stm.Flush();
                stm.Close();
                clientSocket.Close();
                return true;//SendOrderLicense( m_active, ip, port);
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public String generateKey(String code)
        {
 
            var pointer = new IntPtr(); //Pointer to be used by the native function
            string name = null; //result string
            generate_key(m_active, code, out pointer);
            name = Marshal.PtrToStringAnsi(pointer); //access the vin's pointer and convert to string
            return name;
        }
        public string getseriacode()
        {
            var pointer = new IntPtr(); //Pointer to be used by the native function
            string name = null; //result string
            getCPUKey(m_active, out pointer);
            name = Marshal.PtrToStringAnsi(pointer); //access the vin's pointer and convert to string
            return name;
        }
        public bool Register(String s)
        {
            return ActiveKey(m_active, s);
        }
        //1: actived
        //0: chua dang ky
        //2: het han
        //3: fake
        public int checkRegister()
        {
            return checkLicense(m_active);
        }
    }
}
