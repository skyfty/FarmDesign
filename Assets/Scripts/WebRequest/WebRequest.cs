using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum NetWork { 
WARNING,ERROR,SUCCESS
}

public class WebRequest : MonoBehaviour//�ҹ��ӵĵط�
{
    //public static WebRequest _ins;//д�ɾ�̬�࣬����õõ�
    //readonly string url_saveLessons = "/api/teacher/savePrepareLessons";//Сֽ��д���ˣ�·����
    //private void Awake()
    //{
    //    _ins = this;
    //    DontDestroyOnLoad(this);
    //}
    ////ǰ��������intֵ����������Ҫ����ȥ�Ĳ�������̨���������崫ʲô�����ǿ��Լ��붼��1
    ////Action�ǻص����ȱ�ܣ��Ȼ����ٽ����
    //public void GetInfo_Lenssons(int teacherId, int coursewareId, Action<NetWork, string> callBack)//����
    //{
    //    Dictionary<string, object> dic = new Dictionary<string, object>
    //    {
    //        { "teacherId",teacherId},
    //        { "coursewareId",coursewareId}
    //    };
    //    StartCoroutine(GetUrl(url_saveLessons, dic, callBack));
    //}
    ////������ǻ���unity��������������Ͳ�����д��
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
    //        if (www.isNetworkError)//��������ʧ�� -- �����쳣
    //        {
    //            Debug.Log("www.isNetworkError:" + www.error);
    //            //("����ʧ��", "����ʧ��!\n������ʱ������һ������,\n������\n������Ϣ:" + www.error);
    //            callBack(NetWork.ERROR, www.error);
    //        }
    //        else if (!mark.Equals(www.responseCode))//��������ɹ�,��δ����ȷ���������
    //        {
    //            Debug.Log("warning:" + www.responseCode.ToString());
    //            //("����ʧ��", "�����쳣!\n������.\n�������:" + www.responseCode);
    //            callBack(NetWork.WARNING, www.responseCode.ToString());//warning
    //        }
    //        else if (mark.Equals(www.responseCode))//��������ɹ� - �������з�������
    //        {
    //            Debug.Log("success:" + www.downloadHandler.text.ToString());
    //            string json = www.downloadHandler.text;

    //            callBack(NetWork.SUCCESS, json);
    //        }
    //    }
    //}
}

