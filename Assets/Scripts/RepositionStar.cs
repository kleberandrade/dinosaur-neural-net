using UnityEngine;

public class RepositionStar : MonoBehaviour
{
	public float m_MinStart = -500f;
	public float m_MaxStart = 500f;
	private bool m_IsNight = false;

    public void Start()
    {
        Animator animator = GetComponent<Animator>();
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, -1, Random.value);

        transform.position = new Vector3(m_MinStart + Random.value * (m_MaxStart - m_MinStart), 0.3333333333f + Random.value * 4.6666666667f, 0f);
    }

    public void Update ()
    {
		if (!m_IsNight && TimeOfDay.Instance.IsNight())
        {
			transform.position = new Vector3(m_MinStart + Random.value * (m_MaxStart - m_MinStart), 0.3333333333f + Random.value * 4.6666666667f, 0f);
		}

		m_IsNight = TimeOfDay.Instance.IsNight();
	}
}
