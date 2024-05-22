using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float m_speed = 5.0f;
    private Rigidbody m_rb;
    public Vector3 directionballe;
    private bool speed = true;
    public GameObject ai;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        StartCoroutine(Gravityball());
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == true)
        {
            m_rb.AddForce(directionballe * m_speed);
        }
    }

    IEnumerator Gravityball()
    {
        yield return new WaitForSeconds(0.1f);
        m_rb.useGravity = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if collision.gameObject.tag == "Sol")
        {
            ai.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
        }
        Debug.Log("Collision");
        m_rb.velocity = Vector3.zero;
        speed = false;
    }
}
