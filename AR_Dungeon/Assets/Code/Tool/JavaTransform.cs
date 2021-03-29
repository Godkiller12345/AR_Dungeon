using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class JavaTransform
    {
        public static byte[] ToJavaByte(int data)
        {
            byte[] trans = BitConverter.GetBytes(data);
            byte temp;
            temp = trans[0];
            trans[0] = trans[3];
            trans[3] = temp;
            temp = trans[1];
            trans[1] = trans[2];
            trans[2] = temp;
            return trans;
        }
        public static byte[] ToJavaByte(String data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
        public static int ToINT(byte[] data,int position)
        {
            return BitConverter.ToInt32(data, position);
        }
        public static double ToDouble(byte[] data, int StartPosition)
        {
            return BitConverter.ToDouble(data, StartPosition);
        }
    }
}
