namespace _4915M_Project_P2
{
    partial class CustomerSalesReceiptForm
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
            this.title_Label = new System.Windows.Forms.Label();
            this.close_Button = new System.Windows.Forms.Button();
            this.totalPrice_TextBox = new System.Windows.Forms.TextBox();
            this.branchID_TextBox = new System.Windows.Forms.TextBox();
            this.print_Button = new System.Windows.Forms.Button();
            this.paymentMethod_Label = new System.Windows.Forms.Label();
            this.totalPrice_Label = new System.Windows.Forms.Label();
            this.rentalPeriod_Label = new System.Windows.Forms.Label();
            this.branchID_Label = new System.Windows.Forms.Label();
            this.paymentMethod_TextBox = new System.Windows.Forms.TextBox();
            this.date_TextBox = new System.Windows.Forms.TextBox();
            this.shoppingList_DataGridView = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingList_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // title_Label
            // 
            this.title_Label.AutoSize = true;
            this.title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_Label.Location = new System.Drawing.Point(253, 8);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(308, 37);
            this.title_Label.TabIndex = 0;
            this.title_Label.Text = "HKCS Sales Receipt";
            // 
            // close_Button
            // 
            this.close_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_Button.Location = new System.Drawing.Point(608, 456);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(105, 51);
            this.close_Button.TabIndex = 42;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // totalPrice_TextBox
            // 
            this.totalPrice_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice_TextBox.Location = new System.Drawing.Point(259, 397);
            this.totalPrice_TextBox.Name = "totalPrice_TextBox";
            this.totalPrice_TextBox.ReadOnly = true;
            this.totalPrice_TextBox.Size = new System.Drawing.Size(289, 31);
            this.totalPrice_TextBox.TabIndex = 38;
            // 
            // branchID_TextBox
            // 
            this.branchID_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchID_TextBox.Location = new System.Drawing.Point(260, 65);
            this.branchID_TextBox.Name = "branchID_TextBox";
            this.branchID_TextBox.ReadOnly = true;
            this.branchID_TextBox.Size = new System.Drawing.Size(289, 31);
            this.branchID_TextBox.TabIndex = 33;
            // 
            // print_Button
            // 
            this.print_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print_Button.Location = new System.Drawing.Point(608, 394);
            this.print_Button.Name = "print_Button";
            this.print_Button.Size = new System.Drawing.Size(105, 51);
            this.print_Button.TabIndex = 32;
            this.print_Button.Text = "Print";
            this.print_Button.UseVisualStyleBackColor = true;
            this.print_Button.Click += new System.EventHandler(this.print_Button_Click);
            // 
            // paymentMethod_Label
            // 
            this.paymentMethod_Label.AutoSize = true;
            this.paymentMethod_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethod_Label.Location = new System.Drawing.Point(73, 467);
            this.paymentMethod_Label.Name = "paymentMethod_Label";
            this.paymentMethod_Label.Size = new System.Drawing.Size(180, 25);
            this.paymentMethod_Label.TabIndex = 30;
            this.paymentMethod_Label.Text = "Payment Method:";
            // 
            // totalPrice_Label
            // 
            this.totalPrice_Label.AutoSize = true;
            this.totalPrice_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice_Label.Location = new System.Drawing.Point(134, 400);
            this.totalPrice_Label.Name = "totalPrice_Label";
            this.totalPrice_Label.Size = new System.Drawing.Size(121, 25);
            this.totalPrice_Label.TabIndex = 29;
            this.totalPrice_Label.Text = "Total Price:";
            // 
            // rentalPeriod_Label
            // 
            this.rentalPeriod_Label.AutoSize = true;
            this.rentalPeriod_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentalPeriod_Label.Location = new System.Drawing.Point(190, 433);
            this.rentalPeriod_Label.Name = "rentalPeriod_Label";
            this.rentalPeriod_Label.Size = new System.Drawing.Size(63, 25);
            this.rentalPeriod_Label.TabIndex = 26;
            this.rentalPeriod_Label.Text = "Date:";
            // 
            // branchID_Label
            // 
            this.branchID_Label.AutoSize = true;
            this.branchID_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchID_Label.Location = new System.Drawing.Point(143, 65);
            this.branchID_Label.Name = "branchID_Label";
            this.branchID_Label.Size = new System.Drawing.Size(112, 25);
            this.branchID_Label.TabIndex = 22;
            this.branchID_Label.Text = "Branch ID:";
            // 
            // paymentMethod_TextBox
            // 
            this.paymentMethod_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethod_TextBox.Location = new System.Drawing.Point(260, 467);
            this.paymentMethod_TextBox.Name = "paymentMethod_TextBox";
            this.paymentMethod_TextBox.ReadOnly = true;
            this.paymentMethod_TextBox.Size = new System.Drawing.Size(289, 31);
            this.paymentMethod_TextBox.TabIndex = 43;
            // 
            // date_TextBox
            // 
            this.date_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_TextBox.Location = new System.Drawing.Point(259, 430);
            this.date_TextBox.Name = "date_TextBox";
            this.date_TextBox.ReadOnly = true;
            this.date_TextBox.Size = new System.Drawing.Size(289, 31);
            this.date_TextBox.TabIndex = 44;
            // 
            // shoppingList_DataGridView
            // 
            this.shoppingList_DataGridView.AllowUserToAddRows = false;
            this.shoppingList_DataGridView.AllowUserToDeleteRows = false;
            this.shoppingList_DataGridView.AllowUserToResizeColumns = false;
            this.shoppingList_DataGridView.AllowUserToResizeRows = false;
            this.shoppingList_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shoppingList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shoppingList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.ItemPrice,
            this.ItemQuantity,
            this.DepartmentID});
            this.shoppingList_DataGridView.Location = new System.Drawing.Point(149, 119);
            this.shoppingList_DataGridView.Name = "shoppingList_DataGridView";
            this.shoppingList_DataGridView.ReadOnly = true;
            this.shoppingList_DataGridView.Size = new System.Drawing.Size(400, 232);
            this.shoppingList_DataGridView.TabIndex = 45;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "ItemPrice";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.HeaderText = "ItemQuantity";
            this.ItemQuantity.Name = "ItemQuantity";
            this.ItemQuantity.ReadOnly = true;
            // 
            // DepartmentID
            // 
            this.DepartmentID.HeaderText = "DepartmentID";
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.ReadOnly = true;
            // 
            // CustomerSalesReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 518);
            this.Controls.Add(this.shoppingList_DataGridView);
            this.Controls.Add(this.date_TextBox);
            this.Controls.Add(this.paymentMethod_TextBox);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.totalPrice_TextBox);
            this.Controls.Add(this.branchID_TextBox);
            this.Controls.Add(this.print_Button);
            this.Controls.Add(this.paymentMethod_Label);
            this.Controls.Add(this.totalPrice_Label);
            this.Controls.Add(this.rentalPeriod_Label);
            this.Controls.Add(this.branchID_Label);
            this.Controls.Add(this.title_Label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 557);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 557);
            this.Name = "CustomerSalesReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Receipt";
            this.Load += new System.EventHandler(this.CustomerSalesReceiptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shoppingList_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.TextBox totalPrice_TextBox;
        private System.Windows.Forms.TextBox branchID_TextBox;
        private System.Windows.Forms.Button print_Button;
        private System.Windows.Forms.Label paymentMethod_Label;
        private System.Windows.Forms.Label totalPrice_Label;
        private System.Windows.Forms.Label rentalPeriod_Label;
        private System.Windows.Forms.Label branchID_Label;
        private System.Windows.Forms.TextBox paymentMethod_TextBox;
        private System.Windows.Forms.TextBox date_TextBox;
        private System.Windows.Forms.DataGridView shoppingList_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
    }
}