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
        // Tableau contenant les noms des boutons pr�d�finis dans Unity
        string[] unityButtons = new string[] { "Rond", "Triangle", "Carr�", "Croix", "Mouse X", "Mouse Y", "Select", "Menu","R1","L1", "R2", "L2","L3","R3","touche1","touche2","Pad","BoutonPlay"};

        // Parcours tous les noms des boutons pr�d�finis
        foreach (string buttonName in unityButtons)
        {
            // V�rifie si le bouton est appuy�
            if (Input.GetButtonDown(buttonName))
            {
                // Affiche le nom du bouton appuy�
                Debug.Log("Bouton appuy� : " + buttonName);
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
