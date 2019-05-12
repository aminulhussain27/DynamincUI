using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour 
{

	private static JsonData instance = null;

	public static JsonData Instance()
	{
		if (instance == null)
		{
			instance = new JsonData();
		}

		return instance;
	}

    string filename = "data.json";
    string path;

	public GameData gameData = new GameData();

	// Use this for initialization
	string Url;
	void Start () 
	{
        path = Application.persistentDataPath + "/" + filename;

		Url = "https://s3-ap-southeast-1.amazonaws.com/cdn.hitwicket.co/sample_test_hitcoins.json";
		GetData();
	}

	//I want to make request.
	void GetData()
	{
		//sending the request to url
		WWW www = new WWW(Url);
		StartCoroutine("GetdataEnumerator", Url);
	}
	IEnumerator GetdataEnumerator(WWW www)
	{
		//Wait for request to complete
		yield return www;
		if (www.error != null)
		{
			string serviceData = www.text;
			//Data is in json format, we need to parse the Json.
//			Debug.Log(serviceData);
		}
		else
		{
			Debug.LogError(www.error);
		}
	}


    void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.gameData = gameData;

        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void ReadData()
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.gameData;

            }
            else
            {
                Debug.Log("Unable to read the save data, file does not exist");
                gameData = new GameData();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
