using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : EnemyAI
{
    //Called when the script instance is being loaded
    protected override void Awake()
    {
        
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        _navAgent.SetDestination(Target.transform.position);
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
    
    public override void StartIdle()
    {
        _currentState = AIStates.Idle;

        Health = MaxHealth;

        _navAgent.enabled = false;
    }

    protected override void Idle()
    {

    }

    protected override void StartLoaded()
    {
        _currentState = AIStates.Loaded;

        _navAgent.enabled = true;
    }


    protected override void Loaded()
    {

    }

    protected override void StartDead()
    {
        _currentState = AIStates.Dead;

        AiManager.HideEnemy(gameObject);
    }

    protected override void Dead()
    {
        StartIdle();
    }
}
