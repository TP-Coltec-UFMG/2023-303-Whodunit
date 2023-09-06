using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeLevelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private TMP_Dropdown filtros;
    [SerializeField] private TMP_Dropdown niveis;
    [SerializeField] private Toggle legenda;

    public void Awake(){
        PlayerPrefs.SetInt("legendas", 0);
        PlayerPrefs.SetString("filtroDeDaltonismo", null);
        PlayerPrefs.SetString("nivelDoJogo", null);
       
    }
    public void Update(){
    }
    public void Jogar(){
        SceneManager.LoadScene(nomeLevelDoJogo); 
    }

    public void AbrirOpcoes(){
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);   
    }

    public void FecharOpcoes(){
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void guardaFiltro(){
        PlayerPrefs.SetString("filtroDeDaltonismo", filtros.options[filtros.value].text);
    }

    public void guardaLegenda(){
        if(PlayerPrefs.GetInt("legendas")==0){
            PlayerPrefs.SetInt("legendas", 1);
        }else if(PlayerPrefs.GetInt("legendas")==1){
            PlayerPrefs.SetInt("legendas", 0);
        }
    }


    public void SairDoJogo(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    public void guardaNivel(){
        PlayerPrefs.SetString("nivelDoJogo", niveis.options[niveis.value].text);
    }

    public void fechaOpcoesJogo(){
        painelOpcoes.SetActive(false);
    }

    public void abreOpcoesJogo(){
        painelOpcoes.SetActive(true);
    }

   
}
