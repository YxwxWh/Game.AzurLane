using System.Collections.Generic;
using UnityEngine.Networking;

namespace BYXM
{
    public static class HttpUtility
    {
        public static string GetOriginalDataString(Dictionary<string, string> data)
        {
            string formData = "";

            if (data != null && data.Count != 0)
            {
                foreach (string k in data.Keys)
                {
                    formData += k + "=" + UnityWebRequest.EscapeURL(data[k]) + "&";
                }
            }

            formData = formData.Substring(0, formData.Length - 1);

            return formData;
        }
    }
}
