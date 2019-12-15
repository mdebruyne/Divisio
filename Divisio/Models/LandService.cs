using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Divisio.Models
{
    class LandService
    {
        DivisioEntities ObjContext;

        public LandService()
        {
            ObjContext = new DivisioEntities();
        }

        public List<LandModel> GetAll()
        {
            List<LandModel> ObjLandList = new List<LandModel>();
            try
            {
                var QueryAllLand = from land in ObjContext.land select land;
                foreach (var landen in QueryAllLand)
                {
                    ObjLandList.Add(new LandModel { IdLand = landen.IdLand, Land = landen.LandNaam });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjLandList;
        }

        public bool Add(LandModel objNewLand)
        {
            bool IsAdded = false;

            try
            {
                var ObjLand = new land();
                ObjLand.IdLand = objNewLand.IdLand;
                ObjLand.LandNaam = objNewLand.Land;
                ObjContext.land.Add(ObjLand);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(LandModel objLandToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjLand = ObjContext.land.Find(objLandToUpdate.IdLand);
                ObjLand.LandNaam = objLandToUpdate.Land;
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
                var ObjLandToDelete = ObjContext.land.Find(id);
                ObjContext.land.Remove(ObjLandToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public LandModel Search(int id)
        {
            LandModel ObjLand = null;

            try
            {
                var ObjLandToFind = ObjContext.land.Find(id);
                if (ObjLandToFind != null)
                {
                    ObjLand = new LandModel()
                    {
                        IdLand = ObjLandToFind.IdLand,
                        Land = ObjLandToFind.LandNaam
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjLand;
        }
    }
}
