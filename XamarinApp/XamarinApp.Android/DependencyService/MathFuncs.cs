using XamarinApp.Droid.DependencyService;
using XamarinApp.Droid.Models;
using XamarinApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathFuncs))]
namespace XamarinApp.Droid.DependencyService
{
    public class MathFuncs : IMathFuncs
    {
        public double Add(double a, double b)
        {
            MyMathFuncs o = new MyMathFuncs();
            return o.Add(a, b);
        }
        public double Subtract(double a, double b)
        {
            MyMathFuncs o = new MyMathFuncs();
            return o.Subtract(a, b);
        }
        public double Multiply(double a, double b)
        {
            MyMathFuncs o = new MyMathFuncs();
            return o.Multiply(a, b);
        }
        public double Divide(double a, double b)
        {
            MyMathFuncs o = new MyMathFuncs();
            return o.Divide(a, b);
        }
    }
}