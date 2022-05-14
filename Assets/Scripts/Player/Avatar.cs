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
    public UIManager UiMngr;
    public Transform ItemHolder;
    public GameObject HeldItem;
    [Range(0.1f, 10f)] public float CamRayLength;
    public LayerMask InteractableMask;

    /*private Ray cameraRay;
    private RaycastHit rayHit;*/

    [Header("Debugging")]
    public bool DEBUG = false;

    private void Awake()
    {
        SmokingManager.Instance.SetPlayer(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Gravity
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


        //Camera Raycast
        RaycastHit rayHit;
        Ray cameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out rayHit, CamRayLength, InteractableMask.value))
        {
            Transform objectHit = rayHit.transform;

            Interactable interactee = objectHit.gameObject.GetComponent<Interactable>();

            if (!interactee.Locked)
            {
                UiMngr.ChangeInteractionTXT(interactee.ContextMessage + " " + interactee.name);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactee.Interact(gameObject);
                }
            }
        }
        else
        {
            UiMngr.ChangeInteractionTXT(null);
        }
    }

    void PickUpItem(GameObject item)
    {
        HeldItem = item;

        HeldItem.transform.parent = ItemHolder;

        HeldItem.transform.localPosition = Vector3.zero;
        HeldItem.transform.localRotation = Quaternion.identity;
    }

    public void DropItem()
    {
        Destroy(HeldItem);
    }

    private void OnDrawGizmos()
    {
        if (DEBUG)
        {

        }
    }
}
