using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageButtons : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private List<InventoryItemData> buyItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void item1button()
    {
        int i = 0;
        AddItemToInv(i);
    }
    public void item2button()
    {
        int i = 1;
        AddItemToInv(i);
    }
    public void item3button()
    {
        int i = 2;
        AddItemToInv(i);
    }
    public void item4button()
    {
        int i = 3;
        AddItemToInv(i);
    }
    public void item5button()
    {
        int i = 4;
        AddItemToInv(i);
    }

    private void AddItemToInv(int i)
    {
        var inventory = target.transform.GetComponent<PlayerInventoryHolder>();
        if (inventory != null)
        {
            if (inventory.AddToInventory(buyItems[i], 1))
            {
                Debug.Log($"{buyItems[i]} got added to your inventory");
            }
        }
    }
}
