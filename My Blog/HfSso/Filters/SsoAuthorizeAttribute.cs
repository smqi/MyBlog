using My_Blog.HfSso.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Blog.HfSso.Filters
{
    public class SsoAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //根据需要添加
            filterContext.HttpContext.Response.Redirect("/Home/Index");

        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            LogHelper.Default.WriteInfo("===========进入sso认证过滤器===========");
            string url = httpContext.Request.Url.ToString();
            LogHelper.Default.WriteInfo("===========当前完整请求地址:" + url + "===========");
            bool result = true;

            return result;
        }
    }
}