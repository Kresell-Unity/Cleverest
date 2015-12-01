using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class Playerss : IComparable<Playerss>
{
    public string Name_Player { get; set; }
    public float Score { get; set; }

    public Playerss(string Name_Player, float Score)
    {
        this.Name_Player = Name_Player;
        this.Score = Score;
    }
    public int CompareTo(Playerss other)
    {
        if (other.Score < this.Score)
        {
            return -1;
        }
        else
        if (other.Score > this.Score)
        {
            return 1;
        }
        return 0;
    }
}


public class ListView : MonoBehaviour
{
    public GameObject panel;
    private string connectionString;

    private List<Players> ListPlayers = new List<Players>();
    public GameObject playerPrefabs;
    public Transform playerParent;
    public GameObject dialog;
    public GameObject dialogname;
    public GameObject[] Userslabel;
    public static string[] PleyersGame = new string[3];
    private int param = 0;
    public GameObject startBt;

    // Use this for initialization
    void Start()
    {
        //connectionString = "URI=file:" + "E:/Gir_project/Cleverest/Assets/Cleverest/db/cleverest.sqlite";
		//connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
		connectionString = "URI=file:"  +"D:/Cleverest/cleverest.sqlite";
        ShowPlayers();
    }
   public void ClickPlayer1()
    {
        param = 0;
        panel.SetActive(!panel.activeSelf);
    }
    public void ClickPlayer2()
    {
        param = 1;
        panel.SetActive(!panel.activeSelf);
    }
    public void ClickPlayer3()
    {
        param = 2;
        panel.SetActive(!panel.activeSelf);
    }

    public void BackClickPlayers()
    {
        panel.SetActive(!panel.activeSelf);
        HightScript.check = false;

    }


    void Update() {
        if (HightScript.check)
        {
            dialogname.GetComponent<Text>().text = "Add " + HightScript.name + "?";
            dialog.SetActive(true);
        }
        else { dialog.SetActive(false); }

    }

    public void ClickOK() {
        PleyersGame[param] = HightScript.name;
        Userslabel[param].GetComponent<Text>().text = PleyersGame[param];
        HightScript.check = false;
        panel.SetActive(!panel.activeSelf);
    }

    public void ClickBackSelect() {
        HightScript.check = false;
    }

    public void players()
    {
        ListPlayers.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Players";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListPlayers.Add(new Players(reader.GetString(0), reader.GetFloat(1)));


                    }
                    reader.Close();
                }

            }

        }
        ListPlayers.Sort();
    }


    public void ShowPlayers()
    {
        players();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Content"))
        {
            Destroy(player);
        }
        for (int i = 0; i < ListPlayers.Count; i++)
        {
            GameObject tmpObje = Instantiate(playerPrefabs);

            Players tmpPlayer = ListPlayers[i];

            tmpObje.GetComponent<HightScript>().SetScore(tmpPlayer.Name_Player, tmpPlayer.Score.ToString());
            tmpObje.transform.SetParent(playerParent);

        }

    }

    
}


