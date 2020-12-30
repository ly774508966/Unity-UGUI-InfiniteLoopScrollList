﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class InfiniteListItem : MonoBehaviour {
    public int groupIndex;
    public int index;
    public uint id;

    #region 组件
    [Header("控制高亮")]
    [SerializeField]
    private CP_TransformToggle _toggle;
    public CP_TransformToggle toggle {
        get {
            if(_toggle == null) {
                _toggle = GetComponent<CP_TransformToggle>();
            }
            return _toggle;
        }
    }

    private InfiniteList _infiniteList;
    public InfiniteList infiniteList {
        get {
            if (_infiniteList == null) {
                _infiniteList = GetComponentInParent<InfiniteList>();
            }
            return _infiniteList;
        }
    }

    private RectTransform _rectTransform;
    public RectTransform rectTransform {
        get {
            if (_rectTransform == null) {
                _rectTransform = GetComponent<RectTransform>();
            }
            return _rectTransform;
        }
    }
    #endregion

    protected virtual void Awake() {
    }

    public void Refresh(int groupIndex, int index, uint id) {
        this.groupIndex = groupIndex;
        this.index = index;
        this.id = id;

        infiniteList?.OnItemRefreshed?.Invoke(groupIndex, index, id, this);
    }
}