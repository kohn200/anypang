using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tile : MonoBehaviour
{
    // Properties
    public int m_ID;
    // Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        // transform은 Monobehavior에 들어있는 속성 중 하나이다.
        // 여기서 punch는 가해지는 힘, duration은 시간
        Vector3 strength = new Vector3(0.1f, 0.1f, 0.1f);
        transform.DOPunchScale(strength, 1f);    // DOPunchScale(punch, duration)
        Debug.Log("OnMouseDown() 호출되었습니다.");
    }
}
