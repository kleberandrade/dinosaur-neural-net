using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	public AudioSource m_AudioSource;
	public Text m_ScoreText;
	public Text m_HighScoreText;
	public Text m_FlashScoreText;
	public int m_FlashIterations = 10;
	public float m_FlashDuration = 1;
	private int m_LastHundred = 0;
	private Vector3 m_ScoreStartPosition = Vector3.zero;
	private int m_Iterated = 0;
	private static float m_HighestScore = 0;

	public void Start()
    {
		//m_FlashScoreText.transform.position = m_ScoreText.transform.position + Vector3.up * 50;
	}

    /*
	void Update() {
		if (audioSource && audioClip && (int) (level.getDistance() / 100) != lastHundred) {
			lastHundred = (int) (level.getDistance() / 100);
			flashScore.Value = lastHundred * 100;
			StartCoroutine(FlashScore());
		}
		score.Value = (int) level.getDistance();
		highScore.Value = (int) highestScore;
	}

	void Awake() {
		highScore.Value = (int) highestScore;
	}

	void OnDestroy() {
		highestScore = Mathf.Max(level.getDistance(), highestScore);
	}

	IEnumerator FlashScore() {
		m_ScoreStartPosition = score.transform.position;
		score.transform.position = m_ScoreStartPosition + Vector3.up * 50;
		m_Iterated = 0;
		m_AudioSource.PlayOneShot(m_AudioClip, 1);
		return FlashScore(false);
	}

	IEnumerator FlashScore(bool showScore) {
		m_FlashScoreText.transform.position = m_ScoreStartPosition + (showScore ? Vector3.zero : Vector3.up * 50);
		if (showScore) {
			m_Iterated++;
		}
		if (m_Iterated >= m_FlashIterations) {
			score.transform.position = m_ScoreStartPosition;
			m_FlashScoreText.transform.position = m_ScoreStartPosition + Vector3.up * 50;
		} else {
			yield return new WaitForSeconds(m_FlashDuration);
			StartCoroutine(FlashScore(!showScore));
		}
	}
    */
}
