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
    public partial class MasterDataMaintenanceForm : Form
    {
        public MasterDataMaintenanceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var accounts =
                 from account in context.account.AsEnumerable()
                 select account;
                dataGridView1.Columns.Add("AccountID", "AccountID");
                dataGridView1.Columns.Add("AccountName", "AccountName");
                dataGridView1.Columns.Add("Password", "Password");
                dataGridView1.Columns.Add("AccountType", "AccountType");

                foreach (var list in accounts)
                {
                    dataGridView1.Rows.Add(list.accountID, list.accountName, list.password, list.accountType);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var department =
                 from departments in context.department.AsEnumerable()
                 select departments;
                dataGridView1.Columns.Add("DepartmentID", "DepartmentID");
                dataGridView1.Columns.Add("DepartmentName", "DepartmentName");
                dataGridView1.Columns.Add("Location", "Location");


                foreach (var list in department)
                {
                    dataGridView1.Rows.Add(list.DepartmentID, list.DepartmentName, list.Location);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var inventorys =
                 from inventory in context.inventory.AsEnumerable()
                 select inventory;
                dataGridView1.Columns.Add("InventoryNo", "InventoryNo");
                dataGridView1.Columns.Add("ItemID", "ItemID");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("Date", "Date");
                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("TextFile", "TextFile");

                foreach (var list in inventorys)
                {
                    dataGridView1.Rows.Add(list.InventoryNo, list.ItemID, list.Quantity, list.Date, list.Status, list.TextFile);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var items =
                 from item in context.item.AsEnumerable()
                 select item;
                dataGridView1.Columns.Add("ItemID", "ItemID");
                dataGridView1.Columns.Add("ItemName", "ItemName");
                dataGridView1.Columns.Add("TenantID", "TenantID");
                dataGridView1.Columns.Add("Date", "Date");
                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("TextFile", "TextFile");

                foreach (var list in items)
                {
                    dataGridView1.Rows.Add(list.ItemID, list.ItemName, list.TenantID, list.ShowcaseID, list.Category, list.Price, list.Description, list.Photo, list.Inventory, list.NOS, list.DepartmentID);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var orderss =
                 from orders in context.orders.AsEnumerable()
                 select orders;
                dataGridView1.Columns.Add("OrderID", "OrderID");
                dataGridView1.Columns.Add("CustomerID", "CustomerID");
                dataGridView1.Columns.Add("ItemID", "ItemID");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("Amount", "Amount");
                dataGridView1.Columns.Add("Date", "Date");
                dataGridView1.Columns.Add("PaymentMethod", "PaymentMethod");
                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("DepartmentID", "DepartmentID");
                dataGridView1.Columns.Add("showcaseID", "showcaseID");

                foreach (var list in orderss)
                {
                    dataGridView1.Rows.Add(list.OrderID, list.CustomerID, list.ItemID, list.Quantity, list.Amount, list.Date, list.PaymentMethod, list.Status, list.DepartmentID, list.showcaseID);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var rentrecords =
                 from rentrecord in context.rentrecord.AsEnumerable()
                 select rentrecord;
                dataGridView1.Columns.Add("RentID", "RentID");
                dataGridView1.Columns.Add("DepartmentID", "DepartmentID");
                dataGridView1.Columns.Add("ShowcaseID", "ShowcaseID");
                dataGridView1.Columns.Add("TenantID", "TenantID");
                dataGridView1.Columns.Add("RentMonth", "RentMonth");
                dataGridView1.Columns.Add("RentFirstDay", "RentFirstDay");
                dataGridView1.Columns.Add("RentLastDay", "RentLastDay");
                dataGridView1.Columns.Add("RentPrice", "RentPrice");
                foreach (var list in rentrecords)
                {
                    dataGridView1.Rows.Add(list.RentID, list.DepartmentID, list.ShowcaseID, list.TenantID, list.RentMonth, list.RentFirstDay, list.RentLastDay, list.RentPrice);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var showcaseinfos =
                 from showcaseinfo in context.showcaseinfo.AsEnumerable()
                 select showcaseinfo;
                dataGridView1.Columns.Add("ShowcaseID", "ShowcaseID");
                dataGridView1.Columns.Add("DepartmentID", "DepartmentID");
                dataGridView1.Columns.Add("RentDollars", "RentDollars");
                dataGridView1.Columns.Add("Size", "Size");
                dataGridView1.Columns.Add("RentStatus", "RentStatus");
                foreach (var list in showcaseinfos)
                {
                    dataGridView1.Rows.Add(list.ShowcaseID, list.DepartmentID, list.RentDollars, list.Size, list.RentStatus);
                }
            }
        }

    }
}
