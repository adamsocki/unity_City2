using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public enum WarningTypes
{
    save,
    blankTemplateName,
    DeleteTemplate,
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
        button1.onClick.AddListener(() => Button1Action(warningType));
        button2.onClick.AddListener(() => Button2Action(warningType));

        button1Text = button1.GetComponentInChildren<TextMeshProUGUI>();
        button2Text = button2.GetComponentInChildren<TextMeshProUGUI>();


        switch (warningType)
        {
            case WarningTypes.save:
            {
                    warningText.text = "Changes have been made which have not been saved.\nDo you want to proceed?";
                    button1Text.text = "Save Changes";
                    button2Text.text = "Continue Without\nSaving";
                    return;
            }
            case WarningTypes.blankTemplateName:
            {
                    warningText.text = "You have not given the Tempalte a Name.\nContinuing without giving template a name will delete template.\nDo you want to proceed?";
                    button2Text.text = "Continue Without\nSaving";
                    return;
            }
            case WarningTypes.DeleteTemplate:
            {
                    warningText.text = "Are you sure you want to delete this template?";
                    button1Text.text = "No";
                    button2Text.text = "Yes";
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


    private void Button1Action(WarningTypes warningType)
    {
        
        switch(warningType) 
        {
            case WarningTypes.save:
            {
                    return;
            }
            case WarningTypes.blankTemplateName:
            {
                    return;
            }
            case WarningTypes.DeleteTemplate:
            {
                    return;
            }
            default:
            {
                    return;
            }
        }

        
        this.gameObject.SetActive(false);

    }


    private void Button2Action(WarningTypes warningType)
    {
        // continue with SaveAction
        entityCreationReference.ClearTemplate();
        this.gameObject.SetActive(false);

        switch(warningType)
        {
            case WarningTypes.save:
            {
                    //entityCreationReference.SaveTemplate();
                    return;
            }
            case WarningTypes.blankTemplateName:
            {

                    return;
            }
            case WarningTypes.DeleteTemplate:
            {
                    entityCreationReference.DeleteCurrentTemplate();
                    return;
            }
            default:
            {
                    return;
            } 
        }

    
    }


}
