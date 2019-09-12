using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TileBar_UI : MonoBehaviour
{
    public GameObject Tile;
    public Sprite SecondSprite;
    public int SecondSpriteNumber = 4;
    public int MaxAmount;
    public int YOffset = 0;
    public int TileOffset = 3;
    public float Value;

    private List<GameObject> _tiles = new List<GameObject>();
    private int _activetiles;
    private Sprite _firstSprite;
    private Image _image;

    private void Start()
    {
        for (int i = 0; i < MaxAmount; i++)
        {
            GameObject go = Instantiate(Tile, transform);
            go.transform.localPosition += new Vector3(i*TileOffset, YOffset);
            _tiles.Add(go);
        }

        _image = _tiles[0].GetComponent<Image>();
        _firstSprite = _image.sprite;
        _activetiles = MaxAmount;
    }

    public void SetValue(float value)
    {
        Value = value;
        int tiles = Mathf.FloorToInt(MaxAmount * Value);
        while (tiles < _activetiles)
        {
            
            GameObject lasttile = _tiles.LastOrDefault(t => t.activeSelf);
            if(lasttile != null)
                lasttile.SetActive(false);
            _activetiles--;
            if (SecondSprite != null)
            {
                if (_activetiles <= SecondSpriteNumber)
                {
                    foreach (GameObject tile in _tiles)
                    {
                        Image image = tile.GetComponent<Image>();
                        image.sprite = SecondSprite;
                    }
                }
            }
        }

        while (tiles > _activetiles)
        {
            GameObject lasttile = _tiles.FirstOrDefault(t => !t.activeSelf);
            if (lasttile != null)
                lasttile.SetActive(true);
            _activetiles++;
            if (SecondSprite != null)
            {
                if (_activetiles >= SecondSpriteNumber)
                {
                    foreach (GameObject tile in _tiles)
                    {
                        Image image = tile.GetComponent<Image>();
                        image.sprite = _firstSprite;
                    }
                }
            }
        }
    }
}
