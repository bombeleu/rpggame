using UnityEngine;
using System.Collections;
using System;

public class NewLevelMenu: MonoBehaviour 
{

    struct ChangedAttributes
    {
        public short Health;
        public short Speed;
        public short Chackra;
        public short Nin;
        public short Gen;
        public short Tay;
        public short HandSpeed;
    }


	private int m_freeMainSkillAttrbutes;
	private sbyte m_freeSkillAttributes;
    public GameObject AttributesPanel;
    private MouseOrbit m_mouseOrbit;

	ChangedAttributes m_changedAttributes;

	[SerializeField]
	private Attributes PlayerAttributes;

	[SerializeField]
	private UnityEngine.UI.Text m_helthText;
	[SerializeField]
	private UnityEngine.UI.Text m_speedText;
	[SerializeField]
	private UnityEngine.UI.Text m_chackraText;
	[SerializeField]
	private UnityEngine.UI.Text m_ninText;
	[SerializeField]
	private UnityEngine.UI.Text m_genText;
	[SerializeField]
	private UnityEngine.UI.Text m_tayText;
	[SerializeField]
	private UnityEngine.UI.Text m_handSpeedText;
	[SerializeField]
	private UnityEngine.UI.Text m_freeMainSkillText;
	[SerializeField]
	private UnityEngine.UI.Text m_freeSkillText;
	
	void Start ()
	{
        m_mouseOrbit = GameObject.FindGameObjectWithTag ( "MainCamera" ).GetComponent<MouseOrbit> ();
        PlayerAttributes = GameObject.FindGameObjectWithTag ( "Player" ).GetComponent<Attributes> ();
		m_helthText.text = "Health: " + PlayerAttributes.Health;
		m_speedText.text = "Speed: " + PlayerAttributes.Speed;
		m_chackraText.text = "Chackra: " + PlayerAttributes.Chackra;
		m_ninText.text = "Nin: " + PlayerAttributes.Nin;
		m_genText.text = "Gen: " + PlayerAttributes.Gen;
		m_tayText.text = "Tay: " + PlayerAttributes.Tay;
		m_handSpeedText.text = "Hand Speed: " + PlayerAttributes.HandSpeed;
		PlayerAttributes.LevelUp += OnLevelUp;
		PlayerAttributes.HealthChange += OnHealthChange;
		PlayerAttributes.SpeedChange += OnSpeedChange;
		PlayerAttributes.ChackraChange += OnChackraChange;
		PlayerAttributes.NinChange += OnNinChange;
		PlayerAttributes.GenChange += OnGenChange;
		PlayerAttributes.TayChange += OnTayChange;
		PlayerAttributes.HandSpeedChange += OnHandSpeedChange;
		m_freeMainSkillAttrbutes = -1;
		m_freeSkillAttributes = -1;
        var list = AttributesPanel.GetComponentsInChildren<UnityEngine.UI.Button>();
		foreach ( var button in list)
			button.interactable = false;
	}

    void OnLevelUp ( object sender, EventArgs e )
    {
        AttributesPanel.SetActive ( true );
        if (m_freeSkillAttributes == -1)
            m_freeSkillAttributes = 5;
        else
            m_freeSkillAttributes += 5;
        if (m_freeMainSkillAttrbutes == -1)
            m_freeMainSkillAttrbutes = 500;
        else
            m_freeMainSkillAttrbutes += 500;
        var list = AttributesPanel.GetComponentsInChildren<UnityEngine.UI.Button> ();
        foreach (var button in list)
            button.interactable = true;
        m_changedAttributes.Health = Convert.ToInt16 ( PlayerAttributes.Health );
        m_changedAttributes.Speed = Convert.ToInt16 ( PlayerAttributes.Speed );
        m_changedAttributes.Chackra = Convert.ToInt16 ( PlayerAttributes.Chackra );
        m_changedAttributes.Nin = Convert.ToInt16 ( PlayerAttributes.Nin );
        m_changedAttributes.Gen = Convert.ToInt16 ( PlayerAttributes.Gen );
        m_changedAttributes.Tay = Convert.ToInt16 ( PlayerAttributes.Tay );
        m_changedAttributes.HandSpeed = Convert.ToInt16 ( PlayerAttributes.HandSpeed );
        m_freeMainSkillText.text = "Free Score: " + m_freeMainSkillAttrbutes;
        m_freeSkillText.text = "Free Score: " + m_freeSkillAttributes;
    }

	void OnHealthChange ( object sender, EventArgs e)
	{
		if (m_helthText != null)
		{
			m_helthText.text = "Health: " + PlayerAttributes.Health;
			if (m_changedAttributes.Health != PlayerAttributes.Health && m_freeMainSkillAttrbutes != -1)
				m_helthText.color = Color.red;
		}
	}

	void OnSpeedChange ( object sender, EventArgs e)
	{
		if (m_speedText != null)
		{
			m_speedText.text = "Speed: " + PlayerAttributes.Speed;
			if (m_changedAttributes.Speed != PlayerAttributes.Speed && m_freeMainSkillAttrbutes != -1)
				m_speedText.color = Color.red;
		}
	}

	void OnChackraChange ( object sender, EventArgs e)
	{
		if (m_chackraText != null)
		{
			m_chackraText.text = "Chackra: " + PlayerAttributes.Chackra;
			if (m_changedAttributes.Chackra != PlayerAttributes.Chackra && m_freeMainSkillAttrbutes != -1)
				m_chackraText.color = Color.red;
		}
	}

