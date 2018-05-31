using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string Calculation = "";
        string CurrentInput = "";
        bool RequiresOperator;
        public MainWindow()
        {
            InitializeComponent();
            RefreshText();
        }
        //Input Interactions start
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(0);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(1);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(2);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(3);
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(4);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(5);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(6);
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(7);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(8);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(9);
        }

        private void InputNumber(int Input)
        {
            if (CurrentInput == "0") CurrentInput = "";
            CurrentInput = CurrentInput + Input;
            if (RequiresOperator) CurrentInput = "";
            RefreshText();
        }
        //Input Edits
        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            InputEdit(1);
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            InputEdit(2);
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            InputEdit(3);
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            InputEdit(4);
        }

        private void InputEdit(int Input)
        {
            if (RequiresOperator) Input = 4;
            switch (Input)
            {
                case 1: //Change Symbol of current Number
                    if (CurrentInput == "") break;
                    float CurrentNumber = float.Parse(CurrentInput);
                    CurrentNumber = CurrentNumber * -1;
                    CurrentInput = CurrentNumber.ToString();
                    break;
                case 2: //Add Decimal Point to Current Number
                    if (CurrentInput.Contains(".")) break;
                    if (CurrentInput == "") CurrentInput = "0.";
                    else CurrentInput = CurrentInput + ".";
                    break;
                case 3: //Backspace Current Input
                    if (CurrentInput != "") CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);
                    break;
                case 4: //Clear Current Input
                    CurrentInput = "";
                    break;
            }
            RefreshText();
        }

        //End Input Interactions
        //Start Operator Interactions

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(7);
        }

        private void Squared_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(6);
        }

        private void OneOverInput_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(5);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(4);
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(3);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(2);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            InputOperator(1);
        }
        
        private void InputOperator(int Input)
        {
            if (CurrentInput == "" && RequiresOperator == false) CurrentInput = "0";
            RequiresOperator = false;
            switch (Input)
            {
                case 1:
                    CurrentInput = CurrentInput + "+";
                    break;
                case 2:
                    CurrentInput = CurrentInput + "-";
                    break;
                case 3:
                    CurrentInput = CurrentInput + "×";
                    break;
                case 4:
                    CurrentInput = CurrentInput + "÷";
                    break;
                case 5:
                    CurrentInput = "1÷" + CurrentInput;
                    RequiresOperator = true;
                    break;
                case 6:
                    CurrentInput = CurrentInput + "^2";
                    RequiresOperator = true;
                    break;
                case 7:
                    CurrentInput = "√" + CurrentInput;
                    RequiresOperator = true;
                    break;
            }
            Calculation = Calculation + CurrentInput;
            CurrentInput = "";
            RefreshText();
        }
        //End Operator Interactions
        //Start Action Interactions
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            CalculationAction(1);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CalculationAction(2);
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            CalculationAction(3);
        }

        private void CalculationAction(int Input)
        {
            switch (Input)
            {
                case 1:
                    if (RequiresOperator == false)
                    {
                        if(CurrentInput == "")
                        {
                            CurrentInput = "0";
                        }
                        Calculation = Calculation + CurrentInput;
                    }
                    for(int i=1; i <= 6; i++)
                    {
                        string pass = "";
                        switch (i)
                        {
                            case 1:
                                pass = "√";
                                break;
                            case 2:
                                pass = "^";
                                break;
                            case 3:
                                pass = "÷";
                                break;
                            case 4:
                                pass = "×";
                                break;
                            case 5:
                                pass = "-";
                                break;
                            case 6:
                                pass = "+";
                                break;
                        }
                        if (Calculation.Contains(pass))
                        {
                            int Middle = Calculation.IndexOf(pass);
                            int End = Middle + 1;

                            while (double.TryParse(Calculation[End].ToString(), out double n))
                            {
                                End++;
                                if (End >= Calculation.Length) break;
                            }
                            End--;

                            int Start = Middle - 1;
                            if (Start == -1) Start = 0;

                            while (double.TryParse(Calculation[Start].ToString(), out double n))
                            {
                                Start--;
                                if (Start < 0) break;
                            }

                            Start++;

                            double First = double.Parse(Calculation.Substring(Start, Middle - Start));
                            double Second = double.Parse(Calculation.Substring(Middle + 1, End - Middle));
                            double Solution = 0;

                            switch (i)
                            {
                                case 1:
                                    //Square root pass
                                    Solution = Math.Sqrt(Second);
                                    break;
                                case 2:
                                    //Squared pass
                                    Solution = Math.Pow(First,Second);
                                    break;
                                case 3:
                                    //Division pass
                                    Solution = First / Second;
                                    break;
                                case 4:
                                    //Multiplication pass
                                    Solution = First * Second;
                                    break;
                                case 5:                                                                    
                                    //Subtraction pass
                                    Solution = First - Second;
                                    break;
                                case 6:
                                    //Addition pass
                                    Solution = First + Second;
                                    break;
                            }
                            string TCalculation;
                            TCalculation = Calculation.Substring(0, Start) + Solution;
                            if (End + 1 != Calculation.Length)
                            {
                                TCalculation = TCalculation + Calculation.Substring(End + 1);
                            }
                            Calculation = TCalculation;
                        }

                    }
                    CurrentInput = Calculation;
                    Calculation = "";
                    RequiresOperator = false;
                    break;
                case 2:
                    CurrentInput = "";
                    Calculation = "";
                    RequiresOperator = false;
                    break;
                case 3:
                    if (Calculation == "") break;
                    int Index = Calculation.Length - 2;
                    while (double.TryParse(Calculation[Index].ToString(), out double n))
                    {
                        Index++;
                        if (Index < 0) break;
                    }

                    break;
            }
            RefreshText();
        }
        //End Action Interactions
        //General Functions:
        public void RefreshText()
        {
            if (CurrentInput == "") CurrentNumberText.Text = "0";
            else CurrentNumberText.Text = CurrentInput;
            CalculationText.Text = Calculation;
        }
    }
}
