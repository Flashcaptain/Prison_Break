using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Web : MonoBehaviour, IInteracteble
{
    [SerializeField]
    private Text _jokeText;

    [SerializeField]
    private Door _door;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                _jokeText.text = ("ERROR");
            }
            else
            {
                string joke = webRequest.downloadHandler.text;

                string[] splitArray = joke.Split(char.Parse(":"));
                _jokeText.text = splitArray[splitArray.Length - 1];

                _door._open = true;
            }
        }
    }

    public void Action()
    {
        StartCoroutine(GetRequest("https://api.chucknorris.io/jokes/random"));
    }
}