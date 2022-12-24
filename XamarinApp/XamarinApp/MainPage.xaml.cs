using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Interfaces;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        string operation = "+";
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Clicked(object sender, EventArgs e)
        {
            double a;
            double b;
            try
            {
                a = double.Parse(aEnt.Text);
                b = double.Parse(bEnt.Text);
            }
            catch
            {
                resultLbl.Text = "Error!";
                return;
            }

            double c = double.NaN;

            switch (operation) 
            {
                case "+":
                    c = DependencyService.Get<IMathFuncs>().Add(a, b);
                    break;
                case "-":
                    c = DependencyService.Get<IMathFuncs>().Subtract(a, b);
                    break;
                case "*":
                    c = DependencyService.Get<IMathFuncs>().Multiply(a, b);
                    break;
                case "/":
                    c = DependencyService.Get<IMathFuncs>().Divide(a, b);
                    break;
            }

            resultLbl.Text = $"{a} {operation} {b} = {c}";
        }

        private void OnOperationRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var rbtn = (RadioButton)sender;
            switch ((string)rbtn.Content)
            {
                case "Add":
                    operation = "+";
                    break;
                case "Subtract":
                    operation = "-";
                    break;
                case "Multiply":
                    operation = "*";
                    break;
                case "Divide":
                    operation = "/";
                    break;
            }
        }
    }
}
