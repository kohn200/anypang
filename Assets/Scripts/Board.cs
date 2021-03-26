using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //private Tile[,] m_TilesArray = new Tile[6, 6];  // C#의 2차원 배열 초기화하는 법 C++이랑 다르네유
    // 딕셔너리라는 자료구조를 사용하면 이차원배열을 사용할때보다 덜 헷갈린다ㅎㅎ 그리고 가독성이 좋다!
    // Dictionary<string(key), Tile(value)>
    private Dictionary<string, Tile> m_TilesDictionary = new Dictionary<string, Tile>();

    private GameObject m_TilePrefab;

    public int m_Width = 10;
    public int m_Height = 10;
    // Start is called before the first frame update
    void Start()
    {
        // 여러개의 타일 Prefab을 만들기 위한 틀(찍어내기위한 것이다.)
        m_TilePrefab = Resources.Load("Prefabs/CandyPurple") as GameObject;
        //프리펩 파일을 가져오겠다 그리고 as GameObject로 가져오겠다

        // 타일 생성 Instantiatie<T>(생성할 오브젝트) (동일하게 다수 생성을 위함)
        //Tile tile_0 = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>());
        // 생성 될 타일의 위치
        //tile_0.transform.position = Vector3.zero;
        // 타일의 부모를 Board로 설정한다.
        // tile_0.transform.parent = this.transform; 틀린거
        //tile_0.transform.SetParent(this.transform);
        // 위 주석처리 된 코드는 m_TilePrefab하나 만들고 
        // CreateTiles에서 생성해 줄 것이기 떄문에 필요가 없다. 생성될 타일 위치, 타일의 부모 for문에 넣기.
        CreateTiles();
    }

    /// <summary>
    /// 프리팹을 이용하여 새로운 타일들을 생성한다.
    /// </summary>
    private void CreateTiles()
    {
// Tile tile = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>()); 생성할 객체니깐 for문 안으로 gogo

        for(int y = 0; y < m_Height; y++)
        {
            for(int x = 0; x < m_Width; x++)
            {
                // key 값 예시 : x, y (10, 2)
                string key = x.ToString() + ", " + y.ToString();
                Tile tile = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>());
                // tile.transform.position = Vector3.zero; tile오브젝트들이 다 겹쳐서 나온다!
                tile.transform.position = new Vector3(x + 1, y + 1, 0f);
                transform.SetParent(this.transform);
                m_TilesDictionary.Add(key, tile);
            }
        }
    }
}
