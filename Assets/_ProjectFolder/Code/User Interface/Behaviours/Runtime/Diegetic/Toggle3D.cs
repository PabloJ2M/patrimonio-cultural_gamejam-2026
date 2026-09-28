using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Toggle3D : Selectable3D
{
    [SerializeField] private bool isOn = false;

    public UnityEvent<bool> onValueChanged;

    private void OnValidate() => onValueChanged?.Invoke(isOn);

    public void SetValueWithoutNotify(bool value)
    {
        isOn = value;
        SetColor(isOn ? colors.selectedColor : colors.normalColor);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        SetValueWithoutNotify(!isOn);
        onValueChanged?.Invoke(isOn);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (isOn)
            SetColor(colors.selectedColor);
        else
            base.OnPointerExit(eventData);
    }
}