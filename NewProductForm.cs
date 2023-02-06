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
    public partial class NewProductForm : Form
    {
        public NewProductForm()
        {
            InitializeComponent();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewProductForm_Load(object sender, EventArgs e)
        {
            DepartmentID_ComboBox.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var newitem =
                 from deps in context.department.AsEnumerable()
                 select deps;
                foreach (var dep in newitem)
                {
                    DepartmentID_ComboBox.Items.Add(dep.DepartmentID);
                }
            }
        }

        private void DepartmentID_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showcaseID_ComboBox.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var newitem =
                 from showcaseinfo in context.showcaseinfo.AsEnumerable()
                 where showcaseinfo.DepartmentID == (String)DepartmentID_ComboBox.SelectedItem
                 select showcaseinfo;
                foreach (var itemLists in newitem)
                {
                    showcaseID_ComboBox.Items.Add(itemLists.ShowcaseID);
                }
            }
        }

        private void uploadNewProduct_Button_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var newitem = new item()
                {
                    ItemID = "GD-FD-000007",
                    ItemName = itemName_TextBox.Text,
                    TenantID = tenantID_TextBox.Text,
                    ShowcaseID = Convert.ToString(showcaseID_ComboBox.SelectedItem),
                    Category = "fd",
                    Price = Convert.ToDouble(price_TextBox.Text),
                    Description = description_TextBox.Text,
                    Photo = "asd",
                    Inventory = Convert.ToInt32(quantity_TextBox.Text),
                    NOS = Convert.ToInt32("100"),
                    DepartmentID = Convert.ToString(DepartmentID_ComboBox.SelectedItem)
                };
                context.item.Add(newitem);
                context.SaveChanges();
                MessageBox.Show("create new item successful");
                this.Close();
            }
        }
    }
}
