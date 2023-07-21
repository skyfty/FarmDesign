using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;
using Unity.VisualScripting;

public class HttpTest : MonoBehaviour
{
    #region Init
    //private string jsonUrl = "D:/Server.json";
    //private string jsonUrl = "https://v0.yiketianqi.com/api";
    //private string jsonUrl = "http://192.168.33.212:3004/index.php";
    //private string jsonUrl = "http://192.168.33.212:3004/post.php?id=23";
    private string jsonUrl = "http://192.168.33.212:3004/query.php";

    [Tooltip("请求结果")]
    private string receiveContent = "";

    public crop[] cropclasss;
    [Serializable]
    public class crop
    {
        public string name;
        public GameObject cropGame;
    }

    [Serializable]
    public class cropInfo
    {
        public string id;
        public string x;
        public string y;
        public string z;
        public string crop;
        public string size;
        public string weather;
    }

    public class PosInformation
    {
        public string x;
        public string y;
        public string z;
    }
    public Dictionary<string, GameObject> cropsDic = new Dictionary<string, GameObject>();
    HttpRequest hr = new HttpRequest();

    [SerializeField]
    private int x;
    public int z;
    public int r;

    public int X
    {
        get { return x; }
        set { x = value; Debug.Log(value); }
    }
    public List<GameObject> gameObjects;

    public Dictionary<cropInfo, GameObject> dicGameObject = new Dictionary<cropInfo, GameObject>();
    public Transform gameObjectParentTrans;

    #endregion


    private void Start()
    {
        for (int i = 0; i < cropclasss.Length; i++)
        {
            cropsDic.Add(cropclasss[i].name, cropclasss[i].cropGame);
        }
        //StartCoroutine(Get());
        #region 1*10
        //for (int i = 1; i <= 10; i++)//获取数据
        //{
        //    WWWForm jsonStr = new WWWForm();
        //    jsonStr.AddField("x", 1);
        //    jsonStr.AddField("y", i);
        //    StartCoroutine(Post(jsonUrl, jsonStr,Init));
        //}
        #endregion
        #region All
        //StartCoroutine(Get("http://192.168.33.212:3004/box.php",InitAll));
        //HttpRequest hr= new HttpRequest("http://192.168.33.212:3004/box.php",out receiveContent,InitAll);

        //hr.HttpRequestGet("http://192.168.33.212:3004/box.php", InitAll);


        //XZRPost();
        //InvokeRepeating("RangeChange",0,0.1f);
        //InvokeRepeating("XZRPost", 0.01f, 0.01f);
        #endregion
        //TerrainInfoRequest();
        RoadInfo();
        //InvokeRepeating("GetAll", 0, 10);
        InvokeRepeating("XZRPost", 0, 10);
    }

    public void GetAll() {
        StartCoroutine(Get("http://192.168.33.212:3004/index.php", InitAll));
    }

    private void Update()
    {
        //XZRPost();
        //FromCipsRender();
    }

    #region Terrain Crop

    public void RangeChange()
    {
        r += 1;
        if (r == 10)
        {
            CancelInvoke("RangeChange");
            CancelInvoke("XZRPost");
        }
    }

    public void XZRPost()
    {
        WWWForm jsonStr = new WWWForm();
        jsonStr.AddField("x", x);
        jsonStr.AddField("z", z);
        jsonStr.AddField("r", r);
        //StartCoroutine(Post("http://192.168.33.212:3004/query.php", jsonStr, InitRange));
        StartCoroutine(Post("http://192.168.33.212:3004/query.php", jsonStr, InitAll));
    }
    public void Init()
    {
        PostJsonParse(receiveContent);
        FromCipsRender();
    }

    public void UpdateCipsRender(cropInfo ci) {
        GameObject go = Instantiate(
                        cropsDic[ci.crop],
                    new Vector3(
                        int.Parse(ci.x),
                        float.Parse(ci.y) + 1,
                        int.Parse(ci.z)
                        ), Quaternion.identity
                        );
        dicGameObject.Add(ci, go);
        go.name = ci.x + ci.z;
        go.transform.parent = gameObjectParentTrans;
    }
    public void FromCipsRender()
    {
        //for (int i = 0; i < gameObjects.Count; i++)
        //{
        //    Destroy(gameObjects[i]);
        //}
        //gameObjects.RemoveRange(0, gameObjects.Count);

        foreach (var item in cisDic.Keys)
        {
            if (!dicGameObject.ContainsKey(cisDic[item]))
            {
                GameObject go = Instantiate(
                        cropsDic[cisDic[item].crop],
                    new Vector3(
                        int.Parse(cisDic[item].x),
                        float.Parse(cisDic[item].y) + 1,
                        int.Parse(cisDic[item].z)
                        ), Quaternion.identity
                        );
                dicGameObject.Add(cisDic[item], go);
                go.name = cisDic[item].x + cisDic[item].z;
                go.transform.parent = gameObjectParentTrans;
            }
        }
    }

