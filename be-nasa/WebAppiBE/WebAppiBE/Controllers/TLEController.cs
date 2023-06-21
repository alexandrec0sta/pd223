using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppiBE.Models;
using WebAppiBE.Utils;

namespace WebAppiBE.Controllers
{
    public class TLEController : ControllerBase
    {
        [Route("api/v0/Tle")]
        [HttpGet]
        public object ListTLE()
        {
            try
            {
                string query = $"SELECT * FROM tle";
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

        [Route("api/v0/Tle/{id}")]
        [HttpGet]
        public object ObjTLE(int id)
        {
            try
            {
                string query = $"SELECT * FROM tle WHERE satelliteId = {id}";
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

        [Route("api/v0/Tle/{id}")]
        [HttpDelete]
        public object DeleteTLE(int id)
        {
            try
            {
                string query = $"DELETE FROM tle WHERE satelliteId  ={id}";

                var result = DataActions.DeleteRow(query);

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/v0/Tle/{id}")]
        [HttpPut]
        public object UpdateTLE(int id, [FromBody] TLE objectTLE)
        {
            try
            {
                var result = DataActions.UpdateRowTLE(id, objectTLE);

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
