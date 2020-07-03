using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.CrossPlatformInput;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{

    [SerializeField] float xSpeed = 5f;
    [SerializeField] float ySpeed = 5f;
    [Tooltip("How far the ship can move in frame, [xMin, xMax, yMin, yMax]")]
    [SerializeField] Vector4 boundaries = new Vector4(-2, 2, -2, 2);

    bool playerIsAlive = true;

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive)
        {
            ProcessMovement();
            ProcessRotation();
            ProcessWeapons();
        }
    }

    private void ProcessWeapons()
    {
        bool weaponsFiring = CrossPlatformInputManager.GetButton("Fire1");
        PlayerWeapons playerWeapons = GetComponentInChildren<PlayerWeapons>();
        if (playerWeapons)
        {
            playerWeapons.SetWeaponsActive(weaponsFiring);
        }
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y - 2.5f) * -7 - 10 * CrossPlatformInputManager.GetAxis("Vertical");
        float yaw = (transform.localPosition.x) * 7.5f;
        float roll = -15 * CrossPlatformInputManager.GetAxis("Horizontal");

        transform.localRotation = Quaternion.Euler(new Vector3(
            transform.localRotation.eulerAngles.x,
            yaw,
            transform.localRotation.eulerAngles.z
            ));

        transform.localRotation = Quaternion.Euler(new Vector3(
            pitch,
            transform.localRotation.eulerAngles.y,
            transform.localRotation.eulerAngles.z
            ));

        transform.localRotation = Quaternion.Euler(new Vector3(
            transform.localRotation.eulerAngles.x,
            transform.localRotation.eulerAngles.y,
            roll
            ));
    }

    private void ProcessMovement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        float xPosition = transform.localPosition.x;
        float yPosition = transform.localPosition.y;
        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x + horizontalInput * Time.deltaTime * xSpeed, boundaries[0], boundaries[1]),
            Mathf.Clamp(transform.localPosition.y + verticalInput * Time.deltaTime * ySpeed, boundaries[2], boundaries[3]),
            transform.localPosition.z
            );
    }

    public void KillPlayer()
    {
        playerIsAlive = false;
    }
}
