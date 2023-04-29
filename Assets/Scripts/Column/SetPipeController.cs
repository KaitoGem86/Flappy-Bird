using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetPipeController : MonoBehaviour
{
    [SerializeField] private PipeController topPipe;
    [SerializeField] private PipeController bottomPipe;
    [SerializeField] private CheckPointController checkPoint;


    private LevelData data;
    private float existTime = 8;    

    private void Start()
    {
        SetColumn();
    }

    private void Update()
    {
        MovePipe();
    }


    private void SetCheckPoint()
    {
        //checkPoint.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
        Vector2 topPos = topPipe.transform.position;

        Vector2 checkPointSize = new Vector2(0.7f, Random.Range(GameManager.instance.data.lowestCheckPointSize, GameManager.instance.data.highestCheckPointSize));
        //Vector2 checkPointSize = new Vector2(0.7f, Random.Range(3.1f, 5f));
        checkPoint.GetComponent<BoxCollider2D>().size = checkPointSize;
        
        Vector2 checkPointPos = checkPoint.transform.position;
        checkPointPos.y = topPos.y - topPipe.GetComponent<BoxCollider2D>().size.y / 2 - checkPointSize.y/2 - 0.15f;
        checkPointPos.x = topPos.x + 0.05f;

        checkPoint.transform.position = checkPointPos;
    }

    private void SetPositionTwoPipes()
    {
        Vector2 topPos = topPipe.transform.position;
        Vector2 bottomPos = bottomPipe.transform.position;
        Vector2 checkPointSize = checkPoint.GetComponent<BoxCollider2D>().size;

        bottomPos.y = topPos.y - checkPointSize.y - topPipe.GetComponent<BoxCollider2D>().size.y - 0.3f ; 
        bottomPos.x = topPos.x;

        bottomPipe.transform.position = bottomPos;
    }

    public void SetColumn()
    {
        SetCheckPoint();
        SetPositionTwoPipes();
        Vector2 pos = new Vector2();
        pos.x = this.transform.position.x;
        pos.y = Random.Range(6f, 9f);
        transform.position = pos;
    }

    private void MovePipe()
    {
        Vector2 pos = transform.position;
        pos.x -= GameManager.instance.data.speed * Time.deltaTime;
        transform.position = pos;

        existTime -= Time.deltaTime;
        if(existTime < 0)
            Destroy(gameObject);
    }
}
