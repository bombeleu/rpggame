using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayersInventory: MonoBehaviour
{
    private List<InventoryItem> m_items;
    public event EventHandler<InventoryItemArgs> AddNewItem;
    public event EventHandler<InventoryItemArgs> RemoveItem;

    public void AddItem ( InventoryItem _newItem )
    {
        m_items.Add ( _newItem );
        if ( AddNewItem != null )
            AddNewItem ( this, new InventoryItemArgs ( _newItem.Id ) );
    }

    public void ThrowItem ( InventoryItem _removedItem )
    {
        m_items.Remove ( _removedItem );
        if ( RemoveItem != null )
            RemoveItem ( this, new InventoryItemArgs ( _removedItem.Id ) );
    }
    void Start ()
    {
        m_items = new List<InventoryItem> ();
    }
}
