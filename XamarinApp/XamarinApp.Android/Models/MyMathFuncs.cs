using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace XamarinApp.Droid.Models
{
    internal class MyMathFuncsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public MyMathFuncsSafeHandle() : base(true) { }

        public IntPtr Ptr => this.handle;

        protected override bool ReleaseHandle()
        {
            MyMathFuncsWrapper.DisposeMyMathFuncs(handle);
            return true;
        }
    }

    internal static class MyMathFuncsWrapper
    {
        const string DllName = "libMathFuncs.so";

        [DllImport(DllName, EntryPoint = "CreateMyMathFuncsClass")]
        internal static extern MyMathFuncsSafeHandle CreateMyMathFuncs();

        [DllImport(DllName, EntryPoint = "DisposeMyMathFuncsClass")]
        internal static extern void DisposeMyMathFuncs(IntPtr ptr);

        [DllImport(DllName, EntryPoint = "MyMathFuncsAdd")]
        internal static extern double Add(MyMathFuncsSafeHandle ptr, double a, double b);

        [DllImport(DllName, EntryPoint = "MyMathFuncsSubtract")]
        internal static extern double Subtract(MyMathFuncsSafeHandle ptr, double a, double b);

        [DllImport(DllName, EntryPoint = "MyMathFuncsMultiply")]
        internal static extern double Multiply(MyMathFuncsSafeHandle ptr, double a, double b);

        [DllImport(DllName, EntryPoint = "MyMathFuncsDivide")]
        internal static extern double Divide(MyMathFuncsSafeHandle ptr, double a, double b);
    }

    public class MyMathFuncs : IDisposable
    {
        readonly MyMathFuncsSafeHandle handle;

        public MyMathFuncs()
        {
            handle = MyMathFuncsWrapper.CreateMyMathFuncs();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (handle != null && !handle.IsInvalid)
                handle.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public double Add(double a, double b)
        {
            return MyMathFuncsWrapper.Add(handle, a, b);
        }

        public double Subtract(double a, double b)
        {
            return MyMathFuncsWrapper.Subtract(handle, a, b);
        }

        public double Multiply(double a, double b)
        {
            return MyMathFuncsWrapper.Multiply(handle, a, b);
        }

        public double Divide(double a, double b)
        {
            return MyMathFuncsWrapper.Divide(handle, a, b);
        }
    }

}