using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NeuralNet
{
    public float LearnRate { get; set; }
    public float Momentum { get; set; }
    public List<Neuron> InputLayer { get; set; } = new List<Neuron>();
    public List<List<Neuron>> HiddenLayer { get; set; } = new List<List<Neuron>>();
    public List<Neuron> OutputLayer { get; set; } = new List<Neuron>();

    public NeuralNet(int inputNumbers, int outputNumbers, int hiddenNumbers, int hiddenLayerNumbers = 1, float learnRate = 0.1f, float momentum = 0.9f)
    {
        for (int i = 0; i < inputNumbers; i++)
            InputLayer.Add(new Neuron());

        for (int i = 0; i < hiddenLayerNumbers; i++)
        {
            HiddenLayer.Add(new List<Neuron>());
            for (int j = 0; j < hiddenNumbers; j++)
                HiddenLayer[i].Add(new Neuron(i == 0 ? InputLayer : HiddenLayer[i - 1]));
        }

        for (int i = 0; i < outputNumbers; i++)
            InputLayer.Add(new Neuron(HiddenLayer[hiddenLayerNumbers - 1]));
    }

    private void ForwardPropagate(params float[] inputs)
    {
        int i = 0;
        InputLayer.ForEach(neuron => neuron.Value = inputs[i++]);

        foreach (var layer in HiddenLayer)
            layer.ForEach(neuron => neuron.CalculateValue());

        OutputLayer.ForEach(neuron => neuron.CalculateValue());
    }

    public float[] Compute(params float[] inputs)
    {
        ForwardPropagate(inputs);
        float[] outputs = new float[OutputLayer.Count];
        for (int i = 0; i < OutputLayer.Count; i++)
            outputs[i] = OutputLayer[i].Value;

        return outputs;
    }

    private void BackwardPropagate(params float[] targets)
    {
        int i = 0;
        OutputLayer.ForEach(neuron => neuron.CalculateGradient(targets[i++]));
        for (i = HiddenLayer.Count - 1; i >= 0; i--)
        {
            HiddenLayer[i].ForEach(neuron => neuron.CalculateGradient());
            HiddenLayer[i].ForEach(neuron => neuron.UpdateWeights(LearnRate, Momentum));
        }
        OutputLayer.ForEach(neuron => neuron.UpdateWeights(LearnRate, Momentum));
    }

    public void Train(List<DataSet> dataSets, int numEpochs)
    {
        for (int i = 0; i < numEpochs; i++)
        {
            foreach (var dataSet in dataSets)
            {
                ForwardPropagate(dataSet.Values);
                BackwardPropagate(dataSet.Targets);
            }
        }
    }

    public float CalculateError(params float[] targets)
    {
        int i = 0;
        return OutputLayer.Sum(x => Mathf.Abs(x.CalculateError(targets[i++])));
    }

    public void Train(List<DataSet> dataSets, float minimumError)
    {
        float error = 1.0f;
        int epochs = 0;
        while (error > minimumError && epochs < int.MaxValue)
        {
            List<float> errors = new List<float>();
            foreach (var dataSet in dataSets)
            {
                ForwardPropagate(dataSet.Values);
                BackwardPropagate(dataSet.Targets);
                errors.Add(CalculateError(dataSet.Targets));
            }
            error = errors.Average();
            epochs++;
        }
    }

    public enum TrainingType
    {
        Epoch,
        MinimumError
    }
}
