using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // arvo 0-1 välillä, mitä isompi arvo on sitä nopeammin kamera lukottautuu targettiin
    public Vector3 offset, desiredPosition, smoothedPosition;

    private Camera thisCamera;
    private float halfHeight, halfWidth;


    public void Start()
    {
        thisCamera = GetComponent<Camera>();

        halfHeight = thisCamera.orthographicSize; // Orthographic Size = 1x unit unityssä eli yksi neliö, tässä tapauksessa.                                             
        halfWidth = halfHeight * Screen.width / Screen.height; // koko on 5 ja se kerrotaan näytön leveys jaettuna korkeudella.
    }

    public void LateUpdate() // LateUpdatea tulee aina kutsua kaiken muun jälkeen.
    {
        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //Lerp = Linear interpolation, prosessi millä pääsee smootisti paikasta A paikaan B
        transform.position = target.position + offset;
        transform.LookAt(target);

     
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
