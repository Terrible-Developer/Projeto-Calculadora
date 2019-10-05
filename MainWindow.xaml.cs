using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjetoCalculadora
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string num = "0";
        private string num2;
        private bool isSecondNumber = false; //Defines whether the current number is the first or second one
        private bool decimal1 = false;
        private bool decimal2 = false;
        private string operation;

        //Brush backz = new LinearGradientBrush(Colors.LightSkyBlue, Colors.AliceBlue, 50); //Window Background Brush
        Brush butz = new LinearGradientBrush(Colors.Ivory, Colors.RoyalBlue, 50); // First Button Style Brush
        Brush butg = new LinearGradientBrush(Colors.Goldenrod, Colors.MidnightBlue, 30); // Second Button Style Brush

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string nameproperty = null)  // Gets the caller name as the method is called, instead of needing to specify it
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameproperty));
        }

        /*Operation Methods*/

        //Adds a number
        private void AddNum(string tnum)
        {
            if (!isSecondNumber)
            {
                if (Num == "0")
                {
                    Num = tnum;
                }
                else
                {
                    Num += tnum;
                }
            }
            else
            {
                if (Num2 == "0")
                {
                    Num2 = tnum;
                }
                else
                {
                    Num2 += tnum;
                }
            }
        }

        //First Number       
        public string Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged();
            }
        }
        
        //Second Number
        public string Num2
        {
            get { return num2; }
            set
            {
                num2 = value;
                OnPropertyChanged();
            }
        }
        //Operator
        public string Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                OnPropertyChanged();
            }
        }

        //Final Result
        public string Calc
        {
            get
            {
                double result = 0;
                if (Operation == "+") //Plus
                {
                    try
                    {
                        result = double.Parse(Num) + double.Parse(Num2);
                    }
                    catch
                    {
                        ArgumentNullException argnull = new ArgumentNullException();
                    }
                    return result.ToString();
                }
                else if (Operation == "-") //Minus
                {
                    try
                    {
                        result = double.Parse(Num) - double.Parse(Num2);
                    }
                    catch
                    {
                        ArgumentNullException argnull = new ArgumentNullException();
                    }
                    return result.ToString();
                }
                else if (Operation == "*") //Times
                {
                    try
                    {
                        result = double.Parse(Num) * double.Parse(Num2);
                    }
                    catch
                    {
                        ArgumentNullException argnull = new ArgumentNullException();
                    }
                    return result.ToString();
                }
                else if (Operation == "÷") //Division
                {
                    try
                    {
                        result = double.Parse(Num) / double.Parse(Num2);
                    }
                    catch
                    {
                        ArgumentNullException argnull = new ArgumentNullException();
                    }
                    return result.ToString();
                }
                else if (Operation == "P") //Power
                {
                    try
                    {
                        double power = double.Parse(Num);
                        double baseNum = double.Parse(Num);
                        for (int ct = 1; ct < int.Parse(Num2); ct++)
                        {
                            power *= baseNum;
                        }
                        result = power;
                    }
                    catch
                    {
                        ArgumentNullException argnull = new ArgumentNullException();
                    }
                    return result.ToString();
                }
                else if (Operation == "²√") //Square Root
                {
                    result = Math.Sqrt(double.Parse(Num));
                    return result.ToString();
                }
                else if (Operation == "%") //Percentage
                {
                    double n1 = double.Parse(Num);
                    double n2 = double.Parse(Num2);
                    result = (n2 * 100) / n1;
                    return result.ToString();
                }
                return "0";
            }
            set { }
        }

        /*All Operation Button Clicks*/
        //Defines Operation as a Addition (Adds the second number to the first)
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Operation = "+";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Defines Operations as a subtraction (Subtracts the second numbere from the first)
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Operation = "-";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Defines Operation as a Multiplication (Multiplies the first number times the second) 
        private void Times_Click(object sender, RoutedEventArgs e)
        {
            Operation = "*";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;

                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Defines Operation as a Division (Divides the first number for the second)
        private void Div_Click(object sender, RoutedEventArgs e)
        {
            Operation = "÷";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Defines Operation as a Power (Uses the first number as the base and the second number as the exponent)
        private void Power_Click(object sender, RoutedEventArgs e)
        {
            Operation = "P";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Reset (Resets Both Numbers)
        private void C_Click(object sender, RoutedEventArgs e)
        {
            isSecondNumber = false;
            Num2 = "";
            Num = "0";
            Operation = "";
            OnPropertyChanged();
        }
        //Current Reset (Resets only the current number)
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (isSecondNumber)
            {
                Num2 = "0";
                OnPropertyChanged();
            }
            else
            {
                Num = "0";
                OnPropertyChanged();
            }
        }
        //Make the current number negative/positive (Multiplies the current number to -1)
        private void MakeNegative_Click(object sender, RoutedEventArgs e)
        {
            if (isSecondNumber)
            {
                if (Num2 != null)
                {
                    double nNum2 = double.Parse(Num2);
                    nNum2 *= -1;
                    Num2 = nNum2.ToString();
                    OnPropertyChanged();
                }
            }
            else
            {
                double nNum = double.Parse(Num);
                nNum *= -1;
                Num = nNum.ToString();
                OnPropertyChanged();
            }
        }
        //Calculates the square root of the first number (Does not use a second number, obviously)
        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            if (!isSecondNumber)
            {
                Operation = "²√";
                Num = Calc;
                Operation = "";
                OnPropertyChanged();
            }
        }
        //Calculates a percentage (calculates the second number as a percentage of the first number EX: 100 % 10 = 10)
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            Operation = "%";
            if (!isSecondNumber)
            {
                isSecondNumber = true;
                OnPropertyChanged();
            }
            else
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }
        }
        //Adds a comma to the number
        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!isSecondNumber)
            {
                if (!decimal1)
                {
                    Num += ",";
                    decimal1 = true;
                    OnPropertyChanged();
                }
            }
            else
            {
                if (!decimal2 && Num2 != null)
                {
                    Num2 += ",";
                    decimal2 = true;
                    OnPropertyChanged();
                }
            }
        }
        //Backspace Button, Remove Last Char
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (!isSecondNumber)
            {
                try
                {
                    if (Num.Count() > 1)
                    {
                        string pointtest1 = Num.Substring(Num.Count() - 1);
                        if (pointtest1 == ",")
                        {
                            decimal1 = false;
                        }
                        Num = Num.Remove(Num.Count() - 1);
                    }
                    else
                    {
                        Num = "0";
                    }
                }
                catch
                {
                    ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
                }
            }
            else
            {
                try
                {
                    if (Num2.Count() > 1)
                    {
                        string pointtest2 = Num2.Substring(Num2.Count() - 1);
                        if (pointtest2 == ",")
                        {
                            decimal2 = false;
                        }
                        Num2 = Num2.Remove(Num2.Count() - 1);
                    }
                    else
                    {
                        Num2 = "0";
                    }
                }
                catch
                {
                    ArgumentNullException ex = new ArgumentNullException();
                }
            }
        }
        //Finishes the current operation
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (Num2 != null)
            {
                Num = Calc;
                Num2 = null;
                Operation = "";
                decimal1 = false;
                decimal2 = false;
                OnPropertyChanged();
            }
        }
        //All Number Button Clicks
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            AddNum("0");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddNum("1");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AddNum("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            AddNum("3");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            AddNum("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            AddNum("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            AddNum("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            AddNum("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            AddNum("8");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            AddNum("9");
        }
        //All Keyboard Hotkeys (Clone Functions inside Window Keydown Method)
        private void Calc_KeyDown(object sender, KeyEventArgs e)
        {
            /*Operation/Function Keys*/
            //Press Backspace Key
            if (e.Key == Key.Back)
            {
                if (!isSecondNumber)
                {
                    try
                    {
                        string pointtest1 = Num.Substring(Num.Count() - 1);
                        if (pointtest1 == ",")
                        {
                            decimal1 = false;
                        }
                        Num = Num.Remove(Num.Count() - 1);
                    }
                    catch
                    {
                        ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    try
                    {
                        string pointtest2 = Num2.Substring(Num2.Count() - 1);
                        if (pointtest2 == ",")
                        {
                            decimal2 = false;
                        }
                        Num2 = Num2.Remove(Num2.Count() - 1);
                    }
                    catch
                    {
                        ArgumentNullException ex = new ArgumentNullException();
                    }
                }
            }
            //Press + Key
            if (e.Key == Key.Add)
            {
                Operation = "+";
                if (!isSecondNumber)
                {
                    isSecondNumber = true;
                    OnPropertyChanged();
                }
                else
                {
                    if (Num2 != null)
                    {
                        Num = Calc;
                        Num2 = null;
                        decimal1 = false;
                        decimal2 = false;
                        OnPropertyChanged();
                    }
                }
            }
            //Press - Key
            if (e.Key == Key.Subtract)
            {
                Operation = "-";
                if (!isSecondNumber)
                {
                    isSecondNumber = true;
                    OnPropertyChanged();
                }
                else
                {
                    if (Num2 != null)
                    {
                        Num = Calc;
                        Num2 = null;
                        decimal1 = false;
                        decimal2 = false;
                        OnPropertyChanged();
                    }
                }
            }
            //Press * Key
            if (e.Key == Key.Multiply)
            {
                Operation = "*";
                if (!isSecondNumber)
                {
                    isSecondNumber = true;
                    OnPropertyChanged();
                }
                else
                {
                    if (Num2 != null)
                    {
                        Num = Calc;
                        Num2 = null;

                        decimal1 = false;
                        decimal2 = false;
                        OnPropertyChanged();
                    }
                }
            }
            //Press / Key
            if (e.Key == Key.Divide)
            {
                Operation = "÷";
                if (!isSecondNumber)
                {
                    isSecondNumber = true;
                    OnPropertyChanged();
                }
                else
                {
                    if (Num2 != null)
                    {
                        Num = Calc;
                        Num2 = null;
                        decimal1 = false;
                        decimal2 = false;
                        OnPropertyChanged();
                    }
                }
            }
            //Press P Key
            if (e.Key == Key.P)
            {
                Operation = "P";
                if (!isSecondNumber)
                {
                    isSecondNumber = true;
                    OnPropertyChanged();
                }
                else
                {
                    if (Num2 != null)
                    {
                        Num = Calc;
                        Num2 = null;
                        decimal1 = false;
                        decimal2 = false;
                        OnPropertyChanged();
                    }
                }
            }
            //Press C Key
            if (e.Key == Key.C)
            {
                isSecondNumber = false;
                Num2 = "";
                Num = "0";
                Operation = "";
                OnPropertyChanged();
            }
            //Press E Key
            if (e.Key == Key.E)
            {
                if (isSecondNumber)
                {
                    Num2 = "0";
                    OnPropertyChanged();
                }
                else
                {
                    Num = "0";
                    OnPropertyChanged();
                }
            }
            //Press , Key
            if (e.Key == Key.Decimal)
            {
                if (!isSecondNumber)
                {
                    if (!decimal1)
                    {
                        Num += ",";
                        decimal1 = true;
                        OnPropertyChanged();
                    }
                }
                else
                {
                    if (!decimal2 && Num2 != null)
                    {
                        Num2 += ",";
                        decimal2 = true;
                        OnPropertyChanged();
                    }
                }
            }
            //Press Enter Key
            if (e.Key == Key.Enter)
            {
                if (Num2 != null)
                {
                    Num = Calc;
                    Num2 = null;
                    Operation = "";
                    decimal1 = false;
                    decimal2 = false;
                    OnPropertyChanged();
                }
            }

            /*Number Keys*/
            //Press 0 Key
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                AddNum("0");
            }
            //Press 1 Key
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                AddNum("1");
            }
            //Press 2 Key
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                AddNum("2");
            }
            //Press 3 Key
            if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                AddNum("3");
            }
            //Press 4 Key
            if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                AddNum("4");
            }
            //Press 5 Key
            if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                AddNum("5");
            }
            //Press 6 Key
            if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                AddNum("6");
            }
            //Press 7 Key
            if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                AddNum("7");
            }
            //Press 8 Key
            if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                AddNum("8");
            }
            //Press 9 Key
            if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                AddNum("9");
            }
        }
    }
}