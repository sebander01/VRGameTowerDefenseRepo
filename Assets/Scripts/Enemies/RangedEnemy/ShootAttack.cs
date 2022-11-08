using UnityEngine;

public class ShootAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private float range;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;

    private float _timeSinceLastShot;
    
    private void Awake()
    {
        _timeSinceLastShot = Time.realtimeSinceStartup;
    }

    public void AttackTarget(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        
        if (!(directionToTarget.magnitude <= range)) return;
        if (!(Time.realtimeSinceStartup >= _timeSinceLastShot + 1 / fireRate)) return;

        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = firePoint.position;
        spawnedBullet.GetComponent<Rigidbody>().AddForce(directionToTarget * bulletSpeed);
        Destroy(spawnedBullet, 2);
        _timeSinceLastShot = Time.realtimeSinceStartup;
    }
}
