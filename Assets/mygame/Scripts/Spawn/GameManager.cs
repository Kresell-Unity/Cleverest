using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject planet;
	public Transform[] spawnPoints; // точки спауну
	public GameObject[] enemyPrefabs; // масив обєктів які спамитумуться
	private GameObject[] spawn_obj; //масив де зберігаються всі заспамлені обєкти
	private int pro = 0;

	public int amountEnemies=1; // загальна кіклькість астероїдів які заспамляться 
	public int count_point_spawn;
	private int a = 0;
	private float x=0,y=0;
	public int yieldTimeMin; // мінімальний час появлення астероїдів(спавну)
	public int yieldTimeMax; // максимальний час появлення астероїдів(спавну)
	private int i;
	private int[] sp={1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,30};

	
	 void point_spaawn(){
	 float pint = (360)/count_point_spawn;
		float cor = (360)/count_point_spawn;
		for (int j =0; j<count_point_spawn; j++) {
			x=8*Mathf.Cos(cor);
			y=8*Mathf.Sin(cor);
			spawnPoints[j].position= new Vector3(x,y,1);
		
			cor+=pint;
		}
	}

	void Start(){
		point_spaawn();

	    
	}
	void Update() 
	{
		a++;
		if(a==140){
			StartCoroutine(spawn());
			a=0;
			
		}
	}
	
	IEnumerator spawn()
	{
		if (ManagerTime.time_min == 0 && ManagerTime.time_sec == 20) {
			amountEnemies = sp [Random.Range (0, 4)];
		}
			if (ManagerTime.time_min == 0 &&ManagerTime.time_sec==50) {
				amountEnemies=sp[Random.Range(2, 5)];
		}
		if (ManagerTime.time_min == 1 && ManagerTime.time_sec == 0) {
			amountEnemies = sp [Random.Range (4, 10)];
		}
			if (ManagerTime.time_min == 1&&ManagerTime.time_sec==30) {
				amountEnemies=sp[Random.Range(5, 6)];
		}
		if (ManagerTime.time_min == 2) {
				amountEnemies=sp[Random.Range(5, 8)];
		}
			if (ManagerTime.time_min == 2&&ManagerTime.time_sec==30) {
				amountEnemies=sp[Random.Range(6, 9)];
		}
		if (ManagerTime.time_min == 3) {
				amountEnemies=sp[Random.Range(6, 10)];
		}
			if (ManagerTime.time_min == 3&&ManagerTime.time_sec==30) {
				amountEnemies=sp[8];
		}
		if (ManagerTime.time_min == 4) {
				amountEnemies=sp[Random.Range(7, 8)];
			}
		if (ManagerTime.time_min == 5) {
				amountEnemies=sp[Random.Range(8, 9)];
		}
		if (ManagerTime.time_min == 6) {
				amountEnemies=sp[Random.Range(9, 10)];
		}
		if (ManagerTime.time_min == 8) {
				amountEnemies=sp[Random.Range(10, 11)];
		}
		if (ManagerTime.time_min == 9) {
			amountEnemies=sp[Random.Range(11,12 )];
		}
		if (ManagerTime.time_min == 9) {
			amountEnemies=sp[Random.Range(18,20 )]+pro;
		}
		if (ManagerTime.time_sec == 20) {
			pro++;
		}

		for (int i = 0; i < amountEnemies; i++)
		{

			if (!Paused.paused)
			{
			GameObject obj = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; 
			Transform pos = spawnPoints[Random.Range(0, spawnPoints.Length)]; 
			Instantiate(obj, pos.position, pos.rotation); 

					


			yield return new WaitForSeconds(Random.Range(yieldTimeMin, yieldTimeMax));
		}
		}
	}	
}