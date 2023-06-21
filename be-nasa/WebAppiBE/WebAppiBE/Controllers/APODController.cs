using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppiBE.Utils;

namespace WebAppiBE.Controllers
{
    public class APODController : ControllerBase
    {
        [Route("api/v0/Apod")]
        [HttpGet]
        public object ObjAPOD()
        {
            try
            {
                string query = $"SELECT * FROM apod ORDER BY date DESC LIMIT 1";
                var json = DataActions.ReadDataSetthroughReader(query);

                var jsonData = DataActions.DataTableToJson(json);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                return new JsonResult(jsonData, options);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
