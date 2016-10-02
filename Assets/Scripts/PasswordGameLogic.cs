using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PasswordGameLogic : MonoBehaviour
{

    private GameObject[,] gameObjs;
    Dictionary<int, string> dictionary;
    private int[] shownNumbers;

    private string pwd;
    private int pwdLength;
    private int pwdIndex;
    public Text infoText;

    private float pos1;
    private float pos2;
    private float pos3;
    private float pos4;
    private float pos5;
    private float pos6;



    void Start()
    {
        infoText.text = "";
        getAllGameObjects();
        addValuesToDict();

        showHideNumbers();
        pwdLength = 1;
        pwdIndex = 0;
        pwd = generatePassword(pwdLength);
        Debug.Log(pwd);

    }

    void OnTriggerEnter(Collider letter)
    {
        if (letter.ToString()[0] == pwd[pwdIndex])
        {
            if (pwdIndex + 1 < pwd.Length)
            {
                pwdIndex++;
                infoText.text = "Good guess! Current Password so far: " + pwd.Substring(0, pwdIndex);
            }
            else
            {
                if (pwdLength >= 5)
                {
                    infoText.text = "Well done! You have completed all levels!";
                    return;
                }

                infoText.text = "Nice! The password was " + pwd + ". Get ready for the next level.";
                StartCoroutine(WaitCoroutine(3));
            }
        }
        else
        {
            infoText.text = "Incorrect! Try again!";
        }
    }

    private IEnumerator WaitCoroutine(int time)
    {
        yield return new WaitForSeconds(time);
        transform.position = new Vector3(0, 3.5f, 0);
        showHideNumbers();
        pwdLength += 2;
        pwdIndex = 0;
        pwd = generatePassword(pwdLength);
        infoText.text = "";
        Debug.Log(pwd);
    }

    void getAllGameObjects()
    {
        gameObjs = new GameObject[6, 6];

        gameObjs[0, 0] = GameObject.Find("A1");
        gameObjs[0, 1] = GameObject.Find("B1");
        gameObjs[0, 2] = GameObject.Find("C1");
        gameObjs[0, 3] = GameObject.Find("D1");
        gameObjs[0, 4] = GameObject.Find("E1");
        gameObjs[0, 5] = GameObject.Find("F1");

        gameObjs[1, 0] = GameObject.Find("A2");
        gameObjs[1, 1] = GameObject.Find("B2");
        gameObjs[1, 2] = GameObject.Find("C2");
        gameObjs[1, 3] = GameObject.Find("D2");
        gameObjs[1, 4] = GameObject.Find("E2");
        gameObjs[1, 5] = GameObject.Find("F2");

        gameObjs[2, 0] = GameObject.Find("A3");
        gameObjs[2, 1] = GameObject.Find("B3");
        gameObjs[2, 2] = GameObject.Find("C3");
        gameObjs[2, 3] = GameObject.Find("D3");
        gameObjs[2, 4] = GameObject.Find("E3");
        gameObjs[2, 5] = GameObject.Find("F3");

        gameObjs[3, 0] = GameObject.Find("A4");
        gameObjs[3, 1] = GameObject.Find("B4");
        gameObjs[3, 2] = GameObject.Find("C4");
        gameObjs[3, 3] = GameObject.Find("D4");
        gameObjs[3, 4] = GameObject.Find("E4");
        gameObjs[3, 5] = GameObject.Find("F4");

        gameObjs[4, 0] = GameObject.Find("A5");
        gameObjs[4, 1] = GameObject.Find("B5");
        gameObjs[4, 2] = GameObject.Find("C5");
        gameObjs[4, 3] = GameObject.Find("D5");
        gameObjs[4, 4] = GameObject.Find("E5");
        gameObjs[4, 5] = GameObject.Find("F5");

        gameObjs[5, 0] = GameObject.Find("A6");
        gameObjs[5, 1] = GameObject.Find("B6");
        gameObjs[5, 2] = GameObject.Find("C6");
        gameObjs[5, 3] = GameObject.Find("D6");
        gameObjs[5, 4] = GameObject.Find("E6");
        gameObjs[5, 5] = GameObject.Find("F6");
    }

    void addValuesToDict()
    {
        dictionary = new Dictionary<int, string>();

        dictionary.Add(0, "A");
        dictionary.Add(1, "B");
        dictionary.Add(2, "C");
        dictionary.Add(3, "D");
        dictionary.Add(4, "E");
        dictionary.Add(5, "F");
    }

    void showHideNumbers()
    {
        shownNumbers = new int[6];
        for (int i = 0; i < 6; i++)
        {
            shownNumbers[i] = Random.Range(0, 6);

            gameObjs[i, shownNumbers[i]].SetActive(true);
            for (int j = 0; j < 6; j++)
            {
                if (shownNumbers[i] == j) continue;
                gameObjs[i, j].SetActive(false);
            }

        }
    }

    string generatePassword(int n)
    {
        int[] shownNumbersCopy = (int[])shownNumbers.Clone();
        string pwd = "";
        for (int i = 0; i < n; i++)
        {
            int rnd = Random.Range(0, 6);
            while (shownNumbersCopy[rnd] == -1)
            {
                rnd++;
                if (rnd == 6) rnd = 0;
            }

            pwd += dictionary[shownNumbersCopy[rnd]];
            shownNumbersCopy[rnd] = -1;


        }
        return pwd;
    }
}