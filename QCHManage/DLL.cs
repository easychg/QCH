using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace QCHManage
{
    class DLL
    {

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetTransMode", CharSet = CharSet.Unicode)]
        public static extern int SetTransMode(int handle, int TransMode, int mark, int ConType, int markid);

        [DllImport("ListenPlayDll.dll", EntryPoint = "StartSend", CharSet = CharSet.Unicode)]
        public static extern int StartSend();

        [DllImport("ListenPlayDll.dll", EntryPoint = "EndSend", CharSet = CharSet.Unicode)]
        public static extern int EndSend(int handle);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetNetworkPara", CharSet = CharSet.Unicode)]
        public static extern int SetNetworkPara(int handle, int pno, string ip);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetSerialPortPara", CharSet = CharSet.Unicode)]
        public static extern int SetSerialPortPara(int handle, int pno, int port, int rate);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddControl", CharSet = CharSet.Unicode)]
        public static extern int AddControl(int handle, int pno, int DBColor);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddProgram", CharSet = CharSet.Unicode)]
        public static extern int AddProgram(int handle, int jno, int playTime);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetProgramTimer", CharSet = CharSet.Unicode)]
        public static extern int SetProgramTimer(int handle, int pno, int jno, int TimingModel, int WeekSelect, int startSecond,
                                                 int startMinute, int startHour, int startDay, int startMonth, int startWeek, int startYear,
                                                 int endSecond, int endMinute, int endHour, int endDay, int endMonth, int endWeek,
                                                 int endYear);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddQuitText", CharSet = CharSet.Unicode)]
        public static extern int AddQuitText(int handle, int jno, int qno, int left, int top, int width, int height, int FontColor, string fontName, int fontSize, int fontBold, int Italic, int Underline, string text);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddFileArea", CharSet = CharSet.Unicode)]
        public static extern int AddFileArea(int handle, int jno, int qno, int left, int top, int width, int height, int BackBit);


        [DllImport("ListenPlayDll.dll", EntryPoint = "AddFile", CharSet = CharSet.Unicode)]
        public static extern int AddFile(int handle, int jno, int qno, int mno, string fileName, int width, int height, int playstyle,
            int QuitStyle, int playspeed, int delay, int MidText, int mode);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddTimerArea", CharSet = CharSet.Unicode)]
        public static extern int AddTimerArea(int handle, int jno, int qno, int left, int top, int width, int height,
                                              int fontColor, string fontName, int fontSize, int fontBold, int Italic, int Underline,
                                              int mode, int DayShow, int CulWeek, int CulDay, int CulHour, int CulMin, int CulSec,
                                              int year, int week, int month, int day, int hour, int minute, int second);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddDClockArea", CharSet = CharSet.Unicode)]
        public static extern int AddDClockArea(int handle, int jno, int qno, int left, int top, int width, int height,
                                               int fontColor, string fontName, int fontSize, int fontBold, int Italic, int Underline,
                                               int year, int week, int month, int day, int hour, int minute, int second, int TwoOrFourYear,
                                               int HourShow, int format, int spanMode, int Advacehour, int Advaceminute);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddLnTxtArea", CharSet = CharSet.Unicode)]
        public static extern int AddLnTxtArea(int handle, int jno, int qno, int left, int top, int width, int height, string LnFileName, int PlayStyle, int Playspeed, int times);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AddFileString", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int AddFileString(int pno, int jno, int qno, int mno, string str, string strFont, int fontsize, int fontcolor, bool bold, bool italic, bool underline, int Duiqi, int width, int height, int playstyle, int QuitStyle, int playspeed, int delay, int MidText);


        [DllImport("ListenPlayDll.dll", EntryPoint = "SendControl", CharSet = CharSet.Unicode)]
        public static extern int SendControl(int handle, int SendType, IntPtr hwnd);


        [DllImport("ListenPlayDll.dll", EntryPoint = "SendScreenPara", CharSet = CharSet.Unicode)]
        public static extern int SendScreenPara(int handle, int dbcolor, int widht, int height);

        [DllImport("ListenPlayDll.dll", EntryPoint = "AdjustTime", CharSet = CharSet.Unicode)]
        public static extern int AdjustTime(int handle, IntPtr hwnd);


        [DllImport("ListenPlayDll.dll", EntryPoint = "AddLnTxtString", CharSet = CharSet.Unicode)]
        public static extern int AddLnTxtString(int handle, int jno, int qno, int left, int top, int width, int height, string str, string strFont, int fontsize, int fontcolor, bool bold, bool italic, bool underline, int PlayStyle, int Playspeed, int times);


        [DllImport("ListenPlayDll.dll", EntryPoint = "AddNeiMaTxtArea1", CharSet = CharSet.Unicode)]

        public static extern int AddNeiMaTxtArea1(int handle, int jno, int qno, int left, int top, int width, int
                              height, string showtext, int ShowStyle, int fontname, int fontcolor, int PlayStyle, int
                              QuitStyle, int Playspeed, int times);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetScreenInfo", CharSet = CharSet.Unicode)]
        public static extern int SetScreenInfo(int handle, ScreenInfo si);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SearchController2", CharSet = CharSet.Unicode)]
        public static extern int SearchController2(int handle, string filepath, bool broacast, int value);


        [DllImport("ListenPlayDll.dll", EntryPoint = "SetPower", CharSet = CharSet.Unicode)]
        public static extern int SetPower(int handle, int value);

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScreenInfo
    {
        public int screenwidth;
        public int screenheight;
        public int dbcolor;
        public int baud;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string screenname;
    }

}
