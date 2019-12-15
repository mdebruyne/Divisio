using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Divisio.Models
{
    public class UserService
    {
        DivisioEntities ObjContext;

        public UserService()
        {
            ObjContext = new DivisioEntities();
        }

        public List<UserModel> GetAll()
        {
            List<UserModel> ObjUserList = new List<UserModel>();
            try
            {
                var QueryAllUsers = from users in ObjContext.users select users;
                foreach (var users in QueryAllUsers)
                {
                    ObjUserList.Add(new UserModel { Naam = users.Naam, IdUser = users.IdUser, Voornaam = users.Voornaam, Huisnummer = users.Huisnummer, Straat = users.Straat, IdPostcodeGemeente = Convert.ToInt32(users.postcodeGemeente_IdGemeente) });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserList;
        }

        public bool Add(UserModel objNewUser)
        {
            bool IsAdded = false;
            
            try
            {
                var ObjUser = new users();
                ObjUser.IdUser = objNewUser.IdUser;
                ObjUser.Naam = objNewUser.Naam;
                ObjUser.Straat = objNewUser.Straat;
                ObjUser.Huisnummer = objNewUser.Huisnummer;
                ObjUser.Voornaam = objNewUser.Voornaam;
                ObjUser.postcodeGemeente_IdGemeente = objNewUser.IdPostcodeGemeente;
                ObjContext.users.Add(ObjUser);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(UserModel objUserToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjUser = ObjContext.users.Find(objUserToUpdate.IdUser);
                ObjUser.Naam = objUserToUpdate.Naam;
                ObjUser.Straat = objUserToUpdate.Straat;
                ObjUser.Huisnummer = objUserToUpdate.Huisnummer;
                ObjUser.Voornaam = objUserToUpdate.Voornaam;
                ObjUser.postcodeGemeente_IdGemeente = objUserToUpdate.IdPostcodeGemeente;
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
                var ObjUserToDelete = ObjContext.users.Find(id);
                ObjContext.users.Remove(ObjUserToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public UserModel Search(int id)
        {
            UserModel ObjUser = null;

            try
            {
                var ObjUserToFind = ObjContext.users.Find(id);
                if (ObjUserToFind != null)
                {
                    ObjUser = new UserModel()
                    {
                        IdUser = ObjUserToFind.IdUser,
                        Naam = ObjUserToFind.Naam,
                        Voornaam = ObjUserToFind.Voornaam,
                        Straat = ObjUserToFind.Straat,
                        Huisnummer = ObjUserToFind.Huisnummer,
                        IdPostcodeGemeente = Convert.ToInt32(ObjUserToFind.postcodeGemeente_IdGemeente)
                     };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUser;
        }
    }
}
