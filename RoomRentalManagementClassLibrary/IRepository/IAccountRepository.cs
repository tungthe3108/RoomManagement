using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> ListAccount();
        public void AddAccount(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(int id);
        public Account GetAccount(string username, string password);
        public Account GetAccountById(int id);
    }
}
