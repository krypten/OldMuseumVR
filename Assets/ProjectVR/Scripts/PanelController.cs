using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public GameObject[] UIPanels;

	// Use this for initialization
	public void Hide () {
		// Disable the start UI.
		gameObject.SetActive(false);
		foreach(GameObject UIPanel in UIPanels)
		{
			UIPanel.SetActive(true);	
		}
	}
}
