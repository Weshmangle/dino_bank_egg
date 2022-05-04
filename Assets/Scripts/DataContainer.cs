using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class DataContainer : ScriptableObject
{
    public string nameContainer;
    public int limit;
    public float cost;
    public float factorLimit;
    public float factorCost;
}
