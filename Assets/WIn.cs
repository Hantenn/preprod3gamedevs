using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Win.SetActive(true);
            StartCoroutine(Winning());
        }
    }
    // Update is called once per frame
    public IEnumerator Winning()
    {
        yield return new WaitForSeconds(10);
        Application.Quit();
    }
}
