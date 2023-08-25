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
        string nivel=PlayerPrefs.GetString("nivel");
        if(PlayerPrefs.GetInt("jaEntrouNoMenu")==0){
        tempoDeInicio=Time.realtimeSinceStartup;
        }
        PlayerPrefs.SetInt("jaEntrouNoMenu",1);
        Debug.Log("tempo menu"+tempoDeInicio);
        botoes = opcoes.GetComponentsInChildren<Button>();
        foreach(Button item in botoes)
        {
            item.onClick.AddListener(AnalisaResposta);
        }
        Debug.Log(nivel);

        switch (nivel)
        {
            case "Fácil":
                this.tempoDeJogo=10;
                break;
            case "Médio":
                this.tempoDeJogo=20;
                break;
            case "Difícil":
                this.tempoDeJogo=30;
                break;
            default:
                this.tempoDeJogo=10;
                break;
        }
        Debug.Log(this.tempoDeJogo);
        Debug.Log(tempoDeInicio);
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
        Debug.Log(tempoDeInicio);
            if(!respostaJogo.activeInHierarchy){
               AtivaInterface();
            } 
        }
    }

    public void AtivaInterface(){
        respostaJogo.SetActive(true);
    }

}
