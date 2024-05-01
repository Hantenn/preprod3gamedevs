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
            currentCapsuleHeight = isCrouching ? crouchingCapsuleHeight : standingCapsuleHeight; // Mettre à jour la hauteur de la capsule
        }

        Vector3 lInputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        Vector3 lDirection = lInputVector.normalized;

        float lDetectionDistance = SpeedInMeterPerSecond * Time.deltaTime;
        float lPlayerRadius = .5f;
        Vector3 lPoint2 = transform.position + (Vector3.up * currentCapsuleHeight);
        bool lHitSomething = Physics.CapsuleCast(transform.position, lPoint2, lPlayerRadius, lDirection, out RaycastHit raycastHit, lDetectionDistance);

        bool lCanMove = (lHitSomething == false) || (raycastHit.collider.isTrigger == true);
        if (lCanMove == false)
        {
            Vector3 moveDirX = new Vector3(lDirection.x, 0, 0).normalized;
            lHitSomething = Physics.CapsuleCast(transform.position, lPoint2, lPlayerRadius, moveDirX, out RaycastHit raycastHitX, lDetectionDistance);

            if (lHitSomething == false)
            {
                lDirection = moveDirX;
                lCanMove = true;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, lDirection.z).normalized;
                lHitSomething = Physics.CapsuleCast(transform.position, lPoint2, lPlayerRadius, moveDirZ, out RaycastHit raycastHitZ, lDetectionDistance);
                if (lHitSomething == false)
                {
                    lDirection = moveDirZ;
                    lCanMove = true;
                }
                else
                {
                    lDirection = Vector3.zero;
                    lCanMove = false;
                }
            }
        }

        if (lCanMove == true)
        {
            transform.position = transform.position + (lDirection * lDetectionDistance);
        }

        if (lDirection.magnitude > 0)
        {
            _playerVisual.transform.forward = Vector3.Slerp(_playerVisual.transform.forward, lDirection, RotationSpeedInDegreePerSecond * Time.deltaTime);
        }
    }
}
