using UnityEngine;


public class wallOfBrickSetter : MonoBehaviour {
    private void Start() {
        GameManager.Instance.fallenBrickNeeded += transform.childCount;
        GameManager.Instance.SetAmmo();
    }
}