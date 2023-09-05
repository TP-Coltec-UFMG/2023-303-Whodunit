using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TempoControl : MonoBehaviour
{
        [SerializeField] private string menu;
        public TMP_Text minutos;
        public TMP_Text segundos;
        public float tempoDeInicio;
        public float tempoDeJogo;
        public string nivel;
        public int s, m;

    void Start() {
        tempoDeInicio = PlayerPrefs.GetFloat("tempoDeMenu");
        nivel = PlayerPrefs.GetString("nivel");
        tempoDeJogo = PlayerPrefs.GetFloat("tempoDeJogo");
        Debug.Log("nivel" + nivel);   
        s = ((int)tempoDeJogo%60);
        m = ((int)tempoDeJogo/60);
        segundos.text= s.ToString("F0");
        minutos.text= m.ToString("F0");

    }

     public void abreMenu(){
        SceneManager.LoadScene(menu); 
    }

    // Update is called once per frame
    void Update()
    {   

        if (s != 0 || m!=0) {

            s = (((int)tempoDeJogo-(int)(Time.realtimeSinceStartup-tempoDeInicio))%60);
            m = (((int)tempoDeJogo-(int)(Time.realtimeSinceStartup-tempoDeInicio))/60);
            if (s<10) {
                segundos.text = "0" + s.ToString("F0");
            } else {
                segundos.text = s.ToString("F0");
            }
            minutos.text = m.ToString("F0");
        }
    }
}