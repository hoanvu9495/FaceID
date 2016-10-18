using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using lib;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace NFaceID
{
    public class VideoCapture
    {

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initCamera(out IntPtr cap);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setResolution(IntPtr cap, int w, int h);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isExistCamera([MarshalAs(UnmanagedType.LPStr)] String file, ref bool val);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenWebcam(int index, out IntPtr cap);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenFileVideo([MarshalAs(UnmanagedType.LPStr)] String file, out IntPtr cap);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenCamera([MarshalAs(UnmanagedType.LPStr)] String file, out IntPtr cap);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RetrievalFrame(IntPtr capture, ref IntPtr frane);

        

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseCamera(ref IntPtr capture);


        public IntPtr m_capture = new IntPtr();
        public bool isOpen = false;
        public VideoCapture()
        {
            initCamera(out m_capture);
        }
        ~VideoCapture()
        {
            if (isOpen)
                ReleaseCamera(ref m_capture);
        }
        public void Dispose()
        {
            if (isOpen)
                ReleaseCamera(ref m_capture);
            isOpen = false;
            m_capture = (IntPtr)null;
        }
        public bool Open(int index)
        {
            isOpen = OpenWebcam(index, out m_capture);
            return isOpen;
        }
        public bool Open(string url, int w, int h)
        {
            setResolution(m_capture, w, h);
            isOpen = OpenCamera(url, out m_capture);
            return isOpen;
        }
        public bool OpenVideo(string url)
        {
            isOpen = OpenFileVideo(url, out m_capture);
            return isOpen;
        }
        public bool queryFrame(ref Bitmap bmp)
        {
            if (isOpen)
            {
                IntPtr frame = (IntPtr)null;
                bool res = RetrievalFrame(m_capture, ref frame);
                if (frame != null && res)
                {
                    if (frame != null)
                    {
                        if (bmp != null)
                            bmp.Dispose();
                        bmp = Ultis.ConvertIntPrToBitmap(frame);
                        //release frame;
                        Ultis.ReleaseImage(ref frame);
                        if (bmp == null)
                            return false;
                        return true;
                    }
                    return false;
                    
                }
                //bmp.Dispose();
                return res;
            }
            return false;
        }

        public bool checkState(string url)
        {
            bool val = false;
            isExistCamera(url, ref val);
            return val;
        }

    }
}
