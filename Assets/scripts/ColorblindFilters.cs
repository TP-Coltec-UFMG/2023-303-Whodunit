using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorblindFilters : MonoBehaviour{


public string filtro;
public CameraController cam;
[SerializeField] private TMP_Dropdown filtros;


// Start is called before the first frame update
void Start(){
    alteraFiltro();
}
public void alteraFiltro(){
    Debug.Log(PlayerPrefs.GetString("filtroDaltonismo"));
    this.filtro = PlayerPrefs.GetString("filtroDaltonismo");
    cam = Camera.main.GetComponent<CameraController>();
    switch (filtro)
    {
        case "PROTANOPIA":
            cam.filter.mode = ColorBlindMode.Protanopia;
            break;
        case "DEUTERANOPIA":
            cam.filter.mode = ColorBlindMode.Deuteranopia;
            break;
        case "TRITANOPIA":
            cam.filter.mode = ColorBlindMode.Tritanopia;
            break;
        default:
            cam.filter.mode = ColorBlindMode.Normal;
            break;
    }
}
public void alteraFiltroJogo(){
    PlayerPrefs.SetString("filtroDaltonismo", filtros.options[filtros.value].text);
    Debug.Log("teste2"+filtros.options[filtros.value].text);
    alteraFiltro();
}
}

// Update is called once per frame
