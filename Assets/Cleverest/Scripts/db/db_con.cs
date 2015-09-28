using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class Players : IComparable<Players>
{
	public string Name_Player{ get; set;}
	public float Score{ get; set; }

	public Players(string Name_Player, float Score){
		this.Name_Player = Name_Player;
		this.Score = Score;
	}
	public int CompareTo (Players other)
	{
		if (other.Score < this.Score) {
			return -1;
		}
		else
		if (other.Score > this.Score) {
			return 1;
		} 
		return 0;
	}
}

public class Themes
{
	public string Theme{ get; set; }
	public string Question{ get; set; }
	public string Answer{ get; set; }

    public Themes(string Theme) {
        this.Theme = Theme;
    }
	public Themes(string Theme,string Question,string Answer){
		this.Theme = Theme;
		this.Question = Question;
		this.Answer = Answer;
	}
}

public class db_con : MonoBehaviour {
    public GameObject panel;
	private string connectionString;

	private List<Players> ListPlayers= new List<Players>();
    public GameObject playerPrefabs;
	public Transform playerParent;
    public GameObject namePlayer;
    public InputField enterName;
    public GameObject nameDialog;
//----------------------------------------------------------------------------
    private List<Themes> ListThemes = new List<Themes>();
    public GameObject themePrefabs;
    public GameObject nameTheme;
    public Transform themeParent;
    public InputField themeName;
    public InputField []themeQuestion;
    public InputField []themeAnswer;
    public GameObject themeDialog;
    public GameObject DeletePlayerPanel;

