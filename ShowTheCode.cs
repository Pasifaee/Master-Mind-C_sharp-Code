using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowTheCode : MonoBehaviour
{
    //This code makes the "Show the code" button show the code

    public Button showCodeButton;
    private GameObject codeToShow;

    void Start()
    {
        codeToShow = GameObject.Find("ShowTheCode");
        codeToShow.SetActive(false);
        showCodeButton.onClick.AddListener(showTheCode);

    }

    void showTheCode()
    {
        codeToShow.SetActive(true);
        for(int i = 1; i<=4; i++)
        {
            GameObject.Find("Code" + i.ToString() + " Text").GetComponent<Text>().text = CodeCreator.Code[i];
        }
        
    }

}
