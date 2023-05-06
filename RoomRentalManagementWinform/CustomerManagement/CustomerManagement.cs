using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoomRentalManagementWinform.CustomerManagement
{
    public partial class CustomerManagement : Form
    {
        public readonly CustomerRepository custRepos = new();
        public readonly RoomRepository roomRepos = new();
        public Account account { get; set; }
        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            List<Room> listRoom = roomRepos.GetListRoom();
            Room empty = new Room
            {
                RoomId = -1,
                RoomName = null
            };
            listRoom.Insert(0, empty);
            room.DataSource = listRoom;
            room.DisplayMember = "RoomName";
            room.ValueMember = "RoomId";

            List<Room> listRoomFind = roomRepos.GetListRoom();

            getListCust();
            dataGridView1.CellClick += dataGridView1_Click;
            dataGridView1.CellDoubleClick += dataGridView1_DoubleClick;
        }

        private void getListCust()
        {
            var cus = custRepos.GetListCustomer().ToList();
            var room = roomRepos.GetListRoom().ToList();
            var query = from c in cus
                        join r in room on c.RoomId equals r.RoomId
                        select new
                        {
                            c.CustomerId,
                            c.Name,
                            r.RoomName,
                            r.RoomId,
                            c.Sex,
                            Dob = c.Dob.ToString("dd/MM/yyyy"),
                            c.Phone,
                            c.Email,
                            c.Address
                        };
            dataGridView1.DataSource = query.ToList();
            dataGridView1.Columns["RoomId"].Visible = false;
            dataGridView1.Columns["CustomerId"].HeaderText = "Mã khách hàng";
            dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
            dataGridView1.Columns["Name"].Width = 160;
            dataGridView1.Columns["RoomName"].HeaderText = "Phòng";
            dataGridView1.Columns["Sex"].HeaderText = "Giới tính";
            dataGridView1.Columns["Dob"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["Phone"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Phone"].Width = 160;
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["Address"].HeaderText = "Địa chỉ";
        }
        private void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0){
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            object value = cell.Value;
            custName.Text = row.Cells["Name"]?.Value.ToString();
            if (DateTime.TryParseExact(row.Cells["Dob"]?.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                    dob.Value = dateValue;
            }
            gender.Text = row.Cells["Sex"]?.Value.ToString();
            room.Text = row.Cells["RoomName"].Value.ToString();
            phone.Text = row.Cells["Phone"]?.Value?.ToString();
            address.Text = row.Cells["Address"].Value?.ToString();
            email.Text = row.Cells["Email"]?.Value?.ToString();
            }
        }
        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
            CustomerDetail custDetail = new CustomerDetail
            {
                customerId = id,
            };
            if(custDetail.ShowDialog() == DialogResult.OK) {

                getListCust();
            }
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            custName.Text = "";
            dob.Text = "";
            gender.Text = "";
            room.Text = "";
            phone.Text = "";
            address.Text = "";
            email.Text = "";
        }

        private void addCustbtn_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer
            {
                Name = custName.Text,
                RoomId = (int)room.SelectedValue,
                Sex = gender.Text,
                Dob = dob.Value,
                Phone = phone.Text,
                Email = email.Text,
                Address = address.Text
            };
            MessageBox.Show(custRepos.AddCustomer(cust));
            getListCust();
        }

        private void deleteCustbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
                string Name = selectedRow.Cells["Name"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {Name.Trim()} không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    custRepos.DeleteCustomer(id);
                    getListCust();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!");
            }
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login.Login();
            Login.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var roomManagement = new RoomRetalManagement.RoomRetalManagement
            {
                account = account
            };
            roomManagement.ShowDialog();
            this.Close();
        }
    }
}
