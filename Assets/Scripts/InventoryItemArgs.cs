using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InventoryItemArgs: EventArgs
{
    private readonly int m_id;
    public InventoryItemArgs ( int _id )
    {
        m_id = _id;
    }

    public int Id
    {
        get
        {
            return m_id;
        }
    }
}