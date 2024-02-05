using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    private bool colorSet = false;

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(20, 1, 0);

           
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

            
            float randomScaleY = Random.Range(1, 4);
            Vector3 newScale = _enemy.transform.localScale;
            newScale.y = randomScaleY;
            _enemy.transform.localScale = newScale;

            
            if (!colorSet)
            {
                Renderer renderer = _enemy.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Color randomColor = new Color(Random.value, Random.value, Random.value);
                    renderer.material.color = randomColor;
                    colorSet = true; 
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on the enemyPrefab!");
                }
            }
        }
    }
}