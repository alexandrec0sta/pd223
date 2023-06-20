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
    public class APODController : ApiController
    {
        [System.Web.Http.Route("api/v0/Apod")]
        [System.Web.Http.HttpGet]
        public object ListAPOD()
        {
            try
            {
                string query = $"SELECT TOP (1)  * FROM APOD ORDER BY date DESC";
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


        [System.Web.Http.Route("api/v0/Apod")]
        [System.Web.Http.HttpPost]
        public object CreateAPOD([FromBody] APOD objectAPOD)
        {
            try
            {
                var result = DataActions.InsertRowAPOD(objectAPOD);

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

        [System.Web.Http.Route("api/v0/Apod/{id}")]
        [System.Web.Http.HttpDelete]
        public object DeleteAPOD(int id)
        {
            try
            {
                string query = $"DELETE FROM APOD WHERE Id ={id}";

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

        [System.Web.Http.Route("api/v0/Apod/{id}")]
        [System.Web.Http.HttpPut]
        public object UpdateAPOD(int id, [FromBody] APOD objectAPOD)
        {
            try
            {
                var result = DataActions.UpdateRowAPOD(id, objectAPOD);

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
