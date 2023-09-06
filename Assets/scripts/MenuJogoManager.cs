using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuJogoManager : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] private Toggle legenda;
      [SerializeField] private TMP_Dropdown filtros;
      [SerializeField] private GameObject painelOpcoes;
       [SerializeField] private GameObject Orientacoes;


    void Awake(){
        if(PlayerPrefs.GetInt("legendas")==0){
            legenda.isOn = false;
        }else{
            legenda.isOn=true;
        }
        legenda.onValueChanged.AddListener(guardaLegenda);
    }
    public void guardaLegenda(bool isOn){
        if(PlayerPrefs.GetInt("legendas")==0){
            PlayerPrefs.SetInt("legendas", 1);
        }else if(PlayerPrefs.GetInt("legendas")==1){
            PlayerPrefs.SetInt("legendas", 0);
        }
    }
     public void fechaOpcoesJogo(){
        painelOpcoes.SetActive(false);
    }

    public void abreOpcoesJogo(){
        painelOpcoes.SetActive(true);
    }
     public void VoltarMenu(){
        SceneManager.LoadScene("Menu"); 
    }

    public void fechaOrientacoes(){
        Orientacoes.SetActive(false);
    }
    public void TerminarJogo(){
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}