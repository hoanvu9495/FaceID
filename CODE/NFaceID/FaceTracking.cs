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
    public class FaceTracking
    {

        //[DllImport("testwarp.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool FT_init(out IntPtr ptr);

        //call native c
        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_init(out IntPtr ptr);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_initSize(IntPtr ptr, int w, int h);



        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_release(out IntPtr ptr);


        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_loadConfig(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_SetROI(IntPtr ptr, int x, int y, int w, int h);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_SetSave(IntPtr ptr, bool val);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_update(IntPtr ptr, IntPtr img);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_getFaceImage(IntPtr ptr, int index, out IntPtr dst);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_setRecognize_status(IntPtr ptr, int index, bool val);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_getRecognize_status(IntPtr ptr, int index, out bool val);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_getSize(IntPtr ptr, out int size);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FT_getLocation(IntPtr ptr, int index, out int x, out int y, out int w, out int h);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool  FT_getTimeStart(IntPtr ptr, int index, out int year, out int month, out int day, out int hour, out int minute, out int second);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_get_ID(IntPtr ptr, int index, out IntPtr id);


        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_getAppear(IntPtr ptr, int index, out int appear);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool getDimesion(IntPtr src, out int width, out int height, out int channel);


        public IntPtr m_face_tracking = new IntPtr();

        public FaceTracking()  // contructor
        {
            FT_init(out m_face_tracking);
        }
        ~FaceTracking()  // destructor
        {
            // cleanup statements...
            Dispose();
        }
        public void Dispose()
        {
            // cleanup statements...
            //release(out m_face_tracking);
        }
        public bool loadConfig(String config)
        {
            return FT_loadConfig(m_face_tracking, config);
        }
        public Bitmap ConvertIntPrToBitmap(IntPtr ptrImage, int w, int h)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(w, h);
            CvInvoke.cvCopy(ptrImage, image.Ptr, (IntPtr)null);
            Bitmap a = image.ToBitmap();
            image.Dispose();
            image = null;
            return a;
        }
        public void initSize(int w, int h)
        {
            FT_initSize(m_face_tracking, w, h);
        }
        public void setRectangle(Rectangle rc)
        {
            FT_SetROI(m_face_tracking, rc.X, rc.Y, rc.Width, rc.Height);
        }
        public void setSave( bool val)
        { 
            FT_SetSave(m_face_tracking, val);
        }
        public void update(Bitmap bitmap)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(bitmap);
            FT_update(m_face_tracking, img.Ptr);
            img.Dispose();
        }
        public bool getFaceImage(int index, ref Bitmap bmp)
        {
            IntPtr frame;
            bool res = FT_getFaceImage(m_face_tracking, index, out frame);
            if (!res || frame == (IntPtr)0)
                return false;
            if (bmp != null)
                bmp.Dispose();
            bmp = Ultis.ConvertIntPrToBitmap(frame);
            Ultis.ReleaseImage(ref frame);
            return res;
        }
        public DateTime getStartTime(int index)
        {
            int y,m,d,h,mi,s;
            bool res = FT_getTimeStart(m_face_tracking,  index, out y, out m, out d, out h, out mi, out s);
            if (res)
            {
                DateTime t = new DateTime(y, m, d, h, mi, s);
                return t;
            }
            return DateTime.Now;
        }
        public bool setRecognize_status(int index, bool val)
        {
            return FT_setRecognize_status(m_face_tracking, index, val);
        }
        public bool getRecognize_status(int index)
        {
            bool res = false;
            bool a = FT_getRecognize_status(m_face_tracking, index, out res);
            return res;
        }
        public String get_ID_Name(int index)
        {
            var pointer = new IntPtr(); //Pointer to be used by the native function
            string name = null; //result string
            FT_get_ID(m_face_tracking, index, out pointer);
            name = Marshal.PtrToStringAnsi(pointer); //access the vin's pointer and convert to string
            return name;
        }
        public int getSize()
        {
            int size = 0;
            FT_getSize(m_face_tracking, out size);
            return size;
        }
        public Rectangle getLocation(int index)
        {
            Rectangle rc = new Rectangle(0, 0, 0, 0);
            int x, y, w, h;
            var result = FT_getLocation(m_face_tracking, index, out x, out y, out w, out h);
            if (result)
            {
                rc.X = x;
                rc.Y = y;
                rc.Width = w;
                rc.Height = h;
            }
            return rc;
        }
        
        public int getAppear(int index)
        {
            int count = 0;
            FT_getAppear(m_face_tracking, index, out count);
            return count;
        }

        public Rectangle Extend(Rectangle rec, int w, int h)
        {
            Rectangle rc = new Rectangle();
            int _w = rec.Width + (int)(rec.Width * 0.5);
            int _h = rec.Height + (int)(rec.Height * 0.5);
            int x = rec.X - (_w - rec.Width) / 2;
            int y = rec.Y - (_h - rec.Height) / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if ((x + _w) >= w) _w = w - x - 1;
            if ((y + _h) >= h) _h = h - y - 1;

            return new Rectangle(x, y, _w, _h); ;
        }
    }
}
