using UnityEngine;
using UnityEngine.SceneManagement;

public class V1_FlowManager : MonoBehaviour
{
    [Header("Database")]
    public ItemDatabase _ItemDatabase;

    [Header("Scoring")]
    public int score;

    [Header("Cooking Process")]
    public DisplayCookingProcess _DisplayCookingProcess;

    [Header("Menu Selection")]
    public DisplayMenuSelection _DisplayMenuSelection;

    [Header("Food Detail")]
    [SerializeField] private int _foodIndex;
    public DisplayFoodDetail _DisplayFoodDetail;

    private void Awake()
    {
        _DisplayMenuSelection.SetButtonSelection(_ItemDatabase.foodList);
    }

    //! function show food description
    public void ShowFoodDescription(int _index)
    {
        _foodIndex = _index;
        _DisplayMenuSelection.SetDescription(_ItemDatabase.foodList[_index].foodName, _ItemDatabase.foodList[_index].foodSprite);
    }

    //! Button function
    public void OnClickStartCook()
    {
        _DisplayCookingProcess.OnStartCookingProcess();
        _DisplayFoodDetail.OnOffFoodDetail(false);
    }

    public void OnClickShowFoodDetail()
    {
        _DisplayFoodDetail.OnOffFoodDetail(true);
        _DisplayMenuSelection.OnOffMenuSelection(false);

        _DisplayFoodDetail.DisplayImageDetail(_ItemDatabase.foodList[_foodIndex].foodSprite);
        _DisplayFoodDetail.SetSpriteFormula(_foodIndex);
    }

    public void OnClickCloseCook()
    {
        // _DisplayCookingProcess.CloseDisplay();
        // _DisplayMenuSelection.OnOffMenuSelection(true);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
