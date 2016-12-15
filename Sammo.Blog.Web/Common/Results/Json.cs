using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Web.Mvc;

namespace Sammo.Blog.Web.Common.Results
{
    public class Json : JsonResult
    {
        public Json()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        public Json(object data, JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
        {
            Data = data;
            JsonRequestBehavior = jsonRequestBehavior;
        }

        public Json(bool state, string msg = "", object data = null, JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
        {
            Data = new JsonData(state, msg, data);
            JsonRequestBehavior = jsonRequestBehavior;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            
            if(Data!=null)
            {
                var setting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                response.Write(JsonConvert.SerializeObject(Data, setting));
            }
        }
    }
}