    /// <summary>
    /// 所有的数据都进行修改
    /// 后面改为传值修改
    /// </summary>
    public void FromTerrainRender()
    {
        TerrainMgr mgr = GameObject.Find("Terrain").GetComponent<TerrainMgr>();
        //for (int i = 1; i < cisDic.Count; i++)
        //{
        //    mgr.Set(int.Parse(cis[i].x), int.Parse(cis[i].z), int.Parse(cis[i].y));
        //}
        foreach (var item in cisDic.Values)
        {
            mgr.Set(int.Parse(item.z), int.Parse(item.x), float.Parse(item.y));
        }
        mgr.Render();
    }

    public void ConfirmStr(string str1,string str2) {
        string[] str1s = str1.Split(",");
        string[] str2s = str2.Split(",");
        foreach (string item in str1s)
        {
            if (!str2s.Contains(item))
            {
                Debug.Log("aaa");
            }
        }
    }
    public void InitAll()
    {
        //receiveContent = hr.receiveContent;
        Debug.Log(receiveContent);
        if (OriginReceive == receiveContent)
        {
            return;
        }
        
        JsonData nowJd = JsonMapper.ToObject(receiveContent);
        JsonData nowData = JsonMapper.ToObject(nowJd["data"].ToJson());
        JsonData data = JsonMapper.ToObject(nowJd["data"].ToJson());

        if (OriginReceive != "")
        {
            JsonData jd = JsonMapper.ToObject(OriginReceive);
            data = JsonMapper.ToObject(jd["data"].ToJson());
        }
        //ConfirmStr(data.ToString(),nowData.ToString());
        cropInfo ci = JsonMapper.ToObject<cropInfo>(nowData[0].ToJson());
        for (int i = 0; i < nowData.Count; i++)
        {
            
            ci = JsonMapper.ToObject<cropInfo>(nowData[i].ToJson());
            if (!cisDic.ContainsKey(ci.id))
            {
                cisDic.Add(ci.id, ci);
            }
            else
            {
                if (data[i] != nowData[i])
                {
                    Destroy(dicGameObject[cisDic[ci.id]]);
                    dicGameObject.Remove(cisDic[ci.id]);
                    cisDic.Remove(ci.id);
                    cisDic.Add(ci.id, ci);
                    UpdateCipsRender(ci);
                }
            }
            
        }
        Weather(ci.weather);
        FromTerrainRender();
        FromCipsRender();
        //foreach (JsonData item in data)
        //{
        //    cropInfo ci = JsonMapper.ToObject<cropInfo>(item.ToJson());

        //    if (!cisDic.ContainsKey(ci.id))
        //    {
        //        cisDic.Add(ci.id, ci);
        //        FromTerrainRender();
        //        FromCipsRender();
        //    }
        //}

        Debug.Log(nowJd);
        OriginReceive = receiveContent;
    }

    public string OriginReceive;
    public void InitRange()
    {
        //cis.RemoveRange(0, cis.Count);
        //receiveContent = hr.receiveContent;

        if (OriginReceive == receiveContent)
        {
            return;
        }

        OriginReceive = receiveContent;
        Debug.Log(receiveContent);
        JsonData jd = JsonMapper.ToObject(receiveContent);
        string msg = jd["msg"].ToString();
        string code = jd["code"].ToString();
        string data = jd["data"].ToJson();
        JsonData dataJd = JsonMapper.ToObject(data);
        foreach (JsonData item in dataJd)
        {
            cropInfo ci = JsonMapper.ToObject<cropInfo>(item.ToJson());
            if (!cisDic.ContainsKey(ci.id))
            {
                cisDic.Add(ci.id, ci);
                FromTerrainRender();
                FromCipsRender();
            }
        }
        Debug.Log("msg:" + msg);
        Debug.Log("code:" + code);

        //cropInfo cropInfos = JsonMapper.ToObject<cropInfo>(receiveContent);
    }



