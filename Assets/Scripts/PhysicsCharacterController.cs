using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)] float maxForce = 5;
    [SerializeField][Range(1, 20)] float jumpForce = 5;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField][Range(0, 5)] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] LayerMask ceilingLayerMask;

    Rigidbody rb;
    Vector3 force = Vector3.zero;
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = yrotation * direction * maxForce;

        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        Debug.DrawRay(transform.position, Vector3.up * rayLength, Color.red);
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Jump") && CheckCeiling())
        {
            rb.AddForce(Vector3.up * jumpForce * 3.5f, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }

    private bool CheckCeiling()
    {
        return Physics.Raycast(transform.position, Vector3.up, rayLength, ceilingLayerMask);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
