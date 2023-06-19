using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    [Header("�����̎��p�����[�^")]
    [SerializeField] TextMeshProUGUI qualityText;
    [SerializeField] string[] qualityNames;    
    [SerializeField] Color[] textColors = default;
    [SerializeField] Image qualityImg;
    [SerializeField] Sprite[] images = default;
    [SerializeField] Image backGround;
    [SerializeField] Color[] backColors = default;
    [Header("�X�R�A�֘A")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;


    void Start()
    {
        qualityText.text = qualityNames[GameManager.qualitynum];
        qualityText.color = textColors[GameManager.qualitynum];
        qualityImg.sprite = images[GameManager.qualitynum];
        backGround.color = backColors[GameManager.qualitynum];

        scoreText.text = $"�X�R�A�F{GameManager.tempScore}�C";
        highScoreText.text = $"�n�C�X�R�A�F{GameManager.highScore}�C";
    }

    public void MoveScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
