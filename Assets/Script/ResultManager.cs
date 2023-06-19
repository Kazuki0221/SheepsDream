using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    [Header("睡眠の質パラメータ")]
    [SerializeField] TextMeshProUGUI qualityText;
    [SerializeField] string[] qualityNames;    
    [SerializeField] Color[] textColors = default;
    [SerializeField] Image qualityImg;
    [SerializeField] Sprite[] images = default;
    [SerializeField] Image backGround;
    [SerializeField] Color[] backColors = default;
    [Header("スコア関連")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;


    void Start()
    {
        qualityText.text = qualityNames[GameManager.qualitynum];
        qualityText.color = textColors[GameManager.qualitynum];
        qualityImg.sprite = images[GameManager.qualitynum];
        backGround.color = backColors[GameManager.qualitynum];

        scoreText.text = $"スコア：{GameManager.tempScore}匹";
        highScoreText.text = $"ハイスコア：{GameManager.highScore}匹";
    }

    public void MoveScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
