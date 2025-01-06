using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public float RotationSpeed = 30.0f;

    public float xDeg, yDeg; 
    public Transform CannonBarrel;
    
    private Shooter shooter;



    private void Awake() {
        shooter = GetComponent<Shooter>();
    }

    private void Update() {
        CannonMovement();

        if(Input.GetMouseButtonDown(0)){
            if(!onPointerOverUI()){
                shooter.Shoot();
            }
        }
    }

    private bool onPointerOverUI(){
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }


    void CannonMovement(){
        yDeg += Input.GetAxis("Vertical") * RotationSpeed * Time.deltaTime;
        xDeg += Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;

        xDeg = Mathf.Clamp(xDeg, -45, 45);
        yDeg = Mathf.Clamp(yDeg, -5, 45);

        CannonBarrel.localEulerAngles = new Vector3(0,yDeg, xDeg);
    }



}
