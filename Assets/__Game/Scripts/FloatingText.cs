using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Transform _unit;
    private Transform _mainCam;

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform worldSpaceCanvas;

    private void Start()
    {
        _unit = transform.parent;
        _mainCam = Camera.main.transform;
        transform.SetParent(worldSpaceCanvas);
    }

    private void Update()
    {
        if (_unit)
        {
            Vector3 _position = _unit.position - offset;
            Vector3 _rotation = transform.position - _mainCam.transform.position;

            Quaternion lookRotation = Quaternion.LookRotation(_rotation);
            transform.SetPositionAndRotation(_position, lookRotation);
        }
    }
}
