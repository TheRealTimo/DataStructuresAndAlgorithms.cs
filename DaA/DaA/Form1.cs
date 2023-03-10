using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DaA
{
    public partial class Form1 : Form
    {

        DoublyLinkedList<int> myList;
        Stack<int> myStack;
        Queue<int> myQueue;

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
                     myList = new DoublyLinkedList<int>();
                    foreach (int number in intArray)
                    {
                        myList.AddFirst(number);
                    }
                    break;
                case "Stack":
                    myStack = new Stack<int>();
                    foreach (int number in intArray)
                    {
                        myStack.Push(number);
                    }
                    break;
                case "Queue":
                    myQueue = new Queue<int>();
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

        private void form_button_search_Click(object sender, EventArgs e)
        {
            //Make sure the user has entered a number to search for
            if (form_textBox_search.Text == "" )
            {
                MessageBox.Show("Please enter a number to search for");
                return;
            }
            //Make sure the user has entered a number to search for
            if (!System.Text.RegularExpressions.Regex.IsMatch(form_textBox_search.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Please enter only numbers");
                return;
            }
            //Make sure  form_numericUpDown_searchFrom is smaller or equal to form_numericUpDown_searchUntil
            if (form_numericUpDown_searchFrom.Value > form_numericUpDown_searchUntil.Value)
            {
                MessageBox.Show("Please make sure the search from is smaller or equal to the search until");
                return;
            }
            if (form_label_currentStructure.Text == "None")
            {
                MessageBox.Show("Please convert the data first");
                return;
            }
            string searchType = form_comboBox_search.Text;
            string dataStructure = form_label_currentStructure.Text;
            int searchFrom = (int)form_numericUpDown_searchFrom.Value;
            int searchUntil = (int)form_numericUpDown_searchUntil.Value;
            int searchFor = int.Parse(form_textBox_search.Text);

            switch (searchType)
            {
                case "Linear Search":
                    if (dataStructure == "Linked List")
                    {
                        myList.LinearSearch(searchFor, searchFrom, searchUntil);
                    }
                    else if (dataStructure == "Stack")
                    {
                        bool test = myStack.LinearSearch(searchFor, searchFrom, searchUntil);
                        MessageBox.Show(test.ToString());
                    }
                    else if (dataStructure == "Queue")
                    {
                        MessageBox.Show("Needs implementation");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                   
                    break;
                case "Binary":
                    break;
                default:
                    MessageBox.Show("Please select a search type");
                    break;
            }

        }

        private void form_button_sort_Click(object sender, EventArgs e)
        {
            
        }
    }
}
