using Cinemachine;
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
    public CinemachineVirtualCamera Camera1;
    public float raycast = 2.0f;
    public GameObject Light;
    private bool lumiere = false;
    public Transform CameraPoint;

    void Start()
    {
        currentCapsuleHeight = standingCapsuleHeight; // Au début, le joueur est debout
        Camera1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        Light.SetActive(false);
    }

    void Update()
    {
        // Gestion de l'accroupissement
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown(buttonName: "Rond"))
        {
            isCrouching = !isCrouching; // Inverser l'état de l'accroupissement
            currentCapsuleHeight = isCrouching ? crouchingCapsuleHeight : standingCapsuleHeight;

           // Mettre à jour la hauteur de la capsule
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetButtonUp(buttonName: "Rond"))
        {
            currentCapsuleHeight = standingCapsuleHeight;
        }
        // Calcul de la position de départ du rayon à partir du bord de la capsule
        Vector3 raycastOrigin = transform.position + (Vector3.up * currentCapsuleHeight);

        Vector3 lInputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 lInputCam = new Vector3((Input.GetAxisRaw("CamVertical"))*(-1), (Input.GetAxisRaw("CamHorizontal")), 0.0f);
        Vector3 lDirection = lInputVector.normalized;
        lDirection = lInputVector.x * Camera.main.transform.right + lInputVector.z * Camera.main.transform.forward;
        lDirection.y = 0;
        Debug.Log(lInputCam);
        float lDetectionDistance = raycast;
        float vitesse = SpeedInMeterPerSecond * Time.deltaTime;
        Vector3 lPoint2 = transform.position + (Vector3.up * currentCapsuleHeight);

        // Effectuer un Raycast vers l'avant pour détecter les collisions
        RaycastHit hit;
        bool lHitSomething = Physics.Raycast(raycastOrigin, lDirection, out hit, lDetectionDistance, collisionMask);
        bool lHitSomething2 = Physics.SphereCast(lPoint2, 0.5f, lDirection, out hit, lDetectionDistance, collisionMask);
        if (Input.GetButtonDown(buttonName: "R2"))
        {
            SpeedInMeterPerSecond = 15.0f;
            Camera1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
        }
        CameraPoint.Rotate(lInputCam);
        if (Input.GetButtonUp(buttonName: "R2"))
        {
            SpeedInMeterPerSecond = 6.0f;
            Camera1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        }
        if (Input.GetButtonDown(buttonName: "L1"))
        {
            if (lumiere == true)
            {
                Light.SetActive(false);
                lumiere = false;
            }
            else
            {
                Light.SetActive(true);
                lumiere = true;
            }
        }
        // Si une collision est détectée, empêcher le joueur de bouger
        if (lHitSomething || lHitSomething2)
        {
            // Arrêter le mouvement du joueur
            lDirection = Vector3.zero;
        }
        else
        {
            // Si aucune collision n'est détectée, déplacer le joueur normalement
            transform.position += lDirection * vitesse;
        }

        // Ajuster la rotation du joueur
        if (lDirection.magnitude > 0)
        {
            _playerVisual.transform.forward = Vector3.Slerp(_playerVisual.transform.forward, lDirection, RotationSpeedInDegreePerSecond * Time.deltaTime);
        }
    }
}
