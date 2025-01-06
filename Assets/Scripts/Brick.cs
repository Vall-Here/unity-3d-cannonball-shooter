using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool hasFallen;
    private AudioSource audioSource;
    public AudioClip[] fallSound;
    public AudioClip impactSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasFallen) return;

        if (other.GetComponent<FallenWallDetector>() != null)
        {
            audioSource.PlayOneShot(fallSound[Random.Range(0, fallSound.Length)]);
            hasFallen = true;
            GameManager.Instance.BrickFall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cannonBall"))
        {
            audioSource.PlayOneShot(impactSound);
        }
    }
}
