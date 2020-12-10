using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float vel;

    private bool onFruit;
    private GameObject fruit;
    private Rotation fruitRotation;

    public ArduinoInput arduino;

   
    private int sidel;
    private int sider;
    
    void Update()
    {
        //MovementsInput();

        direction.x = sidel + sider;

        transform.LookAt(transform.position + direction * Time.deltaTime * vel );

        transform.position += direction * Time.deltaTime * vel;

        //if (velPT > 0f)
        //{
            
        //    transform.position += direction * Time.deltaTime * vel * velPT;
        //}

       

    }

    private void MovementsInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z =  Input.GetAxis("Vertical");

        if(onFruit)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(!fruitRotation.end)
                {

                    transform.parent = fruit.transform;
                    fruitRotation.isLocked = false;
                    fruitRotation.worm = this.gameObject;

                    arduino.onFruit = true;
                    arduino.fruit = fruitRotation;
                    fruitRotation.arduino = arduino;



                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    

    public void ActionInput()
    {
        Debug.Log("a");
        if (onFruit)
        {
            if (!fruitRotation.end)
            {
                
                arduino.onFruit = true;
                arduino.fruit = fruitRotation;
                fruitRotation.arduino = arduino;

                transform.parent = fruit.transform;
                fruitRotation.isLocked = false;
                fruitRotation.worm = this.gameObject;


                

                this.gameObject.SetActive(false);
            }
        }
    }

   

    public void FowardAndBack(float backForw)
    {
        if(backForw > 0.6)
        {
            direction.z = 1;
        }
        else if (backForw < 0.4)
        {
            direction.z = -1;
        }
        else
        {
            direction.z = 0;
        }
    }

    public void Left(bool state)
    {
        if(state)
        {
           
                sidel = -1;
          
        }
        else
        {
            sidel = 0;
        }
    }

    public void Right(bool state)
    {
        if (state)
        {
            sider = 1;
        }
        else
        {
            sider = 0;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            fruit = other.gameObject;
            fruitRotation = fruit.GetComponent<Rotation>();
            onFruit = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            onFruit = false;
            fruit = null;
        }
    }
}
