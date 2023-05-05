using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UGUI.Framework
{
    /// <summary>
    /// UI事件监听器
    /// </summary>
    public delegate void PointerEventHandler(PointerEventData eventData);
    public class UIEventListener : MonoBehaviour, IPointerDownHandler,IPointerClickHandler,IDragHandler,IEndDragHandler,IBeginDragHandler
    {
        //声名事件类型
        public event PointerEventHandler PointerClick;
        public event PointerEventHandler PointerDown;
        public event PointerEventHandler BeginDraging;
        public event PointerEventHandler OnDraging;
        public event PointerEventHandler EndDraging;

        //用来获取指定物体的Listener 如果没有就添加一个
        public static UIEventListener GetListener(Transform TF)
        {
            UIEventListener uiEventListener = TF.GetComponent<UIEventListener>();
            if (uiEventListener == null)
                uiEventListener = TF.gameObject.AddComponent<UIEventListener>();
            return uiEventListener;
        }

        //开始拖拽
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (BeginDraging != null) BeginDraging(eventData);
        }

        //拖拽中
        public void OnDrag(PointerEventData eventData)
        {
            if (OnDraging != null) OnDraging(eventData);
        }

        //结束拖拽
        public void OnEndDrag(PointerEventData eventData)
        {
            if (EndDraging != null) EndDraging(eventData);
        }

        //鼠标点击
        public void OnPointerClick(PointerEventData eventData)
        {
            //这是接口的实现类 当被点击时触发 
            
            if (PointerClick != null)PointerClick(eventData);
        }
        

        //鼠标按下
        public void OnPointerDown(PointerEventData eventData)
        {
            //抽象行为 抽象类 接口 委托
            if (PointerDown != null) PointerDown(eventData);
        }
    }
}