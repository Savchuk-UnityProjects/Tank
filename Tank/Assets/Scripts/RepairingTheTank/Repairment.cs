using UnityEngine;

public abstract class Repairment : MonoBehaviour
{
    [SerializeField] protected GameObject TheTank;

    protected void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}