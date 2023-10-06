using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Charis
{
    public class GDI
    {
        /// WinAPI Sharp
        // Coded by ToxidWorm
        // Signatures / DLLImports taken from pinvoke.net
        /// WinAPI Sharp

        /*
        GDI starts there, I feel like developing gdi functions in this wrapper is too much to handle for me right now.

        If you feel like contributing, I will accept as much issues and pull requests as possible, feel free to fork and modify!
        */

        public enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000
        }

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        static extern bool BitBltA([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        [return: MarshalAs(UnmanagedType.Bool)]
        public static void BitBlt(IntPtr hdc, int cx, int cy, int x, int y, IntPtr hdc2, int x1, int y1, TernaryRasterOperations dwRop)
        {
            BitBltA(hdc, cx, cy, x, y, hdc, x1, y1, dwRop);
        }

        [DllImport("gdi32.dll", EntryPoint = "StretchBlt", SetLastError = true)]
        static extern bool StretchBltA(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
        int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);
        public static void StretchBlt(IntPtr hdc, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, TernaryRasterOperations dwRop)
        {
            StretchBltA(hdc, nXOriginDest, nYOriginDest, nWidthDest, nHeightDest, hdcSrc, nXOriginSrc, nYOriginSrc, nWidthSrc, nHeightSrc, dwRop);
        }
        [DllImport("user32.dll", EntryPoint = "GetDC", SetLastError = true)]
        static extern IntPtr GetDCa(IntPtr hWnd);
        public static IntPtr GetDC(IntPtr hWnd)
        {
            IntPtr hdc = GetDCa(hWnd);
            return hdc;
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateSolidBrush", SetLastError = true)]
        static extern IntPtr CreateSolidBrushA(uint crColor);
        public static IntPtr CreateSolidBrush(uint crColor)
        {
            return CreateSolidBrushA(crColor);
        }
        [DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObjectA([In] IntPtr hdc, [In] IntPtr hgdiobj);
        public static void SelectObject(IntPtr hdc, IntPtr hgdiobj)
        {
            SelectObjectA(hdc, hgdiobj);
        }
        [DllImport("gdi32.dll", EntryPoint = "PatBlt", SetLastError = true)]
        static extern bool PatBltA(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);
        public static void PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop)
        {
            PatBltA(hdc, nXLeft, nYLeft, nWidth, nHeight, dwRop);
        }
        // GDI Ends there.
    }
}