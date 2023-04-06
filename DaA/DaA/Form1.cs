using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DaA
{
    public partial class Form1 : Form
    {

        private List<int> intNumbers;

        MyDoublyLinkedList<int> myList;
        MyArrayList<int> myArrayList;
        MyBinaryTree<int> myBinaryTree;

        public Form1()
        {
            InitializeComponent();
            OpenFileDialogForm();
        }

        private void ShowMessage(object result, TimeSpan elapsedTime)
        {
            double roundedElapsedSeconds = Math.Round(elapsedTime.TotalSeconds, 1);
            TimeSpan roundedElapsedTime = TimeSpan.FromSeconds(roundedElapsedSeconds);

            if (result is bool booleanValue)
            {
                MessageBox.Show($"Value was found: {booleanValue}. It took {roundedElapsedTime}.");
            }
            else if (result is string stringValue)
            {
                MessageBox.Show($"Sorted: {stringValue}. It took {roundedElapsedTime}.");
            }
            else
            {
                MessageBox.Show($"Operation took {roundedElapsedTime}.");
            }
        }

        public void OpenFileDialogForm()
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.csv)|*.csv",
                Title = "Open text file"
            };

            form_button_initData = new Button()
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            form_button_initData.Click += new EventHandler(form_button_initData_Click);
            Controls.Add(form_button_initData);
        }


        private void form_button_initData_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(file);
                if (lines.Length == 0)
                {
                    MessageBox.Show("Error: file is empty.");
                    return;
                }
                string[] numbers = lines[0].Split(',');
                intNumbers = new List<int>();
                int parsedNumber;
                foreach (string number in numbers)
                {
                    if (int.TryParse(number, out parsedNumber))
                    {
                        intNumbers.Add(parsedNumber);
                    }
                }
                if (intNumbers.Count == 0)
                {
                    MessageBox.Show("Error: file does not contain any valid integers.");
                    return;
                }
                MessageBox.Show("File loaded \n\rNumber of items: " + intNumbers.Count.ToString());
            }
            else
            {
                MessageBox.Show("No file selected");
                Application.Exit();
                return;
            }


            form_numericUpDown_searchFrom.Minimum = 0;
            form_numericUpDown_searchFrom.Maximum = intNumbers.Count - 1;
            form_numericUpDown_searchUntil.Minimum = 0;
            form_numericUpDown_searchUntil.Maximum = intNumbers.Count - 1;
            form_numericUpDown_sortFrom.Minimum = 0;
            form_numericUpDown_sortFrom.Maximum = intNumbers.Count - 1;
            form_numericUpDown_sortUntil.Minimum = 0;
            form_numericUpDown_sortUntil.Maximum = intNumbers.Count - 1;
            form_numericUpDown_searchFrom.Value = 0;
            form_numericUpDown_searchUntil.Value = intNumbers.Count - 1;
            form_numericUpDown_sortFrom.Value = 0;
            form_numericUpDown_sortUntil.Value = intNumbers.Count - 1;
        }

        private void form_button_convert_Click(object sender, EventArgs e)
        {
            //Convert the string to an array of integers
            //Might need to parse CSV values to int


            string convertType = form_comboBox_convert.Text;

            switch (convertType)
            {
                case "Doubly Linked List":
                    myList = new MyDoublyLinkedList<int>();
                    foreach (int number in intNumbers)
                    {
                        myList.AddLast(number);
                    }
                    break;
                case "Array List":
                    myArrayList = new MyArrayList<int>();
                    foreach (int number in intNumbers)
                    {
                        myArrayList.Add(number);
                    }
                    break;
                case "Binary Tree":
                    myBinaryTree = new MyBinaryTree<int>();
                    foreach (int number in intNumbers)
                    {
                        myBinaryTree.Add(number);
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
            if (form_textBox_search.Text == "")
            {
                MessageBox.Show("Please enter a number to search for");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(form_textBox_search.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Please enter only numbers");
                return;
            }

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
                    if (dataStructure == "Doubly Linked List")
                    {
                        (bool found, TimeSpan elapsedTime) = myList.LinearSearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);

                    }
                    else if (dataStructure == "Binary Tree")
                    {
                        (bool found, TimeSpan elapsedTime) = myBinaryTree.LinearSearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);
                    }
                    else if (dataStructure == "Array List")
                    {
                        (bool found, TimeSpan elapsedTime) = myArrayList.LinearSearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                    break;
                case "Binary Search":
                    if (dataStructure == "Doubly Linked List")
                    {
                        (bool found, TimeSpan elapsedTime) = myList.BinarySearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);
                    }
                    else if (dataStructure == "Binary Tree")
                    {
                        (bool found, TimeSpan elapsedTime) = myBinaryTree.BinarySearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);
                    }
                    else if (dataStructure == "Array List")
                    {
                        (bool found, TimeSpan elapsedTime) = myArrayList.BinarySearch(searchFor, searchFrom, searchUntil);
                        ShowMessage(found, elapsedTime);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
                default:
                    MessageBox.Show("Please select a search type");
                    break;
            }

        }

        private void form_button_sort_Click(object sender, EventArgs e)
        {
            string sortType = form_comboBox_sort.Text;
            string dataStructure = form_label_currentStructure.Text;
            int sortFrom = (int)form_numericUpDown_sortFrom.Value;
            int sortUntil = (int)form_numericUpDown_sortUntil.Value;

            if (form_numericUpDown_searchFrom.Value > form_numericUpDown_searchUntil.Value)
            {
                MessageBox.Show("Please make sure the search from is smaller or equal to the search until");
                return;
            }


            switch (sortType)
            {
                case "Bubble Sort":
                    if (dataStructure == "Doubly Linked List")
                    {
                        TimeSpan ts = myList.BubbleSort(sortFrom, sortUntil);
                        ShowMessage(myList.ToString(), ts);
                    }
                    else if (dataStructure == "Binary Tree")
                    {
                        TimeSpan ts = myBinaryTree.BubbleSort(sortFrom, sortUntil);
                        ShowMessage(myBinaryTree.ToString(), ts);
                    }
                    else if (dataStructure == "Array List")
                    {
                        TimeSpan ts = myArrayList.BubbleSort(sortFrom, sortUntil);
                        ShowMessage(myArrayList.ToString(), ts);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
                case "Quick Sort":
                    if (dataStructure == "Doubly Linked List")
                    {
                        TimeSpan ts = myList.QuickSort(sortFrom, sortUntil);
                        ShowMessage(myList.ToString(), ts);
                    }
                    else if (dataStructure == "Binary Tree")
                    {
                        TimeSpan ts = myBinaryTree.QuickSort(sortFrom, sortUntil);
                        ShowMessage(myBinaryTree.ToString(), ts);
                    }
                    else if (dataStructure == "Array List")
                    {
                        TimeSpan ts = myArrayList.QuickSort(sortFrom, sortUntil);
                        ShowMessage(myArrayList.ToString(), ts);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
                default:
                    MessageBox.Show("Please select a sort type");
                    break;
            }
        }

    }
}