using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float m_speed = 10.0f;
    private Rigidbody m_rb;
    public Vector3 directionballe;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        m_rb.AddForce(directionballe * m_speed);
    }
}
