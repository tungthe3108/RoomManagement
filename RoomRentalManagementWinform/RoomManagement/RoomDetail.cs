using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRentalManagementWinform.RoomManagement
{
    public partial class RoomDetail : Form
    {
        public readonly RoomRepository roomRepos = new();
        public readonly CustomerRepository custRepos = new();
        public int RoomId { get; set; }
        public RoomDetail()
        {
            InitializeComponent();
        }

        private void RoomDetail_Load(object sender, EventArgs e)
        {
            Room room = roomRepos.GetRoomById(RoomId);
            roomID.Text = room.RoomId.ToString().Trim();
            roomName.Text = room.RoomName.ToString().Trim(); 
            floor.Text = room.Floor.ToString().Trim(); 
            area.Text = room.Area.ToString().Trim(); 
            maxPerson.Text = room.NumOfPerson.ToString().Trim(); 
            numOfLiving.Text= room.NumOfLiving.ToString().Trim(); 
            price.Text = room.Price.ToString().Trim(); 
            dataGridView1.DataSource = custRepos.GetCustomerByRoomId(RoomId).Select(x => new
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Sex = x.Sex,
                Dob = x.Dob,
                Phone = x.Phone,
                Email = x.Email,
                Address = x.Address
            }).ToList();
            dataGridView1.Columns["CustomerId"].HeaderText = "Mã khách hàng";
            dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
            dataGridView1.Columns["Sex"].HeaderText = "Giới tính";
            dataGridView1.Columns["Dob"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["Phone"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["Address"].HeaderText = "Địa chỉ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room room = new Room { 
                RoomId = RoomId,
                RoomName = roomName.Text,
                Floor = int.Parse(floor.Text),
                Area = decimal.Parse(area.Text),
                NumOfPerson = int.Parse(maxPerson.Text),
                NumOfLiving= int.Parse(numOfLiving.Text),
                Price= decimal.Parse(price.Text),
            };
            roomRepos.UpdateRoom(room);
            MessageBox.Show("Cập nhật thành công!");
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
