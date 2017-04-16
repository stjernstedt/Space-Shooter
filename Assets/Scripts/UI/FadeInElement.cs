using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInElement : MonoBehaviour
{
	public float timeToFadeIn;
	public float targetOpacity;
	float startTime;
	float timePassed;

	MaskableGraphic image;

	void OnEnable()
	{
		image = GetComponent<MaskableGraphic>();
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		startTime = Time.time;
		timePassed = 0;
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
		while (timePassed < timeToFadeIn)
		{
			timePassed = Time.time - startTime;
			float lerpValue = timePassed / timeToFadeIn;
			image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(0, targetOpacity, lerpValue));
			yield return null;
		}
	}
}
