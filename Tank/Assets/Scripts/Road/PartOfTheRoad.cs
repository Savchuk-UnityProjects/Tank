using UnityEngine;

public class PartOfTheRoad : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    [SerializeField] private GameObject Wall;
    [SerializeField] private float MaximalDistanceFromTank;

    [SerializeField] private Transform TheFurthestPoint;
    public Transform GetTheFurthestPoint { get => TheFurthestPoint; }

    [SerializeField] private GameObject Bomb;
    public GameObject GetBomb { get => Bomb; }

    [SerializeField] private GameObject IncreasingTheQuantityOfTheProjectiles;
    public GameObject GetIncreasingTheQuantityOfTheProjectiles { get => IncreasingTheQuantityOfTheProjectiles; }


    private void Update()
    {
        if((Tank.transform.position.x - transform.position.x) >= MaximalDistanceFromTank)
        {
            Wall.transform.position = transform.GetChild(0).position;
            Destroy(gameObject);
        }
    }
}