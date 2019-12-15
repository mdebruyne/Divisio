using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Divisio.Models
{
    class PostcodeGemeenteService
    {
        DivisioEntities ObjContext;

        public PostcodeGemeenteService()
        {
            ObjContext = new DivisioEntities();
        }

        public List<PostcodeGemeenteModel> GetAll()
        {
            List<PostcodeGemeenteModel> ObjPostcodeGemeenteList = new List<PostcodeGemeenteModel>();
            try
            {
                var QueryAllGemeentes = from postcodeGemeente in ObjContext.postcodeGemeente select postcodeGemeente;
                foreach (var gemeentes in QueryAllGemeentes)
                {
                    ObjPostcodeGemeenteList.Add(new PostcodeGemeenteModel { IdGemeente = gemeentes.IdGemeente, Gemeente = gemeentes.Gemeente, Postcode=gemeentes.Postcode, IdProvincie= Convert.ToInt32(gemeentes.Provincie_IdProvincie)});
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjPostcodeGemeenteList;
        }

        public bool Add(PostcodeGemeenteModel objNewGemeente)
        {
            bool IsAdded = false;

            try
            {
                var ObjGemeente= new postcodeGemeente();
                ObjGemeente.IdGemeente = objNewGemeente.IdGemeente;
                ObjGemeente.Gemeente = objNewGemeente.Gemeente;
                ObjGemeente.Postcode = objNewGemeente.Postcode;
                ObjGemeente.Provincie_IdProvincie = objNewGemeente.IdProvincie;
                ObjContext.postcodeGemeente.Add(ObjGemeente);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(PostcodeGemeenteModel objGemeenteToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjGemeente = ObjContext.postcodeGemeente.Find(objGemeenteToUpdate.IdGemeente);
                ObjGemeente.Gemeente = objGemeenteToUpdate.Gemeente;
                ObjGemeente.Postcode = objGemeenteToUpdate.Postcode;
                ObjGemeente.Provincie_IdProvincie = objGemeenteToUpdate.IdProvincie;
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
                var ObjGemeenteToDelete = ObjContext.postcodeGemeente.Find(id);
                ObjContext.postcodeGemeente.Remove(ObjGemeenteToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public PostcodeGemeenteModel Search(int id)
        {
            PostcodeGemeenteModel ObjGemeente = null;

            try
            {
                var ObjGemeenteToFind = ObjContext.postcodeGemeente.Find(id);
                if (ObjGemeenteToFind != null)
                {
                    ObjGemeente = new PostcodeGemeenteModel()
                    {
                        IdGemeente = ObjGemeenteToFind.IdGemeente,
                         Gemeente = ObjGemeenteToFind.Gemeente,
                         Postcode = ObjGemeenteToFind.Postcode,
                         IdProvincie = Convert.ToInt32(ObjGemeenteToFind.Provincie_IdProvincie)
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjGemeente;
        }
    }
}
