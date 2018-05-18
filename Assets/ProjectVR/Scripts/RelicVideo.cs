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
		AudioSource audioSource = GetComponent<AudioSource>();

		//Set Audio Output to AudioSource
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);
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
			Play();
		}
	}

	void Play()
	{
		Application.runInBackground = true;
        StartCoroutine(PlayVideo());
	}

	IEnumerator PlayVideo()
	{
		// Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.Prepare();

		// Wait until Movie is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Movie");
            yield return waitTime;
            break;
        }
		// Play Movie 
        videoPlayer.Play();
		screenRenderer.material = pauseBtnMaterial;
	}
}
