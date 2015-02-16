using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InventoryItem: MonoBehaviour
{
    [SerializeField]
    private int m_id;
    private string m_name;
    public string Name { get { return m_name; } }
    public int Id { get { return m_id; } }
    public void OnTriggerStay ( Collider collide )
    {
        var invent = collide.GetComponent<PlayersInventory> ();
        invent.AddItem ( this );
        this.gameObject.SetActive ( false );
    }
}