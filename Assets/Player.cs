using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float SpeedInMeterPerSecond = 6.0f;
    public float RotationSpeedInDegreePerSecond = 15.0f;
    private float standingCapsuleHeight = 1.8f; // Hauteur de la capsule quand le joueur est debout
    private float crouchingCapsuleHeight = 1.0f; // Hauteur de la capsule quand le joueur est accroupi
    private float currentCapsuleHeight; // Hauteur actuelle de la capsule
    public GameObject _playerVisual;
    private bool isCrouching = false; // Indique si le joueur est accroupi
    public LayerMask collisionMask; // Masque des couches pour les collisions

    void Start()
    {
        currentCapsuleHeight = standingCapsuleHeight; // Au début, le joueur est debout
    }

    void Update()
    {
        // Gestion de l'accroupissement
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching; // Inverser l'état de l'accroupissement
            currentCapsuleHeight = isCrouching ? crouchingCapsuleHeight : standingCapsuleHeight;

           // Mettre à jour la hauteur de la capsule
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            currentCapsuleHeight = standingCapsuleHeight;
        }

        // Calcul de la position de départ du rayon à partir du bord de la capsule
        Vector3 raycastOrigin = transform.position + (Vector3.up * currentCapsuleHeight);

        Vector3 lInputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 lDirection = lInputVector.normalized;

        float lDetectionDistance = SpeedInMeterPerSecond * Time.deltaTime;
        float lPlayerRadius = .5f;
        Vector3 lPoint2 = transform.position + (Vector3.up * currentCapsuleHeight);

        // Effectuer un Raycast vers l'avant pour détecter les collisions
        RaycastHit hit;
        bool lHitSomething = Physics.Raycast(raycastOrigin, lDirection, out hit, lDetectionDistance, collisionMask);

        // Si une collision est détectée, empêcher le joueur de bouger
        if (lHitSomething)
        {
            // Arrêter le mouvement du joueur
            lDirection = Vector3.zero;
        }
        else
        {
            // Si aucune collision n'est détectée, déplacer le joueur normalement
            transform.position += lDirection * lDetectionDistance;
        }

        // Ajuster la rotation du joueur
        if (lDirection.magnitude > 0)
        {
            _playerVisual.transform.forward = Vector3.Slerp(_playerVisual.transform.forward, lDirection, RotationSpeedInDegreePerSecond * Time.deltaTime);
        }
    }
}
