using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Inventory : MonoBehaviour
{
    const int c_PlaySound_Touch_Count = 2;
    const float c_Doubletouch_Delay_Time = 0.5f;

    [Header("Sprite - [해변 오브젝트 이미지들]")]
    public Sprite[] sprites;

    [Header("DragItem [드래그 아이템]")]
    public GameObject dragItem;

    [Header("DragItem Create Pos [드래그 아이템 생성 부모]")]
    public Transform parent_DragItem;

    [Header("Button On/Off")]
    public Button button_OnOff;

    [Header("Animator_On_Off")]
    public Animator anim_OnOff;

    [Header("Grid Layout Group")]
    public GridLayoutGroup gridLayoutGroup;

    public Canvas canvas { get; private set; }

    private bool isInventoryEnabled = true;
    private bool isTimeLoop = false;
    private float waitTime = 0f;
    private int priorIndex = 0;

    private List<DragItem> list_DropItem = new List<DragItem>();
    private List<int> list_DropItem_TouchCount = new List<int>();

    private void Awake()
    {
        StartCoroutine(Init_IE());
        StartCoroutine(StartTimer());
    }

    private IEnumerator Init_IE()
    {
        InitButton();
        Init_List_DropItem_TouchCount();
        Init_List_DragItem();

        yield return null;
    }

    #region Event

    /// <summary>
    /// 드래그 아이템 클릭 이벤트
    /// </summary>
    /// <param name="index"></param>
    private void OnClick_DragItem(int index)
    {
        if(priorIndex == index)
        {            
            if (isTimeLoop)
            {
                list_DropItem_TouchCount[index]++;

                if(list_DropItem_TouchCount[index] >= c_PlaySound_Touch_Count)
                {
                    list_DropItem_TouchCount[index] = 0;
                    PlaySound(index);
                }
            }
            else
            {
                list_DropItem_TouchCount[index] = 1;
            }
        }
        else
        {
            list_DropItem_TouchCount[index] = 1;
        }

        isTimeLoop = true;

        priorIndex = index;
    }

    /// <summary>
    /// On/Off 버튼 클릭
    /// </summary>
    private void OnClick_Button_On_Off()
    {
        isInventoryEnabled = !isInventoryEnabled;

        anim_OnOff.SetTrigger("tr_OnOff");
    }

    #endregion

    #region Private
    /// <summary>
    /// 버튼을 정보를 설정합니다.
    /// </summary>
    private void InitButton()
    {
        button_OnOff.onClick?.RemoveAllListeners();
        button_OnOff.onClick?.AddListener(OnClick_Button_On_Off);
    }

    /// <summary>
    /// 각 버튼 터치 카운트 초기화
    /// </summary>
    private void Init_List_DropItem_TouchCount()
    {
        list_DropItem_TouchCount.Clear();
        list_DropItem_TouchCount = new List<int>();

        for (int i = 0; i < sprites.Length; i++)
        {
            list_DropItem_TouchCount.Add(0);
        }
    }

    /// <summary>
    /// 드래그 아이템을 생성합니다.
    /// </summary>
    private void Init_List_DragItem()
    {

        list_DropItem.Clear();

        for (int i = 0; i < sprites.Length; i++)
        {
            var obj = Instantiate(dragItem, parent_DragItem);
            var dragItem_Com = obj.GetComponent<DragItem>();
            list_DropItem.Add(dragItem_Com);

            var dragItem_Image = obj.GetComponent<Image>();
            var dragItem_Button = obj.GetComponent<Button>();

            int index = i;

            dragItem_Button.onClick?.RemoveAllListeners();
            dragItem_Button.onClick?.AddListener(delegate 
            {
                OnClick_DragItem(index);
            });
            SetSprite(dragItem_Image, i);
        }

        //gridLayoutGroup.enabled = false;
    }

    /// <summary>
    /// 드래그 아이템 스프라이트를 설정합니다.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="index"></param>
    private void SetSprite(Image image, int index)
    {
        image.sprite = sprites[index];
    }

    /// <summary>
    /// DragItem 사운드 재생
    /// </summary>
    private void PlaySound(int index)
    {
        $"PlaySound : {index}".LogError();
    }
    
    /// <summary>
    /// 더블 버튼 클릭 체크
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTimer()
    {
        waitTime = 0;

        while(true)
        {
            if(isTimeLoop)
            {
                waitTime += Time.deltaTime;

                if (waitTime >= c_Doubletouch_Delay_Time)
                {
                    waitTime = 0;
                    isTimeLoop = false;
                }
            }

            yield return null;
        }
    }
    
    private void ResetTime()
    {
        waitTime = 0;
    }

    #endregion
}
