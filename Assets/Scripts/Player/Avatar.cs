using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    private CharacterController _cc;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    private bool _isGrounded;

    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    //public UIManager UiMngr;

    /*public GameObject ActiveRing;
    public GameObject ActiveRingPosition;
    public ObjectPool RingPool;
    private bool _armed = false;

    [SerializeField] private float _chargeTimer = 0;
    [SerializeField] private int _chargeCounter = 0;
    public int MaxchargeCounter = 2;*/

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();

        //AcquireRing(RingPool.RemoveObject());
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

        //Firing Input
        /*if (_armed)
        {
            if (Input.GetMouseButton(0))
            {
                _chargeTimer += Time.deltaTime;

                if (_chargeTimer >= 1)
                {
                    if (_chargeCounter < MaxchargeCounter)
                    {
                        _chargeTimer = 0;
                        _chargeCounter++;

                        ActiveRing.GetComponent<Ring>().IncreaseDamage();
                    }
                    else
                    {
                        Shoot();
                        _chargeTimer = 0;
                        _chargeCounter = 0;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Shoot();
                _chargeTimer = 0;
                _chargeCounter = 0;
            }
        }*/
    }

    /*void Shoot()
    {
        ActiveRing.SendMessage("StartShot");

        ActiveRing = null;
        _armed = false;

        if (RingPool.Count() > 0)
        {
            AcquireRing(RingPool.RemoveObject());
        }
        else
        {
            StartCoroutine(LookForRing());
        }
    }

    IEnumerator LookForRing()
    {
        while (ActiveRing == null)
        {
            if (RingPool.Count() > 0)
            {
                AcquireRing(RingPool.RemoveObject());
            }
            else yield return new WaitForSeconds(0.5f);
        }
    }

    void AcquireRing(GameObject PickedUpRing)
    {
        ActiveRing = PickedUpRing;
        _armed = true;

        ActiveRing.GetComponent<Ring>().StartLoaded();
        ActiveRing.transform.SetParent(ActiveRingPosition.transform);
        ActiveRing.transform.localPosition = Vector3.zero;
        ActiveRing.transform.localRotation = Quaternion.identity;

        //UiMngr.SetAmmoText(RingPool.Count().ToString());
    }*/
}
