using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    //This code makes "Quit" button exit the game

    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(Quit);

    }

    void Quit()
    {
        Application.Quit();
    }
}
