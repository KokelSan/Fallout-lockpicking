using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotationSlider : Slider
{
    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);

    }
}
