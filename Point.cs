using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour{
    public int requiredPoints = 30;
    public GameObject objectToAppear;

    private int currentPoints = 0;

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            LoadNextScene();
        }
    }

    public void AddPoint(){
        currentPoints++;

        if(currentPoints >= requiredPoints && objectToAppear != null && !objectToAppear.activeSelf){
            objectToAppear.SetActive(true);
        }
    }

    private void LoadNextScene(){
        SceneManager.LoadScene("Lvl2");
    }
}