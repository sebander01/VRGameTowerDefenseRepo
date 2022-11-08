using UnityEngine;

public class SuicideAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private float range;
    [SerializeField] private float delay;
    
    public void AttackTarget(Transform target)
    {
        if (!((transform.position - target.position).magnitude <= range)) return;
        
        //Temporary
        Debug.Log("Boom");
        Destroy(gameObject, delay);
    }
}
