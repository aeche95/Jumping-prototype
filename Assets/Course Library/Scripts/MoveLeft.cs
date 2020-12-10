using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    float speed = 25;
    float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       if(transform.position.x<leftBound && gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.IncreaseScore();
            Destroy(gameObject);

        }
    }
}
