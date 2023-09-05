using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuJogoManager : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] private Toggle legenda;
      [SerializeField] private TMP_Dropdown filtros;
      [SerializeField] private GameObject painelOpcoes;


    void Awake(){
        if(PlayerPrefs.GetInt("legendas")==0){
            legenda.isOn = true;
        }
    }
    public void guardaLegenda(){
        if(PlayerPrefs.GetInt("legendas")==0){
            PlayerPrefs.SetInt("legendas", 1);
        }else if(PlayerPrefs.GetInt("legendas")==1){
            PlayerPrefs.SetInt("legendas", 0);
        }
        Debug.Log("aalegenda"+PlayerPrefs.GetInt("legendas"));
    }
     public void fechaOpcoesJogo(){
        painelOpcoes.SetActive(false);
    }

    public void abreOpcoesJogo(){
        painelOpcoes.SetActive(true);
    }

}