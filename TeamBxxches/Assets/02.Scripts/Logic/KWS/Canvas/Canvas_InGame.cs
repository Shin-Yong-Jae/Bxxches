using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_InGame : MonoBehaviour
{
    [Header("해변 캐릭터들 이미지 / 애니메이션")]
    public List<CharacterData> list_CharacterInfo;
}

[System.Serializable]

public class CharacterData
{
    public Sprite sprite;
    public RuntimeAnimatorController animator;
}