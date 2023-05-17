using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCreation : MonoBehaviour
{
    public Button togglePopupButton;
    public Image creationPopupMenu;
    private bool isMenuOpen;

    public void InitEntityCreation()
    {
        isMenuOpen = false;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
        togglePopupButton.onClick.AddListener(TogglePopupButton);
    }

    private void TogglePopupButton()
    {
        isMenuOpen = !isMenuOpen;
        creationPopupMenu.gameObject.SetActive(isMenuOpen);
    }

    


}
