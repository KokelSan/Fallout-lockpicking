using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance;

    [SerializeField] private RectTransform pin;
    [SerializeField] private float pinRotationSpeed;

    public float PinAngle => _currentPinRotation;
    private float _currentPinRotation;

    private bool _canRotatePin = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public void RotatePin(float mouseDelta)
    {
        if (!_canRotatePin) return;

        float newRotation = -_currentPinRotation + mouseDelta * Time.deltaTime * pinRotationSpeed;
        newRotation = Mathf.Clamp(newRotation, -90, 90);  
        pin.eulerAngles = new Vector3(0, 0, newRotation);
        _currentPinRotation = - newRotation;
    }

    public void SetRotationFeasibility(bool canRotatePin)
    {
        _canRotatePin = canRotatePin;
    }

    public void ResetPinRotation()
    {
        pin.eulerAngles = Vector3.zero; // use dotween
        _currentPinRotation = 0;
    }
}