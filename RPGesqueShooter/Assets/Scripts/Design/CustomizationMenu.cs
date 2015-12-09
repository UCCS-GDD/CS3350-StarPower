using UnityEngine;
using System.Collections;

public class CustomizationMenu : MonoBehaviour {

	public GameObject helpPanel;


	public void HelpMenu()
	{
		if (helpPanel.GetComponent<CanvasGroup> ().blocksRaycasts == false) {
			helpPanel.GetComponent<CanvasGroup> ().alpha = 1;
			helpPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		} else {
			helpPanel.GetComponent<CanvasGroup> ().alpha = 0;
			helpPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void MainMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
