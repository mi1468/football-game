using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject target;
    Vector3 lastpos, firstpos, chenge;
    public float power = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                if (hit.transform.GetComponent<Rigidbody>())
                {
                    target = hit.transform.gameObject;
                    firstpos = Input.mousePosition;
                }
            }
            //hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(2, 0, 0));
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastpos = Input.mousePosition;
            chenge = firstpos - lastpos;
            target.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(chenge.x, 0, chenge.y));
        }
    }
}
