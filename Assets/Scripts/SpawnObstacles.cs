using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
	private float m_Distance = 0;
	private float m_SpawnAt = 0;
	private string[] m_ObstacleHistory = new string[]{null, null};
	private int m_ObstacleHistoryIndex = 0;

	public void Update() {
		m_Distance += Time.deltaTime * LevelManager.Instance.m_MainSpeed;
		if (m_Distance >= m_SpawnAt)
        {
            SpawnObstacle();
        }
	}

	private void SpawnObstacle()
    {
		int obstacleIndex;
		ObstacleStuff obstacleStuff = null;
		do {
			obstacleIndex = Random.Range(0, LevelManager.Instance.m_Obstacles.Length);
			obstacleStuff = LevelManager.Instance.m_Obstacles[obstacleIndex].GetComponent<ObstacleStuff>();
		} while ((obstacleStuff.uniqueName == m_ObstacleHistory[0] && obstacleStuff.uniqueName == m_ObstacleHistory[1]) || obstacleStuff.minSpeed > LevelManager.Instance.m_MainSpeed);

		m_ObstacleHistory[m_ObstacleHistoryIndex] = obstacleStuff.uniqueName;
		m_ObstacleHistoryIndex = (m_ObstacleHistoryIndex + 1) % 2;

		GameObject obstacle = Instantiate(LevelManager.Instance.m_Obstacles[obstacleIndex]);
		obstacle.transform.position = new Vector3(transform.localScale.x / 2, transform.position.y, 0);
		obstacle.GetComponent<DestroyOnLeftEdge>().ground = gameObject;

		float minimumSpawnDistance = obstacle.GetComponent<Collider2D>().bounds.size.x * LevelManager.Instance.m_MainSpeed / 4.0f + obstacle.GetComponent<ObstacleStuff>().minGap * 0.6f;
		m_SpawnAt = minimumSpawnDistance * (1 + Random.value * 0.5f);
		m_Distance = 0f;
	}
    
}
