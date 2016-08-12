using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	Vector3 Offset;
	Vector3 ClickPos;

	public void OnBeginDrag (PointerEventData pointerEventData) {
		ClickPos = Input.mousePosition;
		Offset = transform.position - ClickPos;
	}

	public void OnDrag(PointerEventData pointerEventData) {
		
		transform.position = new Vector3(Input.mousePosition.x+Offset.x,Input.mousePosition.y, transform.position.z);
	}
	public void OnEndDrag(PointerEventData pointerEventData) {
		
	}
}
