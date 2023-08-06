using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{
    private bool estadoSom = true;
     [Header("Menu Inicial")]
    [SerializeField] private AudioSource fundoMusical;
    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;
    [SerializeField] private Image muteImage;

    [Header("Menu Jogo")]
    [SerializeField] private GameObject interfaceMudaValor;

    public void LigarDesligarSom(){
        estadoSom = !estadoSom;
        fundoMusical.enabled = estadoSom;
        if(estadoSom){
            muteImage.sprite = somLigadoSprite;
        }else{
            muteImage.sprite = somDesligadoSprite;
        }
    }

    public void  volumeMusical (float value){
        fundoMusical.volume=value;
        PlayerPrefs.SetFloat("volumeAudio", value);
    }
    public void apareceControle(){
        interfaceMudaValor.SetActive(true);
    }

    public void desapareceControle(){
        interfaceMudaValor.SetActive(false);
    }
    public void alteraVolumeMusical(float value){
        Debug.Log("Mudou"+PlayerPrefs.GetFloat("volumeAudio"));
        PlayerPrefs.SetFloat("volumeAudio", value);
    }
}
