using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataBase : MonoBehaviour
{
    public ItemDataBase items;
    private static DataBase instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Items GetItemByID(string ID)
    {
        return instance.items.allItems.FirstOrDefault(i => i.itemID == ID);



        //foreach(Items item in instance.items.allItems)
        //{
        //    if (item.itemID == ID)
        //        return item;
        //}

        //return null;
    }

    public static Items GetRandomItem()
    {
        return instance.items.allItems[Random.Range(0, instance.items.allItems.Count)];
    }

}
