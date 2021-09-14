using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private Vector3 targetPos;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
