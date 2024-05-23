using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropening : MonoBehaviour
{
    public GameObject texte;
    public GameObject porte;
    public bool compte = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (texte.GetComponent<text1>().stop == true)
        {
            texte.SetActive(false);
            porte.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            texte.SetActive(true);
            compte = true;
        }
    }
}
