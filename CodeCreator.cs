using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CodeCreator : MonoBehaviour
{
    //This scripts creates a 4 colour code based on a repetition mode (no repeats, max 2 repeats, repeats or random repeeats) chosen by the user
    
    
    public static string[] Code;

    public static int numberOfColours = 8;
    public static int codeLength = 4;
    public static int repeatsMode = 0;


    void Start()
    {

        Code = new string[9]; //code's maximum length is 8


        switch (repeatsMode)
        {
            case 0: //no repeats mode - generating code where no colour repeats
        
                System.Random rand = new System.Random();

                for (int i = 1; i<=4; i++)
                {
                    Code[i] = RandomColour(rand);
                    for (int j = i-1; j>0; j--)
                    {
                        if (Code[i] == Code[j])
                        {
                            i--;
                            break;
                        }
                    }
                }
                
                break;

            case 1://max 2 repeats mode - A colour can only repeat 2 times

                int noRepeatChance = 40; // setting the chance of no repeats at 40%
                int oneRepeatChance = 35; // setting the chance of exactly one colour repeating once at 35%
                // the chance of two colours repeating once is 25% = 100% - 40% - 35%
 
                System.Random chanceRand = new System.Random();
                int chance = chanceRand.Next(1,101); // generating random number between 1 and 100

                
                if(chance <= noRepeatChance) //No colour repeats
                {
                    rand = new System.Random();

                    for (int i = 1; i <= 4; i++)
                    {
                        Code[i] = RandomColour(rand);
                        for (int j = i - 1; j > 0; j--)
                        {
                            if (Code[i] == Code[j])
                            {
                                i--;
                                break;
                            }
                        }
                    }
                } else if(chance <= noRepeatChance+oneRepeatChance) //Exactly one colour repeats
                {
                    
                    System.Random placeRand;
                    placeRand = new System.Random();
                    rand = new System.Random();

                    int place = placeRand.Next(1, 5);
                    Code[place] = RandomColour(rand);
                    int place2 = placeRand.Next(1, 5);
                    while (place2 == place)
                    {
                        place2 = placeRand.Next(1, 5);
                    }
                    Code[place2] = Code[place];


                    string newColour = RandomColour(rand);
                    string newColour2 = RandomColour(rand);
                    while (newColour == Code[place]) newColour = RandomColour(rand);
                    while (newColour2 == Code[place] || newColour2 == newColour) newColour2 = RandomColour(rand);
                    bool newColourAssigned = false;
                    for(int i = 1; i<=4; i++)
                    {
                        if (Code[i] == null && newColourAssigned == false)
                        {
                            Code[i] = newColour;
                            newColourAssigned = true;
                        }
                        if (Code[i] == null && newColourAssigned == true) Code[i] = newColour2;
                    }
                }
                else //Two colours repeat once
                {
                    System.Random placeRand;
                    placeRand = new System.Random();
                    rand = new System.Random();

                    int place = placeRand.Next(1, 5);
                    Code[place] = RandomColour(rand);
                    int place2 = placeRand.Next(1, 5);
                    while (place2 == place)
                    {
                        place2 = placeRand.Next(1, 5);
                    }
                    Code[place2] = Code[place];


                    string newColour = RandomColour(rand);
                    while (newColour == Code[place]) newColour = RandomColour(rand);
                    for (int i = 1; i <= 4; i++)
                    {
                        if (Code[i] == null) Code[i] = newColour;
                    }
                }
               
                break;

            case 2://Colours repeat every possible way (not randomly)
                
                noRepeatChance = 20;
                int oneRepeatChance2 = 20;
                int twoRepeatChance2 = 20;
                int oneRepeatChance3 = 20;

                chanceRand = new System.Random();
                chance = chanceRand.Next(1, 101);


                if (chance <= noRepeatChance) //No colour repeats
                {
                    rand = new System.Random();

                    for (int i = 1; i <= 4; i++)
                    {
                        Code[i] = RandomColour(rand);
                        for (int j = i - 1; j > 0; j--)
                        {
                            if (Code[i] == Code[j])
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
                else if (chance <= noRepeatChance + oneRepeatChance2) //Exactly one color occurs two times
                {

                    System.Random placeRand;
                    placeRand = new System.Random();
                    rand = new System.Random();

                    int place = placeRand.Next(1, 5);
                    Code[place] = RandomColour(rand);
                    int place2 = placeRand.Next(1, 5);
                    while (place2 == place)
                    {
                        place2 = placeRand.Next(1, 5);
                    }
                    Code[place2] = Code[place];


                    string newColour = RandomColour(rand);
                    string newColour2 = RandomColour(rand);
                    while (newColour == Code[place]) newColour = RandomColour(rand);
                    while (newColour2 == Code[place] || newColour2 == newColour) newColour2 = RandomColour(rand);
                    bool newColourAssigned = false;
                    for (int i = 1; i <= 4; i++)
                    {
                        if (Code[i] == null && newColourAssigned == false)
                        {
                            Code[i] = newColour;
                            newColourAssigned = true;
                        }
                        if (Code[i] == null && newColourAssigned == true) Code[i] = newColour2;
                    }
                }
                else if(chance <= noRepeatChance+oneRepeatChance2+twoRepeatChance2)//Two colours occur two times
                {
                    System.Random placeRand;
                    placeRand = new System.Random();
                    rand = new System.Random();

                    int place = placeRand.Next(1, 5);
                    Code[place] = RandomColour(rand);
                    int place2 = placeRand.Next(1, 5);
                    while (place2 == place)
                    {
                        place2 = placeRand.Next(1, 5);
                    }
                    Code[place2] = Code[place];


                    string newColour = RandomColour(rand);
                    while (newColour == Code[place]) newColour = RandomColour(rand);
                    for (int i = 1; i <= 4; i++)
                    {
                        if (Code[i] == null) Code[i] = newColour;
                    }
                }
                else if(chance <= noRepeatChance + oneRepeatChance2 + twoRepeatChance2 + oneRepeatChance3)//One colour occurs three times
                {
                    System.Random placeRand;
                    placeRand = new System.Random();
                    rand = new System.Random();

                    int place = placeRand.Next(1, 5);
                    Code[place] = RandomColour(rand);


                    string newColour = RandomColour(rand);
                    while (newColour == Code[place]) newColour = RandomColour(rand);
                    for (int i = 1; i <= 4; i++)
                    {
                        if (Code[i] == null) Code[i] = newColour;
                    }
                }
                else //One colour occurs four times
                {
                    rand = new System.Random();
                    string theColour = RandomColour(rand);
                    for(int i = 1; i<=4; i++)
                    {
                        Code[i] = theColour;
                    }
                }
                
                break;

            case 3://Colours repeat every possible way, randomly
                rand = new System.Random();
                for(int i = 1; i<= codeLength; i++)
                {
                    Code[i] = RandomColour(rand);
                }
                break;
            default:
                UnityEngine.Debug.Log("Repeats Mode has not been properly chosen.");
                break;
        }
        //UnityEngine.Debug.Log(Code[1]+Code[2]+Code[3]+Code[4]);
    }
        
        
    

    string RandomColour(System.Random r) // converting a random number between 1 and 8 to a name of one of eight colours
    {
        int randomNumber = r.Next(1,numberOfColours+1);
        switch (randomNumber)
        {
            case 1:
                //randomColourNumber = 1;
                return "white";
                
            case 2:
                //randomColourNumber = 2;
                return "black";
                
            case 3:
                //randomColourNumber = 3;
                return "pink";
                
            case 4:
                //randomColourNumber = 4;
                return "red";
                
            case 5:
                //randomColourNumber = 5;
                return "orange";
                
            case 6:
                //randomColourNumber = 6;
                return "yellow";
                
            case 7:
                //randomColourNumber = 7;
                return "green";
                
            case 8:
                //randomColourNumber = 8;
                return "blue";
            default:
                return "whatever";
        }
    }

    
}
