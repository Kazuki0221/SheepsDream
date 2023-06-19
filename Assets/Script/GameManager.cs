using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("ゲーム時間")] float time;
    [SerializeField, Header("生成のタイミング")] float createTime = 2f;
    [SerializeField, Header("動物オブジェクト")] GameObject[] animalObj = default;
    AnimalController animalController;
    public static int highScore;
    public static int tempScore;
    public static int qualitynum = 0;
    int score = 0;
    int combo = 0;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image comboImg;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] Slider gage;
    float gagePoint;
    const float maxPoint = 10;

    bool isGame = true;
    public bool isPause = false;

    private void Start()
    {
        gage.value = 0;
        gagePoint = 0;

        comboImg.enabled= false;
        comboText.enabled= false;
    }

    void Update()
    {
        if(isGame)
        {
            if (isPause == false)
            {
                if (gagePoint == maxPoint)
                {
                    isGame = false;
                    return;
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    isPause = true;
                }

                if (time <= 0)
                {
                    isGame = false;
                }
                createTime -= Time.deltaTime;
                time -= Time.deltaTime;
                if (createTime <= 0)
                {
                    SelectedAnimal();
                    var rand = Random.Range(0, 101);
                    if (rand >= 0 && rand < 50)
                    {
                        animalController.SetKind(AnimalController.Kind.Normal);
                    }
                    else if (rand >= 50 && rand < 70)
                    {
                        animalController.SetKind(AnimalController.Kind.Slow);
                    }
                    else if (rand >= 70 && rand < 90)
                    {
                        animalController.SetKind(AnimalController.Kind.Fast);
                    }
                    else if (rand >= 90 && rand < 101)
                    {
                        animalController.SetKind(AnimalController.Kind.Bound);
                    }
                    createTime = 2f;
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    isPause = false;
                }
            }

        }
        else
        {
            if(score <= 10 || gagePoint == maxPoint)
            {
                qualitynum = 0;
            }
            else if(score <= 25)
            {
                qualitynum = 1;
            }
            else
            {
                qualitynum = 2;
            }

            tempScore = score;

            if(highScore < score)
            {
                highScore = score;
            }
            SceneManager.LoadScene("ResultScene");
        }

        scoreText.text = $"{score}匹";
        timeText.text = time.ToString("0");
    } 
    public void SelectedAnimal()
    {
        var rand = Random.Range(0, 101);
        if( rand >= 0 && rand < 70 )//ヒツジ生成
        {
            var animal = Instantiate(animalObj[0], transform.position, animalObj[0].transform.rotation);
            animalController = animal.GetComponent<AnimalController>();
        }
        else if(rand >= 70 && rand < 90)//オオカミ生成
        {
            var animal = Instantiate(animalObj[1], transform.position, animalObj[1].transform.rotation);
            animalController = animal.GetComponent<AnimalController>();
        }
        else
        {
            var animal = Instantiate(animalObj[2], transform.position, animalObj[2].transform.rotation);
            animalController = animal.GetComponent<AnimalController>();
        }
    }

    public void AddScore(bool gold)
    {
        if(gold)
        {
            score += 5;
        }
        else
        {
            score++;
        }
    }

    public void AddCombo(bool hit)
    {
        if(hit)
        {
            combo++;
            if (combo > 1)
            {
                comboImg.enabled = true;
                comboText.enabled = true;
            }

            comboText.text = $"{combo}Combo!";
        }
        else
        {
            score += 2 * combo;
            combo = 0;

            comboImg.enabled = false;
            comboText.enabled = false;
        }
    }

    public void ConcededScore()
    {
        score--;
    }

    public void UpdateGage(bool isavoid)
    {
        if(isavoid && gagePoint > 0)
        {
            gagePoint--;
        }
        else if(!isavoid)
        {
            gagePoint++;
        }
        gage.value = gagePoint / maxPoint;
    }

}
