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
        // Tableau contenant les noms des boutons prédéfinis dans Unity
        string[] unityButtons = new string[] { "Rond", "Triangle", "Carré", "Croix", "Mouse X", "Mouse Y", "Select", "Menu","R1","L1", "R2", "L2","L3","R3","touche1","touche2","Pad","BoutonPlay"};

        // Parcours tous les noms des boutons prédéfinis
        foreach (string buttonName in unityButtons)
        {
            // Vérifie si le bouton est appuyé
            if (Input.GetButtonDown(buttonName))
            {
                // Affiche le nom du bouton appuyé
                Debug.Log("Bouton appuyé : " + buttonName);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown(buttonName: "Rond"))
        {
            anima.GetComponent<Animator>().Play("crouch");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetButtonUp(buttonName: "Rond"))
        {
            anima.GetComponent<Animator>().Play("crouch3");
        }
    }
}
