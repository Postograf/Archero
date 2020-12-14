using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VisualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform _stickBackground;
    [SerializeField] private RectTransform _stick;
    [SerializeField] private Player _player;
    private float _maxStickRange;

    private void Start()
    {
        _maxStickRange = _stickBackground.sizeDelta.x / 2.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _stickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out position))
        {
            if (_stickBackground.anchoredPosition == Vector2.zero)
                _stickBackground.anchoredPosition = position;

            if (position.magnitude > _maxStickRange)
                position = position.Resize(_maxStickRange);

            _stick.anchoredPosition = position;
            _player.Move(position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _stickBackground.anchoredPosition = Vector2.zero;
        _stick.anchoredPosition = Vector2.zero;
        _player.Stop();
    }
}
