using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    float timer;
    TextMeshProUGUI scoreText;
    Vector3 startPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        startPos = player.transform.position;
        scoreText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = timer.ToString("F2");
        scoreText.text = Vector3.Distance(startPos, player.transform.position).ToString("F2");
    }
}
