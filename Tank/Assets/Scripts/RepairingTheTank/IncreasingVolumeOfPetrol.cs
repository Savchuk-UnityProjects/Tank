using UnityEngine;

public class IncreasingVolumeOfPetrol : Repairment
{
    [SerializeField] private float DeltaVolume;

    private new void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        base.OnTriggerEnter2D(AnyCollider);
        TheTank.IncreaseVolumeOfThePetrol(DeltaVolume);
    }
}