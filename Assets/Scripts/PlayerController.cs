using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 50f;

    private void OnEnable()
    {
        _inputReader.Fire += Fire;
    }

    private void OnDisable()
    {
        _inputReader.Fire -= Fire;
    }

    private void Fire(bool phase)
    {
        if (phase)
        {
            Debug.Log("Tapped");
        }
        else
        {
            Debug.Log("Released");
        }
    }

    private void Start()
    {
        _inputReader.EnablePlayerInputActions();
    }

    private void Update()
    {
        var movementDir = new Vector3(_inputReader.Direction.x, 0f, _inputReader.Direction.y).normalized;
        transform.position += movementDir * _moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Lerp(transform.forward, movementDir, _rotationSpeed * Time.deltaTime);
    }



    // [SerializeField] private Vector2 _joystickSize = new Vector2(200, 200);
    // [SerializeField] private FloatingJoystick _joystick;

    // private Finger _movementFinger;
    // private Vector2 _movementAmount;

    // private void OnEnable()
    // {
    //     EnhancedTouchSupport.Enable();
    //     ETouch.Touch.onFingerDown += Touch_onFingerDown;
    //     ETouch.Touch.onFingerUp += Touch_onFingerUp;
    //     ETouch.Touch.onFingerMove += Touch_onFingerMove;
    // }

    // private void OnDisable()
    // {
    //     ETouch.Touch.onFingerDown -= Touch_onFingerDown;
    //     ETouch.Touch.onFingerUp -= Touch_onFingerUp;
    //     ETouch.Touch.onFingerMove -= Touch_onFingerMove;
    //     EnhancedTouchSupport.Disable();
    // }

    // private void Touch_onFingerDown(Finger finger)
    // {
    //     if (_movementFinger == null)
    //     {
    //         _movementFinger = finger;
    //         _movementAmount = Vector2.zero;
    //         _joystick.gameObject.SetActive(true);
    //         _joystick.RectTransform.sizeDelta = _joystickSize;
    //         _joystick.RectTransform.anchoredPosition = ClampStartPosition(finger.screenPosition);
    //     }
    // }

    // private void Touch_onFingerUp(Finger finger)
    // {
    //     if (_movementFinger == finger)
    //     {
    //         _movementFinger = null;
    //         _joystick.Knob.anchoredPosition = Vector2.zero;
    //         _joystick.gameObject.SetActive(false);
    //         _movementAmount = Vector2.zero;
    //     }
    // }

    // private void Touch_onFingerMove(Finger finger)
    // {
    //     if (_movementFinger == finger)
    //     {
    //         Vector2 knobPosition;
    //         var maxMovement = _joystickSize.x / 2f;
    //         ETouch.Touch currentTouch = finger.currentTouch;

    //         if (Vector2.Distance(currentTouch.screenPosition, _joystick.RectTransform.anchoredPosition) > maxMovement)
    //         {
    //             knobPosition = (currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition).normalized * maxMovement;
    //         }
    //         else
    //         {
    //             knobPosition = currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition;
    //         }

    //         _joystick.Knob.anchoredPosition = knobPosition;
    //         _movementAmount = knobPosition / maxMovement;
    //     }
    // }

    // private Vector2 ClampStartPosition(Vector2 position)
    // {
    //     if (position.x < _joystickSize.x / 2)
    //     {
    //         position.x = _joystickSize.x / 2;
    //     }
    //     if (position.y < _joystickSize.y / 2)
    //     {
    //         position.y = _joystickSize.y / 2;
    //     }
    //     else if (position.y > Screen.height - _joystickSize.y / 2)
    //     {
    //         position.y = Screen.height - _joystickSize.y / 2;
    //     }

    //     return position;
    // }
}

