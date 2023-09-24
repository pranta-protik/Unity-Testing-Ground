using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputActions;

[CreateAssetMenu(fileName = "InputReader", menuName = "Unity-Testing-Ground/InputReader", order = 0)]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction Jump = delegate { };
    public event UnityAction<bool> Fire = delegate { };

    private PlayerInputActions _playerInputActions;

    public Vector3 Direction => _playerInputActions.Player.Move.ReadValue<Vector2>();

    private void OnEnable()
    {
        if (_playerInputActions == null)
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.SetCallbacks(this);
        }
    }

    public void EnablePlayerInputActions() => _playerInputActions.Enable();

    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Jump.Invoke();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Fire.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Fire.Invoke(false);
                break;
        }
    }
}
