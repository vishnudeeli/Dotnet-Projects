using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CalculatorDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string currentCalculation = "";
        public void Display(string value)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += value;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
            
        }
       
     
        private void button1_Click(object sender, EventArgs e)
        {
            Display("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Display("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Display("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Display("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Display("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Display("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Display("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Display("0");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Display("+");
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            Display("-");
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            Display("x");
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Display("÷");
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            Display(".");
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            {
                string formattedCalculation = currentCalculation.ToString().Replace("x", "*").Replace("÷","/");

                try
                {
                    textBox1.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                    currentCalculation = textBox1.Text;
                    
                }
                catch (Exception ex)
                {
                    textBox1.Text = "NaN";
                    currentCalculation = "";
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            currentCalculation = "";
            
        }
        
        
        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }

            // Re-display the calculation onto the screen
            textBox1.Text = currentCalculation;
            
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Display("(");
        }

        private void buttonClosed_Click(object sender, EventArgs e)
        {
            Display(")");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}

