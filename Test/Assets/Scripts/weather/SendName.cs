using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SendName : MonoBehaviour
{
    [SerializeField] private TMP_Text city;

    public void ChangeScene()
    {
        SceneManager.LoadScene("Clima");
    }

private void OnDestroy()
{
    DataBetweenScenes.instance._city = city.text;
}

}