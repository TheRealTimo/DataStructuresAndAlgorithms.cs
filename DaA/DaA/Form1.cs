using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DaA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void form_button_initData_Click(object sender, EventArgs e)
        {
            if (form_textBox_initData.Text == "")
            {
                MessageBox.Show("Please enter some data to be sorted and searched");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(form_textBox_initData.Text, @"^[0-9, ]+$"))
            {
                MessageBox.Show("Please enter only numbers and , and space");
                return;
            }

            if (form_textBox_initData.Text[0] == ',' || form_textBox_initData.Text[0] == ' ' || form_textBox_initData.Text[form_textBox_initData.Text.Length - 1] == ',' || form_textBox_initData.Text[form_textBox_initData.Text.Length - 1] == ' ')
            {
                MessageBox.Show("Please only start and end with a number");
                return;
            }
            int numberOfNumbers = form_textBox_initData.Text.Split(',').Length;
            form_numericUpDown_searchFrom.Minimum = 0;
            form_numericUpDown_searchFrom.Maximum = numberOfNumbers;
            form_numericUpDown_searchUntil.Minimum = 0;
            form_numericUpDown_searchUntil.Maximum = numberOfNumbers;
            form_numericUpDown_sortFrom.Minimum = 0;
            form_numericUpDown_sortFrom.Maximum = numberOfNumbers;
            form_numericUpDown_sortUntil.Minimum = 0;
            form_numericUpDown_sortUntil.Maximum = numberOfNumbers;
            form_numericUpDown_searchFrom.Value = 0;
            form_numericUpDown_searchUntil.Value = numberOfNumbers;
            form_numericUpDown_sortFrom.Value = 0;
            form_numericUpDown_sortUntil.Value = numberOfNumbers;
        }

        private void form_button_convert_Click(object sender, EventArgs e)
        {
            //Convert the string to an array of integers
            string[] stringArray = form_textBox_initData.Text.Split(',');
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }
            string convertType = form_comboBox_convert.Text;

            switch (convertType)
            {
                case "Linked List":
                    DoublyLinkedList<int> myList = new DoublyLinkedList<int>();
                    foreach (int number in intArray)
                    {
                        myList.AddFirst(number);
                    }
                    break;
                case "Stack":
                    Stack<int> myStack = new Stack<int>();
                    foreach (int number in intArray)
                    {
                        myStack.Push(number);
                    }
                    break;
                case "Queue":
                    Queue<int> myQueue = new Queue<int>();
                    foreach (int number in intArray)
                    {
                    myQueue.Enqueue(number);
                    }
                    break;
                default:
                    MessageBox.Show("Please select a convert type");
                    break;
            }
            form_label_currentStructure.Text = convertType.ToString();

        }
    }
}
