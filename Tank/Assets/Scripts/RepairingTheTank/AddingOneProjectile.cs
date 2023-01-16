using UnityEngine;

public class AddingOneProjectile : Repairment
{
    private new void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        base.OnTriggerEnter2D(AnyCollider);
        TheTank.GetComponent<Tank>().IncreaseTheQuantityOfTheProjectiles();
    }
}