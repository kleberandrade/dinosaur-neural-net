using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Sensors")]
    public float m_ObstacleDistance;
    public float m_ObstacleVelocity;
    public float m_ObstacleHeight;
    public float m_ObstaclePosition;

    [Header("Actions")]
    public float m_Jump = 0.0f;
    public float m_Crouch = 0.0f;

    private Rigidbody m_Body;
    private DataSet m_DataSet;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            DoJump();

        if (Input.GetButton("Fire1"))
            DoCrouch();
        else
            m_Crouch = 0.0f;
    }

    private void SaveSensors()
    {
        m_DataSet = new DataSet();

        m_DataSet.Values = new float[] {
            m_ObstacleDistance,
            m_ObstacleVelocity,
            m_ObstaclePosition,
            m_ObstacleHeight
        };

        m_DataSet.Targets = new float[]
        {
            m_Jump,
            m_Crouch
        };
    }

    private void SuccessAction()
    {
        NeuralNetManager.Instance.Train(m_DataSet);
    }

    private void WrongAction()
    {

    }

    public void DoCrouch()
    {
        m_Crouch = 1.0f;
        Debug.Log("DoCrouch");
        SaveSensors();
    }

    public void DoJump()
    {
        m_Jump = 1.0f;
        Debug.Log("DoCrouch");
        SaveSensors();
    }
}
