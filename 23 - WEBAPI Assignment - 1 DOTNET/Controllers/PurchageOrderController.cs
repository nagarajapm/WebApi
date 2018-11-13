using _23___WEBAPI_Assignment___1_DOTNET.Data_Access_Layer;
using _23___WEBAPI_Assignment___1_DOTNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _23___WEBAPI_Assignment___1_DOTNET.Controllers
{
    [Route("api/PurchageOrder")]
    public class PurchageOrderController : ApiController
    {
        DataAccessLayer objDataAccessLayer = new DataAccessLayer();
        [HttpGet]
        public IEnumerable<PODetails> GetAllPurchageOrders()
        {
            return objDataAccessLayer.GetAllPurchageOrders();
        }
        [HttpGet]
        public PODetails GetAllPurchageOrders(string PONO)
        {
            return objDataAccessLayer.GetAllPurchageOrders(PONO);
        }
        [HttpDelete]
        public int DeletePurchageOrdersByID(string PONO)
        {
            return objDataAccessLayer.DeletePurchageOrdersByID(PONO);
        }
        [HttpPost]
        public int InsertPODetails(PODetails PODetails)
        {
            return objDataAccessLayer.InsertPODetails(PODetails);
        }
        [HttpPut]
        public int UpdatePODetails(PODetails PODetails)
        {
            return objDataAccessLayer.UpdatePurchageOrders(PODetails);
        }
    }
}
