using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
	public GameObject m_Cloud;
	public float m_MinCloudHeight = 1;
	public float m_MaxCloudHeight = 1;
	private float m_Distance;
	private float m_SpawnAt;

	public void Update()
    {
		m_Distance += Time.deltaTime * LevelManager.Instance.m_MainSpeed;
		if (m_Distance >= m_SpawnAt)
        {
            SpawnCloud();
        }	
	}

	private void SpawnCloud()
    {
		GameObject cloud = Instantiate(m_Cloud);
        cloud.transform.position = new Vector3(transform.localScale.x * 0.5f, m_MinCloudHeight + Random.value * (m_MaxCloudHeight - m_MinCloudHeight), 0.0f);
        cloud.GetComponent<DestroyOnLeftEdge>().ground = gameObject;

		m_SpawnAt = (3 + 100 + Random.value * 300) * 4;
		m_Distance = 0f;
	}
}
