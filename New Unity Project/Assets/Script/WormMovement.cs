using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float vel;

    private bool onFruit;
    private GameObject fruit;
    private Rotation fruitRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementsInput();


        transform.LookAt(transform.position + direction * Time.deltaTime * vel);
        transform.position += direction * Time.deltaTime * vel;

    }

    private void MovementsInput()
    {
        direction.z = Input.GetAxis("Horizontal");
        direction.x = -1 * Input.GetAxis("Vertical");

        if(onFruit)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.parent = fruit.transform;
                fruitRotation.isLocked = false;
                fruitRotation.worm = this.gameObject;

                this.gameObject.SetActive(false);
            }
           
           
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
