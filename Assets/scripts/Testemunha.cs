using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Testemunha : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;
    private Transform _playerTransform;
    private const float _INTERACT_DISTANCE=5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsWithinInteractDistance()){
            Interact();
        }
        if(_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance()){
            _interactSprite.gameObject.SetActive(false);

        }else if(!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance()){
                        _interactSprite.gameObject.SetActive(true);
        }
    }
    public abstract void Interact();
    private bool IsWithinInteractDistance(){
        if(Vector2.Distance(_playerTransform.position, _playerTransform.position)<_INTERACT_DISTANCE){
            return true;
        }else{
            return false;
        }
    }
}
