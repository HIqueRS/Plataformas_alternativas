using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class ArduinoInput : MonoBehaviour
{
    
    private SerialPort port ;


    private string aux;
    public WormMovement worm;
    public Rotation fruit;

    public bool onFruit;

    private float auxInt;

    private string[] stringArray;
    
    // Start is called before the first frame update
    void Start()
    {
        port = new SerialPort("COM5", 9700);
        port.Open();
        port.ReadTimeout = 100;

        onFruit = false;
    }
    
   
    

    // Update is called once per frame
    void Update()
    {
        if (port.IsOpen)
        {
            try
            {
               
                //port.Write("p");
                //speed
                aux = port.ReadLine();



                // auxInt = int.Parse(aux);

                stringArray = aux.Split(' ');

                Debug.Log("a");

                if (stringArray[0] == "p")
                {
                    // Debug.Log(stringArray[1]);
                    auxInt = int.Parse(stringArray[1]);
                    
                   
                    auxInt = auxInt / 1024f;

                    if(!onFruit)
                    {
                        worm.FowardAndBack(auxInt);

                    }
                    else
                    {
                        fruit.FowardAndBack(auxInt);
                    }
                        
                   
                    
                    
                }
                else if (stringArray[0] == "l")
                {
                    if (stringArray[1] == "3")
                    {
                        //left true
                        if (!onFruit)
                        {
                            worm.Left(true);
                        }
                        else
                        {
                            fruit.Left(true);
                        }

                    }
                    else if (stringArray[1] == "6")
                    {
                        //left false
                        if (!onFruit)
                        {
                            worm.Left(false);
                        }
                        else
                        {
                            fruit.Left(false);
                        }
                    }
                }
                else if (stringArray[0] == "a")
                {
                    if (stringArray[1] == "5")
                    {
                       
                        //action true
                        if (!onFruit)
                        {
                            worm.ActionInput();
                        }
                        else
                        {
                            Debug.Log("hmm");
                            fruit.ActionButton();
                        }
                    }
                }
                else if (stringArray[0] == "r")
                {
                    if (stringArray[1] == "7")
                    {
                        //right true
                        if (!onFruit)
                        {
                            worm.Right(true);
                        }
                        else
                        {
                            fruit.Right(true);
                        }
                    }
                    else if (stringArray[1] == "14")
                    {
                        //right false
                        if (!onFruit)
                        {
                            worm.Right(false);
                        }
                        else
                        {
                            fruit.Right(false);
                        }
                    }
                }


                //worm.MoveFoward(int.Parse(aux));


            }
            catch (System.Exception e)
            {

                Debug.LogException(e);
            }
        }
    }
}
