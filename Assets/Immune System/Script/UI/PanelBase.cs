using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
	public void HidePanelObj()
	{
		this.gameObject.SetActive(false);
	}
	public void ShowPanelObj()
	{
		this.gameObject.SetActive(true);
	}
}
