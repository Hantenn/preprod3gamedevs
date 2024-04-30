using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifie si un bouton de la manette est appuy�
        foreach (string buttonName in Input.GetJoystickNames())
        {
            // V�rifie si le bouton est appuy�
            if (!string.IsNullOrEmpty(buttonName) && Input.GetButtonDown(buttonName))
            {
                // Affiche le nom du bouton appuy�
                Debug.Log("Bouton appuy� : " + buttonName);
            }
        }
    }
}
