using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Linq;
using System.Text;
using UnityEngine.UI;


public class QA
{
    public string Theme { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public QA(string Theme)
    {
        this.Theme = Theme;
    }
}

public class ListTheme : MonoBehaviour
{
    //----------------------------------------------------------------------------
    public GameObject ThemePanel;
    private List<QA> ListThemes = new List<QA>();
    public GameObject themePrefabs;
    public Transform themeParent;
    public GameObject themeDialog;
    public GameObject dialogname;
    private string connectionString;
    public GameObject startBt;

    public GameObject[] Themeslabel;
    public static string[] ThemesGame = new string[4];
    private int paramt = 0;

    // Use this for initialization
    void Start()
    {
       // connectionString = "URI=file:" + "E:/Gir_project/Cleverest/Assets/Cleverest/db/cleverest.sqlite";
		connectionString = "URI=file:" + Application.dataPath + "/Cleverest/db/cleverest.sqlite";
        startBt.SetActive(false);
        ShowThemes();
    }

    public void ClickTheme1()
    {
        paramt = 0;
        ThemePanel.SetActive(!ThemePanel.activeSelf);
    }
    public void ClickTheme2()
    {
        paramt = 1;
        ThemePanel.SetActive(!ThemePanel.activeSelf);
    }
    public void ClickTheme3()
    {
        paramt = 2;
        ThemePanel.SetActive(!ThemePanel.activeSelf);
    }

    public void ClickTheme4()
    {
        paramt = 3;
        ThemePanel.SetActive(!ThemePanel.activeSelf);
    }


    void Update()
    {
        if (ThemeScript.edit)
        {
            dialogname.GetComponent<Text>().text = "Add " + ThemeScript.name + "?";
            themeDialog.SetActive(true);
        }
        else { themeDialog.SetActive(false); }    
    }

    public void ClickOK()
    {
        ThemesGame[paramt] = ThemeScript.name;
        Themeslabel[paramt].GetComponent<Text>().text = ThemesGame[paramt];
        ThemeScript.edit = false;
        ThemePanel.SetActive(!ThemePanel.activeSelf);
    }

    public void ClickBackSelect()
    {
        ThemeScript.edit = false;
    }
    
    public void BackClickTheme()
    {
        ThemePanel.SetActive(!ThemePanel.activeSelf);
        ThemeScript.edit = false;

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
                        ListThemes.Add(new QA(reader.GetString(0)));


                    }
                    reader.Close();
                }

            }

        }
        // ListPlayers.Sort();
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

            QA tmpTheme = ListThemes[i];

            tmpObje.GetComponent<ThemeScript>().SetTheme(tmpTheme.Theme);
            tmpObje.transform.SetParent(themeParent);

        }

    }
}


