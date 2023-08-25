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
    // Start is called before the first frame update
    void Start()
    {

        string nivel=PlayerPrefs.GetString("nivelDoJogo");
        tempoDeInicio=Time.realtimeSinceStartup;

        PlayerPrefs.SetFloat("tempoDeMenu", tempoDeInicio);
        Debug.Log("nivel"+nivel);

        botoes = opcoes.GetComponentsInChildren<Button>();

        foreach(Button item in botoes)
        {
            item.onClick.AddListener(AnalisaResposta);
        }

        switch (nivel){
            case "Fácil":
                this.tempoDeJogo=30;
                break;
            case "Médio":
                this.tempoDeJogo=40;
                break;
            case "Difícil":
                this.tempoDeJogo=50;
                break;
            default:
                this.tempoDeJogo=30;
                break;
        }
        Debug.Log(this.tempoDeJogo);
        
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
