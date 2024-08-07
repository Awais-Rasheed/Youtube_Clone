namespace Youtube
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            search = new Button();
            search_query = new RichTextBox();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // search
            // 
            search.Location = new Point(771, 30);
            search.Name = "search";
            search.Size = new Size(89, 35);
            search.TabIndex = 0;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // search_query
            // 
            search_query.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            search_query.Location = new Point(179, 30);
            search_query.Name = "search_query";
            search_query.Size = new Size(586, 36);
            search_query.TabIndex = 1;
            search_query.Text = "";
            search_query.TextChanged += search_query_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(43, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 36);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(899, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(217, 36);
            comboBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1141, 562);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Controls.Add(search_query);
            Controls.Add(search);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button search;
        private RichTextBox search_query;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
    }
}