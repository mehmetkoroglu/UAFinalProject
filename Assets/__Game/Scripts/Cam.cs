using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public static Cam Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform ucav;

    private Transform _target;

    private void Start()
    {
        _target = player;
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, _target.position, speed * Time.deltaTime);
        float angle = Mathf.Clamp(-Input.mousePosition.y, 25, 90);
        transform.rotation = Quaternion.Euler(angle, _target.eulerAngles.y, _target.eulerAngles.z);
    }

    public void SetTargetPlayer() => _target = player;
    public void SetTargetUCAV() => _target = ucav;
}
