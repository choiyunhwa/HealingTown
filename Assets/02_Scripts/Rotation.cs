using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRanderer;
    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>(); 
    }

    private void Start()
    {
        controller.OnLookEvent += RotationAram;
    }

    private void RotationAram(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerRanderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}

