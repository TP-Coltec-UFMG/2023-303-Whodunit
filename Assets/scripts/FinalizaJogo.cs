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
    // Start is called before the first frame update
    void Start()
    {
        tempoDeInicio=Time.realtimeSinceStartup;
        botoes = opcoes.GetComponentsInChildren<Button>();
        foreach(Button item in botoes)
        {
            item.onClick.AddListener(AnalisaResposta);
        }
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
        if((Time.realtimeSinceStartup-tempoDeInicio)>30){
        Debug.Log(tempoDeInicio);
        Debug.Log(Time.realtimeSinceStartup);
            if(!respostaJogo.activeInHierarchy){
               AtivaInterface();
            } 
        }
    }

    public void AtivaInterface(){
        respostaJogo.SetActive(true);
    }

}
