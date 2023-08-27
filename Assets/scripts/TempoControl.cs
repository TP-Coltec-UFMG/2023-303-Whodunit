using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempoControl : MonoBehaviour
{
    [SerializeField] private string menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     public void abreMenu(){
        Debug.Log("tempoDeJogo"+(Time.realtimeSinceStartup-PlayerPrefs.GetFloat("tempoDeMenu")));
        Debug.Log("tempoDeMenu"+PlayerPrefs.GetFloat("tempoDeMenu"));
        SceneManager.LoadScene(menu); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
