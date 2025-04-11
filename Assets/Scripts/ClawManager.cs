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
