using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnRotatePin(InputValue value)
    {
        Vector2 delta = value.Get<Vector2>();
        if (delta.x != 0)
        {
            PinManager.Instance.RotatePin(-delta.x);
        }       
    }

    public void OnTryUnlock(InputValue value)
    {
        GameManager.Instance.TryResolution();
    }
}