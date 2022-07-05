using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private string uri = "https://dog.ceo/api/breeds/image/random";    
    private Texture2D image;
    private RawImage dogImage;
    private dog d;



    private void Awake()
    {
        dogImage = GetComponent<RawImage>();
    }

    void Start()
    {
        StartCoroutine(GetRequest(uri));
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dogImage.texture = image;
        }
    }




    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            
            yield return webRequest.SendWebRequest();

            string resultado = webRequest.downloadHandler.text;
            Debug.Log(resultado);
            dog d = JsonUtility.FromJson<dog>(resultado);
            Debug.Log(d.message);

            StartCoroutine(GetImage(d.message));
        }
    }

    IEnumerator GetImage(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri))
        {

            yield return webRequest.SendWebRequest();

            image = DownloadHandlerTexture.GetContent(webRequest);
        }
    }

    
}
