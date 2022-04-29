using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    [Header("Components")]
    private CharacterController _cc;
    public Camera MainCamera;


    [Header("Ground vars")]
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    private bool _isGrounded;

    [Header("Speed vars")]
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    [Header("Scene Interaction")]
    //public UIManager UiMngr;
    [Range(0.1f, 10f)] public float CamRayLength;
    public LayerMask InteractableMask;

    /*private Ray cameraRay;
    private RaycastHit rayHit;*/

    [Header("Debugging")]
    public bool DEBUG = false;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (_isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _cc.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        _cc.Move(velocity * Time.deltaTime);

        RaycastHit rayHit;
        Ray cameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out rayHit, CamRayLength, InteractableMask.value))
        {
            Transform objectHit = rayHit.transform;

            Debug.Log("Printing hit name: " + objectHit.name);
            // Do something with the object that was hit by the raycast.
        }
    }

    private void OnDrawGizmos()
    {
        if (DEBUG)
        {

        }
    }
}
