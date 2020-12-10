using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Rotation worm;

    private bool rightRot;
    private bool leftRot;


    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;


    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        //transform.position = new Vector3(target.position.x + (worm.direction.x +1) * -7, target.position.y  + 5, target.position.z + (worm.direction.z +1)* -7);


        //transform.LookAt(target);



        // compute position
        //if (offsetPositionSpace == Space.Self)
        //{
        //    transform.position = target.TransformPoint(offsetPosition);
        //}
        //else
        //{
        //    transform.position = target.position + offsetPosition;
        //}

        if (rightRot)
        {
            transform.RotateAround(target.transform.position, Vector3.up, -20 * Time.deltaTime);
        }

        if (leftRot)
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }


        Vector3 aa,bb;

        bb = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);

        aa = target.transform.position - bb;



        aa = aa.normalized;

        Debug.Log(aa);

        worm.direction = aa;

        transform.position = new Vector3(target.position.x + (worm.direction.x ) * -7, target.position.y + 5, target.position.z + (worm.direction.z) * -7);

    }

    public void RotateInput(int side, bool state)
    {
        if (side < 0)
        {
            leftRot = state;
        }
        else
        {
            rightRot = state;
        }
    }
}
