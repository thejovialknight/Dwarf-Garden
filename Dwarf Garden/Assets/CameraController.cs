using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, MatchManager.Instance.CurrentPlayer().ActiveUnit().transform.position, lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
