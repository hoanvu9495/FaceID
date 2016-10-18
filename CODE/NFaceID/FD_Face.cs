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
    public class FD_Face
    {
        //call native c
        [DllImport("FaceInvoke.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FD_Init(out IntPtr ptr);

        [DllImport("FaceInvoke.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FD_LoadConfig( ref IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file);

        [DllImport("FaceInvoke.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FD_Detect(IntPtr ptr, IntPtr img, out int x, out int y, out int w, out int h);

        [DllImport("FaceInvoke.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FD_DetectFaceImage(IntPtr ptr, IntPtr img, out IntPtr dst);

        [DllImport("FaceInvoke.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FD_Release(out IntPtr ptr);

        public IntPtr m_face_fd = new IntPtr();
        public FD_Face()  // contructor
        {
            FD_Init(out m_face_fd);
        }
        ~FD_Face()  // destructor
        {
            // cleanup statements...
            Dispose();
        }
        public void Dispose()
        {
            // cleanup statements...
            //FD_Release(out m_face_fd);
        }
        public bool LoadConfig(String str)
        {
            return FD_LoadConfig( ref m_face_fd, str);
        }
        public bool Detect(Bitmap bmp, ref Rectangle rc)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(bmp);
            int x, y, w, h;
            bool res = FD_Detect(m_face_fd, img.Ptr, out x, out y, out w, out h);
            if (res)
            {
                rc = new Rectangle(x, y, w, h);
                img.Dispose();
                return true;
            }
            img.Dispose();
            return false;
        }
        public Bitmap DetectFaceImage(Bitmap bmp)
        {
            Bitmap result = null;
            Image<Bgr, byte> img = new Image<Bgr, byte>(bmp);
            IntPtr face;
            bool res = FD_DetectFaceImage(m_face_fd, img.Ptr, out face);
            if (res)
            {
                result = Ultis.ConvertIntPrToBitmap(face);
                img.Dispose();
                Ultis.ReleaseImage(ref face);
                return result;
            }
            return result;

        }

    }
}
