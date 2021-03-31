using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Communication
    {
        public void Send (int protocal,byte[] data)
        {
            //call this function to send things by UserSocket
            byte[] buf = new byte[data.Length + 4];
            Buffer.BlockCopy(JavaTransform.ToJavaByte(protocal), 0, buf, 0, 4);
            Buffer.BlockCopy(data, 0, buf, 4, data.Length);
            Client.UserSocket.Send(buf);
        }

        public ReadType Read()
        {
            //call this function to read things by UserSocket and will return call back information
            byte[] buf = new byte[1000];
            int length = Client.UserSocket.Receive(buf);
            int protocol = JavaTransform.ToINT(buf, 0);
            byte[] data = new byte[length - 4];
            Buffer.BlockCopy(buf, 4, data, 0, length - 4);
            return new ReadType(protocol, data);
        }
    }
}
