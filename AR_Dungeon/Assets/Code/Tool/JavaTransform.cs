using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class JavaTransform
    {
        // ToJavaByte will transform things to byte array in java type
        public static byte[] ToJavaByte(int data)
        {
            byte[] trans = BitConverter.GetBytes(data);
            byte tmp;
            for (int i = 0; i < 2; i++)
            {
                tmp = trans[i];
                trans[i] = trans[3 - i];
                trans[3 - i] = tmp;
            }
            return trans;
        }
        public static byte[] ToJavaByte(String data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
        public static byte[] ToJavaByte(double data)
        {
            byte[] trans = BitConverter.GetBytes(data);
            byte tmp;
            for (int i = 0; i < 4; i++)
            {
                tmp = trans[i];
                trans[i] = trans[7 - i];
                trans[7 - i] = tmp;
            }
            return trans;
        }


        // Byte array to Data
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