    // Use this for initialization
    void Start () {
		connectionString = "URI=file:" + "E:/Gir_project/Cleverest/Assets/Cleverest/db/cleverest.sqlite";
        ShowPlayers();
        ShowThemes();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
        if (ThemeScript.edit) { Show_editTheme(); }
        if (HightScript.check) {
            namePlayer.GetComponent<Text>().text = "Delete " + HightScript.name + "?";
            DeletePlayerPanel.SetActive(true);
        }
        else { DeletePlayerPanel.SetActive(false); }
    }
    public void ClickOKDletePlayer() {
        DeletePlayer(HightScript.name);
        DeletePlayerPanel.SetActive(false);
        ShowPlayers();
    }
    public void BackDeletePlayer() {
        DeletePlayerPanel.SetActive(false);
        HightScript.check = false;
    }
    public void ADDClick()
    {
            nameDialog.SetActive(!nameDialog.activeSelf);     
    }
    public void ADDClickTheme()
    {
        themeDialog.SetActive(!themeDialog.activeSelf);
        themeName.text = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            themeQuestion[i].text = string.Empty;
            themeAnswer[i].text = string.Empty;
        }
    }
    public void BackClickTheme()
    {
       themeDialog.SetActive(false);
        ThemeScript.edit = false;

    }
    public void BackClick()
    {
        nameDialog.SetActive(false);
    }

    private void InsertPlayers(string name,int newScore){
		using(IDbConnection dbConnection=new SqliteConnection(connectionString))
		{
			dbConnection.Open();
			
			using(IDbCommand dbCmd=dbConnection.CreateCommand())
			{
				string sqlQuery=string.Format ("INSERT INTO Players(Name_Player,Score) VALUES(\'{0}\',\'{1}\')",name,newScore);
				dbCmd.CommandText= sqlQuery;
				dbCmd.ExecuteScalar();

			}
			
		}
	}

    private void InsertThemes(string name, string question,string answer)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                    string sqlQuery = string.Format("INSERT INTO QA(Theme,Question,Answer) VALUES(\'{0}\',\'{1}\',\'{2}\')", name, question, answer);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                
            }

        }
    }

    private void DeletePlayer(string name){
		using(IDbConnection dbConnection=new SqliteConnection(connectionString))
		{
			dbConnection.Open();
			
			using(IDbCommand dbCmd=dbConnection.CreateCommand())
			{
				string sqlQuery=string.Format ("DELETE FROM Players WHERE Name_Player=\'{0}\'",name);
				dbCmd.CommandText= sqlQuery;
				dbCmd.ExecuteScalar();

			}
			
		}
	}

	public void players(){
		ListPlayers.Clear ();
		using(IDbConnection dbConnection=new SqliteConnection(connectionString))
		      {
			dbConnection.Open();

				using(IDbCommand dbCmd=dbConnection.CreateCommand())
			{
				string sqlQuery="SELECT * FROM Players";
				dbCmd.CommandText= sqlQuery;

				using(IDataReader reader=dbCmd.ExecuteReader()){
					while(reader.Read()){
						ListPlayers.Add(new Players(reader.GetString(0),reader.GetFloat(1)));

						
					}
                    reader.Close();
                }
			
			}

		}
		ListPlayers.Sort ();
		}

    private void edittheme(string name)
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
                        ListThemes.Add(new Themes(reader.GetString(0), reader.GetString(1), reader.GetString(2)));


                    }
                    reader.Close();
                }

            }

        }
    }

    public void Show_editTheme() {
            edittheme(ThemeScript.name);
            int i = 0;
            foreach (Themes qa in ListThemes)
            {
                themeName.text = qa.Theme;
                themeQuestion[i].text = qa.Question;
                themeAnswer[i].text = qa.Answer;
                i++;
            }
            themeDialog.SetActive(true);
    }

    private void themes()
    {
        ListThemes.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT DISTINCT Theme FROM QA";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListThemes.Add(new Themes(reader.GetString(0)));
 
                        
                    }
                    reader.Close();
                }

            }

        }
       // ListPlayers.Sort();
    }

    public void ShowPlayers(){
		players ();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Content"))
        {
            Destroy(player);
        }
		for (int i=0; i<ListPlayers.Count; i++) {
			GameObject tmpObje=Instantiate(playerPrefabs);

			Players tmpPlayer= ListPlayers[i];

			tmpObje.GetComponent<HightScript>().SetScore(tmpPlayer.Name_Player,tmpPlayer.Score.ToString());
			tmpObje.transform.SetParent(playerParent);
		
		}

	}

    public void ShowThemes()
    {
        themes();

        foreach (GameObject theme in GameObject.FindGameObjectsWithTag("Theme"))
        {
            Destroy(theme);
        }
        for (int i = 0; i < ListThemes.Count; i++)
        {
            GameObject tmpObje = Instantiate(themePrefabs);

            Themes tmpTheme = ListThemes[i];

            tmpObje.GetComponent<ThemeScript>().SetTheme(tmpTheme.Theme);
            tmpObje.transform.SetParent(themeParent);

        }

    }
    public void EnterName() {
        if (enterName.text != string.Empty)
        {
            int score = 0;
            InsertPlayers(enterName.text, score);
            nameDialog.SetActive(!nameDialog.activeSelf);
            enterName.text = string.Empty;

            ShowPlayers();
        }
    }
    public void EnterTheme()
    {
        if (themeName.text != string.Empty)
        {
            
            
            InsertThemes(themeName.text, themeQuestion[0].text, themeAnswer[0].text);
            InsertThemes(themeName.text, themeQuestion[1].text, themeAnswer[1].text);
            InsertThemes(themeName.text, themeQuestion[2].text, themeAnswer[2].text);
            InsertThemes(themeName.text, themeQuestion[3].text, themeAnswer[3].text);
            InsertThemes(themeName.text, themeQuestion[4].text, themeAnswer[4].text);
            InsertThemes(themeName.text, themeQuestion[5].text, themeAnswer[5].text);
            InsertThemes(themeName.text, themeQuestion[6].text, themeAnswer[6].text);
            InsertThemes(themeName.text, themeQuestion[7].text, themeAnswer[7].text);
            InsertThemes(themeName.text, themeQuestion[8].text, themeAnswer[8].text);
            InsertThemes(themeName.text, themeQuestion[9].text, themeAnswer[9].text);

            themeDialog.SetActive(!themeDialog.activeSelf);
            ShowThemes();
        }
    }
}


