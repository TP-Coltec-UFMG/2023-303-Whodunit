using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D fisica;
    private Vector2 direcao;
    [SerializeField]private float velocidade = 100f;
    [SerializeField]private Animator animacao;


    private void Start(){
        this.fisica=GetComponent<Rigidbody2D>();
    }
    private void Update(){
        this.direcao.x = Input.GetAxisRaw("Horizontal");
        this.direcao.y = Input.GetAxisRaw("Vertical");
        
        animacao.SetFloat("Horizontal", direcao.x);
        animacao.SetFloat("Vertical", direcao.y);
        animacao.SetFloat("Velocidade", direcao.magnitude);
    }
    private void FixedUpdate()
    {
        this.fisica.MovePosition(fisica.position + direcao * velocidade * Time.fixedDeltaTime);
    }
    
}
