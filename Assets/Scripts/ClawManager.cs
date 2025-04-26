using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ClawManager : MonoBehaviour
{
    [SerializeField] XRJoystick _joystick;
    [SerializeField] XRSlider _slider;
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Animator _anim;
    [SerializeField] ClawGrab _grab;

    Vector3 _input;
    bool _isGrabing;

    private void OnEnable()
    {
        _joystick.onValueChangeX.AddListener(UpdateX);
        _joystick.onValueChangeY.AddListener(UpdateZ);
        _slider.onValueChange.AddListener(UpdateY);
    }

    private void OnDisable()
    {
        _joystick.onValueChangeX.RemoveListener(UpdateX);
        _joystick.onValueChangeY.RemoveListener(UpdateZ);
        _slider.onValueChange.RemoveListener(UpdateY);
    }
    
    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _input.normalized * _moveSpeed * Time.fixedDeltaTime);
        if (transform.position.y < -1.503)
        {
            transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        }
        if (transform.position.y > 4.23)
        {
            transform.position = new Vector3(transform.position.x, 4.20f, transform.position.z);
        }
        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > -6.4)
        {
            transform.position = new Vector3(-6.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -4.24)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4.2f);
        }
        if (transform.position.z > 4.4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4.3f);
        }
    }

    public void ChangeClawState()
    {
        if (!_isGrabing)
        {
            _anim.SetTrigger("Grab");
            _grab.gameObject.SetActive(true);
        }
        else
        {
            _anim.SetTrigger("Release");
            _grab.Release();
        }
        _isGrabing = !_isGrabing;
    }

    protected void UpdateX(float p_xMovement)
    {
        _input.x = p_xMovement;
    }

    protected void UpdateY(float p_yMovement)
    {
        if (Mathf.Abs(p_yMovement) == 1)
        {
            _input.y = p_yMovement;
        }
        else
        {
            _input.y = 0;
        }
    }

    protected void UpdateZ(float p_zMovement)
    {
        _input.z = p_zMovement;
    }
}
