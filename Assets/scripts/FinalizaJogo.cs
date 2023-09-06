using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinalizaJogo : MonoBehaviour
{
       [SerializeField] private GameObject respostaJogo;
       [SerializeField] GameObject opcoes;
       [SerializeField] GameObject interfaceAcertou;
       [SerializeField] GameObject interfaceErrou;
       Button[] botoes;
       private float tempoDeInicio;
       public float tempoDeJogo;
       private string nivel;
    // Start is called before the first frame update
    void Start()
    {
        this.nivel=PlayerPrefs.GetString("nivelDoJogo");
        tempoDeInicio=Time.realtimeSinceStartup;
        PlayerPrefs.SetFloat("tempoDeMenu", tempoDeInicio);
        PlayerPrefs.SetInt("jaEntrouNoMenu",1);
        botoes = opcoes.GetComponentsInChildren<Button>();

        foreach(Button item in botoes)
        {
            item.onClick.AddListener(AnalisaResposta);
        }

        switch (nivel)
        {
            case "Fácil":
                this.tempoDeJogo=600;
                break;
            case "Médio":
                this.tempoDeJogo=420;
                break;
            case "Difícil":
                this.tempoDeJogo=300;
                break;
            default:
                this.tempoDeJogo=600;
                break;
        }
        PlayerPrefs.SetFloat("tempoDeJogo", this.tempoDeJogo);
    
    }

    public void AnalisaResposta(){
        GameObject objetoQueChamou = EventSystem.current.currentSelectedGameObject;
        opcoes.SetActive(false);
        if(objetoQueChamou.GetComponentInChildren<TMP_Text>().text=="teste1"){
            interfaceAcertou.SetActive(true);
        }else{
            interfaceErrou.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if((Time.realtimeSinceStartup-tempoDeInicio)>this.tempoDeJogo){
            if(!respostaJogo.activeInHierarchy){
               AtivaInterface();
            } 
        }
    }

    public void AtivaInterface(){
        respostaJogo.SetActive(true);
    }

}
