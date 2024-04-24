using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance;

    [SerializeField] private RectTransform pin;
    [SerializeField] private float pinRotationSpeed;

    public float PinAngle => _currentPinRotation;
    private float _currentPinRotation;

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
        float newRotation = -_currentPinRotation + mouseDelta * Time.deltaTime * pinRotationSpeed;
        newRotation = Mathf.Clamp(newRotation, -90, 90);  
        pin.eulerAngles = new Vector3(0, 0, newRotation);
        _currentPinRotation = - newRotation;
    }
}