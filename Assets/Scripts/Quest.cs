using System;
using System.Collections;

public class Quest
{
    public enum QuestRank
    {
        E,
        D,
        C,
        B,
        A,
        S
    }
    public virtual void Subscribe ( PlayersInventory _playerInventory ) { }
    public bool IsDone { get { return m_isDone; } }
    protected bool m_isDone;
    protected QuestRank m_rank;
    protected int m_id;
    protected int m_idQuestGiver;
}
