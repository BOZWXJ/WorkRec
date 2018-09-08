using System;
using System.Runtime.InteropServices;

namespace WorkRec.Lib
{
	public static class WinAPI
	{
		[DllImport("user32.dll")]
		public static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);

		[StructLayout(LayoutKind.Sequential)]
		public struct FLASHWINFO
		{
			public UInt32 cbSize;
			public IntPtr hwnd;
			public FLASHWFLAGS dwFlags;
			public UInt32 uCount;
			public UInt32 dwTimeout;
		}

		[Flags]
		public enum FLASHWFLAGS : uint
		{
			/// <summary>
			/// 点滅を止める
			/// </summary>
			FLASHW_STOP = 0,
			/// <summary>
			/// タイトルバーを点滅させる
			/// </summary>
			FLASHW_CAPTION = 1,
			/// <summary>
			/// タスクバー・ボタンを点滅させる
			/// </summary>
			FLASHW_TRAY = 2,
			/// <summary>
			/// タスクバー・ボタンとタイトルバーを点滅させる
			/// </summary>
			FLASHW_ALL = 3,
			/// <summary>
			/// FLASHW_STOPが指定されるまでずっと点滅させる
			/// </summary>
			FLASHW_TIMER = 4,
			/// <summary>
			/// ウィンドウが最前面に来るまでずっと点滅させる
			/// </summary>
			FLASHW_TIMERNOFG = 12
		}

		public const int WM_QUERYENDSESSION = 0x11;
	}
}
