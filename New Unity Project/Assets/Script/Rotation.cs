using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotation : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float vel;
    [HideInInspector] public GameObject worm;
    public int fruit; //0 maça 1 pessego 2 morango 3 melancia

    [HideInInspector]
    public bool isLocked;

    public bool end;

    public Validation val;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLocked = true;
        end = false;
        val.deliveredFruits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!end)
        {

            MovementsInput();
        }


       
        
    }

    private void FixedUpdate()
    {
        if(!isLocked)
        {
            rb.AddTorque(direction* vel);
        }
    }

    private void MovementsInput()
    {
        direction.z = -1 * Input.GetAxis("Horizontal");
        direction.x = Input.GetAxis("Vertical");

        if (!isLocked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isLocked = true;

                worm.SetActive(true);
                worm.transform.SetParent(null);

                
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //make monkey and test the fruit

        if(other.gameObject.CompareTag("Monkey"))
        {
            if( other.gameObject.GetComponent<MonkeyScript>().fruit == fruit)
            {
                isLocked = true;

                worm.SetActive(true);
                worm.transform.SetParent(null);

                end = true;

                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                val.deliveredFruits++;

                if(val.deliveredFruits >= 4)
                {
                    EndGame();
                }

                Destroy(this.gameObject);
            }
        }

    }

    private void EndGame()
    {
        SceneManager.LoadScene("End");
    }


}
