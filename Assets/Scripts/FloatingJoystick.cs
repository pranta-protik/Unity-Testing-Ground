using UnityEngine;

public class FloatingJoystick : MonoBehaviour
{
    [SerializeField] private RectTransform _knob;

    public RectTransform RectTransform { get; private set; }
    public RectTransform Knob => _knob;


    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}



