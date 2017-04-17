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

	MaskableGraphic element;

	void OnEnable()
	{
		element = GetComponent<MaskableGraphic>();
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		startTime = Time.time;
		timePassed = 0;
		element.color = new Color(element.color.r, element.color.g, element.color.b, 0);
		while (timePassed < timeToFadeIn)
		{
			timePassed = Time.time - startTime;
			float lerpValue = timePassed / timeToFadeIn;
			element.color = new Color(element.color.r, element.color.g, element.color.b, Mathf.Lerp(0, targetOpacity, lerpValue));
			yield return null;
		}
	}
}
