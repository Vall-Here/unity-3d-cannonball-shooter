using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject CannonBall;
    public Transform ShootPoint;
    public float ShootForce = 1000.0f;
    private Ammo ammo;
    private CannonAudio cannonAudio;

    private void Awake() {
        ammo = GetComponent<Ammo>();
        cannonAudio = GetComponent<CannonAudio>();
    }

    public void Shoot(){
        
        if(ammo.CurrentAmmo <= 0) return;
      
        cannonAudio.PlayShootSound();
        GameObject cannonBall = Instantiate(CannonBall, ShootPoint.position, ShootPoint.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.AddForce(cannonBall.transform.forward * ShootForce, ForceMode.Impulse);
        ammo.CurrentAmmo--;
    }
}
