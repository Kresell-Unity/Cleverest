using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Players
{

	public int Id{ get; set; }
	public string Name_Player{ get; set;}
	public float Score{ get; set; }
}

public class QA
{
	public int ID{ get; set; }
	public string Theme{ get; set; }
	public string Question{ get; set; }
	public string Answer{ get; set; }
}

public class db_con : MonoBehaviour {
	private string connectionString;
	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
		players ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void players(){
		using(IDbConnection dbConnection=new SqliteConnection(connectionString))
		      {
			dbConnection.Open();

				using(IDbCommand dbCmd=dbConnection.CreateCommand())
			{
				string sqlQuery="SELECT * FROM Players";
				dbCmd.CommandText= sqlQuery;

				using(IDataReader reader=dbCmd.ExecuteReader()){
					while(reader.Read()){
						Debug.Log(reader.GetString(0));
						Debug.Log (reader.GetFloat(1));
						//dbConnection.Close();
						//reader.Close();
					}
				}
			
			}
			
		}
		}
		}


