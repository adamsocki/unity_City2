using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public enum WarningTypes
{
    save,
    blankTemplateName,
}


public class PopupWarningController : MonoBehaviour
{

    public Button button1;
    public Button button2;

    public TextMeshProUGUI warningText;

    private EntityCreation entityCreationReference;

    private TextMeshProUGUI button1Text;
    private TextMeshProUGUI button2Text;


    public void InitPopupWarning(WarningTypes warningType)
    {
        button1.onClick.AddListener(Button1Action);
        button2.onClick.AddListener(Button2Action);

        button1Text = button1.GetComponentInChildren<TextMeshProUGUI>();
        button2Text = button2.GetComponentInChildren<TextMeshProUGUI>();


        switch (warningType)
        {
            case WarningTypes.save:
            {
                warningText.text = "Changes have been made which have not been saved.\nDo you want to proceed?";
                return;
            }
            case WarningTypes.blankTemplateName:
            {
                warningText.text = "You have not given the Tempalte a Name.\nContinuing without giving template a name will delete template.\nDo you want to proceed?";
                    button2Text.text = "Continue Without\nSaving.";
                return;
            }
            default:
            {
                return;
            }

        }

    }




    public void referenceToEntityCreation(EntityCreation entityCreation)
    {
        entityCreationReference = entityCreation; 
    }


    private void Button1Action()
    {
        this.gameObject.SetActive(false);
    }


    private void Button2Action()
    {
        // continue with SaveAction
        entityCreationReference.ClearTemplate();
        this.gameObject.SetActive(false);
    }


}
