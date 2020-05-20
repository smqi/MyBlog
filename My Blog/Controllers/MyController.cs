using My_Blog.HfSso.Common;
using My_Blog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Blog.Controllers
{
    public class MyController : Controller
    {
        // 测试json数据
        public string GetJson()
        {
            LogHelper.Default.WriteInfo("开始测试");
            string str = "";
            try
            {
                //比如说前端传过来的信息是jsonString
                string jsonString = "[{\"name\":\"a\",\"value\":\"1\"},{\"name\":\"b\",\"value\":\"2\"}]";

                List<kvp> objList = (List<kvp>)JsonConvert.DeserializeObject<List<kvp>>(jsonString);
                foreach (var obj in objList)
                {
                    str = str + obj.name + ",";

                }
                str = str.Remove(str.Length - 1, 1);
            }
            catch (Exception) { throw; }
            return str;
        }

        // 测试重定向1
        public RedirectResult Redirect() {
           return Redirect("http://www.baidu.com");
        }

        // 测试重定向2
        public void Redirect2() {
            Response.Redirect("http://www.baidu.com");
        }

        // 测试读取配置
        public void ReadConfig() {
            var _ssoConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("SsoConfig") as HfSso.Models.Config.SsoConfig;
            string _clientId = _ssoConfig.ClientId;
            string _clientSecret = _ssoConfig.ClientSecret;
            LogHelper.Default.WriteInfo(_clientId);
            LogHelper.Default.WriteInfo(_clientSecret);
        }
    }
}