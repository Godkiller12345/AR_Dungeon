using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ReadType
    {
        public int Protocol;
        public byte[] data;

        public ReadType(int protocol, byte[] data)
        {
            Protocol = protocol;
            this.data = data;
        }
    }
}
