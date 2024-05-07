using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClose : MonoBehaviour
{
    public GameObject Capsule;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Capsule.GetComponent<RandomMovement>().IsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Capsule.GetComponent<RandomMovement>().IsClose = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
