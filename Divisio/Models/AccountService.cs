using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Divisio.Models
{
    public class AccountService
    {
        DivisioEntities ObjContext;

        public AccountService()
        {
            ObjContext = new DivisioEntities();
        }

        public List<AccountModel> GetAll()
        {
            List<AccountModel> ObjAccountList = new List<AccountModel>();
            try
            {
                var QueryAllAccounts = from accounts in ObjContext.accounts select accounts;
                foreach (var accounts in QueryAllAccounts)
                {
                    ObjAccountList.Add(new AccountModel { IdAccount = accounts.IdAccount, IdUser = accounts.Users_IdUser, Actief = Convert.ToBoolean(accounts.Actief), Email = accounts.Email, IdAccountType = accounts.AccountType_IdAccountType, Paswoord = accounts.Paswoord, Usernaam = accounts.Usernaam });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjAccountList;
        }

        public bool Add(AccountModel objNewAccount)
        {
            bool IsAdded = false;
            ValideerPaswoord(objNewAccount);


            try
            {
                var ObjAccount = new accounts();
                ObjAccount.IdAccount = objNewAccount.IdAccount;
                ObjAccount.Usernaam = objNewAccount.Usernaam;
                ObjAccount.Paswoord = objNewAccount.Paswoord;
                ObjAccount.Email = objNewAccount.Email;
                ObjAccount.Actief = Convert.ToByte(objNewAccount.Actief);
                ObjAccount.AccountType_IdAccountType = Convert.ToInt32(objNewAccount.IdAccountType);
                ObjAccount.Users_IdUser = Convert.ToInt32(objNewAccount.IdUser);

                ObjContext.accounts.Add(ObjAccount);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public void ValideerPaswoord(AccountModel objAccount)
        {
            if (objAccount.Paswoord.Trim().Length < 8)
            {
                throw new ArgumentException("Paswoord moet minstens 8 character bevatten.");
            }
            else if (objAccount.Paswoord.Trim().Length > 20)
            {
                throw new ArgumentException("Paswoord mag niet meer dan 20 characters bevatten.");
            }
            else if (!objAccount.Paswoord.Any(char.IsUpper))
            {
                throw new ArgumentException("Paswoord moet minstens 1 hoofdletter bevatten");
            }
            else if (!objAccount.Paswoord.Any(char.IsLower))
            {
                throw new ArgumentException("Paswoord moet minstens 1 kleine letter bevatten");
            }
            else if (!objAccount.Paswoord.Any(char.IsNumber))
            {
                throw new ArgumentException("Paswoord moet minstens 1 nummer bevatten");
            }

        }

        public bool Update(AccountModel objAccountToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjAccount = ObjContext.accounts.Find(objAccountToUpdate.IdAccount);
                ObjAccount.Usernaam = objAccountToUpdate.Usernaam;
                ObjAccount.Paswoord = objAccountToUpdate.Paswoord;
                ObjAccount.Email = objAccountToUpdate.Email;
                ObjAccount.Actief = Convert.ToByte(objAccountToUpdate.Actief);
                ObjAccount.AccountType_IdAccountType = Convert.ToInt32(objAccountToUpdate.IdAccountType);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            try
            {
                var ObjAccountToDelete = ObjContext.accounts.Find(id);
                ObjContext.accounts.Remove(ObjAccountToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public AccountModel Search(int id)
        {
            AccountModel ObjAccount = null;

            try
            {
                var ObjAccountToFind = ObjContext.accounts.Find(id);
                if (ObjAccountToFind != null)
                {
                    ObjAccount = new AccountModel()
                    {
                        IdAccount = ObjAccountToFind.IdAccount,
                        Usernaam = ObjAccountToFind.Usernaam,
                        Paswoord = ObjAccountToFind.Paswoord,
                        Email = ObjAccountToFind.Email,
                        Actief = Convert.ToBoolean(ObjAccountToFind.Actief),
                       IdAccountType = ObjAccountToFind.AccountType_IdAccountType,
                        IdUser = ObjAccountToFind.Users_IdUser
                    };
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjAccount;
        }
    }
}
