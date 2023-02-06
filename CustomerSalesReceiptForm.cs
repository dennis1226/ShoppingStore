using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_Project_P2
{
    public partial class CustomerSalesReceiptForm : Form
    {
        public CustomerSalesReceiptForm()
        {
            InitializeComponent();
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static DateTime Today { get; set; }
        private void CustomerSalesReceiptForm_Load(object sender, EventArgs e)
        {
            branchID_TextBox.Text = MainForm.passbranchtocustomersales;
            totalPrice_TextBox.Text = MainForm.passtotalpricetocustomersales;
            paymentMethod_TextBox.Text = MainForm.passpaymentmethodtocustomersales;
            DateTime now = DateTime.Now;
            date_TextBox.Text = Convert.ToString(now);
            //for (int i = 0; i < MainForm.shoppingCartSrc.Length; i++)
           //     shoppingList_DataGridView.Rows.Add(null, MainForm.shoppingCartSrc[i]);
            //checkOutAndPrintReceipt_Button_SalesFunctionPanel_Click (Main,press)
            //shoppingCart_DataGridView_SalesFunctionPanel (Main)
            //shoppingList_DataGridView (here)
        }

        private void print_Button_Click(object sender, EventArgs e)
        {
            //upload data to order
            //delete quantity of item
        }
    }
}
