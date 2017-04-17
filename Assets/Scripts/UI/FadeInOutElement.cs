using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOutElement : MonoBehaviour
{
	public float timeToFadeIn = 1f;
	public float timeToFadeOut = 1f;
	float startTime;
	float timePassed;

	MaskableGraphic element;

	void OnEnable()
	{
		element = GetComponent<Text>();
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
			element.color = new Color(element.color.r, element.color.g, element.color.b, Mathf.Lerp(0, 1, lerpValue));
			yield return null;
		}
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeOut()
	{
		startTime = Time.time;
		timePassed = 0;
		while (timePassed < timeToFadeOut)
		{
			timePassed = Time.time - startTime;
			float lerpValue = timePassed / timeToFadeOut;
			element.color = new Color(element.color.r, element.color.g, element.color.b, Mathf.Lerp(1, 0, lerpValue));
			yield return null;
		}
		gameObject.SetActive(false);
	}
}
