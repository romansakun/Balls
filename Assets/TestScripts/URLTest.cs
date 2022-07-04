using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class URLTest : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    
    // Start is called before the first frame update
    async void Start()
    {
        // var uriBuilder = new UriBuilder(@"https://yandex.ru/search/?text=comy");
        //
        // Debug.Log(uriBuilder.Host);
        // Debug.Log(uriBuilder.Port.ToString());
        // Debug.Log(uriBuilder.Scheme);
        // Debug.Log(uriBuilder.Uri.ToString());
        //
        // var request = WebRequest.Create(uriBuilder.Uri);
        // var stream = request.GetResponse().GetResponseStream();
        // var reader = new StreamReader(stream);
        //
        // var lineIndex = 1;
        // var line = reader.ReadLine();
        // while (!string.IsNullOrEmpty(line))
        // {
        //     Debug.Log($"{lineIndex}: {line}");
        //     line = reader.ReadLine();
        //     lineIndex++;
        // }
        
        
        var values = new Dictionary<string, string>
        {
            { "thing1", "hello" },
            { "thing2", "world" }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

        var responseString = await response.Content.ReadAsStringAsync();
        
        Debug.Log(responseString);
    }

}
