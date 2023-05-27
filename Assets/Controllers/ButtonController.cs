using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public Sprite nullSprite;
    public Sprite clickSprite;
    public Button button;
    
   // private bool pointerDown;
  //  private bool pointerOver;
    public bool isClicked;

    private float pointerDownTimer;

    public float renderPointerDownTime;

    public bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.image.sprite = nullSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isActive)
        {
            button.image.sprite = hoverSprite;
            //pointerOver = true;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isActive && !isClicked)
        {
            button.image.sprite = defaultSprite;
            //pointerOver = false;
        }
    }

    public void OnButtonClick()
    {
        if (isActive)
        {
            button.image.sprite = clickSprite;
           // pointerDown = true;
            isClicked = true;
            //Debug.Log("Button clicked");
        }
        else
        {
            
            //button.image.sprite = nullSprite;
        }
    }

    public void ChangeActiveState()
    {
        isActive = !isActive;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (pointerOver)
    //    {
    //    }
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isClicked)
        {
            
            Reset();
        }
    }


    public void Update()
    {
        if (IsActive && isClicked)
        {
            pointerDownTimer += Time.deltaTime;

            if (pointerDownTimer >= renderPointerDownTime)
            {
                //Debug.Log("Pointer held down for required time");
                Reset();
            }
        }
    }

    private void Reset()
    {
        //pointerDown = false;
        isClicked = false;
        pointerDownTimer = 0;
        button.image.sprite = nullSprite;
    }
}
