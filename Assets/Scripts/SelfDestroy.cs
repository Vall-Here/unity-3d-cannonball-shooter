using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float destroyTime = 5.0f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }


}
