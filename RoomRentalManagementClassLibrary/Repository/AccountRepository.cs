using RoomRentalManagementClassLibrary.DAO;
using RoomRentalManagementClassLibrary.IRepository;
using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public void DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);

        public Account GetAccount(string username, string password) => AccountDAO.Instance.GetAccount(username, password);

        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountByID(id);

        public List<Account> ListAccount() => AccountDAO.Instance.ListAccounts();

        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
