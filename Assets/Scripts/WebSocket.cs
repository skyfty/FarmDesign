using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.WebSockets;
using System;
using System.Threading;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class WebSocket : MonoBehaviour
{
    public InputField input;
    public TextMeshProUGUI consoleTextMeshPro;
    public Text consoleText;
    void Start()
    {
        WebSocketMethod();
    }
    ClientWebSocket ws;
    CancellationToken ct;
    public int port;
    public async void WebSocketMethod() {
        try
        {
            ws = new ClientWebSocket();
            ct = new CancellationToken();
            Uri url = new Uri($"ws://127.0.0.1:{port}/");
            await ws.ConnectAsync(url, ct);
            while (true)
            {
                var result = new byte[1024];
                await ws.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());//接受数据
                
                string str = Encoding.UTF8.GetString(result, 0, result.Length);
                Debug.Log(str);
                str = str.Replace("\0", "");
                ConsoleTextPrint(str);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            consoleText.text += ex.Message;
        }
    }

    public async void Send() {
        try
        {
            await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(input.text)), WebSocketMessageType.Binary, true, ct); //发送数据s
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            consoleText.text += ex.Message;
        }
        
    }
    public void ConsoleTextPrint(string str) {
        consoleText.text += str+"\n";
        //consoleTextMeshPro.text += str+"\t";
    }
}
