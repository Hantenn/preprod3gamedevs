using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public GameObject anima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anima.GetComponent<Animator>().Play("crouch");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anima.GetComponent<Animator>().Play("crouch3");
        }
    }
}
