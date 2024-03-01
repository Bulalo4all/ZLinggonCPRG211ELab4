
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        //Setting the value of the display to zero
        [ObservableProperty]
        string displayValue = "0";
        

        //Setting the command to add the value of the button pressed to the display value
        [RelayCommand]
        void buttonOne()
        {
            if (DisplayValue == "0")
            { DisplayValue = "1"; }
            else
            {
                DisplayValue = DisplayValue + "1";
            }
        }

        [RelayCommand]
        void buttonTwo()
        {
            if (DisplayValue == "0")
            { DisplayValue = "2"; }
            else
            {
                DisplayValue = DisplayValue + "2";
            }
        }

        [RelayCommand]
        void buttonThree()
        {
            if (DisplayValue == "0")
            { DisplayValue = "3"; }
            else
            {
                DisplayValue = DisplayValue + "3";
            }
        }

        [RelayCommand]
        void buttonFour()
        {
            if (DisplayValue == "0")
            { DisplayValue = "4"; }
            else
            {
                DisplayValue = DisplayValue + "4";
            }
        }

        [RelayCommand]
        void buttonFive()
        {
            if (DisplayValue == "0")
            { DisplayValue = "5"; }
            else
            {
                DisplayValue = DisplayValue + "5";
            }
        }

        [RelayCommand]
        void buttonSix()
        {
            if (DisplayValue == "0")
            { DisplayValue = "6"; }
            else
            {
                DisplayValue = DisplayValue + "6";
            }
        }

        [RelayCommand]
        void buttonSeven()
        {
            if (DisplayValue == "0")
            { DisplayValue = "7"; }
            else
            {
                DisplayValue = DisplayValue + "7";
            }
        }

        [RelayCommand]
        void buttonEight()
        {
            if (DisplayValue == "0")
            { DisplayValue = "8"; }
            else
            {
                DisplayValue = DisplayValue + "8";
            }
        }

        [RelayCommand]
        void buttonNine()
        {
            if (DisplayValue == "0")
            { DisplayValue = "9"; }
            else
            {
                DisplayValue = DisplayValue + "9";
            }
        }

        [RelayCommand]
        void buttonZero()
        {
            if (DisplayValue == "0")
            { DisplayValue = "0"; }
            else
            {
                DisplayValue = "0" + DisplayValue;
            }
        }

        [RelayCommand]
        void buttonDecimal()
        {
            if (DisplayValue == "0")
            { DisplayValue = "."; }
            else
            {
                DisplayValue = DisplayValue + ".";
            }
        }


        [RelayCommand]
        void ButtonPlusOrMinus()
        {
            /*if there is no minus in the display value, adds it at the beginning else
            Removes the minus sign from the display value*/
            if (DisplayValue.Contains("-"))
            {
                DisplayValue = DisplayValue.Remove(0, 1);
            }
            else
            {
                DisplayValue = "-" + DisplayValue; 
            }
        }

        [RelayCommand]
        void buttonAC()
        {
            DisplayValue = "0";
            Equation.Clear();
            
        }

        [RelayCommand]
        void AddButton()
        {
            /*Adds the display value to an equation string. It then resets the display value to 0
            and adds the operator to the equation string*/

            Equation.Add(DisplayValue);
            DisplayValue = "0";
            Function = "+";
            Equation.Add(Function);
        }

        [RelayCommand]
        void DivideButton()
        {
            Equation.Add(DisplayValue);
            DisplayValue = "0";
            Function = "/";
            Equation.Add(Function);
        }

        [RelayCommand]
        void MultiplyButton()
        {
            Equation.Add(DisplayValue);
            DisplayValue = "0";
            Function = "*";
            Equation.Add(Function);
        }

        [RelayCommand]
        void MinusButton()
        {
            Equation.Add(DisplayValue);
            DisplayValue = "0";
            Function = "-"; 
            Equation.Add(Function);
        }

        [RelayCommand]
        void calculateButton()
        {
            //Adds the last value of the equation to the equation string
            Equation.Add(DisplayValue);

            //If there is not one value, there are still calculations to be made for the equation
            while (Equation.Count != 1)
            {
                //By order of operations, division must occur before *, +, and -
                while (Equation.Contains("/"))
                {
                    /*Finds the index number of the division sign, takes the two numbers before and after it
                    then parses those two numbers into doubles. Does the calculation. Creates a string 
                    representing the solution*/
                    int indexNum = Equation.FindIndex(x => x == "/");
                    double num1 = Double.Parse(Equation[indexNum - 1]);
                    double num2 = Double.Parse(Equation[indexNum + 1]);
                    double num3 = num1 / num2;
                    string product = "!" + num3.ToString();

                    /* Removes the operator from the equation string, inserts the solution in its place. Finds
                     the numbers before and after the operator and removes them from the equation list*/

                    Equation.RemoveAt(indexNum);
                    Equation.Insert(indexNum, product);

                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum - 1);
                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum + 1);
                    indexNum = Equation.FindIndex(x => x == product);

                    Equation.RemoveAt(indexNum);
                    product = product.Remove(0, 1);
                    Equation.Insert(indexNum, product);
                }

                while (Equation.Contains("*"))
                {
                    int indexNum = Equation.FindIndex(x => x == "*");


                    double num1 = Double.Parse(Equation[indexNum - 1]);
                    double num2 = Double.Parse(Equation[indexNum + 1]);

                    double num3 = num1 * num2;
                    string product = "!" + num3.ToString();

                    Equation.RemoveAt(indexNum);
                    Equation.Insert(indexNum, product);

                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum - 1);
                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum + 1);
                    indexNum = Equation.FindIndex(x => x == product);
                    
                    Equation.RemoveAt(indexNum);
                    product = product.Remove(0, 1);
                    Equation.Insert(indexNum, product);
                }

                while (Equation.Contains("+"))
                {
                    int indexNum = Equation.FindIndex(x => x == "+");


                    double num1 = Double.Parse(Equation[indexNum - 1]);
                    double num2 = Double.Parse(Equation[indexNum + 1]);

                    double num3 = num1 + num2;
                    string product = "!" + num3.ToString();

                    Equation.RemoveAt(indexNum);
                    Equation.Insert(indexNum, product);

                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum - 1);
                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum + 1);
                    indexNum = Equation.FindIndex(x => x == product);

                    Equation.RemoveAt(indexNum);
                    product = product.Remove(0, 1);
                    Equation.Insert(indexNum, product);
                }

                while (Equation.Contains("-"))
                {
                    int indexNum = Equation.FindIndex(x => x == "-");


                    double num1 = Double.Parse(Equation[indexNum - 1]);
                    double num2 = Double.Parse(Equation[indexNum + 1]);

                    double num3 = num1 - num2;
                    string product = "!" + num3.ToString();

                    Equation.RemoveAt(indexNum);
                    Equation.Insert(indexNum, product);

                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum - 1);
                    indexNum = Equation.FindIndex(x => x == product);
                    Equation.RemoveAt(indexNum + 1);
                    indexNum = Equation.FindIndex(x => x == product);

                    Equation.RemoveAt(indexNum);
                    product = product.Remove(0, 1);
                    Equation.Insert(indexNum, product);
                }

            }

            //Displays the result and stores the result in display value for further calculations
            DisplayValue = Equation[0].ToString();

            //Clears the equations list for new calculations
            Equation.Clear();

        }

        //String representing the equation that the user enters
        List<string> Equation = new List<string>();

        //string representing the operator that the user has selected
        string Function;


    }
}
