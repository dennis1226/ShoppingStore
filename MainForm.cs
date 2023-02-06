using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_Project_P2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkOutAndPrintReceipt_Button_SalesFunctionPanel.Enabled = false;
            addToShoppingCart_Button_SalesFunctionPanel.Enabled = false;
            LoginPanel.Show();
            AccountControlAdminPanel.Hide();
            RegisterPanel.Hide();
            MainPanel.Hide();
            AccountInformationPanel.Hide();
            AccountControlAdminPanel.Hide();
            SystemSecurityAndControlPanel.Hide();
            ProductListPanel.Hide();
            ProductListPanel.Hide();
            ProductManagementPanel.Hide();
            ShowcaseManagementPanel.Hide();
            SalesManagementPanel.Hide();
            ShowcaseManagementPanel.Visible = false;
        }
        public static String passbranchtocustomersales;
        public static String passtotalpricetocustomersales;
        public static string passpaymentmethodtocustomersales;
        public static String[] shoppingCartSrc;

        private void clearLoginInfo_Button_Click(object sender, EventArgs e)
        {
            accountName_TextBox_LoginPanel.Text = "";
            loginPassword_TextBox_LoginPanel.Text = "";

        }

        private void haveAccount_Button_RegisterPanel_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
            RegisterPanel.Hide();
        }

        private void clearRegisterInfo_Button_RegisterPanel_Click(object sender, EventArgs e)
        {
            accountName_textBox_RegisterPanel.Text = "";
            password_textBox_RegisterPanel.Text = "";
        }

        private void register_Button_LoginPanel_Click(object sender, EventArgs e)
        {
            RegisterPanel.Show();
        }

        private void forgotPassword_Button_LoginPanel_Click(object sender, EventArgs e)
        {

        }
        public static int userid = 0;
        public static String usertype;
        public static String userName;
        public static String userPassword;
        private void login_Button_LoginPanel_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var user = context.account.Where(u => u.accountName == accountName_TextBox_LoginPanel.Text).FirstOrDefault();
                if (user != null)
                {
                    if (user.password == loginPassword_TextBox_LoginPanel.Text)
                    {
                        userName = accountName_TextBox_LoginPanel.Text;
                        userPassword = loginPassword_TextBox_LoginPanel.Text;
                        accountName_TextBox_LoginPanel.Text = "";
                        loginPassword_TextBox_LoginPanel.Text = "";
                        MainPanel.Show();
                        LoginPanel.Hide();
                    }
                    else
                        MessageBox.Show("Wrong Account or Password");
                }
                else
                    MessageBox.Show("Wrong Account or Password");
            }

        }
        public static String passShowcaseID;
        private void rent_Button_ShowcaseListPanel_Click(object sender, EventArgs e)
        {
            Form ShowcaseRentForm = new ShowcaseRentForm();
            passShowcaseID = (String)showcaseID_TextBox_ShowcaseListPanel.Text;
            ShowcaseRentForm.ShowDialog();
        }

        private void logout_Button_MainPanel_Click(object sender, EventArgs e)
        {
            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                p.Visible = false;
            }
            LoginPanel.Show();
        }

        private void showcaseManagement_Button_MainPanel_Click(object sender, EventArgs e)
        {
            ShowcaseManagementPanel.Visible = true;
            branch_ComboBox_ShowcaseListPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                foreach (var stock2 in context.department.ToList())
                {
                    branch_ComboBox_ShowcaseListPanel.Items.Add(stock2.DepartmentID);
                }
            }
            ProductManagementPanel.Visible = false;
            SalesManagementPanel.Visible = false;
            SystemSecurityAndControlPanel.Visible = false;
        }

        private void showcaseList_Button_ShowcaseManagementPanel_Click(object sender, EventArgs e)
        {
            ShowcaseListPanel.Show();
            branch_ComboBox_ShowcaseListPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                foreach (var stock2 in context.department.ToList())
                {
                    branch_ComboBox_ShowcaseListPanel.Items.Add(stock2.DepartmentID);
                }
            }
            ShowcaseListPanel.Visible = true;
            RentalRecordPanel.Visible = false;
            RentPaymentRecord.Visible = false;
        }

        private void rentalRecord_Button_ShowcaseManagementPanel_Click(object sender, EventArgs e)
        {
            RentalRecordPanel.Visible = true;
            ShowcaseListPanel.Visible = false;
            RentPaymentRecord.Visible = false;
            rentalRecord_DataGridView_RentalRecordPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var rentrecords =
                 from rentrecord in context.rentrecord.AsEnumerable()
                 select rentrecord;
                foreach (var list in rentrecords)
                {
                    rentalRecord_DataGridView_RentalRecordPanel.Rows.Add(list.RentID, list.DepartmentID, list.ShowcaseID, list.TenantID, list.RentMonth, list.RentFirstDay, list.RentLastDay, list.RentPrice);
                }

            }
        }

        private void rentPaymentRecord_Button_ShowcaseManagementPanel_Click(object sender, EventArgs e)
        {
            ShowcaseListPanel.Visible = false;
            RentalRecordPanel.Visible = false;
            RentPaymentRecord.Visible = true;
            RentPaymentRecord.Show();
        }

        private void stockInRecord_Button_ProductManagementPanel_Click(object sender, EventArgs e)
        {
            ProductListPanel.Visible = false;
            StockInRecordPanel.Visible = true;
            StockOutRecordPanel.Visible = false;

            stockInRecord_DataGridView_StockInPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var stockinRecord =
                 from inventorys in context.inventory.AsEnumerable()
                 select inventorys;
                foreach (var list in stockinRecord)
                {
                    stockInRecord_DataGridView_StockInPanel.Rows.Add(list.InventoryNo, list.ItemID, list.Quantity, list.Date, list.Status, list.TextFile);
                }
            }
        }

        private void stockOutRecord_Button_ProductManagementPanel_Click(object sender, EventArgs e)
        {
            ProductListPanel.Visible = false;
            StockInRecordPanel.Visible = false;
            StockOutRecordPanel.Visible = true;

            stockOutRecord_DataGridView_StockOutRecordPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var stockoutRecord =
                 from orderss in context.orders.AsEnumerable()
                 select orderss;
                foreach (var list in stockoutRecord)
                {
                    stockOutRecord_DataGridView_StockOutRecordPanel.Rows.Add(list.OrderID, list.CustomerID, list.ItemID, list.Quantity, list.Amount, list.Date, list.PaymentMethod,list.Status);
                }
            }
        }

        private void productList_Button_ProductManagementPanel_Click(object sender, EventArgs e)
        {
            ProductListPanel.Visible = true;
            StockInRecordPanel.Visible = false;
            StockOutRecordPanel.Visible = false;
            productList_ListBox_ProductListPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var itemList =
                 from items in context.item.AsEnumerable()
                 select items;
                foreach (var itemLists in itemList)
                {
                    productList_ListBox_ProductListPanel.Items.Add(itemLists.ItemName);
                }
            }

        }

        private void productManagement_Button_MainPanel_Click(object sender, EventArgs e)
        {
            ShowcaseManagementPanel.Visible = false;
            ProductManagementPanel.Visible = true;
            SalesManagementPanel.Visible = false;
            SystemSecurityAndControlPanel.Visible = false;
            ProductListPanel.Visible = false;
            StockInRecordPanel.Visible = false;
            StockOutRecordPanel.Visible = false;
        }

        private void uploadNewProduct_Button_ProductListPanel_Click(object sender, EventArgs e)
        {
            Form NewProductForm = new NewProductForm();
            NewProductForm.ShowDialog();
        }
        public static DateTime Today { get; set; }
        private void checkOutAndPrintReceipt_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
            Form CustomerSalesReceiptForm = new CustomerSalesReceiptForm();
            passbranchtocustomersales = branch_ComboBox_SalesFunctionPanel.Text;
            passtotalpricetocustomersales = totalPrice_TextBox_SalesFunctionPanel.Text;
            passpaymentmethodtocustomersales = paymentMethod_ComboBox_SalesFunctionPanel.Text;
            //for (int i = 0; i < shoppingCart_DataGridView_SalesFunctionPanel.RowCount; i++)
            //  shoppingCartSrc[i] = shoppingCart_DataGridView_SalesFunctionPanel.Rows.ToString();

            using (hkcsEntities context = new hkcsEntities())
            {
                String ItemID = "";
                String ItemName = "";
                double price = 0;
                int quantity = 0;
                String deptid = "";
                String shopshowcaseID = "";

                for (int k = 0; k < shoppingCart_DataGridView_SalesFunctionPanel.Rows.Count; k++)
                {
                    //itemID
                    ItemID = Convert.ToString(shoppingCart_DataGridView_SalesFunctionPanel.Rows[k].Cells[0].Value);
                    //item name
                    ItemName = Convert.ToString(shoppingCart_DataGridView_SalesFunctionPanel.Rows[k].Cells[1].Value);
                    //amount
                    price = Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.Rows[k].Cells[2].Value);
                    //quantity
                    quantity = Convert.ToInt32(shoppingCart_DataGridView_SalesFunctionPanel.Rows[k].Cells[3].Value);
                    //deptid
                    deptid = Convert.ToString(shoppingCart_DataGridView_SalesFunctionPanel.Rows[k].Cells[4].Value);
                    //showcaseID
                    var ScID =
                    from items in context.item.AsEnumerable()
                    where items.ItemName == ItemName
                    select items;
                    foreach (var scID in ScID)
                    {
                        shopshowcaseID = scID.ShowcaseID; 
                    }

                    var neworder = new orders()
                        {
                            CustomerID = "",
                            ItemID = Convert.ToString(ItemID),
                            Quantity = quantity,
                            Amount = price,
                            Date = Today,
                            PaymentMethod = paymentMethod_ComboBox_SalesFunctionPanel.Text,
                            Status = "done",
                            DepartmentID = deptid,
                            showcaseID = shopshowcaseID
                    };                 
                        context.orders.Add(neworder);
                }
                context.SaveChanges();
            }
            CustomerSalesReceiptForm.ShowDialog();
        }

        private void salesFunction_Button_SalesManagementPanel_Click(object sender, EventArgs e)
        {
            SalesFunctionPanel.Visible = true;
            ShowcaseSalesRecordPanel.Visible = false;
            productList_DataGridView_SalesFunctionPanel.Rows.Clear();
            shoppingCart_DataGridView_SalesFunctionPanel.Rows.Clear();
            totalPrice_TextBox_SalesFunctionPanel.Text = "0";
            totalPrice = 0;
           
        }

        private void showcaseSalesRecord_Button_SalesManagementPanel_Click(object sender, EventArgs e)
        {
            SalesFunctionPanel.Visible = false;
            ShowcaseSalesRecordPanel.Visible = true;
            branch_ComboBox_ShowcaseSalesRecordPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {

                foreach (var list in context.department.ToList())
                {
                    branch_ComboBox_ShowcaseSalesRecordPanel.Items.Add(list.DepartmentID);

                }
            }
        }

        private void salesManagement_Button_MainPanel_Click(object sender, EventArgs e)
        {
            ShowcaseManagementPanel.Visible = false;
            ProductManagementPanel.Visible = false;
            SalesManagementPanel.Visible = true;
            SystemSecurityAndControlPanel.Visible = false;
            productList_DataGridView_SalesFunctionPanel.Rows.Clear();
        }

        private void accountInformation_Button_SystemSecurityAndControlPanel_Click(object sender, EventArgs e)
        {
            AccountInformationPanel.Visible = true;
            AccountControlAdminPanel.Visible = false;
            userID_TextBox_AccountInformationPanel.Text = userName;
            password_TextBox_AccountInformationPanel.Text = userPassword;
        }

        private void accountControlAdmin_Button_SystemSecurityAndControlPanel_Click(object sender, EventArgs e)
        {
            userList_ListBox_AccountControlAdminPanel.Items.Clear();
            updateAccountInformation_Button_AccountControlAdminPanel.Enabled = false;
            AccountInformationPanel.Visible = false;
            AccountControlAdminPanel.Visible = true;
            using (hkcsEntities context = new hkcsEntities())
            {
                var Type =
                 from accounts in context.account.AsEnumerable()
                 where userType_ComboBox_AccountControlAdminPanel.Text == accounts.accountType
                 select accounts.accountID;
                foreach (var accountType in Type)
                {
                    userType_ComboBox_AccountControlAdminPanel.Items.Add(accountType);
                }
            }
        }

        private void systemSecurityAndControl_Button_MainPanel_Click(object sender, EventArgs e)
        {
            ShowcaseManagementPanel.Visible = false;
            ProductManagementPanel.Visible = false;
            SalesManagementPanel.Visible = false;
            SystemSecurityAndControlPanel.Visible = true;
        }

        private void masterDataMaintenance_Button_MainPanel_Click(object sender, EventArgs e)
        {
            Form MasterDataMaintenanceForm = new MasterDataMaintenanceForm();
            MasterDataMaintenanceForm.Show();
        }
        public static String registerType;

        private void branch_ComboBox_ShowcaseListPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            available_CheckBox_ShowcaseListPanel.Checked = false;
            showcaseList_ListBox_ShowcaseListPanel.Items.Clear();
            showcaseID_TextBox_ShowcaseListPanel.Text = "";
            branchID_TextBox_ShowcaseListPanel.Text = "";
            size_TextBox_ShowcaseListPanel.Text = "";
            pricePerMonth_TextBox_ShowcaseListPanel.Text = "";
            status_textBox_ShowcaseListPanel.Text = "";
            using (hkcsEntities context = new hkcsEntities())
            {
                var showCaseList =
                 from showcaseinfo in context.showcaseinfo.AsEnumerable()
                 where showcaseinfo.DepartmentID == branch_ComboBox_ShowcaseListPanel.Text
                 where showcaseinfo.RentStatus == "registed"
                 select showcaseinfo;
                foreach (var showList in showCaseList)
                {
                    showcaseList_ListBox_ShowcaseListPanel.Items.Add(showList.ShowcaseID);
                }
            }
        }

        private void available_CheckBox_ShowcaseListPanel_CheckedChanged(object sender, EventArgs e)
        {
            showcaseList_ListBox_ShowcaseListPanel.Items.Clear();
            showcaseID_TextBox_ShowcaseListPanel.Text = "";
            branchID_TextBox_ShowcaseListPanel.Text = "";
            size_TextBox_ShowcaseListPanel.Text = "";
            pricePerMonth_TextBox_ShowcaseListPanel.Text = "";
            status_textBox_ShowcaseListPanel.Text = "";

            if (available_CheckBox_ShowcaseListPanel.Checked)
            {
                using (hkcsEntities context = new hkcsEntities())
                {
                    var showCaseList =
                     from showcaseinfo in context.showcaseinfo.AsEnumerable()
                     where showcaseinfo.DepartmentID == branch_ComboBox_ShowcaseListPanel.Text
                     where showcaseinfo.RentStatus == "noregisted"
                     select showcaseinfo;
                    foreach (var showList in showCaseList)
                    {
                        showcaseList_ListBox_ShowcaseListPanel.Items.Add(showList.ShowcaseID);
                    }
                }

            }
            else
            {
                using (hkcsEntities context = new hkcsEntities())
                {
                    var showCaseList =
                     from showcaseinfo in context.showcaseinfo.AsEnumerable()
                     where showcaseinfo.DepartmentID == branch_ComboBox_ShowcaseListPanel.Text
                     where showcaseinfo.RentStatus == "registed"
                     select showcaseinfo;
                    foreach (var showList in showCaseList)
                    {
                        showcaseList_ListBox_ShowcaseListPanel.Items.Add(showList.ShowcaseID);
                    }
                }
            }
        }

        private void showcaseList_ListBox_ShowcaseListPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            showcaseID_TextBox_ShowcaseListPanel.Text = (String)showcaseList_ListBox_ShowcaseListPanel.SelectedItem;
            using (hkcsEntities context = new hkcsEntities())
            {
                var info =
                 from showcaseinfo in context.showcaseinfo.AsEnumerable()
                 where showcaseinfo.ShowcaseID == showcaseID_TextBox_ShowcaseListPanel.Text
                 select showcaseinfo;
                foreach (var showinfo in info)
                {
                    branchID_TextBox_ShowcaseListPanel.Text = showinfo.DepartmentID;
                    size_TextBox_ShowcaseListPanel.Text = showinfo.Size;
                    pricePerMonth_TextBox_ShowcaseListPanel.Text = Convert.ToString(showinfo.RentDollars);
                    status_textBox_ShowcaseListPanel.Text = showinfo.RentStatus;
                }
            }
            if (status_textBox_ShowcaseListPanel.Text == "noregister")
                rent_Button_ShowcaseListPanel.Enabled = false;
            else
                rent_Button_ShowcaseListPanel.Enabled = true;

            if (status_textBox_ShowcaseListPanel.Text == "registed")
                rent_Button_ShowcaseListPanel.Enabled = false;
            else
                rent_Button_ShowcaseListPanel.Enabled = true;
        }

        private void ShowcaseManagementPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RentPaymentRecord_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void F5_button_RentalRecordPanel_Click(object sender, EventArgs e)
        {
            rentalRecord_DataGridView_RentalRecordPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var rentrecords =
                 from rentrecord in context.rentrecord.AsEnumerable()
                 select rentrecord;
                foreach (var list in rentrecords)
                {
                    rentalRecord_DataGridView_RentalRecordPanel.Rows.Add(list.RentID, list.DepartmentID, list.ShowcaseID, list.TenantID, list.RentMonth, list.RentFirstDay, list.RentLastDay, list.RentPrice);
                }
            }
        }

        private void outOfStock_CheckBox_ProductListPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (outOfStock_CheckBox_ProductListPanel.Checked){
            productList_ListBox_ProductListPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var itemListoutstock =
                 from items in context.item.AsEnumerable()
                 where items.ItemName == (String)productList_ListBox_ProductListPanel.SelectedItem
                 where items.Inventory == 0 
                 select items;
                foreach (var stockout in itemListoutstock)
                {
                    productList_ListBox_ProductListPanel.Items.Add(stockout.ItemName);
                }
            }
            }
            else
            {
                productList_ListBox_ProductListPanel.Items.Clear();
                using (hkcsEntities context = new hkcsEntities())
                {
                    var itemList =
                     from items in context.item.AsEnumerable()
                     select items;
                    foreach (var itemLists in itemList)
                    {
                        productList_ListBox_ProductListPanel.Items.Add(itemLists.ItemName);
                    }
                }
            }
        }

        private void refresh_Button_ProductListPanel_Click(object sender, EventArgs e)
        {
            if (outOfStock_CheckBox_ProductListPanel.Checked)
            {
                productList_ListBox_ProductListPanel.Items.Clear();
                using (hkcsEntities context = new hkcsEntities())
                {
                    var itemListoutstock =
                     from items in context.item.AsEnumerable()
                     where items.ItemName == (String)productList_ListBox_ProductListPanel.SelectedItem
                     where items.Inventory == 0
                     select items;
                    foreach (var stockout in itemListoutstock)
                    {
                        productList_ListBox_ProductListPanel.Items.Add(stockout.ItemName);
                    }
                }
            }
            else
            {
                productList_ListBox_ProductListPanel.Items.Clear();
                using (hkcsEntities context = new hkcsEntities())
                {
                    var itemList =
                     from items in context.item.AsEnumerable()
                     select items;
                    foreach (var itemLists in itemList)
                    {
                        productList_ListBox_ProductListPanel.Items.Add(itemLists.ItemName);
                    }
                }
            }
        }

        private void productList_ListBox_ProductListPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            description_TextBox_ProductListPanel.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var itemdes =
                 from items in context.item.AsEnumerable()
                 where  items.ItemName == (String)productList_ListBox_ProductListPanel.SelectedItem
                 select items;
                foreach (var itemLists in itemdes)
                {
                    description_TextBox_ProductListPanel.Text = itemLists.Description;
                    showcaseID_TextBox_ProductListPanel.Text = itemLists.ShowcaseID;
                    productID_TextBox_ProductListPanel.Text = itemLists.ItemID;
                    price_TextBox_ProductListPanel.Text = Convert.ToString(itemLists.Price); 
                    quantity_TextBox_ProductListPanel.Text = Convert.ToString(itemLists.Inventory);
                }
            }
            
        }

        private void uploadPicture_Button_ProductListPanel_Click(object sender, EventArgs e)
        {
            //productPicture_PictureBox_ProductListPanel show where = itemname rows picturename 
        }

        private void updateProductInformation_Button_ProductListPanel_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var itemdes =
                 from items in context.item.AsEnumerable()
                 where items.ItemName == (String)productList_ListBox_ProductListPanel.SelectedItem
                 select items;
                foreach (var itemLists in itemdes)
                {
                    itemLists.Description = description_TextBox_ProductListPanel.Text;
                    itemLists.ShowcaseID = showcaseID_TextBox_ProductListPanel.Text;
                    itemLists.ItemID = productID_TextBox_ProductListPanel.Text;
                    itemLists.Price = Convert.ToDouble(price_TextBox_ProductListPanel.Text);
                    itemLists.Inventory = Convert.ToInt32(quantity_TextBox_ProductListPanel.Text);
                }
                context.SaveChanges();
                MessageBox.Show("Update successful");
            }
        }

        private void refresh_Button_StockInPanel_Click(object sender, EventArgs e)
        {
            stockInRecord_DataGridView_StockInPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var stockinRecord =
                 from inventorys in context.inventory.AsEnumerable()
                 select inventorys;
                foreach (var list in stockinRecord)
                {
                    stockInRecord_DataGridView_StockInPanel.Rows.Add(list.InventoryNo, list.ItemID, list.Quantity, list.Date, list.Status, list.TextFile);
                }
            }
        }

        private void refresh_Button_StockOutRecordPanel_Click(object sender, EventArgs e)
        {
            stockOutRecord_DataGridView_StockOutRecordPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var stockoutRecord =
                 from orderss in context.orders.AsEnumerable()
                 select orderss;
                foreach (var list in stockoutRecord)
                {
                    stockOutRecord_DataGridView_StockOutRecordPanel.Rows.Add(list.OrderID, list.CustomerID, list.ItemID, list.Quantity, list.Amount, list.Date, list.PaymentMethod, list.Status);
                }
            }
        }

        private void SalesManagementPanel_Paint(object sender, PaintEventArgs e)
        {
            branch_ComboBox_SalesFunctionPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var branch =
                 from dept in context.department.AsEnumerable()
                 select dept;
                foreach (var list in branch)
                {
                    branch_ComboBox_SalesFunctionPanel.Items.Add(list.DepartmentID);
                }
            }
        }

        private void branch_ComboBox_SalesFunctionPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            productList_DataGridView_SalesFunctionPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var item =
                 from items in context.item.AsEnumerable()
                 where (String)branch_ComboBox_SalesFunctionPanel.SelectedItem == items.DepartmentID
                 select items;
                foreach (var list in item)
                {
                    productList_DataGridView_SalesFunctionPanel.Rows.Add(list.ItemID,list.ItemName,list.Price,list.Inventory,list.DepartmentID);
                }
            }
            
        }

        private void refresh_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
            productList_DataGridView_SalesFunctionPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var item =
                 from items in context.item.AsEnumerable()
                 where (String)branch_ComboBox_SalesFunctionPanel.SelectedItem == items.DepartmentID
                 select items;
                foreach (var list in item)
                {
                    productList_DataGridView_SalesFunctionPanel.Rows.Add(list.ItemName, list.Price, list.Inventory);
                }
            }
        }
        public double totalPrice = 0;
        private void addToShoppingCart_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
            
            //add item to cart
            shoppingCart_DataGridView_SalesFunctionPanel.Rows.Add(
                productList_DataGridView_SalesFunctionPanel.CurrentRow.Cells[0].Value,
                productList_DataGridView_SalesFunctionPanel.CurrentRow.Cells[1].Value,
                productList_DataGridView_SalesFunctionPanel.CurrentRow.Cells[2].Value,
                (String)quantity_TextBox_SalesFunctionPanel.Text,
                productList_DataGridView_SalesFunctionPanel.CurrentRow.Cells[4].Value);

            //cal total price
            double waitingprice = Convert.ToDouble(quantity_TextBox_SalesFunctionPanel.Text) * (double)productList_DataGridView_SalesFunctionPanel.CurrentRow.Cells[2].Value;
           
            totalPrice = (totalPrice + waitingprice);
            totalPrice_TextBox_SalesFunctionPanel.Text = Convert.ToString(totalPrice);
            
            //double newtotalprice = Convert.ToDouble(totalPrice_TextBox_SalesFunctionPanel.Text) + waitingprice;
            //totalPrice_TextBox_SalesFunctionPanel.Text = Convert.ToString(newtotalprice);
        }

        private void SalesFunctionPanel_Paint(object sender, PaintEventArgs e)
        {
            if (productList_DataGridView_SalesFunctionPanel.Rows.Count > 0)
                addToShoppingCart_Button_SalesFunctionPanel.Enabled = true;
            else
                addToShoppingCart_Button_SalesFunctionPanel.Enabled = false;

            if (shoppingCart_DataGridView_SalesFunctionPanel.Rows.Count > 0)
            {
                removeProductFromShoppingCart_Button_SalesFunctionPanel.Enabled = true;
            }
            else
            {
                removeProductFromShoppingCart_Button_SalesFunctionPanel.Enabled = false;
            }
            if(changeQuantity_TextBox_SalesFunctionPanel.Text != "" && Convert.ToInt32(changeQuantity_TextBox_SalesFunctionPanel.Text) > 0)
                changeQuantity_Button_SalesFunctionPanel.Enabled = true;
            else
                changeQuantity_Button_SalesFunctionPanel.Enabled = false;

            if (totalPrice_TextBox_SalesFunctionPanel.Text != "" && paymentMethod_ComboBox_SalesFunctionPanel.Text != "")
                checkOutAndPrintReceipt_Button_SalesFunctionPanel.Enabled = true;
            else
                checkOutAndPrintReceipt_Button_SalesFunctionPanel.Enabled = false;

            if (shoppingCart_DataGridView_SalesFunctionPanel.Rows.Count > 0)
                branch_ComboBox_SalesFunctionPanel.Enabled = false;
            else
                branch_ComboBox_SalesFunctionPanel.Enabled = true;
        }

        private void quantity_TextBox_SalesFunctionPanel_TextChanged(object sender, EventArgs e)
        {

        }

        private void productList_DataGridView_SalesFunctionPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void shoppingCart_DataGridView_SalesFunctionPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void changeQuantity_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
            shoppingCart_DataGridView_SalesFunctionPanel.CurrentRow.Cells[3].Value = changeQuantity_TextBox_SalesFunctionPanel.Text;
            double cartTotal = 0;
            for (int i = 0; i < shoppingCart_DataGridView_SalesFunctionPanel.Rows.Count; i++)
            {
                cartTotal = cartTotal + Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.Rows[i].Cells[2].Value) * Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.Rows[i].Cells[3].Value);
            }
            totalPrice_TextBox_SalesFunctionPanel.Text = Convert.ToString(cartTotal);
            changeQuantity_TextBox_SalesFunctionPanel.Clear();
        }

        private void removeProductFromShoppingCart_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
           
            totalPrice = totalPrice - Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.CurrentRow.Cells[2].Value) * Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.CurrentRow.Cells[3].Value);
            int x = shoppingCart_DataGridView_SalesFunctionPanel.CurrentRow.Index;
            shoppingCart_DataGridView_SalesFunctionPanel.Rows.RemoveAt(x);
            
            totalPrice = 0;
            for (int i = 0; i < shoppingCart_DataGridView_SalesFunctionPanel.Rows.Count; i++)
            {
                totalPrice = totalPrice + Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.Rows[i].Cells[2].Value) * Convert.ToDouble(shoppingCart_DataGridView_SalesFunctionPanel.Rows[i].Cells[3].Value);
            }
            totalPrice_TextBox_SalesFunctionPanel.Text = Convert.ToString(totalPrice);
        }

        private void clearShoppingCart_Button_SalesFunctionPanel_Click(object sender, EventArgs e)
        {
            shoppingCart_DataGridView_SalesFunctionPanel.Rows.Clear();
            totalPrice = 0;
            totalPrice_TextBox_SalesFunctionPanel.Text = "0";
        }

        private void totalPrice_TextBox_SalesFunctionPanel_TextChanged(object sender, EventArgs e)
        {
            totalPrice = Convert.ToDouble(totalPrice_TextBox_SalesFunctionPanel.Text);
        }

        private void showcase_ComboBox_ShowcaseSalesRecordPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var showcaseOrderRecord =
                 from orders in context.orders.AsEnumerable()
                 where (String)branch_ComboBox_ShowcaseSalesRecordPanel.SelectedItem == orders.DepartmentID
                 where (String)showcase_ComboBox_ShowcaseSalesRecordPanel.SelectedItem == orders.showcaseID
                 select orders;
                foreach (var listtherecord in showcaseOrderRecord)
                {
                    showcaseSalesRecord_DataGridView_ShowcaseSalesRecordPanel.Rows.Add(listtherecord.OrderID, listtherecord.CustomerID, listtherecord.ItemID, listtherecord.Quantity, listtherecord.Amount, listtherecord.Date, listtherecord.PaymentMethod, listtherecord.Status, listtherecord.DepartmentID, listtherecord.showcaseID);
                }
            }
        }

        private void ShowcaseSalesRecordPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void branch_ComboBox_ShowcaseSalesRecordPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            showcase_ComboBox_ShowcaseSalesRecordPanel.Items.Clear();
            showcaseSalesRecord_DataGridView_ShowcaseSalesRecordPanel.Rows.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var orderShowcaseID =
                 from orderss in context.orders.AsEnumerable()
                 where Convert.ToString(branch_ComboBox_ShowcaseSalesRecordPanel.SelectedItem) == orderss.DepartmentID
                 select orderss;
                foreach (var list in orderShowcaseID)
                {
                    showcase_ComboBox_ShowcaseSalesRecordPanel.Items.Add(list.showcaseID);
                }
            }
        }

        private void register_Button_RegisterPanel_Click_1(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                if(registerType_comboBox_RegisterPanel.SelectedIndex >= 0) {
                    if (accountName_textBox_RegisterPanel.Text == "" || password_textBox_RegisterPanel.Text == "" || confirmPassword_textBox_RegisterPanel.Text == "")
                        MessageBox.Show("no input");
                    else
                    {
                        registerType = (String)registerType_comboBox_RegisterPanel.SelectedItem;
                        var newUser = context.account.Where(u => u.accountName == accountName_textBox_RegisterPanel.Text).FirstOrDefault();
                        if (newUser == null)
                        {
                            if (password_textBox_RegisterPanel.Text == confirmPassword_textBox_RegisterPanel.Text)
                            {
                                var ac = new account()
                                {
                                    accountName = accountName_textBox_RegisterPanel.Text,
                                    password = password_textBox_RegisterPanel.Text,
                                    accountType = registerType
                                };
                                context.account.Add(ac);
                                MessageBox.Show("Register successful");
                                context.SaveChanges();
                                LoginPanel.Show();
                                RegisterPanel.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Password not match");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account already registered");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Pledase choose your type");
                }
                
            }
        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateAccountInformation_Button_AccountInformationPanel_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var updateAccount =
                from accounts in context.account.AsEnumerable()
                where userName == accounts.accountName
                select accounts;
                foreach (var update in updateAccount)
                {
                    update.password = newPassword_TextBox_AccountInformationPanel.Text;
                }
                context.SaveChanges();
                newPassword_TextBox_AccountInformationPanel.Clear();
                MessageBox.Show("successful");
                LoginPanel.Show();
                MainPanel.Hide();
            }
        }

        private void deleteAccount_Button_AccountInformationPanel_Click(object sender, EventArgs e)
        {
            
            using (hkcsEntities context = new hkcsEntities())
            {
                var del =
                (from accounts in context.account
                 where (String)userID_TextBox_AccountInformationPanel.Text == accounts.accountName
                 select accounts).FirstOrDefault();
                context.account.Remove(del);
                context.SaveChanges();
            }
            MessageBox.Show("Delete Account Successful");
            MainPanel.Hide();
            LoginPanel.Show();
        }

        private void userType_ComboBox_AccountControlAdminPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            userList_ListBox_AccountControlAdminPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var Type =
                 from accounts in context.account.AsEnumerable()
                 where (String)userType_ComboBox_AccountControlAdminPanel.SelectedItem == accounts.accountType
                 select accounts;
                foreach (var accountType in Type)
                {
                    userList_ListBox_AccountControlAdminPanel.Items.Add(accountType.accountID);
                }
            }
        }

        private void refresh_Button_AccountControlAdminPanel_Click(object sender, EventArgs e)
        {
            userList_ListBox_AccountControlAdminPanel.Items.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var Type =
                 from accounts in context.account.AsEnumerable()
                 where (String)userType_ComboBox_AccountControlAdminPanel.SelectedItem == accounts.accountType
                 select accounts;
                foreach (var accountType in Type)
                {
                    userList_ListBox_AccountControlAdminPanel.Items.Add(accountType.accountID);
                }
            }
        }

        private void userList_ListBox_AccountControlAdminPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            newPassword_TextBox_AccountControlAdminPanel.Clear();
            using (hkcsEntities context = new hkcsEntities())
            {
                var accInfo =
                 from accounts in context.account.AsEnumerable()
                 where Convert.ToInt32(userList_ListBox_AccountControlAdminPanel.SelectedItem) == accounts.accountID
                 select accounts;
                foreach (var Info in accInfo)
                {
                    userID_TextBox_AccountControlAdminPanel.Text = Convert.ToString(Info.accountName);
                    password_TextBox_AccountControlAdminPanel.Text = Info.password;
                }
            }
        }

        private void userID_TextBox_AccountControlAdminPanel_TextChanged(object sender, EventArgs e)
        {
            if (userList_ListBox_AccountControlAdminPanel.SelectedIndex > 0)
                updateAccountInformation_Button_AccountControlAdminPanel.Enabled = true;
        }

        private void updateAccountInformation_Button_AccountControlAdminPanel_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var updatepass =
                 from accounts in context.account.AsEnumerable()
                 where Convert.ToInt32(userList_ListBox_AccountControlAdminPanel.SelectedItem) == accounts.accountID
                 select accounts;
                foreach (var update in updatepass)
                {
                    update.password = newPassword_TextBox_AccountControlAdminPanel.Text;
                }
                context.SaveChanges();
            }
            newPassword_TextBox_AccountControlAdminPanel.Clear();
            MessageBox.Show("update successful");
        }

        private void newPassword_TextBox_AccountControlAdminPanel_TextChanged(object sender, EventArgs e)
        {
            if (newPassword_TextBox_AccountControlAdminPanel.Text == "")
                updateAccountInformation_Button_AccountControlAdminPanel.Enabled = false;
            else
                updateAccountInformation_Button_AccountControlAdminPanel.Enabled = true;
        }

        private void deleteAccount_Button_AccountControlAdminPanel_Click(object sender, EventArgs e)
        {
            using (hkcsEntities context = new hkcsEntities())
            {
                var del =
                (from accounts in context.account
                 where (String)userID_TextBox_AccountControlAdminPanel.Text == accounts.accountName
                 select accounts).FirstOrDefault();
                context.account.Remove(del);
                context.SaveChanges();
            }
            MessageBox.Show("Delete Account Successful");
        }

        private void userID_Label_AccountControlAdminPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
