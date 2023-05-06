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

namespace RoomRentalManagementWinform.Login
{
    
    public partial class Login : Form
    {
        private static readonly AccountRepository accountRepo = new();
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim() != "" || password.Text.Trim() != "")
            {
                var account = accountRepo.GetAccount(username.Text.Trim(), password.Text.Trim());
                if (account != null)
                {
                    if (account.Role == "admin")
                    {
                        this.Hide();
                        var accountManagement = new AccountManagement.AccountManagement();
                        accountManagement.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        if(account.Status == false)
                        {
                            MessageBox.Show("Tài khoản bị vô hiệu hóa!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.Hide();
                        var roomRetailManagement = new RoomRetalManagement.RoomRetalManagement
                        {
                            account = account
                        };
                        roomRetailManagement.ShowDialog();
                      
                        this.Close();
                    }
                    username.Text = "";
                    password.Text = "";
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ tài khoản và mật khẩu", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
