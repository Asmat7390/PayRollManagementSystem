using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSysetm
{
    public partial class PayrollCalculator : Form
    {
        #region-----------------Some Goble Variables--------------------
        string fullName = string.Empty;
        //Declare variable for each day of the Weeks
        double Mon1 = 0.00, Tues1 = 0.00, wen1 = 0.00, thurs1 = 0.00, Fri1 = 0.00, Sat1 = 0.00, Sun1 = 0.00;
        double Mon2 = 0.00, Tues2 = 0.00, wen2 = 0.00, thurs2 = 0.00, Fri2 = 0.00, Sat2 = 0.00, Sun2 = 0.00;
        double Mon3 = 0.00, Tues3 = 0.00, wen3 = 0.00, thurs3 = 0.00, Fri3 = 0.00, Sat3 = 0.00, Sun3 = 0.00;
        double Mon4 = 0.00, Tues4 = 0.00, wen4 = 0.00, thurs4 = 0.00, Fri4 = 0.00, Sat4 = 0.00, Sun4 = 0.00;
        
        //Declare Variable For Hours
        double totalHoursWk1, totalHoursWk2, totalHoursWk3, totalHoursWk4;
        double contractualHoursWk1, contractualHoursWk2, contractualHoursWk3, contractualHoursWk4;
        

        double overtimeHoursWk1, overtimeHoursWk2, overtimeHoursWk3, overtimeHoursWk4;
        double totalContractualHours;
        double totalOvertimeHours;
        double totalHoursWorked;

        //Declare Variable for Amount(Eranings)
        double contractualAmountWk1, contractualAmountWk2, contractualAmountWk3, contractualAmountWk4;
        double overtimeAmountWk1, overtimeAmountWk2, overtimeAmountWk3, overtimeAmountWk4;
        double totalContractualAmount;
        double totalOvertomeAmount;
        double totalAmountEraned;

        //Declare Variable for Mondatroy Deductions
        double tax, NIContribution, taxRate, NIRate, SLC;
        double totalDeductions;

        //declare initialise constant Voluntary Deductions
        const double Union = 10.00;
        const double SLCRate = .05;

        //declare variable for pay rates
        double hourlySalaryRate, overtimeSalaryRate;

        //Declare variable for Net Pay
        double netPay;
        #endregion------------------------------------------------------

        public PayrollCalculator()
        {
            InitializeComponent();
        }

        private void btnComputePay_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                GetWeek1Values();
                GetWeek2Values();
                GetWeek3Values();
                GetWeek4Values();
                totalHoursWk1 = Mon1 + Tues1 + wen1 + thurs1 + Fri1 + Sat1 + Sun1;
                totalHoursWk2 = Mon2 + Tues2 + wen2 + thurs2 + Fri2 + Sat2 + Sun2;
                totalHoursWk3 = Mon3 + Tues3 + wen3 + thurs3 + Fri3 + Sat3 + Sun3;
                totalHoursWk4 = Mon4 + Tues4 + wen4 + thurs4 + Fri4 + Sat4 + Sun4;
                //Retrieve Hourly Rate
                try
                {
                    hourlySalaryRate = double.Parse(nudHourlyRate.Value.ToString());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("the following Error has occured "+ex.Message,"Error Message");
                }
                //OverTime Rate
                overtimeSalaryRate = hourlySalaryRate * 1.5;
                #region-----------------Week 1 Computation--------
                //Hours Worked ,No Overtime
                if (totalHoursWk1 <= 36)
                {
                    contractualHoursWk1 = totalHoursWk1;
                    contractualAmountWk1 = hourlySalaryRate * totalHoursWk1;
                    overtimeHoursWk1 = 0.00;
                    overtimeAmountWk1 = 0.00;
                }
                //Hours Worked, With Overtime
                else if (totalHoursWk1 > 36)
                {
                    contractualHoursWk1 = 36;
                    contractualAmountWk1 = hourlySalaryRate * contractualHoursWk1;
                    overtimeHoursWk1 = totalHoursWk1 - contractualHoursWk1;
                    overtimeAmountWk1 = overtimeHoursWk1 * overtimeSalaryRate;

                }
                #endregion------------------------------------
                #region-----------------Week 2 Computation--------
                //Hours Worked ,No Overtime
                if (totalHoursWk2 <= 36)
                {
                    contractualHoursWk2 = totalHoursWk2;
                    contractualAmountWk2 = hourlySalaryRate * totalHoursWk2;
                    overtimeHoursWk2 = 0.00;
                    overtimeAmountWk2 = 0.00;
                }
                //Hours Worked, With Overtime
                else if (totalHoursWk2 > 36)
                {
                    contractualHoursWk2 = 36;
                    contractualAmountWk2 = hourlySalaryRate * contractualHoursWk2;
                    overtimeHoursWk2 = totalHoursWk2 - contractualHoursWk2;
                    overtimeAmountWk2 = overtimeHoursWk2 * overtimeSalaryRate;

                }
                #endregion------------------------------------
                #region-----------------Week 3 Computation--------
                //Hours Worked ,No Overtime
                if (totalHoursWk3 <= 36)
                {
                    contractualHoursWk3 = totalHoursWk3;
                    contractualAmountWk3 = hourlySalaryRate * totalHoursWk3;
                    overtimeHoursWk3 = 0.00;
                    overtimeAmountWk3 = 0.00;
                }
                //Hours Worked, With Overtime
                else if (totalHoursWk3 > 36)
                {
                    contractualHoursWk3 = 36;
                    contractualAmountWk3 = hourlySalaryRate * contractualHoursWk3;
                    overtimeHoursWk3 = totalHoursWk1 - contractualHoursWk3;
                    overtimeAmountWk3 = overtimeHoursWk3 * overtimeSalaryRate;

                }
                #endregion------------------------------------
                #region-----------------Week 4 Computation--------
                //Hours Worked ,No Overtime
                if (totalHoursWk4 <= 36)
                {
                    contractualHoursWk4 = totalHoursWk1;
                    contractualAmountWk4 = hourlySalaryRate * totalHoursWk4;
                    overtimeHoursWk4 = 0.00;
                    overtimeAmountWk4 = 0.00;
                }
                //Hours Worked, With Overtime
                else if (totalHoursWk4 > 36)
                {
                    contractualHoursWk4 = 36;
                    contractualAmountWk4 = hourlySalaryRate * contractualHoursWk4;
                    overtimeHoursWk4 = totalHoursWk4 - contractualHoursWk4;
                    overtimeAmountWk4 = overtimeHoursWk4 * overtimeSalaryRate;

                }
                #endregion------------------------------------
            }
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetCntrols();
            ResetCntrols();
        }

        private void btnGeneratePaySlip_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintPaySlip_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDbConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string selectCommand = "SELECT FirstName , LastName,NINumber FROM tblEmployee Where EmployeeID=" + txtEmployeeID.Text + "";
            SqlCommand cmd = new SqlCommand(selectCommand, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                if (dataReader.Read())
                {
                    txtFirstName.Text = dataReader[0].ToString();
                    txtLastName.Text = dataReader[1].ToString();
                    txtNINumber.Text = dataReader[2].ToString();
                    fullName = txtFirstName.Text + " " + txtLastName.Text;
                    lblEmployeeFullName.Text = fullName;
                }
                else
                {
                    MessageBox.Show("No Recorde Where Found With" + txtEmployeeID.Text, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error Message");
            }
            finally
            {
                con.Close();
            }
        }
        public void ListOFMonths()
        {
            //string[] months = new string[13] { "Select a Month", "January", "Feburary", "March", "April", "May", "Jun", "July", "August", "September", "October", "November", "December" };
            List<string> months = new List<string>();
            months.Add("Select a Month---");
            months.Add("January");
            months.Add("Feburary");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("Jun");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");
            //foreach loop
            //foreach (var month in months)
            //{
            //    cmbCurrentMonth.Items.Add(month);
            //    cmbCurrentMonth.SelectedIndex = 0;
            //}
            //for Loop
            //for (int month = 0; month < months.Count; month++)
            //{
            //    cmbCurrentMonth.Items.Add(months[month]);
            //    cmbCurrentMonth.SelectedIndex = 0;
            //}
            months.ForEach(month => cmbCurrentMonth.Items.Add(month));
            months.ElementAt(cmbCurrentMonth.SelectedIndex = 0);
            foreach (var month in months)
            {
                cmbSearchPayMonth.Items.Add(month);
                cmbSearchPayMonth.SelectedIndex = 0;
            }
        }
        private void PayrollCalculator_Load(object sender, EventArgs e)
        {
            ListOFMonths();
        }
        #region-----------------Four Week Datatype Convert to Double----------------
        //Get and Convert Week 1 Value to duoble datatype
        public void GetWeek1Values()
        {
            try
            {
                Mon1 = double.Parse(nudMon1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudMon1.Focus();
            }
            try
            {
                Tues1 = double.Parse(nudTues1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudTues1.Focus();
            }
            try
            {
                wen1 = double.Parse(nudWen1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudWen1.Focus();
            }
            try
            {
                thurs1 = double.Parse(nudThurs1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudThurs1.Focus();
            }
            try
            {
                Fri1 = double.Parse(nudFri1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudFri1.Focus();
            }
            try
            {
                Sat1 = double.Parse(nudSat1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSat1.Focus();
            }
            try
            {
                Sun1 = double.Parse(nudSun1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSun1.Focus();
            }
        }
        //Get and Convert Week  Value to duoble datatype
        public void GetWeek2Values()
        {
            try
            {
                Mon2 = double.Parse(nudMon2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudMon2.Focus();
            }
            try
            {
                Tues2 = double.Parse(nudTues2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudTues2.Focus();
            }
            try
            {
                wen2 = double.Parse(nudWen2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudWen2.Focus();
            }
            try
            {
                thurs2 = double.Parse(nudThurs2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudThurs2.Focus();
            }
            try
            {
                Fri2 = double.Parse(nudFri2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudFri2.Focus();
            }
            try
            {
                Sat2 = double.Parse(nudSat1.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSat2.Focus();
            }
            try
            {
                Sun2 = double.Parse(nudSun2.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSun2.Focus();
            }
        }
        //Get and Convert Week 3 Value to duoble datatype
        public void GetWeek3Values()
        {
            try
            {
                Mon3 = double.Parse(nudMon3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudMon3.Focus();
            }
            try
            {
                Tues3 = double.Parse(nudTues3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudTues3.Focus();
            }
            try
            {
                wen3 = double.Parse(nudWen3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudWen3.Focus();
            }
            try
            {
                thurs3 = double.Parse(nudThurs3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudThurs3.Focus();
            }
            try
            {
                Fri3 = double.Parse(nudFri3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudFri3.Focus();
            }
            try
            {
                Sat3 = double.Parse(nudSat3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSat3.Focus();
            }
            try
            {
                Sun3 = double.Parse(nudSun3.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSun3.Focus();
            }
        }
        //Get and Convert Week 4 Value to duoble datatype
        public void GetWeek4Values()
        {
            try
            {
                Mon4 = double.Parse(nudMon4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudMon4.Focus();
            }
            try
            {
                Tues4 = double.Parse(nudTues4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudTues4.Focus();
            }
            try
            {
                wen4 = double.Parse(nudWen4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudWen4.Focus();
            }
            try
            {
                thurs4 = double.Parse(nudThurs4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudThurs4.Focus();
            }
            try
            {
                Fri4 = double.Parse(nudFri4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudFri4.Focus();
            }
            try
            {
                Sat4 = double.Parse(nudSat4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSat4.Focus();
            }
            try
            {
                Sun4 = double.Parse(nudSun4.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following occurred :" + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudSun4.Focus();
            }
        }
        #endregion----------------------------------------------------
        #region------------------Validation-----------------
        //Controls Validation
        public bool ValidateControls()
        {
            if (txtEmployeeID.Text == "")
            {
                MessageBox.Show("Please Enter Employee ID.", "Data EntrY Error");
                this.txtEmployeeID.Focus();
                return false;
            }
            if (listBoxPayPeriod.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Pay Period.", "Data Entry Error");
                this.listBoxPayPeriod.Focus();
                return false;
            }
            if (cmbCurrentMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Current Month.", "Data Entry Error");
                this.cmbCurrentMonth.Focus();
                return false;
            }
            return true;
        }
        #endregion-----------------------------------------

        #region------------------Reset All Controls---------------
        //Clear & intialise some Controls 0.00
        public void ResetCntrols()
        {
            txtEmployeeID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNINumber.Text = "";
            lblEmployeeFullName.Text = "";
            listBoxPayPeriod.SelectedIndex = 0;
            cmbCurrentMonth.SelectedIndex = 0;
            nudMon1.Text = "0.00";
            nudTues1.Text = "0.00";
            nudWen1.Text = "0.00";
            nudThurs1.Text = "0.00";
            nudFri1.Text = "0.00";
            nudSat1.Text = "0.00";
            nudSun1.Text = "0.00";
            nudMon2.Text = "0.00";
            nudTues2.Text = "0.00";
            nudWen2.Text = "0.00";
            nudThurs2.Text = "0.00";
            nudFri2.Text = "0.00";
            nudSat2.Text = "0.00";
            nudSun2.Text = "0.00";
            nudMon3.Text = "0.00";
            nudTues3.Text = "0.00";
            nudWen3.Text = "0.00";
            nudThurs3.Text = "0.00";
            nudFri3.Text = "0.00";
            nudSat3.Text = "0.00";
            nudSun3.Text = "0.00";
            nudMon4.Text = "0.00";
            nudTues4.Text = "0.00";
            nudWen4.Text = "0.00";
            nudThurs4.Text = "0.00";
            nudFri4.Text = "0.00";
            nudSat4.Text = "0.00";
            nudSun4.Text = "0.00";
            txtContractualHours.Text = "0.00";
            txtContractualEarnings.Text = "0.00";
            txtOvertimeHours.Text = "0.00";
            txtOvertimeEarnings.Text = "0.00";
            nudHourlyRate.Text = "10.00";
            txtNIContribution.Text = "0.00";
            txtUnoin.Text = "0.00";
            txtTaxAmount.Text = "0.00";
            txtSLC.Text = "0.00";
            txtTotalDeductions.Text = "0.00";
            txtTotalEarnings.Text = "0.00";
            txtTotalHoursWorked.Text = "0.00";
            txtNetPay.Text = "0.00";
            txtOvertimeRate.Text = "0.00";
            txtHours.Text = "00";
            txtMinutes.Text = "00";
            txtDecimalHours.Text = "0.00";
        }
        #endregion-------------------------------------------------
    }
}
