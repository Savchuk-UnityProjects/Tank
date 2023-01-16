using UnityEngine;

public class TrackingAnObject : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToBeTracked;
    [SerializeField] private Vector3 Offset;

    private void LateUpdate()
    {
        transform.position = ObjectToBeTracked.transform.position + Offset;
    }
}