using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace PayrollSysetm
{
    public partial class EmployeeForm : Form
    {
        string gender;
        string maritalStatus;
        bool isMember;
        public EmployeeForm()
        {
            InitializeComponent();
        }
        
        #region==================Validation //ChechedItem //ClearControl====================
       private void ClearControls()
        {
            txtEmployeeID.Clear();
            txtFristName.Clear();
            txtLastName.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtNationalInsuranceNo.Text = "";
            dtpDateOfBirth.Value = new DateTime(1990, 12, 30);
            rdbMarried.Checked = false;
            rdbSingle.Checked = false;
            chkUnoinMember.Checked = false;
            txtAddress.Text = string.Empty;
            txtCity.Text = null;
            txtPostCode.Text = "";
            cmbCountry.SelectedIndex = 0;
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtNotes.Text = "";
        }
        private void CheckedItems()
        {
            if (rdbMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            if (rdbMarried.Checked)
            {
                maritalStatus = "Married";
            }
            else
            {
                maritalStatus = "Single";
            }
            if (chkUnoinMember.Checked)
            {
                isMember = true;
            }
            else
            {
                isMember = false;
            }
        }

        private bool IsControlsDataVilad()
        {
            Regex objEmployeeID = new Regex("^[0-9]{3,4}$");
            Regex objFirstName = new Regex("^[A-Z][a-zA-Z]*$");
            Regex objLastName = new Regex("^[A-Z][a-zA-Z]*$");
            Regex objNi = new Regex(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$");
            //Regex objSSN = new Regex(@"^\d{3}-\d{2}-\d{4}$");
            Regex objEmail = new Regex("^[a-zA-Z0-9]{1,30}@[a-zA-Z0-9]{1,30}.[a-zA-Z]{2,3}$");

            if (Convert.ToInt32(txtEmployeeID.Text.Length) < 1)
            {
                MessageBox.Show("Please, Enter Employee ID ", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeID.Focus();
                txtEmployeeID.BackColor = Color.Silver;
                return false;
            }
            else if (!objEmployeeID.IsMatch(txtEmployeeID.Text))
            {
                MessageBox.Show("Please, Enter a Valid Employee ID ", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeID.Focus();
                txtEmployeeID.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtEmployeeID.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(txtFristName.Text))
            {
                MessageBox.Show("Please, Enter First Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFristName.Focus();
                txtFristName.BackColor = Color.Silver;
                return false;
            }else if (!objFirstName.IsMatch(txtFristName.Text))
            {
                MessageBox.Show("Please, Enter a Valid First Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFristName.Focus();
                txtFristName.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtFristName.BackColor = Color.White;
            }
           
            if (txtLastName.Text=="")
            {
                MessageBox.Show("Please, Enter Last Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                txtLastName.BackColor = Color.Silver;
                return false;
            }else if (!objLastName.IsMatch(txtLastName.Text))
            {
                MessageBox.Show("Please, Enter a Valid Last Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                txtLastName.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtLastName.BackColor = Color.White;
            }
            if (rdbFemale.Checked==false && rdbMale.Checked==false)
            {
                MessageBox.Show("Please, Check either Male Or Female", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grbGender.Focus();
                rdbMale.BackColor = Color.Silver;
                rdbFemale.BackColor = Color.Silver;
                return false;
            }
            else
            {
                rdbMale.BackColor = Color.CornflowerBlue;
                rdbFemale.BackColor = Color.CornflowerBlue;
            }
            if (txtNationalInsuranceNo.Text == "")
            {
                MessageBox.Show("Please, Enter National Insurance No", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNationalInsuranceNo.Focus();
                txtNationalInsuranceNo.BackColor = Color.Silver;
                return false;
            }else if (!objNi.IsMatch(txtNationalInsuranceNo.Text))
            {
                MessageBox.Show("Please, Enter a Valid National Insurance No", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNationalInsuranceNo.Focus();
                txtNationalInsuranceNo.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtNationalInsuranceNo.BackColor = Color.Silver;
            }
            if (rdbSingle.Checked==false && rdbMarried.Checked)
            {
                MessageBox.Show("Please, Check either Married Or Single", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grbMaritalStaatus.Focus();
                rdbMarried.BackColor = Color.Silver;
                rdbSingle.BackColor = Color.Silver;
                return false;
            }
            else
            {
                rdbSingle.BackColor = Color.CornflowerBlue;
                rdbMarried.BackColor = Color.CornflowerBlue;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please, Enter Address", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                txtAddress.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtAddress.BackColor = Color.White;
            }
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please, Enter City", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                txtCity.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtCity.BackColor = Color.White;
            }
            if (txtPostCode.Text == "")
            {
                MessageBox.Show("Please, Enter Post Code", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostCode.Focus();
                txtPostCode.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtPostCode.BackColor = Color.White;
            }
            //if (cmbCountry.SelectedIndex==0 || cmbCountry.SelectedIndex==-1)
            //{
            //    MessageBox.Show("Please, Select a Country From the List", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmbCountry.Focus();
            //    cmbCountry.BackColor = Color.Silver;
            //    return false;
            //}
            //else
            //{
            //    cmbCountry.BackColor = Color.White;
            //}
            if (txtPhoneNumber.Text.Length ==0)
            {
                MessageBox.Show("Please, Enter Phone Number", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                txtPhoneNumber.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtPhoneNumber.BackColor = Color.Silver;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please, Enter Email Address", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                txtEmail.BackColor = Color.Silver;
                return false;
            }
            //else if (!objEmail.IsMatch(txtEmail.Text))
            //{
            //    MessageBox.Show("Please, Enter a Valid Email Address", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtEmail.Focus();
            //    txtEmail.BackColor = Color.Silver;
            //    return false;
            //}
            else if (txtEmail.Text.Length>=1)
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(txtEmail.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error"+ex, "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    txtEmail.BackColor = Color.Silver;
                    return false;
                }
            }
            else
            {
                txtEmail.BackColor = Color.White;
            }
            if (txtNotes.Text.Length >30)
            {
                MessageBox.Show("Too Much Text! Please, Enter fewer text", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNotes.Focus();
                txtNotes.BackColor = Color.Silver;
                return false;
            }
            else
            {
                txtNotes.BackColor = Color.White;
            }
            return true;
        }
        #endregion=================================================

        #region==================CRUD OPERATION==============
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (IsControlsDataVilad())
            {
                CheckedItems();
                string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDbConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                try
                {
                    con.Open();
                    string insertCommand = "Insert Into tblEmployee Values(" + Convert.ToInt32(txtEmployeeID.Text) + ",'" + txtFristName.Text + "','" 
                                                                             + txtLastName.Text + "','" + gender + "','" + txtNationalInsuranceNo.Text + "','" 
                                                                             + dtpDateOfBirth.Value.ToString("MM/dd/yyyy") + "','" + maritalStatus + "','" 
                                                                             + isMember + "','" + txtAddress.Text + "','" + txtCity.Text + "','" 
                                                                             + txtPostCode.Text + "','" + cmbCountry.SelectedItem.ToString() + "','" 
                                                                             + txtPhoneNumber.Text + "','" + txtEmail.Text + "','" + txtNotes.Text + "')";
                    SqlCommand cmd = new SqlCommand(insertCommand,con);
                    cmd.ExecuteNonQuery();
                    this.tblEmployeeTableAdapter.Fill(this.payrollSystemDbDataSet.tblEmployee);
                    MessageBox.Show("Employee With ID " + txtEmployeeID.Text + " " + "has been Add Successfully!", "Insertion Successful ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("The following error Occurred : " + ex.Message, "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (IsControlsDataVilad())
            {
                CheckedItems();
                string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDbConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                try
                {
                    con.Open();
                    string UpdateCommand = "UPDATE  tblEmployee Set FirstName='" + this.txtFristName.Text + "', LastName='"
                                                                             + this.txtLastName.Text + "', Gender='" + this.gender + "', NINumber='" + this.txtNationalInsuranceNo.Text + "', DateOfBirth='"
                                                                             + this.dtpDateOfBirth.Value.ToString("MM/dd/yyyy") + "', MaritalStatus='" + this.maritalStatus + "', IsMember='"
                                                                             + this.isMember + "', Address='" + this.txtAddress.Text + "',City='" + this.txtCity.Text + "',PostCode='"
                                                                             + this.txtPostCode.Text + "',Country='" + this.cmbCountry.SelectedItem.ToString() + "', PhoneNumber='"
                                                                             + this.txtPhoneNumber.Text + "',Email='" + txtEmail.Text + "',Notes='" + txtNotes.Text + "' WHERE EmployeeID="+txtEmployeeID.Text+"";
                    SqlCommand cmd = new SqlCommand(UpdateCommand, con);
                    cmd.ExecuteNonQuery();
                    this.tblEmployeeTableAdapter.Fill(this.payrollSystemDbDataSet.tblEmployee);
                    MessageBox.Show("Employee With ID " + txtEmployeeID.Text + " " + "has been Updated Successfully!", "Update Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearControls();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("The following error Occurred : " + ex.Message, "Updation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are sure you want to permanently delete this Employee Record ? ", "Confirm Record Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDbConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                try
                {
                    con.Open();
                    string DeleteCommand = "Delete  From tblEmployee Where EmployeeID=" + txtEmployeeID.Text + "";
                    SqlCommand cmd = new SqlCommand(DeleteCommand, con);
                    cmd.ExecuteNonQuery();
                    this.tblEmployeeTableAdapter.Fill(this.payrollSystemDbDataSet.tblEmployee);
                    MessageBox.Show("Employee With ID " + txtEmployeeID.Text + " " + "has been Deleted Successfully!", "Delete Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("The following error Occurred : " + ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewFrom objPreviewFrom = new PreviewFrom();
            objPreviewFrom.PreviewEmployeeData(Convert.ToInt32(txtEmployeeID.Text), txtFristName.Text, txtLastName.Text, gender, txtNationalInsuranceNo.Text, dtpDateOfBirth.Text, maritalStatus, isMember, txtAddress.Text, txtCity.Text, txtPostCode.Text, cmbCountry.SelectedItem.ToString(), txtPhoneNumber.Text, txtEmail.Text, txtNotes.Text);
            objPreviewFrom.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion===================================================================

        #region===============KeyPress Event Validation==============
        bool IsNumberOrBackspace;
        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                IsNumberOrBackspace = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                IsNumberOrBackspace = true;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion=========================================================

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDbDataSet.tblEmployee' table. You can move, or remove it, as needed.
            this.tblEmployeeTableAdapter.Fill(this.payrollSystemDbDataSet.tblEmployee);
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmployeeID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtFristName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            gender = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            txtNationalInsuranceNo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            dtpDateOfBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            maritalStatus = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            isMember =Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
            txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
            txtPostCode.Text = dataGridView1.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
            cmbCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
            txtPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
            txtNotes.Text = dataGridView1.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();

            if (gender == "Male")
            {
                rdbMale.Checked = true;
                rdbFemale.Checked = false;
            }
            else
            {
                rdbMale.Checked = false;
                rdbFemale.Checked = true;
            }
            if (maritalStatus == "Married")
            {
                rdbSingle.Checked = false;
                rdbMarried.Checked = true;
            }
            else
            {
                rdbSingle.Checked = true;
                rdbMarried.Checked = false;
            }
            if (isMember == true)
            {
                chkUnoinMember.Checked = true;
            }
            else
            {
                chkUnoinMember.Checked = false;
            }
        }
    }
}
