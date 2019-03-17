using System.Collections;
using ClientWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebService.Controllers
{
    [ApiController]
    public class MappingController : ControllerBase
    {
        [Route("update/NouserCnt")]
        [HttpPost]
        public int urlcount([FromForm] string urlNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@urlNo", urlNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("No_user_count", ht);
            db.Close();
            return result;
        }

        [Route("insert/Mapping")]
        [HttpPost]
        public int Mapping([FromForm] string urlNo, [FromForm] string mNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@urlNo", urlNo);
            ht.Add("@mNo", mNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("Url_Enter", ht);
            db.Close();
            return result;
        }

        [Route("update/Mapping")]
        [HttpPost]
        public int Mappingud([FromForm] string mNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@mNo", mNo);
            DataBase db = new DataBase();
            int result = db.NonQuerys("logout_Info", ht);
            db.Close();
            return result;
        }
    }
}
