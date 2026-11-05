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

namespace Contacts
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }

        private DataTable _dtAllContacts;

        private void _RefreshContactsList()
        {
            _dtAllContacts = clsContact.GetAllContacts();

            dgvAllContacts.DataSource = _dtAllContacts;

            if (dgvAllContacts.Rows.Count > 0)
            {
                dgvAllContacts.ClearSelection();
            }

            if (_dtAllContacts.DefaultView.Count == 0)

                lblNoContatcs.Visible = true;

            else

                lblNoContatcs.Visible = false;
        }



        private void dgvAllContacts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(dgvAllContacts.CurrentRow.Cells[0].Value.ToString());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddEditContacts frm = new frmAddEditContacts((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshContactsList();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContacts.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }


        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {

            _RefreshContactsList();

            // يجعل العنوان في المنتصف الأفقي للشاشة تماماً بناءً على عرضه الحالي
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;

            cbFilterBy.SelectedIndex = 0; // يفترض أن "None" هو العنصر الأول في القائمة
            txtFilterValue.Enabled = false;

        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContacts frm = new frmAddEditContacts(-1);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllContacts == null || _dtAllContacts.Rows.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || string.IsNullOrEmpty(cbFilterBy.Text) || cbFilterBy.Text == "None")
            {
                _dtAllContacts.DefaultView.RowFilter = "";
                lblNoContatcs.Visible = (_dtAllContacts.DefaultView.Count == 0);
                return;
            }

            string filterColumn = cbFilterBy.Text;

            if (filterColumn == "First Name") filterColumn = "FirstName";
            if (filterColumn == "Last Name") filterColumn = "LastName";

            string filterValue = txtFilterValue.Text.Trim();

            if (filterColumn == "ContactID")
            {
                if (int.TryParse(filterValue, out int id))
                {
                    _dtAllContacts.DefaultView.RowFilter = $"[ContactID] = {id}";
                }
                else
                {
                    _dtAllContacts.DefaultView.RowFilter = "[ContactID] = -1";
                }
            }
            else
            {
                _dtAllContacts.DefaultView.RowFilter = $"[{filterColumn}] LIKE '{filterValue}%'";
            }

            lblNoContatcs.Visible = (_dtAllContacts.DefaultView.Count == 0);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "None" || string.IsNullOrEmpty(cbFilterBy.Text))
            {
                txtFilterValue.Text = "";
                txtFilterValue.Enabled = false;
            }
            else
            {
                txtFilterValue.Enabled = true;
                txtFilterValue.Focus(); 
            }
        }
    }
}
