using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Randomize : MonoBehaviour {

	public GameObject sampleA; //Sheep
	public List<GameObject> bodyPartsA;

	[Space(15)]
	public GameObject sampleB;	//Crocodile
	public List<GameObject> bodyPartsB;

	[Space(10)]
	public Transform spawnPosA;
	public Transform spawnPosB;

	public GameObject sampleX;

	private GameObject egg;
	private GameObject specamin;

	public List<GameObject> bodyPartsX;
	public List<Texture> errors;
	public List<GameObject> animals;

	public int generation;

	public Text countText;

	GameObject body = null;
	GameObject head = null;
	GameObject foot = null;
	GameObject tail = null;

	// Use this for initialization
	void Start () {
		InstantiateCreature();
	}

	void InstantiateCreature(){

		if(sampleA == null){
			int randomAnimal = Random.Range(0,animals.Count);
			GameObject a = Instantiate(animals[randomAnimal],spawnPosA.position,Quaternion.identity) as GameObject;
			sampleA = animals[randomAnimal];
			sampleA = a;
		}else{
			sampleA.transform.position = spawnPosA.position;
		}

		int randomAnimalB = Random.Range(0,animals.Count);
		GameObject b = Instantiate(animals[randomAnimalB],spawnPosB.position,Quaternion.identity) as GameObject;
		sampleB = animals[randomAnimalB];
		sampleB = b;
	}

	

	void CreateCreature(){
		sampleA.SetActive(false);
		sampleB.SetActive(false);

		specamin = Instantiate(sampleX,new Vector2(0,0),Quaternion.identity) as GameObject;

		egg = Instantiate(sampleX,new Vector2(0,0),Quaternion.identity) as GameObject;

		Debug.Log("children for object XXX " + specamin.transform.childCount);
		egg.name = "freddy";


	

		int randomBody = Random.Range(0,2);
		if(randomBody == 0){
			//Sheeps body
			bodyPartsX.Add(sampleA.transform.GetChild(0).gameObject);
			//sampleA.transform.GetChild(0).transform.parent = sampleX.transform;
		}else{
			//Crocodile body
			bodyPartsX.Add(sampleB.transform.GetChild(0).gameObject);
			//sampleB.transform.GetChild(0).transform.parent = sampleX.transform;
		}

		int randomHead = Random.Range(0,2);
		if(randomHead == 0){
			//Sheeps Head
			bodyPartsX.Add(sampleA.transform.GetChild(1).gameObject);
			//sampleA.transform.GetChild(1).transform.parent = sampleX.transform;
		}else{
			//Crocodile Head
			bodyPartsX.Add(sampleB.transform.GetChild(1).gameObject);
			//sampleB.transform.GetChild(1).transform.parent = sampleX.transform;
		}
			

		int randomTail = Random.Range(0,2);
		if(randomTail == 0){
			//Sheeps Tail
			bodyPartsX.Add(sampleA.transform.GetChild(2).gameObject);
			//sampleA.transform.GetChild(2).transform.parent = sampleX.transform;
		}else{
			//Crocodile Tail
			bodyPartsX.Add(sampleB.transform.GetChild(2).gameObject);
			//sampleB.transform.GetChild(2).transform.parent = sampleX.transform;
		}

		int randomFoot = Random.Range(0,2);
		if(randomFoot == 0){
			//Sheeps Foot
			bodyPartsX.Add(sampleA.transform.GetChild(3).gameObject);
			//sampleA.transform.GetChild(0).transform.parent = sampleX.transform;
		}else{
			//Crocodile Foot
			bodyPartsX.Add(sampleB.transform.GetChild(3).gameObject);
			//sampleB.transform.GetChild(2).transform.parent = sampleX.transform;
		}
			
		if(randomFoot == 0){
			//Sheeps Foot
			bodyPartsX.Add(sampleA.transform.GetChild(4).gameObject);
			//sampleA.transform.GetChild(0).transform.parent = sampleX.transform;
		}else{
			//Crocodile Foot
			bodyPartsX.Add(sampleB.transform.GetChild(4).gameObject);
			//sampleB.transform.GetChild(2).transform.parent = sampleX.transform;
		}

		for (int i = 0; i < bodyPartsX.Count; i++) {
			bodyPartsX[i].transform.parent = specamin.transform;
		}

		PutItTogether();
		// take random body parts
		//random head
	}

	void PutItTogether(){

		for (int i = 0; i < bodyPartsX.Count; i++) {
			if(bodyPartsX[i].name == "Body"){
				body = bodyPartsX[i];
				bodyPartsX[i].transform.position = new Vector2(0,0);
			}

			if(bodyPartsX[i].name == "Head"){
				head = bodyPartsX[i];
				float headSize = head.transform.localScale.x;
				float headSizeY = head.transform.localScale.y +  head.transform.localScale.y/2 -  head.transform.localScale.y/4;

				float bodySize = body.transform.localScale.x;
				float bodySizeY = body.transform.localScale.y - body.transform.localScale.y/2;

				bodyPartsX[i].transform.position = new Vector2(0,0);
				bodyPartsX[i].transform.position = new Vector2(body.transform.position.x - bodySize/2 - headSize/2 , headSizeY/2 - bodySizeY/2);
			}

			if(bodyPartsX[i].name == "Foot1"){
				foot = bodyPartsX[i];
				float footSize = foot.transform.localScale.y;
				float bodySizeY = body.transform.localScale.y;
				float bodySizeX = body.transform.localScale.x;


				bodyPartsX[i].transform.position = new Vector2(0,0);
				bodyPartsX[i].transform.position = new Vector2(body.transform.position.x - bodySizeX/2 + footSize/2 ,-footSize/2 - bodySizeY/2);
			}

			if(bodyPartsX[i].name == "Foot2"){
				foot = bodyPartsX[i];
				float footSize = foot.transform.localScale.y;
				float bodySize = body.transform.localScale.y;
				float bodySizeX = body.transform.localScale.x;

				bodyPartsX[i].transform.position = new Vector2(0,0);
				bodyPartsX[i].transform.position = new Vector2(body.transform.position.x + bodySizeX/2 - footSize/2 ,-footSize/2 - bodySize/2);
			}


			if(bodyPartsX[i].name == "Tail"){
				foot = bodyPartsX[i];
				float bodySize = body.transform.localScale.x;
				float tailSize = foot.transform.localScale.x;
				bodyPartsX[i].transform.position = new Vector2(0,0);
				bodyPartsX[i].transform.position = new Vector2(body.transform.position.x + bodySize/2 + tailSize/2 ,0);
			}

		}
		int randError = Random.Range(0,10); 
		Debug.Log(randError + "_ dna");
		if(randError > 8){
			Error();
		}


//		animals.Add(sampleA);
//		animals.Add(sampleB);
//		sampleA.SetActive(true);
//		sampleB.SetActive(true);
//		Destroy(sampleA);
//		Destroy(sampleB);
		sampleA = specamin;
		//sampleX = null;
		bodyPartsX.Clear();

	}

	void Error(){
		Debug.Log("Error");
		int randError = Random.Range(0,errors.Count);
		for (int i = 0; i < bodyPartsX.Count; i++) {
			if(bodyPartsX[i].GetComponent<Renderer>() != null)
				bodyPartsX[i].GetComponent<Renderer>().material.mainTexture = errors[randError];
		}
		
	}

	public void FuckShitUp(){
		CreateCreature();
	}

	public void ReDoShit(){
		int randomNumber = Random.Range(124,1001);
		sampleA.name = "Specamin" + randomNumber;
		InstantiateCreature();
	}

	public void NextGeneration (){
		
		generation ++;
		countText.text = "generation: " + generation;
	}

	public void StartOver(){
		generation = 0;
		sampleA = null;
		InstantiateCreature();
	}

	public void Quit(){
		Application.Quit();
	}
		

	IEnumerator Timer(){
		yield return new WaitForSeconds(2);
		CreateCreature();
	}
}
