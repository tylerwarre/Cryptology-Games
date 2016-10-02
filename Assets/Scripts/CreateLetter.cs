using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateLetter : MonoBehaviour {

    public GameObject Letter1;
    public GameObject Letter2;
    public GameObject Letter3;
    public GameObject Letter4;
    public GameObject Letter5;
    public GameObject Letter6;
    public GameObject Letter7;
    public GameObject Letter8;
    public GameObject Letter9;
    public GameObject Letter10;
    GameObject ranObject;

    int xCoordinate;
    int score;
    int i = 0;

    bool scored1 = false;
    bool scored2 = false;
    bool scored3 = false;

    public Text scoreText;

    string answers1;
    string answers2;
    string answers3;
    int[] answers = new int[3];
    char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
        'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    // Use this for initialization
    void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
        StartCoroutine(WaitCoroutine(3));
    }

    void Update()
    {
        if (answers1 != null && answers2 != null && answers3 != null)
        {
            KeyCode k = new Event().keyCode;

            KeyCode code1 = (KeyCode)k.GetType().GetField(answers1.ToUpper()).GetValue(k);
            KeyCode code2 = (KeyCode)k.GetType().GetField(answers2.ToUpper()).GetValue(k);
            KeyCode code3 = (KeyCode)k.GetType().GetField(answers3.ToUpper()).GetValue(k);

            if (answers1 != null && Input.GetKeyDown(code1) && scored1 != true)
            {
                score++;
                scored1 = true;
                scoreText.text = "Score: " + score;
            }

            if (answers2 != null && Input.GetKeyDown(code2) && scored2 != true)
            {
                score++;
                scored2 = true;
                scoreText.text = "Score: " + score;
            }

            if (answers3 != null && Input.GetKeyDown(code3) && scored3 != true)
            {
                score++;
                scored3 = true;
                scoreText.text = "Score: " + score;
            }
        }
       

        //if (answers1 != null && Input.GetKeyDown(answers2.ToUpper()) && scored2 != true)
        // {
        //    score++;
        //     scored2 = true;
        //    scoreText.text = "Score: " + score;
        //   }

        // if (answers1 != null && Input.GetKeyDown(answers3.ToUpper()) && scored3 != true)
        //  {
        //     score++;
        //     scored3 = true;
        //      scoreText.text = "Score: " + score;
        //  }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameSelect");
        }
    }

    void selectLetter()
    {
        int numSelected;
        numSelected = (Random.Range(1, 10));

        switch (numSelected)
        {
            case 1:
                ranObject = Letter1;
                answers[i] = numSelected; 
                i++;
                break;
            case 2:
                ranObject = Letter2;
                answers[i] = numSelected;
                i++;
                break;
            case 3:
                ranObject = Letter3;
                answers[i] = numSelected;
                i++;
                break;
            case 4:
                ranObject = Letter4;
                answers[i] = numSelected;
                i++;
                break;
            case 5:
                ranObject = Letter5;
                answers[i] = numSelected;
                i++;
                break;
            case 6:
                ranObject = Letter6;
                answers[i] = numSelected;
                i++;
                break;
            case 7:
                ranObject = Letter7;
                answers[i] = numSelected;
                i++;
                break;
            case 8:
                ranObject = Letter8;
                answers[i] = numSelected;
                i++;
                break;
            case 9:
                ranObject = Letter9;
                answers[i] = numSelected;
                i++;
                break;
            case 10:
                ranObject = Letter10;
                answers[i] = numSelected;
                i++;
                break;
            default:
                break;
        }
    }

    void generateCoordinate()
    {
        xCoordinate = Random.Range(-12, 12);
    }

    void parseAsnwers()
    {
        answers[0] = answers[0] - 3 < 1 ? answers[0] - 3 + 26 : answers[0] - 3;  
        char ans1 = (char)(answers[0] + 96);
        answers1 = ans1.ToString();
        Debug.Log(answers[0] + " " + (answers[0] - 3) % 26 + " " + answers1);

        answers[1] = answers[1] - 3 < 1 ? answers[1] - 3 + 26 : answers[1] - 3;
        char ans2 = (char)(answers[1] + 96);
        answers2 = ans2.ToString();
        Debug.Log(answers[1] + " " + (answers[0] - 3) % 26+ " " + answers2);

        answers[2] = answers[2] - 3 < 1 ? answers[2] - 3 + 26 : answers[2] - 3;
        char ans3 = (char)(answers[2] + 96);
        answers3 = ans1.ToString();
        Debug.Log(answers[2] + " " + (answers[0] - 3) % 26 + " " + answers3);
    }

    private IEnumerator WaitCoroutine(int time)
    {
        yield return new WaitForSeconds(time);
        selectLetter();
        generateCoordinate();
        Instantiate(ranObject, new Vector3(xCoordinate, 20, -25), Quaternion.identity);
        yield return new WaitForSeconds(time);
        selectLetter();
        generateCoordinate();
        Instantiate(ranObject, new Vector3(xCoordinate, 20, -25), Quaternion.identity);
        yield return new WaitForSeconds(time);
        selectLetter();
        generateCoordinate();
        Instantiate(ranObject, new Vector3(xCoordinate, 20, -25), Quaternion.identity);
        parseAsnwers();
    }
}
