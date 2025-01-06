using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenWallDetector : MonoBehaviour
{
    public bool noAmmo = false;

 
    private void OnTriggerEnter(Collider other)
    {
        if (noAmmo && other.gameObject.CompareTag("cannonBall"))
        {
            print("no ammo triggered");
            GameManager.Instance.StartCoroutine(GameManager.Instance.DoDelayCheck());
            
        }
    }
}
