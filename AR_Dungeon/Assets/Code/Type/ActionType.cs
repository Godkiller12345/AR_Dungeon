using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ActionType
    {
        //Please write ActionID in here
        public const int MOVE = 1;


        //Action Data Size
        public const int ActionTypeSize = 28;

        //Action Data
        public int ActionID;
        public int PlayID;
        public int TargetID;
        public double Information1;
        public double Information2;

        public ActionType(int AID, int PID, int TargetID, double I1, double I2)
        {
            this.ActionID = AID;
            this.PlayID = PID;
            this.TargetID = TargetID;
            this.Information1 = I1;
            this.Information2 = I2;
        }
    }
}
