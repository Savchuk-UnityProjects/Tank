using UnityEngine;

public class AddingOneProjectile : Repairment
{
    private new void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        TheTank.IncreaseQuantityOfProjectiles();
        base.OnTriggerEnter2D(AnyCollider);
    }
}
