using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalizaJogo : MonoBehaviour
{
       [SerializeField] private GameObject respostaJogo;
       [SerializeField] Button[] opcoes;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Button item in opcoes)
        {
            item.onClick.AddListener(Teste);
            Debug.Log( item.GetComponentInChildren<TMP_Text>().text);
        }
    }

    public void Teste(){
        Debug.Log("oiii");
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup>12){
            if(!respostaJogo.activeInHierarchy){
               AtivaInterface();
            } 
        }
    }

    public void AtivaInterface(){
        respostaJogo.SetActive(true);
    }

}
