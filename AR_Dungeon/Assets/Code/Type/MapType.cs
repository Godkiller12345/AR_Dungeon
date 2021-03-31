using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class MapType
    {
        //MapType Data Size
        public const int MapTypeSize = 40; //total bytes

        //MapType Data
        public int TypeID;     //like player, monster or ....
        public int BelongID;   //like PID, MID, IID....
        public int Level;
        public int HP;
        public int MP;
        public int state;      //狀態
        public double Longitude;  //經度
        public double Latitude;   //緯度

        public MapType(int typeID, int belongID, int level, int hp, int mp, int state, double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            TypeID = typeID;
            BelongID = belongID;
            this.state = state;
            Level = level;
            HP = hp;
            MP = mp;
        }

    }
}
