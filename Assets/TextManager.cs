using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject money;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPC>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (money.activeSelf == false)
        {
            GetComponent<NPC1>().enabled = true;
            GetComponent<NPC>().enabled = false;
        }
    }
}
