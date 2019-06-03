using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{
    public static TimeOfDay Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float m_LengthOfDay = 100f;
	public float m_LengthOfNight = 100f;
	public float m_FadePerSecond = 1f;
	private bool m_DayTime = true;
	private float m_TimeOfDay = 0;

    public float Value() => m_TimeOfDay;

    public bool IsNight() => !m_DayTime;

    public void Start ()
    {
		StartCoroutine(ChangeDayTime(m_LengthOfDay, false));
	}

	public void Update ()
    {
		if (m_TimeOfDay > 0 && m_DayTime)
        {
            m_TimeOfDay = Mathf.Max(0, m_TimeOfDay - m_FadePerSecond * Time.deltaTime);
		} else if (m_TimeOfDay < 1 && !m_DayTime)
        {
            m_TimeOfDay = Mathf.Min(1, m_TimeOfDay + m_FadePerSecond * Time.deltaTime);
		}
	}	

	private IEnumerator ChangeDayTime(float lengthToWait, bool newDayTime)
    {
		yield return new WaitForSeconds(lengthToWait);
		m_DayTime = newDayTime;
		StartCoroutine(ChangeDayTime(newDayTime ? m_LengthOfDay : m_LengthOfNight, !newDayTime));
	}
}
