using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ia : MonoBehaviour
{
    public Transform Player;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject Capsule;
    public bool Here = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Player.position;
    }
}
