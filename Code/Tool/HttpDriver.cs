using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using XLua;
using LitJson;

namespace BYXM
{
    [LuaCallCSharp]
    public class HttpDriver
    {
        #region Singleton

        private HttpDriver() { }

        public static HttpDriver _Instance = null;

        public static HttpDriver One()
        {
            if (_Instance == null)
            {
                _Instance = new HttpDriver();
            }

            return _Instance;
        }

        #endregion

        private bool _Networking = false;

        /// <summary>
        /// 请求HTTP数据
        /// </summary>
        /// <param name="type">请求类型（来自服务器）</param>
        /// <param name="url">URL地址</param>
        /// <param name="successResponse">成功请求的回调函数（服务器返回的字符串）</param>
        /// <param name="errorResponse">失败的回调函数（服务器返回的状态号，错误信息，失败的URL地址，失败的数据）</param>
        /// <param name="data">数据（Key=>参数的名字，Value=>参数的值）</param>
        /// <param name="timeOut">过期秒数</param>
        /// <returns></returns>
        public string Request(
            HTTP_REQUEST_TYPE type,
            string url,
            string str
        )
        {
            Debug.Log("type:"+ type.ToString());
            Debug.Log("url:" + url);
            Debug.Log("str:" + str);
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] strList = str.Split(',');
            for (int i = 0; i < strList.Length; i++)
            {
                string[] strs = (strList[i]).Split(':');
                if (strs.Length == 2)
                {
                    data.Add(strs[0], strs[1]);
                }
            }

            int timeOut = 10;

            if (type == HTTP_REQUEST_TYPE.Post && (data == null || data.Count == 0))
            {
                Debug.LogError("使用HTTP的POST方式请求服务器，表单数据不能为空！");
                return null;
            }

            if (_Networking)
            {
                Debug.LogError("HTTP引擎正在请求服务器！");
                return null;
            }
            return _Request(type, url, data, timeOut);
        }

        private string _Request(
            HTTP_REQUEST_TYPE type,
            string url,
            Dictionary<string, string> data,
            int timeOut
        )
        {

            string debug = "URL地址：" + url + "\n";
            debug += "数据：" + HttpUtility.GetOriginalDataString(data) + "\n";
            debug += "请求类型：" + type.ToString().ToUpper() + "\n";
            DateTime debugTime = DateTime.UtcNow;

            //生成请求
            UnityWebRequest engine;
            if (type == HTTP_REQUEST_TYPE.Get)
            {
                string getData = HttpUtility.GetOriginalDataString(data);
                url = url + (getData != "" ? "?" : "") + getData;

                engine = UnityWebRequest.Get(url);
            }
            else
            {
                WWWForm postData = new WWWForm();
                foreach (string keyword in data.Keys)
                {
                    postData.AddField(keyword, data[keyword]);
                }

                engine = UnityWebRequest.Post(url, postData);
            }

            engine.timeout = timeOut;
            
            engine.SendWebRequest();

            debug += "消耗时间：" + (DateTime.UtcNow - debugTime).TotalMilliseconds / 1000 + "秒\n";

            //网络问题
            if (engine.isNetworkError)
            {
                Debug.LogError("网络错误：" + engine.error + "\n" + debug);

                engine.Dispose();
            }

            //服务器报错
            if (engine.isHttpError)
            {
                debug = "服务器报错（" + engine.responseCode + "）：" + engine.error + "\n" + debug;
                debug += "服务器返回值：" + engine.downloadHandler.text;
                Debug.LogError(debug);

                engine.Dispose();
            }

            //请求成功
            Debug.Log("请求成功：" + debug + "服务器返回值：" + engine.downloadHandler.text);

            System.Threading.Thread.Sleep(500);
            string response = engine.downloadHandler.text;
            engine.Dispose();

            JsonData jsonData = JsonMapper.ToObject(response);

            return jsonData["Code"].ToString();
        }
    }
}

