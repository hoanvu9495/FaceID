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
using System.Text.RegularExpressions;
using System.Data;
namespace NFaceID
{
    public class Ultis
    {
        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool getDimesion(IntPtr src, out int w, out int h, out int channel);

        [DllImport("CameraCapture.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleaseImage(ref IntPtr capture);

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
                                            "đ",  
                                            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
                                            "í","ì","ỉ","ĩ","ị",  
                                            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
                                            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
                                            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
                                            "d",  
                                            "e","e","e","e","e","e","e","e","e","e","e",  
                                            "i","i","i","i","i",  
                                            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
                                            "u","u","u","u","u","u","u","u","u","u","u",  
                                            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        public static Bitmap ConvertIntPrToBitmap(IntPtr ptrImage)
        {
            if (ptrImage == null)
                return null;
            /*
             * Structure diagram of MIplImage type and OpenCV EmguCV in the IplImage type is the same
             * Only after the conversion, you can use the MIplImage structure of the imageData, height, width, widthStep and other data
             */
            int w, h, channel;
            bool res = getDimesion(ptrImage, out w, out h, out channel);
            if (w == 0 || h == 0)
                return null;
            if (!res)
                return null;
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(w, h);
            if (channel == 3)
                CvInvoke.cvCopy(ptrImage, image.Ptr, (IntPtr)null);
            else
                CvInvoke.cvCvtColor(ptrImage, image.Ptr, COLOR_CONVERSION.GRAY2BGR);

            Bitmap a = image.ToBitmap();
            image.Dispose();
            image = null;
            return a;
        }
    }
}
