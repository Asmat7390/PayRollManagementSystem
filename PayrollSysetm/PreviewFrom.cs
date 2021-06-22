using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSysetm
{
    public partial class PreviewFrom : Form
    {
        public PreviewFrom()
        {
            InitializeComponent();
        }

        public void PreviewEmployeeData(int EmployeeID,string FirstName,string LastName,
            string Gender,string NationalInsuranceNo,string DateOfBirth,string MaritalStatus,
            bool isMember,string Address,string City,string PostCode,string Country,string PhoneNumber,
            string Email,string Notes)
        {
            lblEmployeeID.Text = Convert.ToString(EmployeeID);
            lblFirstName.Text = FirstName;
            lblLastName.Text = LastName;
            lblGender.Text = Gender;
            lblNationalINsuranceNo.Text = NationalInsuranceNo;
            lblDataOfBirth.Text = DateOfBirth;
            lblMaritalStatus.Text = MaritalStatus;
            lblUnionMembership.Text = isMember.ToString();
            lblAddress.Text = Address;
            lblCity.Text = City;
            lblPostCode.Text = PostCode;
            lblCountry.Text = Country;
            lblPhoneNumber.Text = PhoneNumber;
            lblEmailAddress.Text = Email;
            lblNotes.Text = Notes;

        }
    }
}
