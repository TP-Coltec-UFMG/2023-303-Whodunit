using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorblindFilters : MonoBehaviour{


public string filtro;
public CameraController cam;


// Start is called before the first frame update
void Start(){
    this.filtro = PlayerPrefs.GetString("filtroDaltonismo");
    cam = Camera.main.GetComponent<CameraController>();
    switch (filtro)
    {
        case "PROTANOPIA":
            Debug.Log("oi1");
            cam.filter.mode = ColorBlindMode.Protanopia;
            break;
        case "DEUTERANOPIA":
            Debug.Log("oi2");
            cam.filter.mode = ColorBlindMode.Deuteranopia;
            break;
        case "TRITANOPIA":
            Debug.Log("oi3");
            cam.filter.mode = ColorBlindMode.Tritanopia;
            break;
        default:
            Debug.Log("oi4");

            cam.filter.mode = ColorBlindMode.Normal;
            break;
    }
}
}

// Update is called once per frame
