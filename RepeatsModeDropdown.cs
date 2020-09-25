using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Diagnostics;
using UnityEngine.UI;
using System;

public class RepeatsModeDropdown : MonoBehaviour
{
    
    
    
    private Dropdown repeatsDropdown; 

    void Start()
    {
        repeatsDropdown = gameObject.GetComponent<Dropdown>();
        repeatsDropdown.onValueChanged.AddListener(delegate {
            ChangeMode();
        });

        UnityEngine.Debug.Log(gameObject.GetComponent<Dropdown>().value);
    }
    
    

    void ChangeMode()
    {
        CodeCreator.repeatsMode = repeatsDropdown.value;
        
    }
}