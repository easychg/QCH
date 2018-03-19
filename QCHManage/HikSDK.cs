using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace QCHManage
{
    public class HikSDK
    {
        public const string dllName = "HCNetSDK.dll";


        [DllImport(dllName)]
        public static extern bool NET_DVR_Init();
        [DllImport(dllName)]
        public static extern bool NET_DVR_Cleanup();
        [DllImport(dllName)]
        public static extern int NET_DVR_Login_V30(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, out LPNET_DVR_DEVICEINFO_V301 lpDeviceInfo);
        [DllImport(dllName)]
        public static extern bool NET_DVR_Logout(int lUserID);
        [DllImport(dllName)]
        public static extern int NET_DVR_RealPlay(int lUserID, ref NET_DVR_CLIENTINFO lpClientInfo);
        [DllImport(dllName)]
        public static extern bool NET_DVR_StopRealPlay(int lRealHandle);
        [DllImport(dllName)]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref LPNET_DVR_TIME lpStartTime, ref LPNET_DVR_TIME lpStopTime, string sSavedFileName);
        [DllImport(dllName)]
        public static extern int NET_DVR_GetDownloadPos(int lFileHandle);
        [DllImport(dllName)]
        public static extern bool NET_DVR_StopGetFile(int lFileHandle);

        [DllImport(dllName)]
        public static extern int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref LPNET_DVR_TIME lpStartTime, ref LPNET_DVR_TIME lpStopTime, IntPtr hWnd);
        [DllImport(dllName)]
        public static extern bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, out uint LPOutValue);

        [DllImport(dllName)]
        public static extern bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);
        [DllImport(dllName)]
        public static extern bool NET_DVR_StopPlayBackSave(int lPlayHandle);


        public struct NET_DVR_CLIENTINFO
        {
            public int lChannel;
            public int lLinkMode;
            public IntPtr hPlayWnd;
            public string sMultiCastIP;
        }
        public struct LPNET_DVR_DEVICEINFO_V301
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public byte[] sSerialNumber;
            public byte byAlarmInPortNum;
            public byte byAlarmOutPortNum;
            public byte byDiskNum;
            public byte byDVRType;
            public byte byChanNum;
            public byte byStartChan;
            public byte byAudioChanNum;
            public byte byIPChanNum;
            public byte byZeroChanNum;
            public byte byMainProto;
            public byte bySubProto;
            public byte bySupport;
            public byte bySupport1;
            public byte byRes1;
            public int wDevType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
            public byte[] byRes2;
        }
        public struct LPNET_DVR_TIME
        {
            public uint dwYear;
            public uint dwMonth;
            public uint dwDay;
            public uint dwHour;
            public uint dwMinute;
            public uint dwSecond;

        }
    }
}
