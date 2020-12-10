using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatwidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatwidth = GetComponent<BoxCollider>().size.x / 2;
        GameManager.Instance.resetEvent.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatwidth)
        {
            transform.position = startPos;
        }
    }

    void Restart()
    {
        gameObject.transform.position = startPos;
    }
}