    public List<cropInfo> cis;
    [Tooltip("数据及名称")]
    public Dictionary<string, cropInfo> cisDic = new Dictionary<string, cropInfo>();
    public void PostJsonParse(string content)
    {
        JsonData jd = JsonMapper.ToObject(content);
        string msg = jd["msg"].ToString();
        string code = jd["code"].ToString();
        string data = jd["data"].ToJson();
        cropInfo ci = JsonMapper.ToObject<cropInfo>(data);
        cis.Add(ci);

        Debug.Log("msg:" + msg);
        Debug.Log("code:" + code);
    }
    public void JsonParseOnce(string receiveContent)
    {
        JsonData jd = JsonMapper.ToObject(receiveContent);
        string msg = jd["msg"].ToString();
        string data = jd["data"].ToJson();
        string code = jd["code"].ToString();
        //JsonData jd2= JsonMapper.ToObject(data);
        //JsonInfo jsonInfo = JsonMapper.ToObject<JsonInfo>(data);

        Debug.Log(msg);
        Debug.Log(code);
        Debug.Log(data);
    }



    #endregion
    #region Request

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
            if (UA != null)
            {
                UA.Invoke();
            }
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
            UA.Invoke();
            //JsonParseOnce(receiveContent);
            Debug.Log("--------------------------------------------------------------------------");
            //JsonParse(receiveContent);
        }
    }
    #endregion
    #region Terrain Info
    private string TerrainInfoJsonUrl = "http://192.168.33.212:3004/folt.php";
    public void TerrainInfoRequest()
    {
        StartCoroutine(Get(TerrainInfoJsonUrl, AnalyzeTerrainInfo));
    }
    public void AnalyzeTerrainInfo() {
        
        JsonData jd = JsonMapper.ToObject(receiveContent);
        string msg = jd["msg"].ToString(); 
        string code = jd["code"].ToString();
        //string data = jd["data"].ToString();
        JsonData dataJd = JsonMapper.ToObject(jd["data"].ToJson());
        foreach (JsonData item in dataJd)
        {
            Debug.Log(item["id"].ToString() + item["weather"].ToString());
            
        }
        //Weather("rain");
    }
    [Header("TerrainInfo")]
    public ParticleSystem rainPS;
    public ParticleSystem snowPS;

    [Tooltip("天空盒贴图")]
    public Material[] skyboxMats;
    
    #endregion
    #region Road
    private string RoadUrl = "http://192.168.33.212:3004/way.php";
    public void RoadInfo() {
        StartCoroutine(Get(RoadUrl, AnalyzeRoad));
    }
    public void AnalyzeRoad() {
        Debug.Log(receiveContent);
        TerrainMgr mgr = GameObject.Find("Terrain").GetComponent<TerrainMgr>();
        JsonData jd = JsonMapper.ToObject(receiveContent);
        string msg = jd["msg"].ToString();
        string code = jd["code"].ToString();
        //string data = jd["data"].ToString();
        JsonData dataJd = JsonMapper.ToObject(jd["data"].ToJson());
        
        foreach (JsonData item in dataJd)
        {
            Road road = JsonMapper.ToObject<Road>(item.ToJson());
            Debug.Log(road.id.ToString() );
            mgr.Road(int.Parse(road.start_x),int.Parse(road.start_z),int.Parse(road.direction),int.Parse(road.distance));
        }
    }
    public class Road{
        public string id;
        public string start_x;
        public string start_z;
        public string direction;
        public string distance;
        public string chartlet;
        public string transparency;
    }
    #endregion
    #region weather
    public void Weather(string name)
    {
        rainPS.Stop();
        snowPS.Stop();
        switch (name)
        {
            case "cloudy":
                //天空盒修改
                RenderSettings.skybox = skyboxMats[1];
                
                break;
            case "rainy":
                RenderSettings.skybox = skyboxMats[2];
                rainPS.Play();
                break;
            case "snowy":
                RenderSettings.skybox = skyboxMats[3];
                snowPS.Play();
                break;
            default:
                RenderSettings.skybox = skyboxMats[0];
                break;
        }
    }
    #endregion
}