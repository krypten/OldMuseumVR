using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ElevatorController : MonoBehaviour
{
	AudioSource mAudioSource;
	// Play the music
    bool isPlaying;

	// Use this for initialization
	void Start ()
	{
		mAudioSource = GetComponent<AudioSource>();
		isPlaying = false;
	}

	public void Enter()
	{
		if (isPlaying == false) {
			isPlaying = true;
			mAudioSource.Play();
		}
	}

	public void Exit()
	{
		if (isPlaying == true) {
			isPlaying = false;
			mAudioSource.Stop();
		}
	}

	public void LevelChange()
	{
		Exit();
		if (SceneManager.GetActiveScene().name == "Forest") {
			SceneManager.LoadScene("MainMuseum");
		}
		else if (SceneManager.GetActiveScene().name == "MainMuseum")
		{
			SceneManager.LoadScene("Forest");
		}
	}
}
