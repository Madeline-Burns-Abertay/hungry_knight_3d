using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offsetPosition;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = playerTransform.position + offsetPosition;
        
    }
}
