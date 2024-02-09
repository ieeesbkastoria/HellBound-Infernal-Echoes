using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour {
    [SerializeField] private RawImage _img;
    [SerializeField] private float _speed;

    void Update()
    {
        // Only modify the X component of the position vector
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_speed, 0) * Time.deltaTime, _img.uvRect.size);
    }
}

