using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synapse
{
    public Neuron InputNeuron { get; set; }
    public Neuron OutputNeuron { get; set; }
    public float Weight { get; set; }
    public float WeightDelta { get; set; }

    public Synapse(Neuron inputNeuron, Neuron outputNeuron)
    {
        InputNeuron = inputNeuron;
        OutputNeuron = outputNeuron;
        Weight = Random.Range(-1.0f, 1.0f);
    }
}