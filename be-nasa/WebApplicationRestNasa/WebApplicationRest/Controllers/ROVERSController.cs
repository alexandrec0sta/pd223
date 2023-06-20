using Newtonsoft.Json;
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
    public class ROVERSController : ApiController
    {

        [System.Web.Http.Route("api/v0/Rovers")]
        [System.Web.Http.HttpGet]
        public object ListROVERS()
        {
            try
            {
                string query = $"SELECT * FROM ROVERS";
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

        [System.Web.Http.Route("api/v0/Rovers/{id}")]
        [System.Web.Http.HttpGet]
        public object ObjROVERS(int id)
        {
            try
            {
                string query = $"SELECT * FROM ROVERS WHERE id = {id}";
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

        [System.Web.Http.Route("api/v0/Rovers/{id}")]
        [System.Web.Http.HttpDelete]
        public object DeleteROVERS(int id)
        {
            try
            {
                string query = $"DELETE FROM ROVERS WHERE Id ={id}";

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

        [System.Web.Http.Route("api/v0/Rovers/{id}")]
        [System.Web.Http.HttpPut]
        public object UpdateROVERS(int id, [FromBody] ROVERS objectROVERS)
        {
            try
            {
                var result = DataActions.UpdateRowROVERS(id, objectROVERS);

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
