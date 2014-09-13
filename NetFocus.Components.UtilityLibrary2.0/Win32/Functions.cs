using System;
using System.Runtime.InteropServices;

namespace NetFocus.Components.UtilityLibrary.Win32
{
	/// <summary>
	/// Windows API Functions
	/// </summary>
	public class WindowsAPI
	{

		// No need to construct this object
		private WindowsAPI()
		{
		}

		// Constans values
		#region
		public const string TOOLBARCLASSNAME = "ToolbarWindow32";
		public const string REBARCLASSNAME = "ReBarWindow32";
		public const string PROGRESSBARCLASSNAME = "msctls_progress32";
		#endregion

		// CallBacks
		#region
		public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
		#endregion

		// Kernel32.dll functions
		#region
		[DllImport("kernel32.dll", ExactSpelling=true, CharSet=CharSet.Auto)]
		public static extern int GetCurrentThreadId();
		#endregion
	
		// Gdi32.dll functions
		#region
		[DllImport("gdi32.dll")]
		static public extern bool StretchBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
			IntPtr hDCSrc,  int XOriginScr, int YOriginSrc, int WidthScr, int HeightScr, uint Rop);
		[DllImport("gdi32.dll")]
		static public extern IntPtr CreateCompatibleDC(IntPtr hDC);
		[DllImport("gdi32.dll")]
		static public extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int Width, int Heigth);
		[DllImport("gdi32.dll")]
		static public extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
		[DllImport("gdi32.dll")]
		static public extern bool BitBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
			IntPtr hDCSrc,  int XOriginScr, int YOriginSrc, uint Rop);
		[DllImport("gdi32.dll")]
		static public extern IntPtr DeleteDC(IntPtr hDC);
		[DllImport("gdi32.dll")]
		static public extern bool PatBlt(IntPtr hDC, int XLeft, int YLeft, int Width, int Height, uint Rop);
		[DllImport("gdi32.dll")]
		static public extern bool DeleteObject(IntPtr hObject);
		[DllImport("gdi32.dll")]
		static public extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
		[DllImport("gdi32.dll")]
		static public extern int SetMapMode(IntPtr hDC, int fnMapMode);
		[DllImport("gdi32.dll")]
		static public extern int GetObjectType(IntPtr handle);
		[DllImport("gdi32")]
		public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi, 
			int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
		[DllImport("gdi32")]
		public static extern int GetDIBits(IntPtr hDC, IntPtr hbm, int StartScan, int ScanLines, int lpBits, BITMAPINFOHEADER bmi, int usage);
		[DllImport("gdi32")]
		public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, int StartScan, int ScanLines, int lpBits, ref BITMAPINFO_FLAT bmi, int usage);
		[DllImport("gdi32")]
		public static extern IntPtr GetPaletteEntries(IntPtr hpal, int iStartIndex, int nEntries, byte[] lppe);
		[DllImport("gdi32")]
		public static extern IntPtr GetSystemPaletteEntries(IntPtr hdc, int iStartIndex, int nEntries, byte[] lppe);
		[DllImport("gdi32")]
		public static extern uint SetDCBrushColor(IntPtr hdc,  uint crColor);
		[DllImport("gdi32")]
		public static extern IntPtr CreateSolidBrush(uint crColor);
		[DllImport("gdi32")]
		public static extern int SetBkMode(IntPtr hDC, BackgroundMode mode);
		#endregion

		// Uxtheme.dll functions
		#region
		[DllImport("uxtheme.dll")]
		static public extern int SetWindowTheme(IntPtr hWnd, string AppID, string ClassID);
		#endregion
	
		// User32.dll functions
		#region
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool ShowWindow(IntPtr hWnd, short State);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool UpdateWindow(IntPtr hWnd);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool OpenClipboard(IntPtr hWndNewOwner);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool CloseClipboard();
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool EmptyClipboard();
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern IntPtr SetClipboardData( uint Format, IntPtr hData);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
		[DllImport("user32.dll", ExactSpelling=true, CharSet=CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref POINT lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref REBARBANDINFO lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TVITEM lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HDITEM lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HD_HITTESTINFO hti);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhook);
		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetFocus(IntPtr hWnd);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd,  IntPtr rect, int bErase);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool WaitMessage();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TranslateMessage(ref MSG msg);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DispatchMessage(ref MSG msg);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SetCursor(IntPtr hCursor);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetFocus();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ReleaseCapture();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern ushort GetKeyState(int virtKey);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetClassName(IntPtr hWnd,  out STRINGBUFFER ClassName, int nMaxCount);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);
		#endregion
		
		// Common Controls functions
		#region
		[DllImport("comctl32.dll")]
		public static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);
		[DllImport("comctl32.dll", EntryPoint="DllGetVersion")]
		public extern static int GetCommonControlDLLVersion(ref DLLVERSIONINFO dvi);
		#endregion

	}

}
