using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    private List<Item> itemList;

    public Inventory() 
    {
        itemList = new List<Item>();
    }
    
    public void addItem(Item item) {
        foreach(Item Item in itemList) {
            if(Item == item)
            {
                Item.amount++;
                return;
            }
        }

        itemList.Add(item);
    }

    public void openInventory(){
        
    }

    public void removeItem(Item item) {
        if(item.amount == 1) {
            itemList.Remove(item);
        } else {
            item.amount--;
        }
    }
    


}
