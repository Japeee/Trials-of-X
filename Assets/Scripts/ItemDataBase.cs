using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Item/Item Database")]
public class ItemDataBase : ScriptableObject
{
    public List<Items> allItems;
}
