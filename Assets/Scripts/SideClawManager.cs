using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SideClawManager : MonoBehaviour
{
    [SerializeField] XRJoystick _joystick;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody _rigidbody;

    Vector3 _input;

    private void OnEnable()
    {
        _joystick.onValueChangeX.AddListener(UpdateX);
        _joystick.onValueChangeY.AddListener(UpdateZ);
    }

    private void OnDisable()
    {
        _joystick.onValueChangeX.RemoveListener(UpdateX);
        _joystick.onValueChangeY.RemoveListener(UpdateZ);
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _input.normalized * _moveSpeed * Time.fixedDeltaTime);
        if (transform.position.x < 3)
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 6.5)
        {
            transform.position = new Vector3(6.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
        }
        if (transform.position.z > 1.3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.3f);
        }
    }

    protected void UpdateX(float p_xMovement)
    {
        _input.x = p_xMovement;
    }

    protected void UpdateZ(float p_zMovement)
    {
        _input.z = p_zMovement;
    }
}
