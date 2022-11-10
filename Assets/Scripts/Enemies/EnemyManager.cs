using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform _player;

    private IMoveable _movementLogic;
    private IDamageable _healthLogic;
    private IAttackable _attackLogic;


    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        
        _movementLogic = GetComponent<IMoveable>();
        _healthLogic = GetComponent<IDamageable>();
        _attackLogic = GetComponent<IAttackable>();
    }

    void Update()
    {
        if (_healthLogic.IsAlive())
        {
            Vector3 directionToTarget = (_player.position - transform.position).normalized;
            if (!Physics.Raycast(transform.position, directionToTarget, out RaycastHit result)) return;
            if (result.collider.transform != _player) return;
            
            _movementLogic.MoveTowardsTarget(_player, animator);
            _attackLogic.AttackTarget(_player);
        }
        else
        {
            _healthLogic.Die();
        }
    }
}
