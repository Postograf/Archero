using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 300f;
    private Rigidbody _rigidbody;
    private bool _isMoving = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!_isMoving) { }
    }

    public void Move(Vector2 direction)
    {
        var moveDirection = direction.normalized.ToVector3XZ() * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.velocity = moveDirection + new Vector3(0, _rigidbody.velocity.y, 0);
        _isMoving = true;
    }

    public void Stop()
    {
        _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        _isMoving = false;
    }
}
