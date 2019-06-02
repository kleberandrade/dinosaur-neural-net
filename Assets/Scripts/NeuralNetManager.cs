using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetManager : MonoBehaviour
{
    public static NeuralNetManager Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public List<DataSet> m_DataSets = new List<DataSet>();
    private NeuralNet m_Net;
    
    public float m_MinimumError = 0.1f;
    private bool m_Trained;
    public int m_MaxDataSetNumber = 50;

    [Header("Agent")]
    public Player m_Player;

    private void Start()
    {
        m_Net = new NeuralNet(4, 2, 3);
    }

    private void Update()
    {
        if (m_Trained)
        {
            float[] outputs = m_Net.Compute(new float[] {
                                    m_Player.m_ObstacleDistance,
                                    m_Player.m_ObstacleVelocity,
                                    m_Player.m_ObstaclePosition,
                                    m_Player.m_ObstacleHeight
                                }
                              );

            if (outputs[0] > 0.5f)
                m_Player.DoJump();

            if (outputs[1] > 0.5f)
                m_Player.DoCrouch();
        }
    }

    public void Train(DataSet dataSet)
    {
        m_DataSets.Add(dataSet);
        if (!m_Trained && m_DataSets.Count == m_MaxDataSetNumber)
        {
            Debug.Log("Start training of the network...");
            TrainNetwork();
        }
    }

    private void TrainNetwork()
    {
        m_Net.Train(m_DataSets, m_MinimumError);
        m_Trained = true;
        Debug.Log("Network trained!");
    }
}
