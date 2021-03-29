using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Project1
{
    class CatchBroadcast
    {
        public static void CatchAction()
        {
            while (true)
            {
                byte[] buf = new byte[1000];
                int length = Client.ActionSocket.Receive(buf);
                for (int i = 0; i < length/ActionType.ActionTypeSize; i++)
                {
                    int start = i * ActionType.ActionTypeSize;
                    int ActionID, PID, TargetID;
                    double Information1, Information2;
                    ActionID = JavaTransform.ToINT(buf, start);
                    PID = JavaTransform.ToINT(buf, start + 4);
                    TargetID = JavaTransform.ToINT(buf, start + 8);
                    Information1 = JavaTransform.ToDouble(buf, start + 12);
                    Information2 = JavaTransform.ToDouble(buf, start + 20);
                    Client.Actions.Enqueue(new ActionType(ActionID, PID, TargetID, Information1, Information2));
                }
            }
                

        }

        public static void CatchMap()
        {
            while (true)
            {
                byte[] buf = new byte[1000];
                int length = Client.MapSocket.Receive(buf);
                for (int i = 0; i < length/MapType.MapTypeSize; i++)
                {
                    int start = i * MapType.MapTypeSize;
                    int TypeID, BelongID, Level, HP, MP, State;
                    double Longitude, Latitude;
                    TypeID = JavaTransform.ToINT(buf, start);
                    BelongID = JavaTransform.ToINT(buf, start + 4);
                    Level = JavaTransform.ToINT(buf, start + 8);
                    HP = JavaTransform.ToINT(buf, start + 12);
                    MP = JavaTransform.ToINT(buf, start + 16);
                    State = JavaTransform.ToINT(buf, start + 20);
                    Longitude = JavaTransform.ToDouble(buf, start + 24);
                    Latitude = JavaTransform.ToDouble(buf, start + 32);
                    Client.Maps.Enqueue(new MapType(TypeID, BelongID, Level, HP, MP, State, Longitude, Latitude));
                }
                
            }
        }
    }
}
