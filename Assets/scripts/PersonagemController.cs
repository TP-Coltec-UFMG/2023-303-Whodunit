using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemController : MonoBehaviour
{
    [SerializeField] private AudioSource falaPersonagem;
    
    
    
    void OnMouseDown(){
        if(!falaPersonagem.isPlaying){
            falaPersonagem.Play();
        }else{
            falaPersonagem.Stop();
        }
    }
}
