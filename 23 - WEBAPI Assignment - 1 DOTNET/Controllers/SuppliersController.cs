using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _23___WEBAPI_Assignment___1_DOTNET.Data_Access_Layer;
using _23___WEBAPI_Assignment___1_DOTNET.Models;

namespace _23___WEBAPI_Assignment___1_DOTNET.Controllers
{
    [Route("api/Suppliers")]
    public class SuppliersController : ApiController
    {
        DataAccessLayer objDataAccessLayer = new DataAccessLayer();
        [HttpGet]
        public IEnumerable<Suppliers> GetAllSuppliers()
        {
            return objDataAccessLayer.GetAllSuppliers();
        }
        [HttpGet]
        public Suppliers GetAllSuppliers(int SUPLNO)
        {
            return objDataAccessLayer.GetAllSuppliers(SUPLNO);
        }
        [HttpPost]
        public int InsertSuppliers(Suppliers Supplier)
        {
            return objDataAccessLayer.InsertSuppliers(Supplier);
        }
        [HttpPut]
        public int UpdateSuppliers(Suppliers Supplier)
        {
            return objDataAccessLayer.UpdateSuppliers(Supplier);
        }
        [HttpDelete]
        public int DeleteSupplierByID(int id)
        {
            return objDataAccessLayer.DeleteSupplierByID(id);
        }

        
    }
}