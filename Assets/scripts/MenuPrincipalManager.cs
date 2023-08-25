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
        PlayerPrefs.SetString("filtroDaltonismo", null);
    }
    public void Update(){
        if(Time.realtimeSinceStartup<4f){
        Debug.Log("a");
        PlayerPrefs.SetInt("jaEntrouNoMenu", 0);
        }
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

    /*public void SairDoJogo(){
        Debug.Log("Sair do jogo");
        Application.Quit();
    }*/

    public void SairDoJogo(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void guardaFiltro(){
        PlayerPrefs.SetString("filtroDaltonismo", filtros.options[filtros.value].text);
        Debug.Log(PlayerPrefs.GetString("filtroDaltonismo"));
    }

    public void guardaLegenda(){
        PlayerPrefs.SetInt("legendas", 1);
        Debug.Log(PlayerPrefs.GetInt("legendas"));
    }
    
    public void guardaNivel(){
        PlayerPrefs.SetString("nivel", niveis.options[niveis.value].text);
        Debug.Log(PlayerPrefs.GetString("nivel"));
        Debug.Log(PlayerPrefs.GetString("nivel"));
    }

   
}
