using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Players
{
	public string Name_Player{ get; set;}
	public float Score{ get; set; }

	public Players(string Name_Player, float Score){
		this.Name_Player = Name_Player;
		this.Score = Score;
	}
}

public class QA
{
	public string Theme{ get; set; }
	public string Question{ get; set; }
	public string Answer{ get; set; }

	public QA(string Theme,string Question,string Answer){
		this.Theme = Theme;
		this.Question = Question;
		this.Answer = Answer;
	}
}

public class db_con : MonoBehaviour {
	private string connectionString;
	private List<Players> ListPlayers= new List<Players>();
	public GameObject playerPrefabs;
	public Transform playerParent;
	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
		//DeletePlayer ("Kern");
		//players ();
		//InsertPlayers ("Bogdan", 1100);
		ShowPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
	
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
				dbConnection.Close ();
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
				dbConnection.Close ();
			}
			
		}
	}

	private void players(){
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
						Debug.Log(ListPlayers.ToString());
						//dbConnection.Close();
						//reader.Close();
					}
				}
			
			}

		}
		}

	private void ShowPlayers(){
		players ();
		for (int i=0; i<ListPlayers.Count; i++) {
			GameObject tmpObje=Instantiate(playerPrefabs);

			Players tmpPlayer= ListPlayers[i];

			tmpObje.GetComponent<HightScript>().SetScore(tmpPlayer.Name_Player,tmpPlayer.Score.ToString());
			tmpObje.transform.SetParent(playerParent);
		
		}

	}
		}


