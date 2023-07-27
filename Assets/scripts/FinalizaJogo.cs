using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizaJogo : MonoBehaviour
{
       [SerializeField] private GameObject respostaJogo;
    // Start is called before the first frame update
    void Start()
    {
        
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
