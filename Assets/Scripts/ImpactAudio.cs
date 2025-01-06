using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip breakWall;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if ( other.gameObject.GetComponent<Brick>() != null)
        {
            print("brick hit");
            audioSource.volume = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(breakWall);   
        }
    }
}
