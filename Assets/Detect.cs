using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public Transform Player;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool active;
    private bool following = false;
    public GameObject zone;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (zone.GetComponent<dooropening>().compte == true && first == true)
        {
            agent.destination = Player.position;
            agent.speed = 25;
            first = false;
        }
        if (following == true)
        {
            agent.destination = Player.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playerplayer");
            StartCoroutine(Follow());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playerplayer2");
            active = false;
        }
    }
    IEnumerator Follow()
    {
        following = true;
        yield return new WaitForSeconds(6);
        following = false;
    }
}
