using RoomRentalManagementClassLibrary.Models;
using RoomRentalManagementClassLibrary.Repository;
using RoomRentalManagementWinform.CustomerManagement;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RoomRentalManagementWinform.AccountManagement
{
    public partial class AccountManagement : Form
    {
        private readonly AccountRepository accountRepos = new();
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            List<string> listRole = new List<string>();
            statusFind.SelectedIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = accountRepos.ListAccount().Select(x => new
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                Name = x.Name,
                Role = x.Role,
                Status = (x.Status == true) ? "Hoạt động" : "Tạm ngưng"
            }).Where(x =>
                (string.IsNullOrEmpty(accountfind.Text.Trim()) || x.Username.Contains(accountfind.Text.Trim()))
                && (statusFind.Text.Trim() == "Tất cả trạng thái" || string.IsNullOrEmpty(statusFind.Text.Trim())  || x.Status == statusFind.Text)
                
                ).ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Username"].HeaderText = "Tài khoản";
            dataGridView1.Columns["Password"].HeaderText = "Mật khẩu";
            dataGridView1.Columns["Name"].HeaderText = "Người dùng";
            dataGridView1.Columns["Name"].Width = 170;
            dataGridView1.Columns["Role"].HeaderText = "Vai trò";
            dataGridView1.Columns["Role"].Width = 170;
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
            dataGridView1.Columns["Status"].Width = 170;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void statuscb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rolefind_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void accountfind_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Hãy nhập đủ thông tin tài khoản và mật khẩu!", "Thất bại");
                return;
            }
            Account a = new Account
            {
                Username = username.Text,
                Password = password.Text,
                Name = name.Text,
                Role = "Nhân viên",
                Status = true
            };
            accountRepos.AddAccount(a);
            MessageBox.Show("Thêm tài khoản thành công!", "Thành công");
            LoadData();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            object value = cell.Value;
            username.Text = row.Cells["Username"].Value.ToString();
            password.Text = row.Cells["Password"].Value.ToString();
            name.Text = row.Cells["Name"].Value.ToString();
            //role.Text = row.Cells["Role"].Value.ToString();
            //status.Text = row.Cells["Status"].Value.ToString();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            AccountDetail custDetail = new AccountDetail
            {
                accountId = id,
            };
            if (custDetail.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
            name.Text = ""; 
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string username = selectedRow.Cells["Username"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phòng {username.Trim()} không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    accountRepos.DeleteAccount(id);
                    LoadData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login.Login();
            Login.ShowDialog();
            this.Close();
        }
    }
}
