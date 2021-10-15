using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class Items : ScriptableObject
{
    public string itemID;
    public string itemName;
    [TextArea]
    public string itemDescription;

    public Sprite ItemSprite;

}
