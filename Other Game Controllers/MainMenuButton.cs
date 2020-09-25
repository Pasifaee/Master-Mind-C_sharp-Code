using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    //This code makes "Main Menu" button load the Main Menu Scene

    public Button mainMenuButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(LoadMenuScene);

    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
