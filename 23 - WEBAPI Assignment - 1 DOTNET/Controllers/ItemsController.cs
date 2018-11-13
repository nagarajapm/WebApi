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
    [Route("api/Items")]
    public class ItemsController : ApiController
    {
        DataAccessLayer objDataAccessLayer = new DataAccessLayer();
        [HttpGet]
        public IEnumerable<Items> GetAllItems()
        {
            return objDataAccessLayer.GetAllItems();
        }
        [HttpGet]
        public Items GetAllItems(string ITCODE)
        {
            return objDataAccessLayer.GetAllItems(ITCODE);
        }
        [HttpPost]
        public int InsertItems(Items Item)
        {
            return objDataAccessLayer.InsertItems(Item);
        }
        [HttpDelete]
        public int DeleteItemByID(string id)
        {
            return objDataAccessLayer.DeleteItemByID(id);
        }
        [HttpPut]
        public int UpdateItems(Items Item)
        {
            return objDataAccessLayer.UpdateItems(Item);
        }
    }
}
