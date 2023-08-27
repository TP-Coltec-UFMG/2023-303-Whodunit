using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private GameObject jogador;
    private Vector3 posicao;
    public ColorBlindFilter filter;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public float smoothing;

    public Transform target; 
    
    void LateUpdate(){
        if (transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.transform.position.x,target.transform.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
