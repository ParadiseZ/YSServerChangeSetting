﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSServerChangeSetting
{
    internal class Config
    {
        private static Dictionary<string, string> configDic = new Dictionary<string, string>();
        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 
        private static string filePath = @"..\\config.ini";
        public static string ReadConfig(string key)
        {
            if (File.Exists(@filePath) == false)//如果不存在就创建file文件夹
            {
                FileStream f = File.Create(filePath);
                f.Close();
            }
            string s = File.ReadAllText(filePath);
            try
            {
                configDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            }
            catch
            {
                configDic = new Dictionary<string, string>();
            }

            if (configDic != null && configDic.ContainsKey(key))
            {
                return configDic[key];
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 添加配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void WriteConfig(string key, string value)
        {
            if (configDic == null)
            {
                configDic = new Dictionary<string, string>();
            }
            configDic[key] = value;
            string s = JsonConvert.SerializeObject(configDic);
            File.WriteAllText(filePath, s);
        }
        /// <summary>
        /// 删除配置信息
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteConfig(string key)
        {
            if (configDic != null && configDic.ContainsKey(key))
            {
                configDic.Remove(key);
                string s = JsonConvert.SerializeObject(configDic);
                File.WriteAllText(filePath, s);
            }
        }
    }
}
