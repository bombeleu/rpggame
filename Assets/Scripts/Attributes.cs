using UnityEngine;
using System.Collections;
using System;

public class Attributes : MonoBehaviour 
{
	[SerializeField]
	private int m_health;
	[SerializeField]
	private int m_speed;
	[SerializeField]
	private int m_chackra;
	[SerializeField]
	private int m_level;
	[SerializeField]
	private int m_ninSkill;
	[SerializeField]
	private int m_taySkill;
	[SerializeField]
	private int m_genSkill;
	[SerializeField]
	private int m_handSpeedSkill;	
	[SerializeField]
	private int Expirience;
	[SerializeField]
	private int NextLevelExp;

	public event EventHandler HealthChange;
	public event EventHandler SpeedChange;
	public event EventHandler ChackraChange;
	public event EventHandler NinChange;
	public event EventHandler GenChange;
	public event EventHandler TayChange;
	public event EventHandler HandSpeedChange;
	public event EventHandler LevelUp; 

	public int Health 
	{ 
		get {return m_health;} 
		set 
		{
			m_health = value;
			if (HealthChange != null)
				HealthChange (new object (), EventArgs.Empty);
		}
	}

	public int Speed
	{
		get {return m_speed;}
		set
		{
			m_speed = value;
			if (SpeedChange != null)
				SpeedChange (this, null);
		}
	}

	public int Chackra
	{
		get {return m_chackra;}
		set
		{
			m_chackra = value;
			if ( ChackraChange != null )
				ChackraChange (this, null);
		}
	}

	public int Nin
	{
		get {return m_ninSkill;}
		set
		{
			m_ninSkill = value;
			if ( NinChange != null )
				NinChange (this, null);
		}
	}

	public int Gen 
	{
		get {return m_genSkill;}
		set
		{
			m_genSkill = value;
			if (GenChange != null)
				GenChange (this, null);
		}
	}

	public int Tay
	{
		get {return m_taySkill;}
		set
		{
			m_taySkill = value;
			if (TayChange != null)
				TayChange (this, null);
		}
	}

	public int HandSpeed
	{
		get {return m_handSpeedSkill;}
		set
		{
			m_handSpeedSkill = value;
			if (HandSpeedChange != null)
				HandSpeedChange (this, null);
		}
	}

	public int Level 
	{
		get {return m_level;}
		set
		{
			if (m_level >= value)
				throw new ArgumentOutOfRangeException ("BadLevel");
			else
			{
				m_level = value;
				if (LevelUp != null)
					LevelUp (this, null);
			}
		}
	}

	public void IncreaseExp ( int exp )
	{
		Expirience += exp;
		if (Expirience > NextLevelExp)
		{
			Level ++;
			NextLevelExp += (NextLevelExp/2)-((NextLevelExp/2)%5);
		}
	}

	void Awake ()
	{
		Health = 1000;
		Speed = 2500;
		Chackra = 1500;
		NextLevelExp = 100;
	}
}
