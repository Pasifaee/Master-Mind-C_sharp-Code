using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayStartButton : MonoBehaviour
{
    //This code makes "Play" button load Main Scene
    
    public Button playStartButton;

    void Start() {

        playStartButton.onClick.AddListener(LoadPlayScene);
        
    }

    void LoadPlayScene()
    {
        RowButton.currentRowNumber = 1; //reset the currentRowNumber
        SceneManager.LoadScene("Main Scene");
    }

}
