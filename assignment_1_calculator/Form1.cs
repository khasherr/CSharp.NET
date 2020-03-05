using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_1_calculator
{
    public partial class Form1 : Form
    {

        Double value = 0;
        String math_operation = "";
        bool operation_keyin = false;

        public Form1()
        {
            InitializeComponent();
        }


        // applied button click method to every buttons
        // displays the sender object onto the textbox
        private void button_Click(object sender, EventArgs e)

        {

            //result text is zero and everytime new number is keyedin - it does not append the number 
            if ((result.Text == "0") || (operation_keyin)){
                result.Clear();
            }
            //casted object to button type 
            Button b = (Button)sender;
            result.Text += b.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void mathOps_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            math_operation = b.Text;
            value = Double.Parse(result.Text);
            operation_keyin = true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (math_operation)
            {
                case "+":
                    result.Text = (value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    break;
                case"pwr":
                    result.Text = (Math.Pow(value, double.Parse(result.Text))).ToString();
                    break;
                case"sqrt":
                    result.Text = ((Math.Sqrt(value))).ToString();
                    break;
                case "abs": 
                    result.Text = ((Math.Abs(value))).ToString();
                    break;
                case "log": 
                        result.Text = ((Math.Log10(value))).ToString();
                    break;
                case "exp":
                    result.Text = (Math.Exp(value)).ToString();
                    break;
                case "fact":
                    result.Text = (MathNet.Numerics.SpecialFunctions.Factorial(Convert.ToInt32(value)).ToString());
                    break;
                case "mod":
                    result.Text = (value % (Convert.ToInt32(result.Text))).ToString();
                    break;
                case "ln":
                    result.Text = (Math.Log(value)).ToString();
                    break;

                case "1/x":
                    result.Text = (1 / value).ToString();
                  break;


                default:
                    break;

            }

            operation_keyin = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }
    }
}
