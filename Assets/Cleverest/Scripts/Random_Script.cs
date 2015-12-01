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
    public GameObject[] Players = new GameObject[3];
    public GameObject[] PlayersGM = new GameObject[3];
    private int[] mas2 = new int[36];
    public Sprite[] button_skins = new Sprite[5];
    private string connectionString;
    private List<QSA> ListTheme1 = new List<QSA>();
    private List<QSA> ListTheme2 = new List<QSA>();
    private List<QSA> ListTheme3 = new List<QSA>();
    private List<QSA> ListTheme4 = new List<QSA>();
    public GameObject panelQA;

    public Text panelQAtext;
    public Text textViewAnswer;
    private int numberBT;

    private int score = 0;
    private int[] Pl= new int[3];
    private int turn=0;

    //______________________________________________________
    //------------------------------------------------------
    //______________________________________________________

    public GameObject paneGameOver;
    private int countGameOver = 0;

    //______________________________________________________
    //------------------------------------------------------
    //______________________________________________________

    private string[] Question = new string[36];
    private string[] Answer = new string[36];

    void Start()
    {
        // connectionString = "URI=file:" + "E:/Gir_project/Cleverest/Assets/Cleverest/db/cleverest.sqlite";
        //connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
		connectionString = "URI=file:"  +"D:/Cleverest/cleverest.sqlite";
         Randomize();
 
        SelectTheme(ListTheme.ThemesGame[0], ListTheme1);
        SelectTheme(ListTheme.ThemesGame[1], ListTheme2);
        SelectTheme(ListTheme.ThemesGame[2], ListTheme3);
        SelectTheme(ListTheme.ThemesGame[3],ListTheme4);

        PushTable(ListTheme1, 0);
        PushTable(ListTheme2, 2);
        PushTable(ListTheme3, 1);
        PushTable(ListTheme4, 3);

        paneGameOver.SetActive(false); 

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
        if (a < 3)
        {
            while (count < 10)
            {

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
        else {
            while (count < 6)
            {

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

    }

    private void SelectTheme(string name, List<QSA> L)
    {
        L.Clear();
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
                        L.Add(new QSA(reader.GetString(0), reader.GetString(1), reader.GetString(2)));

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

        for (int i = 0; i < 3; i++)
        {
            Players[i].GetComponent<Text>().text = ListView.PleyersGame[i] + " " + Pl[i];
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
		panelQA.SetActive (false);
		score = 0;
		if (countGameOver == 36) {
			paneGameOver.SetActive (true);
			for (int i = 0; i < 3; i++) {
				PlayersGM [i].GetComponent<Text> ().text = ListView.PleyersGame [i] + " " + Pl [i];
			}
			using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
				dbConnection.Open ();
				
				using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery1 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [0], ListView.PleyersGame [0]);
				dbCmd.CommandText = sqlQuery1;
				string sqlQuery2 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [1], ListView.PleyersGame [1]);
				dbCmd.CommandText = sqlQuery2;
				string sqlQuery3 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [2], ListView.PleyersGame [2]);
				dbCmd.CommandText = sqlQuery3;
				}
			}
		}
	}
		
		public void BtYES()
		{
			panelQA.SetActive(false);
			if (turn == 1) { Pl[0] += score; }
        if (turn == 2) { Pl[1] += score; }
        if (turn == 3) { Pl[2] += score; }
        score = 0;
        if (countGameOver==36) { paneGameOver.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                PlayersGM[i].GetComponent<Text>().text = ListView.PleyersGame[i] + " " + Pl[i];
            }
			using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
				dbConnection.Open ();
				
				using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
					string sqlQuery1 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [0], ListView.PleyersGame [0]);
					dbCmd.CommandText = sqlQuery1;
					string sqlQuery2 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [1], ListView.PleyersGame [1]);
					dbCmd.CommandText = sqlQuery2;
					string sqlQuery3 = string.Format ("UPDATE Players set Score=\'{0}\'  where Name_Player =\'{1}\'", Pl [2], ListView.PleyersGame [2]);
					dbCmd.CommandText = sqlQuery3;
				}
			} 
        }
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
        if (turn == 3) { turn = 0; }
            turn++;
        textViewAnswer.text = "";
        if (mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite == button_skins[4]) {
            countGameOver++;
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 0) {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[0];
                panelQA.GetComponent<Image>().sprite = button_skins[0];
                if (turn == 1) { score = 2; }
                else
                {
                    if (turn == 2 || turn == 3) { score = 3; } else { score = 1; }
                }              
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 1)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[1];
                panelQA.GetComponent<Image>().sprite = button_skins[1];
                if (turn == 3) { score = 2; }
                else
                {
                    if (turn == 2 || turn == 1) { score = 3; } else { score = 1; }
                }
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 2)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[2];
                panelQA.GetComponent<Image>().sprite = button_skins[2];
                if (turn == 2) { score = 2; }
                else
                {
                    if (turn == 1 || turn == 3) { score = 3; } else { score = 1; }
                }
            }
            if (mas2[Convert.ToInt32(f.GetComponent<Text>().text) - 1] == 3)
            {
                mas[Convert.ToInt32(f.GetComponent<Text>().text) - 1].GetComponent<Image>().sprite = button_skins[3];
                panelQA.GetComponent<Image>().sprite = button_skins[3];
                if (turn == 1) { score= 1; }
                if (turn == 2) { score= 1; }
                if (turn == 3) { score= 1; }
            }
            StartCoroutine(countpred(0));
            panelQAtext.text = Question[Convert.ToInt32(f.GetComponent<Text>().text) - 1];
            numberBT = Convert.ToInt32(f.GetComponent<Text>().text) - 1;
        }        
    }
}