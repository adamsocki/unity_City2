using TMPro;

public class EntityOptionData : TMP_Dropdown.OptionData
{
    public EntityHandle handle;

    public EntityOptionData(string text, EntityHandle handle) : base(text)
    {
        this.handle = handle;
    }
}

public class CreateNewDataTMP : TMP_Dropdown.OptionData
{

}

