using UnityEngine;
using UnityEngine.EventSystems;

public class UIPinchZoom : MonoBehaviour, IDragHandler
{
	[SerializeField] private float minScale = 0.5f;
	[SerializeField] private float maxScale = 3f;
	[SerializeField] private float sensitivity = 0.1f;

	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Input.touchCount == 2)
		{
			Touch touch0 = Input.GetTouch(0);
			Touch touch1 = Input.GetTouch(1);

			Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
			Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

			float prevDistance = Vector2.Distance(touch0PrevPos, touch1PrevPos);
			float currentDistance = Vector2.Distance(touch0.position, touch1.position);

			float scaleFactor = (currentDistance / prevDistance) * sensitivity;
			Vector3 newScale = rectTransform.localScale * scaleFactor;

			newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
			newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
			newScale.z = 1;

			rectTransform.localScale = newScale;
		}
	}
}