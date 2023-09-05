using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] speechTxt;
    public string actorName;
    public AudioSource falaPersonagem;
    public int legendas;
    private DialogueControl dc;
    bool onRadious;

    public LayerMask playerLayer;
    public float radious;

    private void Start(){
        this.dc=FindObjectOfType<DialogueControl>();
        this.legendas = PlayerPrefs.GetInt("legendas");
        this.falaPersonagem.volume=PlayerPrefs.GetFloat("volumeAudio");
    }

    private void FixedUpdate(){
        Interact();
    }

    private void Update(){
        this.legendas = PlayerPrefs.GetInt("legendas");
        if(Input.GetKeyDown(KeyCode.Space)&&onRadious){
            if(!falaPersonagem.isPlaying){
                falaPersonagem.Play();
            }
            if(legendas == 1){
            dc.Speech(this.speechTxt, this.actorName);
            }
             
        }
         this.falaPersonagem.volume=PlayerPrefs.GetFloat("volumeAudio");
    }
    
    public void Interact(){
        Collider2D hit=Physics2D.OverlapCircle(this.transform.position, this.radious, this.playerLayer);
        if(hit != null){
            onRadious=true;
        }else{
            onRadious=false;
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, this.radious);
    }
}