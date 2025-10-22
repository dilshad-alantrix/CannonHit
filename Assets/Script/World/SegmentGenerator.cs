using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class Segment
{
     public string type;
     public GameObject[] prefab;
    
}
public class SegmentGenerator : MonoBehaviour
{
    [Header("Segment")]
    [SerializeField] private Segment[] segments;

    [Header("Player and Floor Settings")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float floorLength;
    [SerializeField] private int maxSegmentCound;
    [SerializeField] private int initialSegmentCound;

    private float spawnZ = 0;
    private Queue<GameObject> segmentQueue = new();




    void Start()
    {
        for (int i = 0; i < initialSegmentCound; i++)
        {
            StartspawnSegment();
        }
    }


    void Update()
    {
        if (playerTransform.position.z > spawnZ - (floorLength * maxSegmentCound))
        {
            spawnSegment();
            removeSegment();
        }
    }

    private void spawnSegment()
    {
        Segment segmentData = segments[0];
        GameObject prefab = segmentData.prefab[UnityEngine.Random.Range(0, segmentData.prefab.Length - 1)];
        Vector3 spawnPoint = new Vector3(0, 0, spawnZ);
        GameObject newSegment = Instantiate(prefab, spawnPoint, quaternion.identity);
        segmentQueue.Enqueue(newSegment);
        spawnZ += floorLength;
    }
    
    private void StartspawnSegment()
    {
        Segment segmentData = segments[0];
        GameObject prefab = segmentData.prefab[0];
        Vector3 spawnPoint = new Vector3(0, 0, spawnZ);
        GameObject newSegment = Instantiate(prefab, spawnPoint, quaternion.identity);
        segmentQueue.Enqueue(newSegment);
        spawnZ += floorLength;
    }

    private void removeSegment()
    {
        if (segmentQueue.Count > maxSegmentCound+1)
        {
            GameObject oldSegment = segmentQueue.Dequeue();
            Destroy(oldSegment);
        }
    }
}
