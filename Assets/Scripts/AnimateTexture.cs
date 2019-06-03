using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour
{
	public Renderer m_Renderer = null;
	public Vector2 m_Direction = Vector2.up;
	public float m_SpeedMultiplier = 1;

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void Update ()
    {
		m_Renderer.material.mainTextureOffset += m_Direction.normalized * Time.deltaTime * LevelManager.Instance.m_MainSpeed * m_SpeedMultiplier * m_Renderer.material.mainTextureScale.x / transform.localScale.x;
	}
}
