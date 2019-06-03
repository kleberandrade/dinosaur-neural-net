using UnityEngine;

public class MoveRelatively : MonoBehaviour
{
	public float m_SpeedMultiplier = 1;
	public float m_SpeedOffset = 0;
	private float m_ActualSpeedOffset;

	public void Start()
    {
		m_ActualSpeedOffset = Random.value < 0.5 ? m_SpeedOffset : -m_SpeedOffset;
	}

	public void Update()
    {
		transform.position += Vector3.left * Time.deltaTime * (LevelManager.Instance.m_MainSpeed * m_SpeedMultiplier + m_ActualSpeedOffset);
	}
}
