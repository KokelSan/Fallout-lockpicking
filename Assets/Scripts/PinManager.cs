using UnityEngine;
using UnityEngine.UI;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance;

    [SerializeField] private RectTransform pin;
    [SerializeField] private Slider rotationSlider;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    private void Start()
    {
        rotationSlider.onValueChanged.AddListener(UpdatePinRotation);
    }

    public void UpdatePinRotation(float newZRotation)
    {
        pin.eulerAngles = new Vector3(0, 0, -newZRotation);
    }

    public float GetPinAngle()
    {
        return rotationSlider.value;
    }
}