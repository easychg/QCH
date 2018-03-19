using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCHManage
{

    public struct Contractdata
    {
        public static string contractno;
        public static string time;
        public static string news;
        public static string hwname;
        public static string ghunit;
        public static string shunit;
        public static double htzl;
        public static double yysl;
    }

    public struct  Truckdata
    {
        public static string id;
        public static string kcode;
        public static string carnumber;
        public static string cx;
        public static string jsy;
        public static string lxdh;
        public static double cpz;
        public static string htno;
        public static double bzweight;
        public static string homeunit;
    }

    public class Classdata
    {
        public static int ContractFlag;
        public static int TruckFlag;
    }
}
