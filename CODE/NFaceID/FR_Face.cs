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
    public class FR_Face
    {
        //call native c
        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FR_Init(out IntPtr ptr);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_loadConfig(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file);


        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_enroll(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_enroll_once_image(IntPtr ptr, IntPtr src, [MarshalAs(UnmanagedType.LPStr)] String name);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FR_load_trained(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String _folder);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FR_recognize(IntPtr ptr, IntPtr query, out double confi);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_recognizeFromImage(IntPtr ptr, IntPtr src, out double confident, out int id, out IntPtr output);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_RecognizeAge(IntPtr ptr, IntPtr src, out int age);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_RecognizeGender(IntPtr ptr, IntPtr src, out IntPtr output);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FR_TrainOneFolder(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String _folder, out IntPtr feat);


        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_ListFeatureToFile(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file, IntPtr feat);

        [DllImport("FaceCall.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FR_ListFeatureFromFile(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] String file, out IntPtr feat);

        public IntPtr m_face_recognize = new IntPtr();
        public FR_Face()  // contructor
        {
            FR_Init(out m_face_recognize);
        }
        ~FR_Face()  // destructor
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
            return FR_loadConfig(m_face_recognize, config);
        }
        public bool enroll( [MarshalAs(UnmanagedType.LPStr)] String file)
        {
            return FR_enroll(m_face_recognize, file);
        }
        public void load_trained( [MarshalAs(UnmanagedType.LPStr)] String _folder)
        {
            FR_load_trained(m_face_recognize, _folder);
        }
        public int recognize( IntPtr query, out double confi)
        {
            return FR_recognize(m_face_recognize, query, out confi);
        }

        public bool recognizeFromImage( Bitmap src, out double confident, out int id, out String output)
        {
            var pointer = new IntPtr(); //Pointer to be used by the native function
            bool res = false;
            Image<Bgr, byte> img = new Image<Bgr, byte>(src);
            res = FR_recognizeFromImage(m_face_recognize, img.Ptr, out confident, out id, out pointer);
            output = Marshal.PtrToStringAnsi(pointer); //access the vin's pointer and convert to string
            img.Dispose();
            return res;

        }
        public bool enroll_one_image(Bitmap src, String name)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(src);
            bool res = false;
            res = FR_enroll_once_image(m_face_recognize, img.Ptr, name);
            img.Dispose();
            return res;
        }
        public int recognizeAge(Bitmap src)
        {
            int age = 0;
            bool res = false;
            Image<Bgr, byte> img = new Image<Bgr, byte>(src);
            res = FR_RecognizeAge(m_face_recognize, img.Ptr, out age);
            img.Dispose();
            return age;
        }
        public String recognizeGender(Bitmap src)
        {
            String output = "";
            var pointer = new IntPtr(); //Pointer to be used by the native function
            bool res = false;
            Image<Bgr, byte> img = new Image<Bgr, byte>(src);
            res = FR_RecognizeGender(m_face_recognize, img.Ptr, out pointer);
            output = Marshal.PtrToStringAnsi(pointer); //access the vin's pointer and convert to string
            img.Dispose();
            return output;
        }
        public void TrainOneFolder( [MarshalAs(UnmanagedType.LPStr)] String _folder, out IntPtr feat)
        {
            FR_TrainOneFolder(m_face_recognize, _folder, out feat);
        }
        public bool ListFeatureToFile( [MarshalAs(UnmanagedType.LPStr)] String file, IntPtr feat)
        {
            return FR_ListFeatureToFile(m_face_recognize, file, feat);
        }
        public bool ListFeatureFromFile( [MarshalAs(UnmanagedType.LPStr)] String file, out IntPtr feat)
        {
            return FR_ListFeatureFromFile(m_face_recognize, file, out feat);
        }
    }
}

