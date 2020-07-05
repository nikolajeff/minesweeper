using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	/*
	private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }*/
	
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
		}
    }
}
