using UnityEngine;

public class TestHealth : MonoBehaviour, IDamageable
{
    public bool isAlive;
    
    public bool IsAlive()
    {
        return isAlive;
    }

    public void Die()
    {
        Destroy(gameObject, 2);
    }
}
