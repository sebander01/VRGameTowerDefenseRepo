using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform player;
    private Transform _player;

    private IMoveable _movementLogic;
    private IDamageable _healthLogic;
    private IAttackable _attackLogic;

    private void Awake()
    {
        //Move this init call to some kind of wave manager
        Init(player);
        
        _movementLogic = GetComponent<IMoveable>();
        _healthLogic = GetComponent<IDamageable>();
        _attackLogic = GetComponent<IAttackable>();
    }

    //Call to give the script a reference to the player, probs from the wave manager when you spawn it 
    void Init(Transform player)
    {
        _player = player;
    }

    void Update()
    {
        if (_healthLogic.IsAlive())
        {
            Vector3 directionToTarget = (player.position - transform.position).normalized;
            if (!Physics.Raycast(transform.position, directionToTarget, out RaycastHit result)) return;
            if (result.collider.transform != player) return;
            
            _movementLogic.MoveTowardsTarget(_player, animator);
            _attackLogic.AttackTarget(player);
        }
        else
        {
            _healthLogic.Die();
        }
    }
}
