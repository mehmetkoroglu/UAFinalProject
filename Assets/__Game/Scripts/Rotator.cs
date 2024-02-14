using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 10f;

    private void FixedUpdate()
    {
        transform.Rotate(speed * Time.fixedDeltaTime * direction, Space.Self);
    }
}
