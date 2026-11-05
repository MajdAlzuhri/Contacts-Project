using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Contacts
{
    public partial class frmAddEditContacts : Form
    {

        public enum enMood { AddNew = 0, Update = 1 };

        private enMood _Mode;

        int _ContactID;
        clsContact _Contact;

        public frmAddEditContacts(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (ContactID == -1)
                _Mode = enMood.AddNew;
            else
                _Mode = enMood.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);
            }
        }


        private void _LoadDate()
        {
            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 0;

            
            if (_Mode == enMood.AddNew)
            {
                this.Text = "Add New Contact";
                lblMode.Text = "Add New Contact";
                lblMode.Left = (this.ClientSize.Width - lblMode.Width) / 2; 
                _Contact = new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if (_Contact == null)
            {
                MessageBox.Show($"This form will be closed because no contact with ID = {_ContactID} was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Edit Contact";
            lblMode.Text = "Edit Contact ID = " + _ContactID;
            lblMode.Left = (this.ClientSize.Width - lblMode.Width) / 2;

            lblContactID.Text = _ContactID.ToString();
            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAdress.Text = _Contact.Address;
            dateTimePicker1.Value = _Contact.DateOfBirth;

            if (!string.IsNullOrEmpty(_Contact.ImagePath) && File.Exists(_Contact.ImagePath))
            {
                pictureBox1.Load(_Contact.ImagePath);
            }
            else
            {
                pictureBox1.ImageLocation = null;
            }

            lbllRemove.Visible = (!string.IsNullOrEmpty(_Contact.ImagePath) && File.Exists(_Contact.ImagePath));

            if (_Contact.CountryID != -1)
            {
                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);
            }
        }

        private bool _ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "First Name is required!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "");
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Last Name is required!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtLastName, "");
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Phone number is required!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Trim().ToLower().EndsWith("@gmail.com"))
                {
                    errorProvider1.SetError(txtEmail, "Email must end with @gmail.com!");
                    isValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtEmail, "");
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_ValidateInputs())
            {
                MessageBox.Show("Please fix the validation errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }


            int CountryID = clsCountry.Find(cbCountry.Text).ID; 

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAdress.Text;
            _Contact.DateOfBirth = dateTimePicker1.Value;
            _Contact.CountryID = CountryID;

            if (pictureBox1.ImageLocation != null)
                _Contact.ImagePath = pictureBox1.ImageLocation;
            else
                _Contact.ImagePath = "";

            if (_Contact.Save())
                MessageBox.Show("Data Saved Successsfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMood.Update;
            lblMode.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text=_Contact.ID.ToString();

        }

        private void frmAddEditContacts_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pictureBox1.ImageLocation = null;
            lbllRemove.Visible = false;


        }
    }

}
