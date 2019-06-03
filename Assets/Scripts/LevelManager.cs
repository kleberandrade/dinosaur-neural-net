using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

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

    public GameObject[] m_Obstacles;
	public float m_MainSpeed = 10;
	public float m_MaxSpeed = 10;
	public float m_Acceleration = 10;
    public float m_SmoothTime = 0.25f;

    private float m_Distance = 0f;

    public float Distance { get => m_Distance; set => m_Distance = value; }

    public void Start()
    {
		Distance = 0f;
	}
	
	public void Update ()
    {
		Distance += m_MainSpeed * Time.deltaTime * m_SmoothTime;
		if (m_MainSpeed < m_MaxSpeed)
        {
			m_MainSpeed += m_Acceleration;
		}
	}
}
