using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Example : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(GetRequest("http://localhost/projetosalgado/Conexão.php"));
        //StartCoroutine(Logar("usuario1", "senha1"));
        StartCoroutine(Registrar("usuario2", "senha2"));
    }

    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator Logar(string validusuario, string validsenha)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", validusuario);
        form.AddField("senha", validsenha);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/projetosalgado/Login.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            
        }
    }

    public IEnumerator Registrar(string validusuario, string validsenha)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", validusuario);
        form.AddField("senha", validsenha);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/projetosalgado/Register.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            
        }
    }


}
