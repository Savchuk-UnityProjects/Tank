using UnityEngine;

public class IncreasingVolumeOfPetrol : Repairment
{
    [SerializeField] private float DeltaVolume;

    private new void OnTriggerEnter2D(Collider2D AnyCollider)
    {
        TheTank.IncreaseVolumeOfThePetrol(DeltaVolume);
        base.OnTriggerEnter2D(AnyCollider);
    }
}
