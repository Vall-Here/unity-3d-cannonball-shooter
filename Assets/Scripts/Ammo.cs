using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int MaxAmmo;
    public int currentAmmo;

    public TextMeshProUGUI AmmoText;


    public int CurrentAmmo {
        get {
            return currentAmmo;
        }
        set {
            currentAmmo = value;
            AmmoText.text = "Ammo: " + currentAmmo + "/" + MaxAmmo;
            if(currentAmmo <= 0 && GameManager.Instance.fallenBrickAmounr < GameManager.Instance.fallenBrickNeeded){
                AmmoText.text = "Out of Ammo";
                // GameManager.score = 0;
                GameManager.Instance.CheckLose();
            }
        }
    }

    void SetAmmo(){
        MaxAmmo = GameManager.Instance.fallenBrickNeeded/3;
        currentAmmo = MaxAmmo;
        AmmoText.text = "Ammo: " + currentAmmo + "/" + MaxAmmo;
    }

    void Start()
    {
        GameManager.Instance.setAmmo += SetAmmo;
    }

    private void OnDisable() {
        GameManager.Instance.setAmmo -= SetAmmo;
    }
}
