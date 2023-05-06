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

namespace RoomRentalManagementWinform.AccountManagement
{
    public partial class AccountDetail : Form
    {
        public readonly AccountRepository accountRepos = new();
        public int accountId { get; set; }
        public AccountDetail()
        {
            InitializeComponent();
        }

        private void AccountDetail_Load(object sender, EventArgs e)
        {
            Account account = accountRepos.GetAccountById(accountId);
            Id.Text = accountId.ToString();
            username.Text = account.Username;
            password.Text = account.Password;
            name.Text = account.Name;
            status.Text = account.Status == true ? "Hoạt động" : "Tạm ngưng";
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            Account account = new Account
            {
                Id = accountId,
                Username = username.Text,
                Password = password.Text,
                Name = name.Text,
                Role = "Nhân viên",
                Status = status.Text == "Hoạt động" ? true : false,
            };
            accountRepos.UpdateAccount(account);
            MessageBox.Show("Cập nhật thông tin tài khoản thành công");
        }
    }
}
