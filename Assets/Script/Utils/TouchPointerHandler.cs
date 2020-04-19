using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchPointerHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public delegate void OnDragStarted();
	public static event OnDragStarted onDragStarted;
	public delegate void OnDragCompleted();
	public static event OnDragCompleted onDragCompleted;
	public delegate void OnDraging();
	public static event OnDraging onDraging;

	public void OnDrag(PointerEventData eventData)
	{
		if(onDraging != null)
			onDraging();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (onDragStarted != null)
			onDragStarted();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (onDragCompleted != null)
			onDragCompleted();
	}
}
