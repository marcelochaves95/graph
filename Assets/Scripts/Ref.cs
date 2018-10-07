﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ref : MonoBehaviour {
    
    [SerializeField] private int size;

    [SerializeField] private float granularity;

    [SerializeField] private GameObject initialVertex;
    [SerializeField] private GameObject vertexPrefab;
    public GameObject[,] vertexMatrix;

    private void Start () {
        InitializeMatrix(size);
        CreateVertex();
        DrawEdges(vertexMatrix);
    }

    private void CreateVertex () {
        int iterations = (int)(size / granularity);
        for (int i = 0; i < iterations; i++) {
            for (int j = 0; j < iterations; j++) {
                Vector3 relativePosToSeed = new Vector3(i * granularity, 0, j * granularity);
                GameObject vertex = Instantiate(vertexPrefab, initialVertex.transform.position + relativePosToSeed, Quaternion.identity);
                vertex.name = "v_" + i.ToString() + "," + j.ToString();
                vertexMatrix[i, j] = vertex;
            }
        }
    }
    
    private void DrawEdges (GameObject[,] m) {
        for (int i = 0; i < m.Length-1; i++) {
            for (int j = 0; j < m.Length-1; j++) {
                if (j+1 < m.Length) Debug.DrawLine(m[i, j].transform.position, m[i, j + 1].transform.position, Color.blue, 10000);
                if (i+1 < m.Length) Debug.DrawLine(m[i, j].transform.position, m[i+1, j].transform.position, Color.blue, 10000);
            }   
        }
    } 

    private void InitializeMatrix (int size) {
        vertexMatrix = new GameObject[size * size, size * size];
    }
}