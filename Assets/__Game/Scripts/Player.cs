using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSensivity = 10f;

    private Rigidbody _rb;
    private Animator _animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        SetAnimations();
    }

    private void SetAnimations()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            _animator.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("isRunning", true);
                moveSpeed = 10f;
            }
            else
            {
                _animator.SetBool("isRunning", false);
                moveSpeed = 5f;
            }
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;
        direction = moveSpeed * Time.deltaTime * direction;
        _rb.MovePosition(transform.position + transform.TransformDirection(direction));

        Vector3 rotation = new(0f, Input.mousePosition.x, 0f);
        transform.DORotate(rotation, turnSensivity);
    }
}
