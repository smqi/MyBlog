using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace My_Blog.Controllers
{
    public class MyApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            string data = null;
            using (var httpClient = new HttpClient())
            {
                //url
                var url = new Uri("https://www.baidu.com/");
                //设置webapi的用户名和密码
                //var body = new FormUrlEncodedContent(new Dictionary
                //    {
                //    { "username", "admin"},
                //    { "password", "admin123"}
                //});
                // response
                var response = httpClient.PostAsync(url, null).Result;
                data = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine("==========接口调用完毕!=============");
            return data;//接口调用成功数据
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}