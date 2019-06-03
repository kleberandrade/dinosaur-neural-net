using UnityEngine;

public class MoveConstantly : MonoBehaviour
{
	public float m_SpeedMultiplier = 0.3f;
	public float m_StartAt = 21;
	public float m_RestartAt = -21;

	public void Update()
    {
		transform.position += Vector3.left * Time.deltaTime * m_SpeedMultiplier;
		if (transform.position.x <= m_RestartAt)
        {
            transform.position += Vector3.right * (m_StartAt - m_RestartAt);
        }
	}
}
