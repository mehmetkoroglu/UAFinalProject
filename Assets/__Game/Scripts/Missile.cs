using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    public GameObject explosionEffect;

    [HideInInspector] public Vector3 target;
    [SerializeField] private float speed = 500f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.position = Vector3.MoveTowards(_rb.position, target, speed * Time.deltaTime);
        _rb.transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damageable"))
        {
            Destroy(other.gameObject);

            GameObject explosionEffectClone = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosionEffectClone, 2f);
            Destroy(gameObject, 1f);
        }
    }
}
