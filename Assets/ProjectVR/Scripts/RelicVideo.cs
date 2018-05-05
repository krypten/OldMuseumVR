using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class RelicVideo : MonoBehaviour {
	public Material playBtnMaterial;
	public Material pauseBtnMaterial;
	public Renderer screenRenderer;

	private VideoPlayer videoPlayer;

	void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer> ();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void PlayPause()
	{
		Debug.Log("debug PlayPause");
		if (videoPlayer.isPlaying)
		{
			Debug.Log("debug pause");
			videoPlayer.Pause();
			screenRenderer.material = playBtnMaterial;
		} else
		{
			Debug.Log("debug play");
			videoPlayer.Play();
			screenRenderer.material = pauseBtnMaterial;
		}
	}
}
