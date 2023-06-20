using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplicationRest.Models;
using WebApplicationRest.Utils;

namespace WebApplicationRest.Controllers
{
    public class TLEController : ApiController
    {
        [System.Web.Http.Route("api/v0/Tle")]
        [System.Web.Http.HttpGet]
        public object ListTLE()
        {
            try
            {
                string query = $"SELECT * FROM TLE";
                string json = DataActions.ReadDataSetthroughReader(query);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [System.Web.Http.Route("api/v0/Tle/{id}")]
        [System.Web.Http.HttpGet]
        public object ObjTLE(int id)
        {
            try
            {
                string query = $"SELECT * FROM TLE WHERE satelliteId = {id}";
                string json = DataActions.ReadDataSetthroughReader(query);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
                return response;
            }
        }


        [System.Web.Http.Route("api/v0/Tle")]
        [System.Web.Http.HttpPost]
        public object CreateTLE([FromBody] TLE objectTLE)
        {
            try
            {
                var result = DataActions.InsertRowTLE(objectTLE);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result.ToString(), Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [System.Web.Http.Route("api/v0/Tle/{id}")]
        [System.Web.Http.HttpDelete]
        public object DeleteTLE(int id)
        {
            try
            {
                string query = $"DELETE FROM TLE WHERE satelliteId  ={id}";

                var result = DataActions.DeleteRow(id, query);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result.ToString(), Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [System.Web.Http.Route("api/v0/Tle/{id}")]
        [System.Web.Http.HttpPut]
        public object UpdateSalary(int id, [FromBody] TLE objectTLE)
        {
            try
            {
                var result = DataActions.UpdateRowTLE(id, objectTLE);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result.ToString(), Encoding.UTF8, "application/json");

                return response;
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}
