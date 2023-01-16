using UnityEngine;

public abstract class Repairment : MonoBehaviour
{
    [SerializeField] protected Tank TheTank;

    protected void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        Destroy(gameObject);
    }
}