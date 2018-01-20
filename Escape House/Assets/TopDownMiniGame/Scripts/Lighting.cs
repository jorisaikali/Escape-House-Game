using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour {

    public Light directionalLight;

    private void Awake()
    {
        directionalLight.gameObject.SetActive(false);
    }

}
