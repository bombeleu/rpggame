using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GatherQuest : Quest
{
    private readonly Dictionary<int, int> m_reqItems;
    private Dictionary<int, int> m_myItems;

    private void OnNewInventoryItem ( object sender, InventoryItemArgs e )
    {
        if ( m_isDone )
            return;
        int nReqItems = 0;
        if ( m_reqItems.TryGetValue ( e.Id, out nReqItems ) )
        {
            int nMyItems = 0;
            m_myItems.TryGetValue ( e.Id, out nMyItems );
            m_myItems.Remove ( e.Id );
            nMyItems++;
            m_myItems.Add ( e.Id, nMyItems );
            if ( nReqItems == nMyItems )
                m_isDone = true;
        }
    }

    private void OnRemoveInventoryItem ( object sender, InventoryItemArgs e )
    {
        int nReqItems = 0;
        if ( m_reqItems.TryGetValue ( e.Id, out nReqItems ) )
        {
            int nMyItems = 0;
            m_myItems.TryGetValue ( e.Id, out nMyItems );
            m_myItems.Remove ( e.Id );
            nMyItems--;
            m_myItems.Add ( e.Id, nMyItems );
            if ( m_isDone )
                m_isDone = false;
        }
    }

    public override void Subscribe(PlayersInventory _playerInventory)
    {
        _playerInventory.AddNewItem += OnNewInventoryItem;
        _playerInventory.RemoveItem += OnRemoveInventoryItem;
    }

    public GatherQuest ( int _id, int _idQuestGiver, Dictionary<int, int> _reqItems, QuestRank _rank )
    {
        m_id = _id;
        m_idQuestGiver = _idQuestGiver;
        m_reqItems = _reqItems;
        m_myItems = new Dictionary<int, int> ();
        foreach ( var item in m_reqItems )
            m_myItems.Add ( item.Key, 0 );
    }
}
