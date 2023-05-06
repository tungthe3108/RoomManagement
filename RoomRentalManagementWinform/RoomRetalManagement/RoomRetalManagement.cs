using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRentalManagementWinform.RoomRetalManagement
{
    public partial class RoomRetalManagement : Form
    {
        public Account account { get; set; }
        public RoomRetalManagement()
        {
            InitializeComponent();
        }

        private void RoomRetalManagement_Load(object sender, EventArgs e)
        {
            username.Text= account.Username;
            password.Text= account.Password;
            name.Text= account.Name;
            roletb.Text= account.Role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var roomManagement = new RoomManagement.RoomManagement
            {
                account = account
            };
            roomManagement.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var customerManagement = new CustomerManagement.CustomerManagement
            {
                account = account
            };
            customerManagement.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login.Login();
            Login.ShowDialog();
            this.Close();
        }
    }
}
