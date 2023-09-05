using UnityEngine ;
using UnityEngine.UI ;

public class SwitchToggle : MonoBehaviour {
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    Color backgroundDefaultColor, handleDefaultColor;
    Image backgroundImage, handleImage;

    Toggle toggle;
    Vector2 handlePosition ;

    void Start(){
    }

    void Awake(){
        toggle=GetComponent <Toggle>();
        handlePosition= uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();
        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch); 
        if(toggle.isOn)
            OnSwitch(true);
        if(PlayerPrefs.GetInt("legendas")==1){
            OnSwitch(true);
            toggle.isOn = false;
        }
        Debug.Log(toggle);
    }
    void OnSwitch(bool on){
        uiHandleRectTransform.anchoredPosition=on?handlePosition* -1 : handlePosition;
        backgroundImage.color= on ? backgroundActiveColor:backgroundDefaultColor;
        handleImage.color = on?handleActiveColor: handleDefaultColor;
    }
    void OnDestroy(){}
}
