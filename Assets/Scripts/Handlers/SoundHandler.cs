using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
	public AudioSource laserSound;

	void OnEnable()
	{
		laserSound.Play();
	}
}
