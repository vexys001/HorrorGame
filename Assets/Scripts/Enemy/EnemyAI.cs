using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAI : MonoBehaviour
{
    public enum AIStates { Idle, Loaded, Alert, Dead }

    [Header("AI")]
    [SerializeField] protected NavMeshAgent _navAgent;
    [SerializeField] protected AIStates _currentState;

    public AIManager AiManager;
    public GameObject Target;
    public int Health;
    protected int MaxHealth = 5;
    private bool _invincibilty = false;

    //Called when the script instance is being loaded
    protected virtual void Awake()
    {
        _currentState = AIStates.Idle;
        _navAgent = GetComponent<NavMeshAgent>();

        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        RunStates();
    }

    void RunStates()
    {
        if (_currentState == AIStates.Idle) Idle();
        else if (_currentState == AIStates.Loaded) Loaded();
        else if (_currentState == AIStates.Alert) Alert();
        else if (_currentState == AIStates.Dead) Dead();
    }
    protected abstract void Move();
    protected abstract void Attack();

    protected IEnumerator TurnOnInvicibility()
    {
        _invincibilty = true;
        yield return new WaitForSeconds(0.5f);
        TurnOffInvicibility();
    }

    protected void TurnOffInvicibility()
    {
        _invincibilty = false;
    }

    public void TakeDamage(int DamageValue)
    {
        if (!_invincibilty)
        {
            StartCoroutine("TurnOnInvicibility");

            Health -= DamageValue;

            if (Health <= 0)
            {
                StartDead();
            }
        }

    }

    public abstract void StartIdle();
    protected abstract void Idle();
    protected abstract void StartLoaded();
    protected abstract void Loaded();
    public void StartAlert()
    {
        _navAgent.enabled = true;
        _currentState = AIStates.Alert;
    }

    public void Alert()
    {
        Move();
    }

    protected abstract void StartDead();
    protected abstract void Dead();
}
