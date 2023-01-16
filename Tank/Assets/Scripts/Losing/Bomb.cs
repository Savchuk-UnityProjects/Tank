using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ExplosionVisaulization;
    [SerializeField] private float DurationOfTheExplosion;
    [SerializeField] private InchangableValues CatalogOfInchangableValues;
    [SerializeField] private EndingGameMethods EndingGame;

    private void OnCollisionEnter2D(Collision2D AnyCollision)
    {
        Explode(AnyCollision);
    }

    private void Explode(Collision2D Collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
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
}