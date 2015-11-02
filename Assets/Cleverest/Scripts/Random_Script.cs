using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class QSA
{
    public string Theme { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public QSA(string Theme)
    {
        this.Theme = Theme;
    }

    public QSA(string Theme, string Question, string Answer)
    {
        this.Theme = Theme;
        this.Question = Question;
        this.Answer = Answer;
    }
}


public class Random_Script : MonoBehaviour
{

    public GameObject[] mas = new GameObject[36];
	public int[] mas2 = new int[36];
    public Sprite[] button_skins = new Sprite[5];
    private string connectionString;
    private List<QSA> ListThemes = new List<QSA>();
    private List<QSA> ListTheme1 = new List<QSA>();
    private List<QSA> ListTheme2 = new List<QSA>();
    private List<QSA> ListTheme3 = new List<QSA>();
    public GameObject panelQA;
    public Text panelQAtext;
    public Text textViewAnswer;
    public int numberBT;

    //______________________________________________________
    //------------------------------------------------------
    //______________________________________________________

    private string[] Question = new string[36];
    private string[] Answer = new string[36];

    void Start()
    {
        // connectionString = "URI=file:" + "E:/Gir_project/Cleverest/Assets/Cleverest/db/cleverest.sqlite";
        connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
         Randomize();
        SelectTheme(ListTheme.ThemesGame[0]);
        ListTheme1 = ListThemes;
        SelectTheme(ListTheme.ThemesGame[1]);
        ListTheme2 = ListThemes;
        SelectTheme(ListTheme.ThemesGame[2]);
        ListTheme3 = ListThemes;

        PushTable(ListTheme1, 0);
        PushTable(ListTheme2, 1);
        PushTable(ListTheme3, 2);

    }

    void Color(int count, int color)
    {
        while (count < 10)
        {
            int a = UnityEngine.Random.Range(0, 35);
            if (Sprite.Equals(mas[a].GetComponent<Image>().sprite, null) && count < 10)
            {
                mas[a].GetComponent<Image>().sprite = button_skins[color];
                count++;
            }
        }
    }

    void Randomize()
    {
        for (int i = 0; i < mas.Length; i++)
            mas[i].GetComponent<Image>().sprite = null;

        Color(0, 0);
        Color(0, 1);
        Color(0, 2);

        for (int i = 0; i < 36; i++)
        {
            if (Sprite.Equals(mas[i].GetComponent<Image>().sprite, null))
            {
                mas[i].GetComponent<Image>().sprite = button_skins[3];
            }
        }

		for (int i = 0; i < 36; i++) {
			if (mas [i].GetComponent<Image> ().sprite == button_skins[0])
				mas2 [i] = 0;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[1])
				mas2 [i] = 1;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[2])
				mas2 [i] = 2;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[3])
				mas2 [i] = 3;
		}
    }

	void PushTable(List<QSA> List,int a)
	{
        int i = 0, count = 0;
        while (count < 10) {

            foreach (QSA d in List)
            {

                if (mas2[i] == a)
                {
                    Question[i] = d.Question;
                    Answer[i] = d.Answer;
                    count++;
                }
                i++;
                if (i > 35) { break; }
            }
        }

    }

    private void SelectTheme(string name)
    {
        ListThemes.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("SELECT * FROM QA WHERE THEME=\'{0}\'", name);
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListThemes.Add(new QSA(reader.GetString(0), reader.GetString(1), reader.GetString(2)));

                    }
                    reader.Close();
                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartsGame.st) {
            for (int i = 0; i < 36; i++)
            {
                mas[i].GetComponent<Image>().sprite = button_skins[4];
            }
            StartsGame.st = false;
            Debug.Log(StartsGame.st);
        }

    }

    IEnumerator countpred(int time)
    {
        while (time > -2)
        {

            yield return new WaitForSeconds(1);

            time -= 1;
            if (time < 0) {
                panelQA.SetActive(true);
                
            }
        }

    }

    public void BtNO() {
        panelQA.SetActive(false);
    }

    public void BtYES()
    {
        panelQA.SetActive(false);
    }

    public void BtViewAnswer()
    {
        if (numberBT < 0)
        {
            textViewAnswer.text = "";
        }
        else
        {
            textViewAnswer.text = Answer[numberBT];
        }
    }


    public void ClickBtQA(Text f)
    {
        textViewAnswer.text = "";
        if (mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite == button_skins[4]) {
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 0) {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[0];
                panelQA.GetComponent<Image>().sprite = button_skins[0];
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 1)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[1];
                panelQA.GetComponent<Image>().sprite = button_skins[1];
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 2)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[2];
                panelQA.GetComponent<Image>().sprite = button_skins[2];
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 3)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[3];
                panelQA.GetComponent<Image>().sprite = button_skins[3];
            }
            StartCoroutine(countpred(1));
            panelQAtext.text = Question[Convert.ToInt32(f.GetComponent<Text>().text) - 1];
            numberBT = Convert.ToInt32(f.GetComponent<Text>().text) - 1;
        }
    }
}