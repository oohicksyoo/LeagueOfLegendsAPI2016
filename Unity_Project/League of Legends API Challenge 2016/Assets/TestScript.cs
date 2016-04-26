using UnityEngine;
using System.Collections;
using System.Linq;
using StringExtensions;

public class TestScript : MonoBehaviour
{
    delegate void callBack(string jsonFileString);

    private Summoner summoner;

    void Start()
    {
        //Debug.Log(Application.streamingAssetsPath + "/" + "DatabaseRequest.php");
        //StartCoroutine(JSONRequest("na.api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/NA1/68690468?api_key=0b9c6c6b-6384-43f8-a653-542fdd27710c"));

        WWWForm variables = new WWWForm();
        variables.AddField("functionName", "summonerInformation");
        variables.AddField("region", "na");
        variables.AddField("summonerName", "Its Freelo Time".FormatSummonerName());

        StartCoroutine(JSONRequest("hicksy.ca/alex/DatabaseRequest.php", variables, SummonerInformation));
    }

    IEnumerator JSONRequest(string path, WWWForm variables,  callBack callBack)
    {
        WWW urlRequest = new WWW(path,variables);

        yield return urlRequest; //Wait on url request to come back to us before proceeding

        string jsonFileString = urlRequest.text;

        callBack.Invoke(jsonFileString);       
    }

    private void SummonerInformation(string jsonFileString)
    {
        Debug.Log(jsonFileString);

        jsonFileString = jsonFileString.Split('{')[2]
                        .Split('}')[0];

        jsonFileString = "{" + jsonFileString + "}";

        Debug.Log(jsonFileString);

        summoner = JsonUtility.FromJson<Summoner>(jsonFileString);

        Debug.Log(summoner.name + ":" + summoner.id);
    }
}
