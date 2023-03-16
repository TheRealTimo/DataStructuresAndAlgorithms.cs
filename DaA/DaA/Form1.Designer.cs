namespace DaA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
 
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.form_label_initData = new System.Windows.Forms.Label();
            this.form_textBox_initData = new System.Windows.Forms.TextBox();
            this.form_button_initData = new System.Windows.Forms.Button();
            this.form_label_currentStructureTitle = new System.Windows.Forms.Label();
            this.form_label_currentStructure = new System.Windows.Forms.Label();
            this.form_label_convert = new System.Windows.Forms.Label();
            this.form_comboBox_convert = new System.Windows.Forms.ComboBox();
            this.form_button_convert = new System.Windows.Forms.Button();
            this.form_label_search = new System.Windows.Forms.Label();
            this.form_textBox_search = new System.Windows.Forms.TextBox();
            this.form_label_search_using = new System.Windows.Forms.Label();
            this.form_comboBox_search = new System.Windows.Forms.ComboBox();
            this.form_label_search_from = new System.Windows.Forms.Label();
            this.form_numericUpDown_searchFrom = new System.Windows.Forms.NumericUpDown();
            this.form_label_search_until = new System.Windows.Forms.Label();
            this.form_numericUpDown_searchUntil = new System.Windows.Forms.NumericUpDown();
            this.form_button_search = new System.Windows.Forms.Button();
            this.form_label_sort = new System.Windows.Forms.Label();
            this.form_comboBox_sort = new System.Windows.Forms.ComboBox();
            this.form_label_sortFrom = new System.Windows.Forms.Label();
            this.form_numericUpDown_sortFrom = new System.Windows.Forms.NumericUpDown();
            this.form_label_sortUntil = new System.Windows.Forms.Label();
            this.form_numericUpDown_sortUntil = new System.Windows.Forms.NumericUpDown();
            this.form_button_sort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_searchFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_searchUntil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_sortFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_sortUntil)).BeginInit();
            this.SuspendLayout();
            // 
            // form_label_initData
            // 
            this.form_label_initData.AutoSize = true;
            this.form_label_initData.Location = new System.Drawing.Point(12, 9);
            this.form_label_initData.Name = "form_label_initData";
            this.form_label_initData.Size = new System.Drawing.Size(149, 13);
            this.form_label_initData.TabIndex = 0;
            this.form_label_initData.Text = "Enter numbers seperated by \',\'";
            // 
            // form_textBox_initData
            // 
            this.form_textBox_initData.Location = new System.Drawing.Point(15, 25);
            this.form_textBox_initData.Name = "form_textBox_initData";
            this.form_textBox_initData.Size = new System.Drawing.Size(347, 20);
            this.form_textBox_initData.TabIndex = 1;
            // 
            // form_button_initData
            // 
            this.form_button_initData.Location = new System.Drawing.Point(368, 25);
            this.form_button_initData.Name = "form_button_initData";
            this.form_button_initData.Size = new System.Drawing.Size(75, 23);
            this.form_button_initData.TabIndex = 2;
            this.form_button_initData.Text = "Save";
            this.form_button_initData.UseVisualStyleBackColor = true;
            this.form_button_initData.Click += new System.EventHandler(this.form_button_initData_Click);
            // 
            // form_label_currentStructureTitle
            // 
            this.form_label_currentStructureTitle.AutoSize = true;
            this.form_label_currentStructureTitle.Location = new System.Drawing.Point(568, 9);
            this.form_label_currentStructureTitle.Name = "form_label_currentStructureTitle";
            this.form_label_currentStructureTitle.Size = new System.Drawing.Size(109, 13);
            this.form_label_currentStructureTitle.TabIndex = 3;
            this.form_label_currentStructureTitle.Text = "Current datastructure:";
            // 
            // form_label_currentStructure
            // 
            this.form_label_currentStructure.AutoSize = true;
            this.form_label_currentStructure.Location = new System.Drawing.Point(568, 25);
            this.form_label_currentStructure.Name = "form_label_currentStructure";
            this.form_label_currentStructure.Size = new System.Drawing.Size(33, 13);
            this.form_label_currentStructure.TabIndex = 4;
            this.form_label_currentStructure.Text = "None";
            // 
            // form_label_convert
            // 
            this.form_label_convert.AutoSize = true;
            this.form_label_convert.Location = new System.Drawing.Point(12, 74);
            this.form_label_convert.Name = "form_label_convert";
            this.form_label_convert.Size = new System.Drawing.Size(83, 13);
            this.form_label_convert.TabIndex = 5;
            this.form_label_convert.Text = "Convert data to:";
            // 
            // form_comboBox_convert
            // 
            this.form_comboBox_convert.FormattingEnabled = true;
            this.form_comboBox_convert.Items.AddRange(new object[] {
            "Linked List",
            "Stack",
            "Queue"});
            this.form_comboBox_convert.Location = new System.Drawing.Point(15, 90);
            this.form_comboBox_convert.Name = "form_comboBox_convert";
            this.form_comboBox_convert.Size = new System.Drawing.Size(121, 21);
            this.form_comboBox_convert.TabIndex = 6;
            // 
            // form_button_convert
            // 
            this.form_button_convert.Location = new System.Drawing.Point(142, 90);
            this.form_button_convert.Name = "form_button_convert";
            this.form_button_convert.Size = new System.Drawing.Size(75, 23);
            this.form_button_convert.TabIndex = 7;
            this.form_button_convert.Text = "Convert";
            this.form_button_convert.UseVisualStyleBackColor = true;
            this.form_button_convert.Click += new System.EventHandler(this.form_button_convert_Click);
            // 
            // form_label_search
            // 
            this.form_label_search.AutoSize = true;
            this.form_label_search.Location = new System.Drawing.Point(12, 194);
            this.form_label_search.Name = "form_label_search";
            this.form_label_search.Size = new System.Drawing.Size(59, 13);
            this.form_label_search.TabIndex = 8;
            this.form_label_search.Text = "Search for:";
            // 
            // form_textBox_search
            // 
            this.form_textBox_search.Location = new System.Drawing.Point(15, 209);
            this.form_textBox_search.Name = "form_textBox_search";
            this.form_textBox_search.Size = new System.Drawing.Size(100, 20);
            this.form_textBox_search.TabIndex = 9;
            // 
            // form_label_search_using
            // 
            this.form_label_search_using.AutoSize = true;
            this.form_label_search_using.Location = new System.Drawing.Point(121, 212);
            this.form_label_search_using.Name = "form_label_search_using";
            this.form_label_search_using.Size = new System.Drawing.Size(32, 13);
            this.form_label_search_using.TabIndex = 10;
            this.form_label_search_using.Text = "using";
            // 
            // form_comboBox_search
            // 
            this.form_comboBox_search.FormattingEnabled = true;
            this.form_comboBox_search.Items.AddRange(new object[] {
            "Exponential Search",
            "Linear Search"});
            this.form_comboBox_search.Location = new System.Drawing.Point(156, 210);
            this.form_comboBox_search.Name = "form_comboBox_search";
            this.form_comboBox_search.Size = new System.Drawing.Size(121, 21);
            this.form_comboBox_search.TabIndex = 11;
            // 
            // form_label_search_from
            // 
            this.form_label_search_from.AutoSize = true;
            this.form_label_search_from.Location = new System.Drawing.Point(283, 213);
            this.form_label_search_from.Name = "form_label_search_from";
            this.form_label_search_from.Size = new System.Drawing.Size(27, 13);
            this.form_label_search_from.TabIndex = 12;
            this.form_label_search_from.Text = "from";
            // 
            // form_numericUpDown_searchFrom
            // 
            this.form_numericUpDown_searchFrom.Location = new System.Drawing.Point(316, 211);
            this.form_numericUpDown_searchFrom.Name = "form_numericUpDown_searchFrom";
            this.form_numericUpDown_searchFrom.Size = new System.Drawing.Size(120, 20);
            this.form_numericUpDown_searchFrom.TabIndex = 13;
            // 
            // form_label_search_until
            // 
            this.form_label_search_until.AutoSize = true;
            this.form_label_search_until.Location = new System.Drawing.Point(442, 213);
            this.form_label_search_until.Name = "form_label_search_until";
            this.form_label_search_until.Size = new System.Drawing.Size(26, 13);
            this.form_label_search_until.TabIndex = 14;
            this.form_label_search_until.Text = "until";
            // 
            // form_numericUpDown_searchUntil
            // 
            this.form_numericUpDown_searchUntil.Location = new System.Drawing.Point(474, 210);
            this.form_numericUpDown_searchUntil.Name = "form_numericUpDown_searchUntil";
            this.form_numericUpDown_searchUntil.Size = new System.Drawing.Size(120, 20);
            this.form_numericUpDown_searchUntil.TabIndex = 15;
            // 
            // form_button_search
            // 
            this.form_button_search.Location = new System.Drawing.Point(600, 208);
            this.form_button_search.Name = "form_button_search";
            this.form_button_search.Size = new System.Drawing.Size(75, 23);
            this.form_button_search.TabIndex = 16;
            this.form_button_search.Text = "Search";
            this.form_button_search.UseVisualStyleBackColor = true;
            this.form_button_search.Click += new System.EventHandler(this.form_button_search_Click);
            // 
            // form_label_sort
            // 
            this.form_label_sort.AutoSize = true;
            this.form_label_sort.Location = new System.Drawing.Point(12, 245);
            this.form_label_sort.Name = "form_label_sort";
            this.form_label_sort.Size = new System.Drawing.Size(57, 13);
            this.form_label_sort.TabIndex = 17;
            this.form_label_sort.Text = "Sort using:";
            // 
            // form_comboBox_sort
            // 
            this.form_comboBox_sort.FormattingEnabled = true;
            this.form_comboBox_sort.Items.AddRange(new object[] {
            "Bubble Sort",
            "Exponential Search"});
            this.form_comboBox_sort.Location = new System.Drawing.Point(12, 261);
            this.form_comboBox_sort.Name = "form_comboBox_sort";
            this.form_comboBox_sort.Size = new System.Drawing.Size(121, 21);
            this.form_comboBox_sort.TabIndex = 18;
            // 
            // form_label_sortFrom
            // 
            this.form_label_sortFrom.AutoSize = true;
            this.form_label_sortFrom.Location = new System.Drawing.Point(139, 264);
            this.form_label_sortFrom.Name = "form_label_sortFrom";
            this.form_label_sortFrom.Size = new System.Drawing.Size(67, 13);
            this.form_label_sortFrom.TabIndex = 19;
            this.form_label_sortFrom.Text = "from element";
            // 
            // form_numericUpDown_sortFrom
            // 
            this.form_numericUpDown_sortFrom.Location = new System.Drawing.Point(212, 264);
            this.form_numericUpDown_sortFrom.Name = "form_numericUpDown_sortFrom";
            this.form_numericUpDown_sortFrom.Size = new System.Drawing.Size(120, 20);
            this.form_numericUpDown_sortFrom.TabIndex = 20;
            // 
            // form_label_sortUntil
            // 
            this.form_label_sortUntil.AutoSize = true;
            this.form_label_sortUntil.Location = new System.Drawing.Point(338, 268);
            this.form_label_sortUntil.Name = "form_label_sortUntil";
            this.form_label_sortUntil.Size = new System.Drawing.Size(26, 13);
            this.form_label_sortUntil.TabIndex = 21;
            this.form_label_sortUntil.Text = "until";
            // 
            // form_numericUpDown_sortUntil
            // 
            this.form_numericUpDown_sortUntil.Location = new System.Drawing.Point(368, 262);
            this.form_numericUpDown_sortUntil.Name = "form_numericUpDown_sortUntil";
            this.form_numericUpDown_sortUntil.Size = new System.Drawing.Size(120, 20);
            this.form_numericUpDown_sortUntil.TabIndex = 22;
            // 
            // form_button_sort
            // 
            this.form_button_sort.Location = new System.Drawing.Point(494, 261);
            this.form_button_sort.Name = "form_button_sort";
            this.form_button_sort.Size = new System.Drawing.Size(75, 23);
            this.form_button_sort.TabIndex = 23;
            this.form_button_sort.Text = "Sort";
            this.form_button_sort.UseVisualStyleBackColor = true;
            this.form_button_sort.Click += new System.EventHandler(this.form_button_sort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 289);
            this.Controls.Add(this.form_button_sort);
            this.Controls.Add(this.form_numericUpDown_sortUntil);
            this.Controls.Add(this.form_label_sortUntil);
            this.Controls.Add(this.form_numericUpDown_sortFrom);
            this.Controls.Add(this.form_label_sortFrom);
            this.Controls.Add(this.form_comboBox_sort);
            this.Controls.Add(this.form_label_sort);
            this.Controls.Add(this.form_button_search);
            this.Controls.Add(this.form_numericUpDown_searchUntil);
            this.Controls.Add(this.form_label_search_until);
            this.Controls.Add(this.form_numericUpDown_searchFrom);
            this.Controls.Add(this.form_label_search_from);
            this.Controls.Add(this.form_comboBox_search);
            this.Controls.Add(this.form_label_search_using);
            this.Controls.Add(this.form_textBox_search);
            this.Controls.Add(this.form_label_search);
            this.Controls.Add(this.form_button_convert);
            this.Controls.Add(this.form_comboBox_convert);
            this.Controls.Add(this.form_label_convert);
            this.Controls.Add(this.form_label_currentStructure);
            this.Controls.Add(this.form_label_currentStructureTitle);
            this.Controls.Add(this.form_button_initData);
            this.Controls.Add(this.form_textBox_initData);
            this.Controls.Add(this.form_label_initData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_searchFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_searchUntil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_sortFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form_numericUpDown_sortUntil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label form_label_initData;
        private System.Windows.Forms.TextBox form_textBox_initData;
        private System.Windows.Forms.Button form_button_initData;
        private System.Windows.Forms.Label form_label_currentStructureTitle;
        private System.Windows.Forms.Label form_label_currentStructure;
        private System.Windows.Forms.Label form_label_convert;
        private System.Windows.Forms.ComboBox form_comboBox_convert;
        private System.Windows.Forms.Button form_button_convert;
        private System.Windows.Forms.Label form_label_search;
        private System.Windows.Forms.TextBox form_textBox_search;
        private System.Windows.Forms.Label form_label_search_using;
        private System.Windows.Forms.ComboBox form_comboBox_search;
        private System.Windows.Forms.Label form_label_search_from;
        private System.Windows.Forms.NumericUpDown form_numericUpDown_searchFrom;
        private System.Windows.Forms.Label form_label_search_until;
        private System.Windows.Forms.NumericUpDown form_numericUpDown_searchUntil;
        private System.Windows.Forms.Button form_button_search;
        private System.Windows.Forms.Label form_label_sort;
        private System.Windows.Forms.ComboBox form_comboBox_sort;
        private System.Windows.Forms.Label form_label_sortFrom;
        private System.Windows.Forms.NumericUpDown form_numericUpDown_sortFrom;
        private System.Windows.Forms.Label form_label_sortUntil;
        private System.Windows.Forms.NumericUpDown form_numericUpDown_sortUntil;
        private System.Windows.Forms.Button form_button_sort;
    }
}

