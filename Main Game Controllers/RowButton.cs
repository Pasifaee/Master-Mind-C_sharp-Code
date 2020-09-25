using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RowButton : MonoBehaviour
{
    //This code controls the behaviour of a white lamp buttons above every row of hemispheres
    //It also scores the user answer in red and white points
    
    private GameObject newButton;
    public static int currentRowNumber = 1;
    public static bool justChangedRow = false;

    public static string[,] colorTable;
    public static float[] yPositions;
    

    void Start()
    {
        colorTable = new string[13,9];
    }

    void OnMouseUpAsButton()
    {
        
        if ((currentRowNumber+1) <= 12) //checking if there's any empty space on the platform to place new balls
        {

            //checking if all four balls have been placed in the row
            for (int i = 1; i <= CodeCreator.codeLength; i++)
            {
                
                if (colorTable[currentRowNumber, i] == null) return;
                
            }


            currentRowNumber++;
            justChangedRow = true;


            //adding colliders to row with currentRowNumber
            string rowTag2 = "Row " + (currentRowNumber).ToString();
            GameObject[] tagList2 = GameObject.FindGameObjectsWithTag(rowTag2);
            foreach (GameObject i in tagList2)
            {
                i.AddComponent<CircleCollider2D>();
                if (i.name.StartsWith("Hemisphere")) i.GetComponent<CircleCollider2D>().radius = 0.06f;

            }

            //removing colliders from row with previous currentRowNumber
            string rowTag = "Row " + (currentRowNumber-1).ToString();
            GameObject[] tagList;
            tagList = GameObject.FindGameObjectsWithTag(rowTag);
            foreach (GameObject i in tagList)
            {
                Destroy(i.GetComponent<CircleCollider2D>());
            }

            justChangedRow = false;

        }

        //SCORING ANSWERS
        int redPoints = 0, whitePoints = 0;
        //Creating a clone of Code table
        string[] Code;
        Code = new string[5];
        for(int i = 1; i<=4; i++)
        {
            Code[i] = CodeCreator.Code[i];
        }

        //Scoring red points
        for (int codeBall = 1; codeBall <= 4; codeBall++)
        {
            
            for (int ball = 1; ball <= 4; ball++)
            {

                if (colorTable[currentRowNumber - 1, ball] == Code[codeBall] && ball == codeBall)
                {
                    redPoints++;
                    colorTable[currentRowNumber - 1, ball] = null;
                    Code[codeBall] = null;
                }
            }
        }

        //Scoring white points
        for (int codeBall = 1; codeBall <= 4; codeBall++)
        {

            for (int ball = 1; ball <= 4; ball++)
            {
                if(colorTable[currentRowNumber - 1, ball] != null && Code[codeBall] != null)
                {
                    if (colorTable[currentRowNumber - 1, ball] == Code[codeBall])
                    {
                        whitePoints++;
                        colorTable[currentRowNumber - 1, ball] = null;
                        Code[codeBall] = null;
                    }
                }
                
            }
        }

        if (redPoints > 0) Animate(true, redPoints);
        if (whitePoints > 0) Animate(false, whitePoints);

        newButton = Instantiate(Resources.Load("Prefabs/GreenRoundButton", typeof(GameObject))) as GameObject; //making the white lamp glow in green
        newButton.transform.position = gameObject.transform.position;

        Destroy(gameObject);
    }

    void Animate(bool isBottom, int points) //the function chooses appropriate animation based on the red and white scores
    {
        Animator anim;
        
        if (isBottom)
        {
            anim = GameObject.Find("ScoreBottomPlatform (" + (currentRowNumber - 2).ToString() + ")").GetComponent<Animator>();
        }
        else
        {
            anim = GameObject.Find("ScoreUpperPlatform (" + (currentRowNumber - 2).ToString() + ")").GetComponent<Animator>();
        }

        string animName;
        if (isBottom)
        {
            animName = "New State " + points.ToString();
        }
        else
        {
            animName = "New State " + points.ToString();
        }
 
        anim.Play(animName);
    }

}
