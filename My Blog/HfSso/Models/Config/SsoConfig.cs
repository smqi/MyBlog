using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace My_Blog.HfSso.Models.Config
{
    public class SsoConfig : ConfigurationSection
    {
        private static ConfigurationProperty _property = new ConfigurationProperty(string.Empty, typeof(KeyValueElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        /// <summary>
        /// 配置列表
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        private KeyValueElementCollection KeyValues
        {
            get { return (KeyValueElementCollection)base[_property]; }
            set { base[_property] = value; }
        }

        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientId
        {   
            get
            {
                if (KeyValues["ClientId"] == null) return "";
                return KeyValues["ClientId"].Value;
            }
        }

        /// <summary>
        /// 客户端密钥
        /// </summary>
        public string ClientSecret
        {
            get
            {
                if (KeyValues["ClientSecret"] == null) return "";
                return KeyValues["ClientSecret"].Value;
            }
        }
    }
}