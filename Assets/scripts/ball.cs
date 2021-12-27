using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject leftgoalcanvas, rightgoalcanvas;
    Rigidbody myrigid;
    // Start is called before the first frame update
    void Start()
    {
        myrigid =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.gameObject.tag == "left goal")
        {
            myrigid.drag = 1;
            Debug.Log(" Left Goal !!! ");
            leftgoalcanvas.SetActive(true);
        }
        if (myTrigger.gameObject.tag == "right goal")
        {
            myrigid.drag = 1;
            Debug.Log(" Right Goal !!! ");
            rightgoalcanvas.SetActive(true);
        }
    }

}
