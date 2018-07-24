using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Syncfusion.Windows.Shared;
using System.Text.RegularExpressions;

namespace Linear_Thermometer_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            custlabel1.LabelValue = "" + Convert.ToChar(176) + "C";
            label1Txt.Text = "" + Convert.ToChar(176) + "C";
            custlabel2.LabelValue = "" + Convert.ToChar(176) + "F";
            label2Txt.Text = "" + Convert.ToChar(176) + "F";
        }
        #endregion Initialization

        #region Helper Methods
        /// <summary>
        /// Orientations the vertical click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationVerticalClick(object sender, RoutedEventArgs e)
        {
            linearGauge.Orientation = Syncfusion.Windows.Gauge.GaugeOrientation.Vertical;
            custlabel1.TextAngle = 0;            
            custlabel2.TextAngle = 0;            
        }

        /// <summary>
        /// Orientations the horizontal click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OrientationHorizontalClick(object sender, RoutedEventArgs e)
        {           
            linearGauge.Orientation = Syncfusion.Windows.Gauge.GaugeOrientation.Horizontal;
            custlabel1.TextAngle = 270;            
            custlabel2.TextAngle = 270;            
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool doCalculate = true;
            Match m = Regex.Match(formulaTxt.Text, "(\\+|\\-|\\*|\\/|\\%){2}");
            if (m != null)
            {
                if (m.Success)
                {
                    doCalculate = false;
                    MessageBox.Show(" Unary Operator Supported  : ! (for unary minus)\n Binary Operators Supported : +, -, *, / and %", "Supported Operators");
                }
            }            

            if (doCalculate)
            {
                if (formulaIsValid(formulaTxt.Text))
                {

                    label2.CalculateFormula = formulaTxt.Text;
                }
                else
                {
                    MessageBox.Show(" Unary Operator Supported  : ! (for unary minus)\n Binary Operators Supported : +, -, *, / and %", "Supported Operators");
                }
            }           
        }

        /// <summary>
        /// Handles the Click event of the RadioButton control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            label1.IsLogarithmic = true;
        }

        /// <summary>
        /// Handles the Click event of the RadioButton control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            label1.IsLogarithmic = false;
        }

        /// <summary>
        /// Handles the Click event of the Button control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {         
            if(integerIsValid(logTxt.Text))
            {
                label1.LogBase = Convert.ToDouble(logTxt.Text);
            }
            else
            {
                MessageBox.Show("Invalid Number");
            }
        }

        /// <summary>
        /// Handles the Click event of the Button control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(integerIsValid(numTxt.Text))
            {
                NumberFormatInfo num = new NumberFormatInfo();
                num.NumberDecimalDigits = Convert.ToInt16(numTxt.Text);
                label1.NumberFormatInfo = num;
            }
            else
            {
                MessageBox.Show("Invalid Number");
            }
        }

        /// <summary>
        /// Handles the Click event of the RadioButton control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            label2.IsCalculateFormulaEnabled = true;
        }

        /// <summary>
        /// Handles the Click event of the RadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            label2.IsCalculateFormulaEnabled = false;
        }

        /// <summary>
        /// Handles the TextChanged event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            custlabel1.LabelValue = label1Txt.Text;
        }

        /// <summary>
        /// Handles the TextChanged event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.TextChangedEventArgs"/> instance containing the event data.</param>
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            custlabel2.LabelValue = label2Txt.Text;
        }
        #endregion Helper Methods

        #region Validation Methods
        /// <summary>
        /// Formulas the is valid.
        /// </summary>
        /// <param name="input">The input formula to be validated.</param>
        /// <returns>Returns true if valid else returns false</returns>
        private bool formulaIsValid(string input)
        {
            char[] op = {'+', '-', '*', '/', '%', '!'};
            if (input.IndexOf("x") != -1)
            {
                if (input == "x")
                {
                    // If the entire input is only "x"
                    return true;
                }

                if (input.IndexOfAny(op) == -1)
                {
                    // Operator should be specified                    
                    return false;
                }
                if (input.Length != 0)
                {
                    if (input[0] == '+' || input[0] == '-' || input[0] == '*' || input[0] == '/' || input[0] == '%')
                    {
                        return false;
                    }
                    if (input[input.Length - 1] == '+' || input[input.Length - 1] == '-' || input[input.Length - 1] == '*' || input[input.Length - 1] == '/' || input[input.Length - 1] == '%'|| input[input.Length - 1] == '!')
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }            
            
            for (int i = 0; i < input.Length; i++)
            {                
                if (char.IsLetter(input[i]))
                {                    
                    if (input[i] != 'x')
                    {
                        // Variables other than 'x' should not be present
                        return false;
                    }
                }
            }
           
            return true;                        
        }

        /// <summary>
        /// Checks whether the integer input is valid.
        /// </summary>
        /// <param name="input">The input text to be validated.</param>
        /// <returns>Returns true if valid else returns false</returns>
        private bool integerIsValid(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion Validation Methods
    }
}
