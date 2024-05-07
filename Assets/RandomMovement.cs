using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public GameObject Capsule;
    public GameObject SousCapsule;
    public bool deactivate = false;
    public Transform centrePoint;
    public bool IsClose;//centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    public Transform Player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        IsClose = false;
    }


    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
        RaycastHit Hit;
        bool HitSomething = Physics.Raycast(transform.position,transform.position,out Hit, 10.0f);
        if (Hit.collider.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            deactivate = true;
        }
        if (IsClose == true)
        {
            agent.SetDestination(Player.position);
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}