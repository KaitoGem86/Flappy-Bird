using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private bool isFly;
    private int point;

    private void Start()
    {
        point = 0;
    }
    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * 300);
            isFly = true;
            GameManager.instance.Fly();
        }
        else
            isFly = false;
        anim.SetBool("isFly", isFly);
        Debug.Log(GameManager.instance.data.name);
        Debug.Log(GameManager.instance.levelIndex);
    }

    public void GainPoint()
    {
        point += 1;
    }

    public int Point
    {
        get { return point; }
    }
}
