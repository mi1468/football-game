using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject target, arrow;
    public Vector3 firstarrowsize, lastpos, firstpos, chenge;
    public float power = 1;
    public float maxdistance = 130;
    public bool havetarget = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(havetarget)
        {
            Vector2 mouse = Input.mousePosition;
            Vector3 chenge = new Vector3(firstpos.x - mouse.x, 0, firstpos.y - mouse.y);
            if(chenge.magnitude > maxdistance)
            {
                chenge = chenge.normalized * maxdistance;
            }
            arrow.transform.localScale = firstarrowsize +  chenge.magnitude / 400 * new Vector3(1, 4, 1);
            arrow.transform.LookAt(chenge);
            arrow.SetActive(true);
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform != null)
            {
                if (hit.transform.GetComponent<Rigidbody>())
                {
                    target = hit.transform.gameObject;
                    arrow = target.transform.GetChild(0).gameObject;
                    havetarget = true;
                    
                    firstpos = Input.mousePosition;
                }
            }
            //hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(2, 0, 0));
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastpos = Input.mousePosition;
            chenge = firstpos - lastpos;
            if (chenge.magnitude > maxdistance)
            {
                chenge = chenge.normalized * maxdistance;
            }
            chenge = power * chenge;
            havetarget = false;
            arrow.SetActive(false);

            target.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(chenge.x, 0, chenge.y));
        }
    }
}
