namespace WinFormsApp1
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
            btnAddNewData = new Button();
            btnRetrieveAllData = new Button();
            btnRetrieveSelectedData = new Button();
            btnUpdateSpecificData = new Button();
            btnDeleteSpecificData = new Button();
            SuspendLayout();
            // 
            // btnAddNewData
            // 
            btnAddNewData.Location = new Point(28, 32);
            btnAddNewData.Margin = new Padding(5, 6, 5, 6);
            btnAddNewData.Name = "btnAddNewData";
            btnAddNewData.Size = new Size(386, 54);
            btnAddNewData.TabIndex = 0;
            btnAddNewData.Text = "Add New Data";
            btnAddNewData.UseVisualStyleBackColor = true;
            btnAddNewData.Click += btnAddNewData_Click;
            // 
            // btnRetrieveAllData
            // 
            btnRetrieveAllData.Location = new Point(28, 98);
            btnRetrieveAllData.Margin = new Padding(5, 6, 5, 6);
            btnRetrieveAllData.Name = "btnRetrieveAllData";
            btnRetrieveAllData.Size = new Size(386, 54);
            btnRetrieveAllData.TabIndex = 1;
            btnRetrieveAllData.Text = "Retrieve All Data";
            btnRetrieveAllData.UseVisualStyleBackColor = true;
            btnRetrieveAllData.Click += btnRetrieveAllData_Click;
            // 
            // btnRetrieveSelectedData
            // 
            btnRetrieveSelectedData.Location = new Point(28, 164);
            btnRetrieveSelectedData.Margin = new Padding(5, 6, 5, 6);
            btnRetrieveSelectedData.Name = "btnRetrieveSelectedData";
            btnRetrieveSelectedData.Size = new Size(386, 54);
            btnRetrieveSelectedData.TabIndex = 2;
            btnRetrieveSelectedData.Text = "Retrieve Selected Data";
            btnRetrieveSelectedData.UseVisualStyleBackColor = true;
            btnRetrieveSelectedData.Click += btnRetrieveSelectedData_Click;
            // 
            // btnUpdateSpecificData
            // 
            btnUpdateSpecificData.Location = new Point(28, 230);
            btnUpdateSpecificData.Margin = new Padding(5, 6, 5, 6);
            btnUpdateSpecificData.Name = "btnUpdateSpecificData";
            btnUpdateSpecificData.Size = new Size(386, 54);
            btnUpdateSpecificData.TabIndex = 3;
            btnUpdateSpecificData.Text = "Update Specific Data";
            btnUpdateSpecificData.UseVisualStyleBackColor = true;
            btnUpdateSpecificData.Click += btnUpdateSpecificData_Click;
            // 
            // btnDeleteSpecificData
            // 
            btnDeleteSpecificData.Location = new Point(28, 296);
            btnDeleteSpecificData.Margin = new Padding(5, 6, 5, 6);
            btnDeleteSpecificData.Name = "btnDeleteSpecificData";
            btnDeleteSpecificData.Size = new Size(386, 54);
            btnDeleteSpecificData.TabIndex = 4;
            btnDeleteSpecificData.Text = "Delete Specific Data";
            btnDeleteSpecificData.UseVisualStyleBackColor = true;
            btnDeleteSpecificData.Click += btnDeleteSpecificData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 376);
            Controls.Add(btnDeleteSpecificData);
            Controls.Add(btnUpdateSpecificData);
            Controls.Add(btnRetrieveSelectedData);
            Controls.Add(btnRetrieveAllData);
            Controls.Add(btnAddNewData);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddNewData;
        private Button button1;
        private Button button2;
        private Button btnRetrieveAllData;
        private Button btnRetrieveSelectedData;
        private Button btnUpdateSpecificData;
        private Button btnDeleteSpecificData;
    }
}
