using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerButton : MonoBehaviour
{
    //This code controls behaviour of the lower arrow button (on the left side of the platform) that allows user to change colours of balls from which they choose

    //rows of balls on the left side of the platfrom from which user can choose
    private GameObject row1;
    private GameObject row2;
    private GameObject row3;

    void Start()
    {
        row1 = GameObject.Find("ChooseRow 1");
        row2 = GameObject.Find("ChooseRow 2");
        row3 = GameObject.Find("ChooseRow 3");
    }

    void OnMouseUpAsButton() //this function runs when the button has been clicked
    {

        if (row1.activeInHierarchy)
        {
            row1.SetActive(false);
            row3.SetActive(true);
            return;
        }
        if (row2.activeInHierarchy)
        {
            row2.SetActive(false);
            row1.SetActive(true);
            return;
        }
        if (row3.activeInHierarchy)
        {
            row3.SetActive(false);
            row2.SetActive(true);
            return;
        }
    }

}
