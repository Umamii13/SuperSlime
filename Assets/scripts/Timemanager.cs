using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{

    private float time;
    private float timetric = 12;
    public GameObject Light;
    public GameObject Lightnight;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public GameObject Light6;
    public GameObject Light8;
    public GameObject Light9;
    public GameObject Light10;

    private void LateUpdate()
    {
        if (time <= timetric)
        {
            Light1.SetActive(false); 
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            Light5.SetActive(false);
            Light6.SetActive(false);
            Light8.SetActive(false);
            
            
        }
        else if (time > timetric && time <= 15)
        {
            Light1.SetActive(true);
            Light2.SetActive(true) ;
            Light3.SetActive(true);
            Light4.SetActive(true);
            Light5.SetActive(true);
            Light6.SetActive(true);
            Light8.SetActive(true);
        }
        
    }
    void Update()
    {
        time += 1 * Time.deltaTime;

        if (time <= timetric)
        {
            Lightnight.SetActive(false);
            Light.SetActive(true);
            Light9.SetActive(true);
            Light10.SetActive(true);

        }    
        else if (time > timetric && time < 15) 
        {
            Light.SetActive(false);
            Light9.SetActive(false);
            Lightnight.SetActive(true);
            Light10.SetActive(false);
        }
        else if (time > timetric && time <= 27)
        {
            Lightnight.SetActive(false);
        }
        else if (time >= 27)
        {
            resettime();
        }
        //resettime();

    }
    private void resettime()
    {
        time = 0f;
    }
}
