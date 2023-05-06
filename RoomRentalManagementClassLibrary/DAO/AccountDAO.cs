using RoomRentalManagementClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRentalManagementClassLibrary.DAO
{
    public class AccountDAO
    {
        public static AccountDAO instance = null;
        public static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Account> ListAccounts()
        {
            List<Account> list = new List<Account>();
            try
            {
                using var context = new RoomRetalManagementContext();
                list = context.Accounts.ToList().Select(x => new Account
                {
                    Id = x.Id,
                    Username = x.Username,
                    Password = x.Password,
                    Name = x.Name,
                    Role = x.Role,
                    Status = x.Status
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Account GetAccount(string username, string password)
        {
            Account account = new Account();
            try
            {
                using var context = new RoomRetalManagementContext();
                account = context.Accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
        public Account GetAccountByID(int id)
        {
            Account account = new Account();
            try
            {
                using var context = new RoomRetalManagementContext();
                account = context.Accounts.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Tài khoản không hợp lệ!");
            }
            return account;
        }
        public void AddAccount(Account account)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                Account account1 = context.Accounts.SingleOrDefault(x => x.Username == account.Username);
                if(account1 == null)
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tài khoản đã tồn tại!");
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAccount(int id)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                Account account = GetAccountByID(id);
                account.Status = false;
                context.Accounts.Update(account);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateAccount(Account accountUpdate)
        {
            try
            {
                using var context = new RoomRetalManagementContext();
                context.Accounts.Update(accountUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
