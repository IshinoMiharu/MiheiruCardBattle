﻿using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems; // この名前空間にあるインターフェイスを使う

/// <summary>
/// カードを制御するコンポーネント
/// 
/// Unity の UI で使えるインターフェイスの一覧
/// https://docs.unity3d.com/ja/2018.4/ScriptReference/EventSystems.IBeginDragHandler.html
/// （※）左パネルのリストに使えるインターフェイスの一覧がある
/// </summary>
public class CardController : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IPointerUpHandler
{
    /// <summary>テーブルオブジェクト（"TableTag" が付いている UI オブジェクト）</summary>
    GameObject _table = null;
    /// <summary>このオブジェクトの Rect Transform</summary>
    RectTransform _rectTransform = default;
    /// <summary>カードをデッキの外に置けるかどうかの設定</summary>
    [SerializeField] bool _canPutOutOfDeck = false;
    /// <summary>動かす前に所属していたデッキ</summary>
    Transform _originDeck = default;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _table = GameObject.FindGameObjectWithTag("TableTag");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
        this.transform.SetAsLastSibling();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

        string message = $"OnPointerDown: {this.name}: ";
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            message += $"マウスポインタは {currentDeck.name} の上にあります";
            _originDeck = currentDeck.transform;
        }
        else
        {
            message += "マウスポインタはデッキの上にありません";
        }

        Debug.Log(message);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            if(currentDeck.name == "UpperDeckPanel")
            {
                this.transform.parent = currentDeck.transform;
            }
        }
        else if (currentDeck == null)
        {
            this.transform.parent = _originDeck;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {this.name}");
        this.transform.SetParent(_table.transform);
    }

    /// <summary>
    /// マウスカーソルが現在どのデッキの上にあるかを返す。デッキとは "DeckTag" がタグ付けされた GameObject のこと。
    /// なお、デッキは UI オブジェクトつまり Rect Transform コンポーネントがアタッチされたオブジェクトである必要がある。
    /// </summary>
    /// <param name="eventData">PointerEventData 型の引数。マウス操作の情報が入っている。</param>
    /// <returns></returns>
    GameObject GetCurrentDeck(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
        
        // results に入っているオブジェクトのうち、DeckTag が付いているオブジェクトを一つ result に取得する
        RaycastResult result = default;

        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("DeckTag"))
            {
                result = item;
                break;
            }
        }

        return result.gameObject;   // 結果の GameObject を返す

        //（※）EventSystem のインターフェイスを使った通常のプログラミングだと、オブジェクトが重なっている場合は「一番上に描画されているオブジェクト」しかマウスの動きを検出できない。
        // そのため、デッキの上にカードが重なっている場合、デッキ側でマウスの動きを検出できない。そのため EventSystem.current.RaycastAll を使う必要があった。
        // ちなみに Hierarchy 上で下にある UI オブジェクトが前面に描画される。
    }


}
