using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum NetWork { 
WARNING,ERROR,SUCCESS
}

public class WebRequest : MonoBehaviour//找棍子的地方
{
    //public static WebRequest _ins;//写成静态类，你才拿得到
    //readonly string url_saveLessons = "/api/teacher/savePrepareLessons";//小纸条写好了（路径）
    //private void Awake()
    //{
    //    _ins = this;
    //    DontDestroyOnLoad(this);
    //}
    ////前面这两个int值，是我们需要传过去的参数，后台会告诉你具体传什么，你们可以假想都是1
    ////Action是回调，先别管，等会我再讲这个
    //public void GetInfo_Lenssons(int teacherId, int coursewareId, Action<NetWork, string> callBack)//棍子
    //{
    //    Dictionary<string, object> dic = new Dictionary<string, object>
    //    {
    //        { "teacherId",teacherId},
    //        { "coursewareId",coursewareId}
    //    };
    //    StartCoroutine(GetUrl(url_saveLessons, dic, callBack));
    //}
    ////这个就是基于unity联网的请求，我这就不具体写了
    //public IEnumerator GetUrl(string url, Dictionary<string, object> getData, Action<NetWork, string> callBack)
    //{
    //    string data = GetStringFromDict(getData);
    //    Debug.Log("data:" + data);
    //    if (!String.IsNullOrEmpty(data))
    //        url = url + "?" + data;
    //    Debug.Log(" RequestService ------ GetUrl() - " + url);

    //    using (UnityWebRequest www = new UnityWebRequest(url, "GET"))
    //    {
    //        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //        www.useHttpContinue = false;

    //        yield return www.SendWebRequest();
    //        long mark = 200;
    //        if (www.isNetworkError)//发起请求失败 -- 弹出异常
    //        {
    //            Debug.Log("www.isNetworkError:" + www.error);
    //            //("请求失败", "请求失败!\n在请求时发生了一个错误,\n请重试\n错误信息:" + www.error);
    //            callBack(NetWork.ERROR, www.error);
    //        }
    //        else if (!mark.Equals(www.responseCode))//发起请求成功,但未能正确到达服务器
    //        {
    //            Debug.Log("warning:" + www.responseCode.ToString());
    //            //("请求失败", "请求异常!\n请重试.\n错误代码:" + www.responseCode);
    //            callBack(NetWork.WARNING, www.responseCode.ToString());//warning
    //        }
    //        else if (mark.Equals(www.responseCode))//本次请求成功 - 服务器有返回数据
    //        {
    //            Debug.Log("success:" + www.downloadHandler.text.ToString());
    //            string json = www.downloadHandler.text;

    //            callBack(NetWork.SUCCESS, json);
    //        }
    //    }
    //}
}

