using UnityEngine;

public class DestroyingOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D AnyCollision)
    {
        Destroy(gameObject);
    }
}