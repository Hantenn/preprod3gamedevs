using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public GameObject Capsule;
    public GameObject SousCapsule;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Capsule.GetComponent<RandomMovement>().deactivate == true)
        {
            Debug.Log("Test");
            Capsule.GetComponent<ia>().enabled = true;
            SousCapsule.GetComponent<Detect>().enabled = true;
            Capsule.GetComponent<RandomMovement>().enabled = false;
            SousCapsule.GetComponent<Detect>().active = true;

        }
        if (SousCapsule.GetComponent<Detect>().active == false)
        {
            Debug.Log("Test2");
            Capsule.GetComponent<ia>().enabled = false;
            SousCapsule.GetComponent<Detect>().enabled = false;
            Capsule.GetComponent<RandomMovement>().enabled = true;
            Capsule.GetComponent<RandomMovement>().deactivate = false;
        }
    }
}
