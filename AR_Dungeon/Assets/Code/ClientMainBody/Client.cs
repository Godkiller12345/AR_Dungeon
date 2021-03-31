using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Project1
{
    public class Client
    {
        public static Queue<ActionType> Actions = new Queue<ActionType>();
        public static Queue<MapType> Maps = new Queue<MapType>();
        public static Queue<ReadType> Mission = new Queue<ReadType>();

        public const int USER_PORT = 8001;
        public const int ACTION_PORT = 8002;
        public const int MAP_PORT = 8003;
        public const String SERVER_ADDRESS = "127.0.0.1";
        public static Socket UserSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket ActionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket MapSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static bool debug = true;

        public static void Main()
        {
            try
            {
                UserSocket.Connect(SERVER_ADDRESS, USER_PORT);
                ActionSocket.Connect(SERVER_ADDRESS, ACTION_PORT);
                MapSocket.Connect(SERVER_ADDRESS, MAP_PORT);

                //new process to catch action and map
                Thread action = new Thread(new ThreadStart(CatchBroadcast.CatchAction));
                action.Start();
                Thread map = new Thread(new ThreadStart(CatchBroadcast.CatchMap));
                map.Start();

                //Read action and call correspond function
                while (true)
                {
                    foreach (ActionType a in Actions)
                    {
                        switch (a.ActionID)
                        {
                            //action call by server
                            //please put Action model in case 
                            //ActionID is in ActionType
                            case ActionType.MOVE:
                                break;

                            default:
                                if (debug)
                                {
                                    Console.WriteLine("Error ActionID");
                                }
                                {
                                    break;
                                }
                        }
                    }
                }

                /*
                 * test send
                while (true)
                {
                    int protacol = Convert.ToInt32(Console.ReadLine());
                    String msg = Console.ReadLine();
                    byte[] sendint = JavaTransform.ToJavaByte(protacol);
                    byte[] sendstr = JavaTransform.ToJavaByte(msg);
                    byte[] send = new byte[sendint.Length + sendstr.Length];
                    Buffer.BlockCopy(sendint, 0, send, 0, sendint.Length);
                    Buffer.BlockCopy(sendstr, 0, send, 4, sendstr.Length);

                    UserSocket.Send(send);

                }
                */
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }


}
