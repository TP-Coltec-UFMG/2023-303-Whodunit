using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField]private GameObject jogador;
   private Vector3 posicao;
   public ColorBlindFilter filter;


   private void Start(){
        filter = GetComponent<ColorBlindFilter>();
        
        this.posicao=new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
   }
    void LateUpdate()
    {
        this.posicao.x=jogador.transform.position.x;
        this.posicao.y=jogador.transform.position.y;
        this.transform.position=this.posicao;
    }
}
