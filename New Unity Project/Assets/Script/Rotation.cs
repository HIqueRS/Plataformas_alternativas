using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float vel;
    [HideInInspector] public GameObject worm;

    [HideInInspector]
    public bool isLocked;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementsInput();


       
        
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
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

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

    
}
