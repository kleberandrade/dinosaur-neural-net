using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Neuron
{
    public float Gradient { get; set; }
    public float Value { get; set; }
    public List<Synapse> InputSynapses { get; set; }
    public List<Synapse> OutputSynapses { get; set; }
    public float Bias { get; set; }
    public float BiasDelta { get; set; }

    public Neuron()
    {
        InputSynapses = new List<Synapse>();
        OutputSynapses = new List<Synapse>();
        Bias = Random.Range(-1.0f, 1.0f);
    }

    public Neuron(IEnumerable<Neuron> inputNeurons) : this()
    {
        foreach (var inputNeuron in inputNeurons)
        {
            var synapse = new Synapse(inputNeuron, this);
            inputNeuron.OutputSynapses.Add(synapse);
            InputSynapses.Add(synapse);
        }
    }

    public float CalculateValue()
    {
        return Value = Sigmoid.Output(InputSynapses.Sum(x => x.Weight * x.InputNeuron.Value) + Bias);
    }

    public float CalculateError(float target)
    {
        return target - Value;
    }

    public float CalculateGradient(float? target = null)
    {
        if (target == null)
            return Gradient = OutputSynapses.Sum(x => x.OutputNeuron.Gradient * x.Weight) * Sigmoid.Derivative(Value);

        return Gradient = CalculateError(target.Value) * Sigmoid.Derivative(Value);
    }

    public void UpdateWeights(float learnRate, float momentum)
    {
        float prevDelta = BiasDelta;
        BiasDelta = learnRate * Gradient;
        Bias += BiasDelta + momentum * prevDelta;

        foreach (var synapse in InputSynapses)
        {
            prevDelta = synapse.WeightDelta;
            synapse.WeightDelta = learnRate * Gradient * synapse.InputNeuron.Value;
            synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
        }
    }
}