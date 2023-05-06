using Microsoft.EntityFrameworkCore;
using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RoomRentalManagementWinform.RoomManagement
{
    public partial class RoomManagement : Form
    {
        private readonly RoomRepository roomRepos = new();
        private readonly RoomRetalManagementContext context = new();
        public Account account { get; set; }
        public RoomManagement()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("a");
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            //var query = from room in context.Rooms
            //            join customer in context.Customers on room.RoomId equals customer.RoomId
            //            group customer by room.RoomId into g
            //            select new
            //            {
            //                RoomId = g.Key,
            //                RoomName = context.Rooms.FirstOrDefault(x => x.RoomId == g.Key).RoomName,
            //                NumOfPerson = context.Rooms.FirstOrDefault(x => x.RoomId == g.Key).NumOfPerson,
            //                CustomerCount = g.Count(),
            //                Area = context.Rooms.FirstOrDefault(x => x.RoomId == g.Key).Area,
            //                Price = context.Rooms.FirstOrDefault(x => x.RoomId == g.Key).Price,
            //                Status = context.Rooms.FirstOrDefault(x => x.RoomId == g.Key).Status,
            //            };
            //var result = query.ToList();
            GetListRooms();
            numOfPerson.DataSource = context.NumOfPeople.ToList();
            area.DataSource = context.Areas.ToList();
            price.DataSource = context.RoomPrices.ToList();
            List<string> listPrice = new List<string>();
            listPrice.Add("Tất cả loại giá");
            foreach (var item in context.RoomPrices.ToList())
            {
                listPrice.Add(item.ToString());
            }

            dataGridView1.CellDoubleClick += dgvRoomList_CellDoubleClick;
            dataGridView1.CellClick += dgvRoomList_CellClick;
        }

        private void dgvRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            object value = cell.Value;
            roomName.Text = row.Cells["RoomName"].Value.ToString();
            numOfPerson.Text = row.Cells["NumOfPerson"].Value.ToString();
            area.Text = row.Cells["Area"].Value.ToString();
            price.Text = row.Cells["Price"].Value.ToString();
            //if (row.Cells[2].Value.ToString() == "Female")
            //dtp1.Text = row.Cells[3].Value.ToString();
            //cb1.Text = row.Cells[4].Value.ToString();
        }

        private void dgvRoomList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["RoomId"].Value);
            RoomDetail roomDetail = new RoomDetail
            {
                RoomId = id
            };
            if(roomDetail.ShowDialog() == DialogResult.OK)
            {
                GetListRooms();
            }
        }
        public void GetListRooms()
        {
            dataGridView1.DataSource = roomRepos.GetListRoom().ToList().Select(x => new
            {
                RoomId = x.RoomId,
                RoomName = x.RoomName,
                NumOfPerson = x.NumOfPerson,
                NumOfLiving = x.NumOfLiving,
                Area = x.Area,
                Price = x.Price,
                Status = (x.NumOfLiving == 0) ? "Trống" : (x.NumOfPerson == x.NumOfLiving) ? "Đã đủ" : "Chưa đủ"
            }).ToList();
            dataGridView1.Columns["RoomId"].Visible = false;
            dataGridView1.Columns["RoomName"].HeaderText = "Tên phòng";
            dataGridView1.Columns["NumOfPerson"].HeaderText = "Số người ở tối đa";
            dataGridView1.Columns["NumOfPerson"].Width = 160;
            dataGridView1.Columns["NumOfLiving"].HeaderText = "Số người đang ở";
            dataGridView1.Columns["Area"].HeaderText = "Diện tích(/m2)";
            dataGridView1.Columns["Area"].Width = 150;
            dataGridView1.Columns["Price"].HeaderText = "Giá";
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
        }

        private void addRoombtn_Click(object sender, EventArgs e)
        {
            if(roomName.Text.Trim().Length == 0 ||
               numOfPerson.Text.Trim().Length == 0 ||
               area.Text.Trim().Length == 0 ||
               price.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập đủ thông tin các trường: Tên phòng, Số người ở tối đa, Diện tich, Giá");
            }
            else
            {
                Room r = new Room();
                r.RoomName = roomName.Text.Trim();
                r.Area = Convert.ToDecimal(area.Text);
                r.NumOfPerson = Convert.ToInt32(numOfPerson.Text.Trim());
                r.Price = Convert.ToDecimal(price.Text);
                roomRepos.AddRoom(r);
            }
            GetListRooms();
            MessageBox.Show("Thêm phòng thành công");
        }


       

        private void deleteRoombtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["RoomId"].Value);
                string roomName = selectedRow.Cells["RoomName"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phòng {roomName.Trim()} không?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    roomRepos.DeleteRoom(id);
                    GetListRooms();
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            roomName.Text = "";
            numOfPerson.Text = "";
            area.Text = "";
            price.Text = "";
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
