using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //private Tile[,] m_TilesArray = new Tile[6, 6];  // C#�� 2���� �迭 �ʱ�ȭ�ϴ� �� C++�̶� �ٸ�����
    // ��ųʸ���� �ڷᱸ���� ����ϸ� �������迭�� ����Ҷ����� �� �򰥸��٤��� �׸��� �������� ����!
    // Dictionary<string(key), Tile(value)>
    private Dictionary<string, Tile> m_TilesDictionary = new Dictionary<string, Tile>();

    private GameObject m_TilePrefab;

    public int m_Width = 10;
    public int m_Height = 10;
    // Start is called before the first frame update
    void Start()
    {
        // �������� Ÿ�� Prefab�� ����� ���� Ʋ(�������� ���̴�.)
        m_TilePrefab = Resources.Load("Prefabs/CandyPurple") as GameObject;
        //������ ������ �������ڴ� �׸��� as GameObject�� �������ڴ�

        // Ÿ�� ���� Instantiatie<T>(������ ������Ʈ) (�����ϰ� �ټ� ������ ����)
        //Tile tile_0 = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>());
        // ���� �� Ÿ���� ��ġ
        //tile_0.transform.position = Vector3.zero;
        // Ÿ���� �θ� Board�� �����Ѵ�.
        // tile_0.transform.parent = this.transform; Ʋ����
        //tile_0.transform.SetParent(this.transform);
        // �� �ּ�ó�� �� �ڵ�� m_TilePrefab�ϳ� ����� 
        // CreateTiles���� ������ �� ���̱� ������ �ʿ䰡 ����. ������ Ÿ�� ��ġ, Ÿ���� �θ� for���� �ֱ�.
        CreateTiles();
    }

    /// <summary>
    /// �������� �̿��Ͽ� ���ο� Ÿ�ϵ��� �����Ѵ�.
    /// </summary>
    private void CreateTiles()
    {
// Tile tile = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>()); ������ ��ü�ϱ� for�� ������ gogo

        for(int y = 0; y < m_Height; y++)
        {
            for(int x = 0; x < m_Width; x++)
            {
                // key �� ���� : x, y (10, 2)
                string key = x.ToString() + ", " + y.ToString();
                Tile tile = Instantiate<Tile>(m_TilePrefab.transform.GetComponent<Tile>());
                // tile.transform.position = Vector3.zero; tile������Ʈ���� �� ���ļ� ���´�!
                tile.transform.position = new Vector3(x + 1, y + 1, 0f);
                transform.SetParent(this.transform);
                m_TilesDictionary.Add(key, tile);
            }
        }
    }
}
