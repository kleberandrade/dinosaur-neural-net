using UnityEngine;

public class MoonPhases : MonoBehaviour
{
	public Sprite[] m_Sprites;
	private int m_Phase;
	private bool m_IsNight;

    private SpriteRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
		if (m_Sprites.Length > 0) {
			m_Phase = m_Sprites.Length - 1;
			m_Renderer.sprite = m_Sprites[m_Phase];
		}
	}

	public void Update()
    {
		if (m_Sprites.Length > 0)
        {
			if (!m_IsNight && TimeOfDay.Instance.IsNight())
            {
				m_Phase = (m_Phase + 1) % m_Sprites.Length;
				m_Renderer.sprite = m_Sprites[m_Phase];
			}
		}
		m_IsNight = TimeOfDay.Instance.IsNight();
		m_Renderer.color = new Color(0.7333333333f, 0.7333333333f, 0.7333333333f, TimeOfDay.Instance.Value());
	}
}
