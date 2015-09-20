using UnityEngine;
using System.Collections;

using System.Collections.Generic;
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

	// Use this for initialization
	void Start () {
		using (var db=new SqliteConnection(Application.dataPath+"/Cleverest/db/cleverest.sqlite")) {
			//IEnumerable<Players> list=db.Query<Players>("SELECT * FROM weapons");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
