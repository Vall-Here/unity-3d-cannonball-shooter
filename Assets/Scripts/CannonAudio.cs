using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAudio : MonoBehaviour{

    [Header("Audio")]
    [SerializeField] AudioClip shootSound;

    private AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShootSound(){
        audioSource.pitch = Random.Range(1f, 1.4f);
        audioSource.PlayOneShot(shootSound);
    }
}
