using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign5
{
    public partial class Form1 : Form
    {
        private string[] areaCode = {"236", "250", "778", "507", "780", "805", "403",
                                     "587", "825", "306", "639", "204", "432", "807",
                                     "249", "705", "226", "519", "548", "709"};
        private double[] rate = { .05, .05, .05, .03, .03, .03, .04, .06, .06, .06,
                                  .08, .08, .08, .09, .09, .09, .10, .10, .12, .14};

        private int[] minTime = { 3, 3, 3, 0, 0, 0, 5, 5, 5, 2,
                                  2, 2, 4, 4, 4, 6, 6, 6, 8, 9};
        int totalMinutes;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Shutdown the painting of the comboBox as items are added.
            comboBox1.BeginUpdate();
            lengthBox.Enabled = false;

            //load comboBox with the area codes
            //use the method comboBox1.Items.Add("403");
            int s1 = areaCode.Length - 1;

            for (int i = 0; i <= s1; i++)
            {
                comboBox1.Items.Add(areaCode[i]);
            }

            // Allow the comboBox to repaint and display the new items.
            comboBox1.EndUpdate();
        }


        // comboBox was changed - calculate the charges for the phone call
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lengthBox.Enabled = true; //the lengthbox will only be enabled once the user selects an area code
            valueProcessor();
        }
        
        private void lengthBox_TextChanged(object sender, EventArgs e)
        {
            valueProcessor();
        }
        
        private void valueProcessor ()
        {
            int selectedIndex = comboBox1.SelectedIndex; //this is the array's address

            if (lengthBox.Text == "")
            {
                int tempVal = 0;
                lengthBox.Text = tempVal.ToString();
            }

            minBox.Text = minTime[selectedIndex].ToString();
            rateBox.Text = rate[selectedIndex].ToString();

            //if the length is less than the minimum, the cost would be length * rate
            //if the length is more than the minimum, the cost would be (length - minimum) * rate

            int lengthBoxVal = Int32.Parse(lengthBox.Text);
            int minTimeVal = minTime[selectedIndex];
            double rateVal = rate[selectedIndex];
            double totalVal = 0;

            if (lengthBoxVal > minTimeVal)//length is greater than minimum
            {
                totalMinutes = lengthBoxVal - minTimeVal;
                totalVal = rateVal + (totalMinutes * rateVal);
                totalBox.Text = "$" + totalVal.ToString("0.00");
            }
            else //length of call is less than minimum
            {
                if (lengthBoxVal == 0)
                {
                    totalBox.Text = "$ 0.00";
                } else
                {
                    totalMinutes = lengthBoxVal;
                    totalVal = rateVal;
                    totalBox.Text = "$ " + totalVal.ToString("0.00");
                }

            }
        }
    }
}
