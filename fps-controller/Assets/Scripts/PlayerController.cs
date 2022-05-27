using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] 
    private float m_speed = .01f;
    [SerializeField] private float m_rotSpeed = 10;
    [SerializeField] private Transform m_camera;
    private Vector3 m_rot;

    public Transform orientation;
    Vector3 moveDirection;

    private void Awake()
    {
         Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void RotatePlayer()
    {
        m_rot.x = -Input.GetAxis("Mouse Y");
        m_rot.y = Input.GetAxis("Mouse X");
        m_rot.z = 0;

        m_camera.Rotate(m_rot, Space.Self);
        transform.Rotate(new Vector3(0, m_rot.y, 0), Space.Self);
    }

    private void MovePlayer()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.Translate(moveDirection.normalized * m_speed , Space.Self);
    }
}
