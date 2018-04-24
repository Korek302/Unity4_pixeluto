using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private float volume = 0.5f;
    [SerializeField]
    private float minVolume = 0.0f;
    [SerializeField]
    private float maxVolume = 1.0f;

    private AudioSource _audio;
    
    void Start ()
    {
        _audio = this.GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        _audio.volume = volume;
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(150, 0, 100, 30), "Volume");
        volume = GUI.HorizontalSlider(new Rect(150, 30, 100, 30), volume, minVolume, maxVolume);
    }
}
