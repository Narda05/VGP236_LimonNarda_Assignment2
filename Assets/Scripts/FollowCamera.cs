using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float smoothSpeed = 10.0f;
   
    void Start()
    {
       
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }

   
    void Update()
    {

        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
