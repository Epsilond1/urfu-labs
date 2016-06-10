namespace class_list_template
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookName = new System.Windows.Forms.TextBox();
            this.bookAuthor = new System.Windows.Forms.TextBox();
            this.bookList = new System.Windows.Forms.ListBox();
            this.BShow = new System.Windows.Forms.Button();
            this.BClear = new System.Windows.Forms.Button();
            this.bookYear = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioYear = new System.Windows.Forms.RadioButton();
            this.radioName = new System.Windows.Forms.RadioButton();
            this.BAdd = new System.Windows.Forms.Button();
            this.BDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookName
            // 
            this.bookName.Location = new System.Drawing.Point(12, 219);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(233, 20);
            this.bookName.TabIndex = 0;
            // 
            // bookAuthor
            // 
            this.bookAuthor.Location = new System.Drawing.Point(251, 219);
            this.bookAuthor.Name = "bookAuthor";
            this.bookAuthor.Size = new System.Drawing.Size(100, 20);
            this.bookAuthor.TabIndex = 1;
            // 
            // bookList
            // 
            this.bookList.FormattingEnabled = true;
            this.bookList.Location = new System.Drawing.Point(12, 24);
            this.bookList.Name = "bookList";
            this.bookList.Size = new System.Drawing.Size(417, 173);
            this.bookList.TabIndex = 3;
            // 
            // BShow
            // 
            this.BShow.Location = new System.Drawing.Point(447, 24);
            this.BShow.Name = "BShow";
            this.BShow.Size = new System.Drawing.Size(150, 23);
            this.BShow.TabIndex = 4;
            this.BShow.Text = "Заполнить";
            this.BShow.UseVisualStyleBackColor = true;
            this.BShow.Click += new System.EventHandler(this.BShow_Click);
            // 
            // BClear
            // 
            this.BClear.Location = new System.Drawing.Point(447, 62);
            this.BClear.Name = "BClear";
            this.BClear.Size = new System.Drawing.Size(150, 23);
            this.BClear.TabIndex = 5;
            this.BClear.Text = "Очистить";
            this.BClear.UseVisualStyleBackColor = true;
            this.BClear.Click += new System.EventHandler(this.BClear_Click);
            // 
            // bookYear
            // 
            this.bookYear.Location = new System.Drawing.Point(358, 218);
            this.bookYear.Name = "bookYear";
            this.bookYear.Size = new System.Drawing.Size(71, 20);
            this.bookYear.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioYear);
            this.groupBox1.Controls.Add(this.radioName);
            this.groupBox1.Location = new System.Drawing.Point(447, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортировка";
            // 
            // radioYear
            // 
            this.radioYear.AutoSize = true;
            this.radioYear.Location = new System.Drawing.Point(6, 42);
            this.radioYear.Name = "radioYear";
            this.radioYear.Size = new System.Drawing.Size(88, 17);
            this.radioYear.TabIndex = 1;
            this.radioYear.TabStop = true;
            this.radioYear.Text = "Год издания";
            this.radioYear.UseVisualStyleBackColor = true;
            // 
            // radioName
            // 
            this.radioName.AutoSize = true;
            this.radioName.Location = new System.Drawing.Point(6, 19);
            this.radioName.Name = "radioName";
            this.radioName.Size = new System.Drawing.Size(101, 17);
            this.radioName.TabIndex = 0;
            this.radioName.TabStop = true;
            this.radioName.Text = "Наименование";
            this.radioName.UseVisualStyleBackColor = true;
            // 
            // BAdd
            // 
            this.BAdd.Location = new System.Drawing.Point(447, 215);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(150, 23);
            this.BAdd.TabIndex = 8;
            this.BAdd.Text = "Добавить";
            this.BAdd.UseVisualStyleBackColor = true;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // BDelete
            // 
            this.BDelete.Location = new System.Drawing.Point(447, 98);
            this.BDelete.Name = "BDelete";
            this.BDelete.Size = new System.Drawing.Size(150, 23);
            this.BDelete.TabIndex = 9;
            this.BDelete.Text = "Удалить";
            this.BDelete.UseVisualStyleBackColor = true;
            this.BDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 251);
            this.Controls.Add(this.BDelete);
            this.Controls.Add(this.BAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bookYear);
            this.Controls.Add(this.BClear);
            this.Controls.Add(this.BShow);
            this.Controls.Add(this.bookList);
            this.Controls.Add(this.bookAuthor);
            this.Controls.Add(this.bookName);
            this.Name = "Form1";
            this.Text = "Работа с классом List<T>";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.TextBox bookAuthor;
        private System.Windows.Forms.ListBox bookList;
        private System.Windows.Forms.Button BShow;
        private System.Windows.Forms.Button BClear;
        private System.Windows.Forms.MaskedTextBox bookYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioYear;
        private System.Windows.Forms.RadioButton radioName;
        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.Button BDelete;
    }
}