	void OnNinChange ( object sender, EventArgs e)
	{
		if (m_ninText != null)
		{
			m_ninText.text = "Nin: " + PlayerAttributes.Nin;
			if (m_changedAttributes.Nin != PlayerAttributes.Nin && m_freeSkillAttributes != -1)
				m_ninText.color = Color.red;
		}
	}

	void OnGenChange ( object sender, EventArgs e)
	{
		if (m_genText != null)
		{
			m_genText.text = "Gen: " + PlayerAttributes.Gen;
			if (m_changedAttributes.Gen != PlayerAttributes.Gen && m_freeSkillAttributes != -1)
				m_genText.color = Color.red;
		}
	}

	void OnTayChange ( object sender, EventArgs e)
	{
		if (m_tayText != null)
		{
			m_tayText.text = "Tay: " + PlayerAttributes.Tay;
			if (m_changedAttributes.Tay != PlayerAttributes.Tay && m_freeSkillAttributes != -1)
				m_tayText.color = Color.red;
		}
	}

	void OnHandSpeedChange ( object sender, EventArgs e)
	{
		if (m_handSpeedText != null)
		{
			m_handSpeedText.text = "HandSpeed: " + PlayerAttributes.HandSpeed;
			if (m_changedAttributes.HandSpeed != PlayerAttributes.HandSpeed && m_freeSkillAttributes != -1)
				m_handSpeedText.color = Color.red;
		}
	}
	
	public void Plus ( String nameAttribute )
	{
		switch (nameAttribute)
		{
			case "Health":
				if (m_freeMainSkillAttrbutes != 0)
				{
					PlayerAttributes.Health += 100;
					m_freeMainSkillAttrbutes -= 100;
				}
				break;
			case "Speed":
				if (m_freeMainSkillAttrbutes != 0)
				{
					PlayerAttributes.Speed += 100;
					m_freeMainSkillAttrbutes -= 100;
				}
				break;
			case "Chackra":
				if (m_freeMainSkillAttrbutes != 0)
				{
					PlayerAttributes.Chackra += 100;
					m_freeMainSkillAttrbutes -= 100;
				}
				break;
			case "Nin":
				if (m_freeSkillAttributes != 0)
				{
					PlayerAttributes.Nin += 1;
					m_freeSkillAttributes -= 1;
				}
				break;
			case "Tay":
				if (m_freeSkillAttributes != 0)
				{
					PlayerAttributes.Tay += 1;
					m_freeSkillAttributes -= 1;
				}
				break;
			case "Gen":
				if (m_freeSkillAttributes != 0)
				{
					PlayerAttributes.Gen += 1;
					m_freeSkillAttributes -= 1;
				}
				break;
			case "HandSpeed":
				if (m_freeSkillAttributes != 0)
				{
					PlayerAttributes.HandSpeed += 1;
					m_freeSkillAttributes -= 1;
				}
				break;
		}
		m_freeMainSkillText.text = "Free Score: " + m_freeMainSkillAttrbutes;
		m_freeSkillText.text = "Free Score: " + m_freeSkillAttributes;
	}
	
	public void Minus ( String nameAttribute )
	{
		switch (nameAttribute)
		{
		case "Health":
			if (m_changedAttributes.Health < PlayerAttributes.Health)
			{
				PlayerAttributes.Health -= 100;
				m_freeMainSkillAttrbutes += 100;
			}
			break;
		case "Speed":
			if (m_changedAttributes.Speed < PlayerAttributes.Speed)
			{
				PlayerAttributes.Speed -= 100;
				m_freeMainSkillAttrbutes += 100;
			}
			break;
		case "Chackra":
			if (m_changedAttributes.Chackra < PlayerAttributes.Chackra)
			{
				PlayerAttributes.Chackra -= 100;
				m_freeMainSkillAttrbutes += 100;
			}
			break;
		case "Nin":
			if (m_changedAttributes.Nin < PlayerAttributes.Nin)
			{
				PlayerAttributes.Nin -= 1;
				m_freeSkillAttributes += 1;
			}
			break;
		case "Tay":
			if (m_changedAttributes.Tay < PlayerAttributes.Tay)
			{
				PlayerAttributes.Tay -= 1;
				m_freeSkillAttributes += 1;
			}
			break;
		case "Gen":
			if (m_changedAttributes.Gen < PlayerAttributes.Gen)
			{
				PlayerAttributes.Gen -= 1;
				m_freeSkillAttributes += 1;
			}
			break;
		case "HandSpeed":
			if (m_changedAttributes.HandSpeed < PlayerAttributes.HandSpeed)
			{
				PlayerAttributes.HandSpeed -= 1;
				m_freeSkillAttributes += 1;
			}
			break;
		}
		m_freeMainSkillText.text = "Free Score: " + m_freeMainSkillAttrbutes;
		m_freeSkillText.text = "Free Score: " + m_freeSkillAttributes;
	}

	public void OnSubmit ()
	{
		if (m_freeMainSkillAttrbutes == 0 && m_freeSkillAttributes == 0)
		{
			m_changedAttributes = new ChangedAttributes ();
			m_freeMainSkillAttrbutes = -1;
			m_freeSkillAttributes = -1;
			var listButton = AttributesPanel.GetComponentsInChildren <UnityEngine.UI.Button> ();
			foreach ( var button in listButton)
				button.interactable = false;
            var listText = AttributesPanel.GetComponentsInChildren<UnityEngine.UI.Text>();
			foreach ( var text in listText)
				text.color = Color.black;
		}
	}

}
