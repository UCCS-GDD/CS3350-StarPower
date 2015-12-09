using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	public GameObject canvas;

	bool paused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (paused)			
			{
				//Time.timeScale = 1f;
				canvas.GetComponent<CanvasGroup>().alpha = 0f;
				canvas.GetComponent<CanvasGroup>().interactable = false;
				canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			else
			{
				//Time.timeScale = 0f;
				canvas.GetComponent<CanvasGroup>().alpha = 1f;
				canvas.GetComponent<CanvasGroup>().interactable = true;
				canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
			}

			paused = !paused;
		}
	}
}