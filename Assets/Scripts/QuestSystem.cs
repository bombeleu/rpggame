using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class QuestSystem : MonoBehaviour
{
    List<Quest> m_currentQuests;
    // Use this for initialization
    void Start ()
    {
        m_currentQuests = new List<Quest> ();
        var dic = new Dictionary <int, int> ();
        dic.Add ( 1, 3 );
        AddQuest ( new GatherQuest ( 1, 1, dic, Quest.QuestRank.E ) );
    }

    public void AddQuest ( Quest _quest )
    {
        m_currentQuests.Add ( _quest );
        _quest.Subscribe ( GetComponent<PlayersInventory> () );
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
