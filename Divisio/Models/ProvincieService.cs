using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Divisio.Models
{
    class ProvincieService
    {
        DivisioEntities ObjContext;

        public ProvincieService()
        {
            ObjContext = new DivisioEntities();
        }

        public List<ProvincieModel> GetAll()
        {
            List<ProvincieModel> ObjProvincieList = new List<ProvincieModel>();
            try
            {
                var QueryAllProvincie = from provincie in ObjContext.provincie select provincie;
                foreach (var provincies in QueryAllProvincie)
                {
                    ObjProvincieList.Add(new ProvincieModel { IdProvincie=provincies.Idprovincie, Provincie = provincies.ProvincieNaam, IdLand = Convert.ToInt32(provincies.Land_IdLand) });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjProvincieList;
        }

        public bool Add(ProvincieModel objNewProvincie)
        {
            bool IsAdded = false;

            try
            {
                var ObjProvincie = new provincie();
                ObjProvincie.Idprovincie = objNewProvincie.IdLand;
                ObjProvincie.ProvincieNaam = objNewProvincie.Provincie;
                ObjProvincie.Land_IdLand = objNewProvincie.IdLand;
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(ProvincieModel objProvincieToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjProvincie = ObjContext.provincie.Find(objProvincieToUpdate.IdProvincie);
                ObjProvincie.ProvincieNaam = objProvincieToUpdate.Provincie;
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
                var ObjProvincieToDelete = ObjContext.provincie.Find(id);
                ObjContext.provincie.Remove(ObjProvincieToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public ProvincieModel Search(int id)
        {
            ProvincieModel ObjProvincie = null;

            try
            {
                var ObjProvincieToFind = ObjContext.provincie.Find(id);
                if (ObjProvincieToFind != null)
                {
                    ObjProvincie = new ProvincieModel()
                    {
                        IdProvincie = ObjProvincieToFind.Idprovincie,
                        Provincie = ObjProvincieToFind.ProvincieNaam,
                        IdLand = Convert.ToInt32(ObjProvincieToFind.Land_IdLand)
                        
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjProvincie;
        }
    }
}
