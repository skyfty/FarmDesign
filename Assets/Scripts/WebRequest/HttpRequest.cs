using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class HttpRequest : MonoBehaviour
{
    public string receiveContent="";

    public void HttpRequestGet( string jsonUrl, UnityAction UA = null) {
        Debug.Log(jsonUrl);
        Debug.Log(UA);
        StartCoroutine(this.Get(jsonUrl));
        //Debug.Log(receiveContent);
    }


    /// <summary>
    /// Post请求
    /// </summary>
    /// <param name="jsonUrl">请求地址</param>
    /// <param name="wwwForm">请求参数</param>
    /// <param name="UA">请求结束后执行的事件(可空)</param>
    /// <returns></returns>
    IEnumerator Post(string jsonUrl, WWWForm wwwForm, UnityAction UA = null)
    {
        UnityWebRequest request = UnityWebRequest.Post(jsonUrl, wwwForm);
        request.timeout = 5;

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            receiveContent = request.downloadHandler.text;
            UA.Invoke();
            Debug.Log("--------------------------------------------------------------------------");
            //JsonParse(receiveContent);
        }
        #region ERROR
        //using (UnityWebRequest www = UnityWebRequest.Post(jsonUrl, "{ \"x\": 1, \"y\": 4 }", "application/json"))
        //{
        //    yield return www.SendWebRequest();

        //    if (www.result != UnityWebRequest.Result.Success)
        //    {
        //        Debug.Log(www.error);
        //    }
        //    else
        //    {
        //        string receiveContent = www.downloadHandler.text;
        //        JsonParseOnce(receiveContent);
        //        Debug.Log("--------------------------------------------------------------------------");
        //    }
        //}
        #endregion
    }

    /// <summary>
    /// Get请求
    /// </summary>
    /// <param name="jsonUrl">请求地址</param>
    /// <param name="UA">请求结束后执行的事件(可空)</param>
    /// <returns></returns>
    IEnumerator Get(string jsonUrl, UnityAction UA = null)
    {
        Debug.Log(jsonUrl);
        UnityWebRequest request = UnityWebRequest.Get(jsonUrl);
        request.timeout = 5;
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            receiveContent = request.downloadHandler.text;
            //UA.Invoke();
            //JsonParseOnce(receiveContent);
            Debug.Log("--------------------------------------------------------------------------");
            //JsonParse(receiveContent);
        }
    }

}
