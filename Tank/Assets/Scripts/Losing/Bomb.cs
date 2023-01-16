using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ExplosionVisaulization;
    [SerializeField] private float DurationOfTheExplosion;
    [SerializeField] private InchangableValues CatalogOfInchangableValues;
    [SerializeField] private EndingGameMethods EndingGame;

    private SpriteRenderer SpriteRendererOfThisBomb;
    private Collider2D ColliderOfThisBomb;

    private void Start()
    {
        SpriteRendererOfThisBomb = GetComponent<SpriteRenderer>();
        ColliderOfThisBomb = GetComponent<Collider2D>();
    }


    private void Explode(Collision2D Collision)
    {
        SpriteRendererOfThisBomb.enabled = false;
        ColliderOfThisBomb.enabled = false;
        ExplosionVisaulization.enabled = true;

        int LayerOfCollidedObject = Collision.gameObject.layer;
        if (LayerOfCollidedObject == CatalogOfInchangableValues.LayerOnlyWithTank)
        {
            EndingGame.SendThatTheTankWasExploded();
            EndingGame.EndGame();
        }
        else
        {
            StartCoroutine(ExplodeWithoutTheTank());
        }
    }

    private IEnumerator ExplodeWithoutTheTank()
    {
        yield return new WaitForSeconds(DurationOfTheExplosion);
        ExplosionVisaulization.enabled = false;
        StopCoroutine(ExplodeWithoutTheTank());
    }

    private void OnCollisionEnter2D(Collision2D AnyCollision)
    {
        Explode(AnyCollision);
    }
}