using UnityEngine;

public class Ground : MonoBehaviour
{
	public int m_Offset = 0;

    private SpriteRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    public void Start ()
    {
		transform.position += m_Offset * m_Renderer.bounds.size.x * Vector3.right;
	}
	
	public void Update ()
    {
		if (transform.position.x <= -m_Renderer.bounds.size.x) {
            transform.position += 2 * m_Renderer.bounds.size.x * Vector3.right;
        }
	}
}
