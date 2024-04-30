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
        // Vérifie si un bouton de la manette est appuyé
        foreach (string buttonName in Input.GetJoystickNames())
        {
            // Vérifie si le bouton est appuyé
            if (!string.IsNullOrEmpty(buttonName) && Input.GetButtonDown(buttonName))
            {
                // Affiche le nom du bouton appuyé
                Debug.Log("Bouton appuyé : " + buttonName);
            }
        }
    }
}
