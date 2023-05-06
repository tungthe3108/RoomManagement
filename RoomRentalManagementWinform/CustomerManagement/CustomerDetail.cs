using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RoomRentalManagementWinform.CustomerManagement
{
    public partial class CustomerDetail : Form
    {
        public int customerId { get; set; }
        public readonly CustomerRepository custRepos = new();
        public readonly RoomRepository roomRepos = new();
        public CustomerDetail()
        {
            InitializeComponent();
        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            List<Room> listRoom = roomRepos.GetListRoom();
            Room empty = new Room
            {
                RoomId = -1,
                RoomName = null
            };
            listRoom.Insert(0, empty);
            roomId.DataSource = listRoom;
            roomId.DisplayMember = "RoomName";
            roomId.ValueMember = "RoomId";
            Customer cust = custRepos.GetCustomerById(customerId);
            custId.Text = cust.CustomerId.ToString();
            custName.Text = cust.Name.ToString();
            roomId.SelectedValue = cust.RoomId;
            gender.Text = cust.Sex.ToString();
            phone.Text = cust.Phone.ToString();
            email.Text = cust.Email.ToString();
            address.Text = cust.Address.ToString();
            dob.Value = cust.Dob;
            //if (DateTime.TryParseExact(row.Cells["Dob"]?.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            //{
            //    dob.Value = dateValue;
            //}
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer
            {
                CustomerId = int.Parse(custId.Text),
                Name = custName.Text,
                RoomId = (int)roomId.SelectedValue,
                Sex = gender.Text,
                Phone = phone.Text,
                Email = email.Text,
                Address = address.Text,
                Dob = dob.Value
            };
            custRepos.UpdateCustomer(cust);
            MessageBox.Show("Cập nhật thông tin khách hàng thành công");
        }

        private void cancelbtn_Click(object sender, EventArgs e) => Close();
    }
}
