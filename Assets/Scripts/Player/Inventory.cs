using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> itemList;
    
    public void AddItem(GameObject item) {
        itemList.Add(item);
    }
}
