using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class Getweather : MonoBehaviour
{
    private string uri = "https://goweather.herokuapp.com/weather/Curitiba";

    void Start()
    {
        StartCoroutine(GetRequest(uri+DataBetweenScenes.instance._city));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            yield return webRequest.SendWebRequest();

            string resultado = webRequest.downloadHandler.text;
            Debug.Log(resultado);

            Weather w = JsonUtility.FromJson<Weather>(resultado);

                     
        }
    }

}
