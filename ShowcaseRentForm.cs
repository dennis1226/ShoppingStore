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
    public partial class ShowcaseRentForm : Form
    {
        public ShowcaseRentForm()
        {
            InitializeComponent();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowcaseRentForm_Load(object sender, EventArgs e)
        {
            rent_Button.Enabled = false;
            confirm_CheckBox.Enabled = false;
            showcaseID_TextBox.Text = MainForm.passShowcaseID;
            using (hkcsEntities context = new hkcsEntities())
            {
                var info =
                 from showcaseinfo in context.showcaseinfo.AsEnumerable()
                 where showcaseinfo.ShowcaseID == showcaseID_TextBox.Text
                 select showcaseinfo;
                foreach (var showinfo in info)
                {
                    branchID_TextBox.Text = showinfo.DepartmentID;
                    //size_TextBox.Text = showinfo.Size;
                    pricePerMonth_TextBox.Text = Convert.ToString(showinfo.RentDollars);

                }
            }
        }

        private void rentalStartDate_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //String x = rentalStartDate_DateTimePicker.Value.ToString("yyyy-MM-dd");

        }

        private void confirm_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (confirm_CheckBox.Checked)
            {
                rent_Button.Enabled = true;
                paymentMethod_ComboBox.Enabled = false;
                userID_TextBox.Enabled = false;
                rentalPeriod_TextBox.Enabled = false;
            }
            else
            {
                rent_Button.Enabled = false;
                paymentMethod_ComboBox.Enabled = true;
                userID_TextBox.Enabled = true;
                rentalPeriod_TextBox.Enabled = true;
            }


            if (userID_TextBox.Text == null && rentalPeriod_TextBox.Text == null && paymentMethod_ComboBox.Items == null)
            {
                MessageBox.Show("some input is missing");
                confirm_CheckBox.Text = "Unchecked";
            }
            else
            {
                rentalEndDate_DateTimePicker.Value = rentalStartDate_DateTimePicker.Value.AddMonths(int.Parse(rentalPeriod_TextBox.Text));
                double x = Convert.ToDouble(pricePerMonth_TextBox.Text) * Convert.ToDouble(rentalPeriod_TextBox.Text);
                totalPrice_TextBox.Text = Convert.ToString(x);
            }
        }

        private void rent_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rent Successful" + "\nUser ID:" + userID_TextBox.Text + "\nRent LastDay:" + rentalEndDate_DateTimePicker.Value + "\nPaymentMethod:" + paymentMethod_ComboBox.Text);
            using (hkcsEntities context = new hkcsEntities())
            {
                        var rentrecord = new rentrecord()
                        {
                            DepartmentID = branchID_TextBox.Text,
                            ShowcaseID = showcaseID_TextBox.Text,
                            TenantID = userID_TextBox.Text,
                            RentMonth = Convert.ToInt32(rentalPeriod_TextBox.Text),
                            RentFirstDay = rentalStartDate_DateTimePicker.Text,
                            RentLastDay = rentalEndDate_DateTimePicker.Text,
                            RentPrice = Convert.ToDouble(totalPrice_TextBox.Text),
                            PaymentMethod = paymentMethod_ComboBox.Text
                        };
                        context.rentrecord.Add(rentrecord);
                        context.SaveChanges();

                         var updatestatus =
                            from showcaseinfos in context.showcaseinfo
                            where showcaseinfos.ShowcaseID == showcaseID_TextBox.Text
                            select showcaseinfos;
                         foreach (var updaterentstatus in updatestatus)
                            {
                                updaterentstatus.RentStatus = "registed";
                            }
                            context.SaveChanges();
                        this.Close();
            }
        }

        private void userID_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (userID_TextBox.Text != "" && rentalPeriod_TextBox.Text != "" && paymentMethod_ComboBox.Text != "")
                confirm_CheckBox.Enabled = true;
            else
                confirm_CheckBox.Enabled = false;
        }

        private void rentalPeriod_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (userID_TextBox.Text != "" && rentalPeriod_TextBox.Text != "" && paymentMethod_ComboBox.Text != "")
                confirm_CheckBox.Enabled = true;
            else
                confirm_CheckBox.Enabled = false;
        }

        private void paymentMethod_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userID_TextBox.Text != "" && rentalPeriod_TextBox.Text != "" && paymentMethod_ComboBox.Text != "")
                confirm_CheckBox.Enabled = true;
            else
                confirm_CheckBox.Enabled = false;
        }
    }
}
