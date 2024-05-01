using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float SpeedInMeterPerSecond = 6.0f;
    public float RotationSpeedInDegreePerSecond = 15.0f;
    public GameObject _playerVisual;
    private bool lCanMove = true;
    void Start()
    {

    }

    void Update()
    {

        // Récupérer les entrées de mouvement
        Vector3 lInputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 lDirection = lInputVector.normalized;

        // Calculer la distance de détection en fonction de la vitesse
        float lDetectionDistance = SpeedInMeterPerSecond * Time.deltaTime;


        // Si le joueur peut bouger, mettre à jour sa position
        if (lCanMove)
        {
            transform.position += lDirection * lDetectionDistance;
        }

        // Si le joueur est en mouvement, ajuster sa rotation
        if (lDirection.magnitude > 0)
        {
            _playerVisual.transform.forward = Vector3.Slerp(_playerVisual.transform.forward, lDirection, RotationSpeedInDegreePerSecond * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.tag == "Obstacle")
        {
            lCanMove = false;
        }
    }
}
