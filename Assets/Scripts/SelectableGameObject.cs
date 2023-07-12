using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class SelectableGameObject : MonoBehaviour
{
    [SerializeField] Renderer m_SelectableRendererComponent = null;
    [SerializeField] Color m_SelectedColor = Color.blue;
    [SerializeField] Color m_HighlightedColor = Color.red;
    [SerializeField] TMP_Text m_SelectableText = null;

    private Color m_InitialColor = Color.white;
    private Color m_InitialTextColor = Color.white;
    private bool m_Selected = false;

    public UnityEvent<SelectableGameObject> OnSelect = null;
    public UnityEvent<SelectableGameObject> OnDeselect = null;

    public bool Selected
    {
        get
        {
            return m_Selected;
        }
    }

    public void SelectGameObject()
    {
        if (!m_Selected)
        {
            m_Selected = true;
            m_SelectableRendererComponent.material.color = m_SelectedColor;
            m_SelectableText.color = m_SelectedColor;
            OnSelect.Invoke(this);
        }
    }

    public void DeselectGameObject()
    {
        if (m_Selected)
        {
            m_Selected = false;
            m_SelectableRendererComponent.material.color = m_InitialColor;
            m_SelectableText.color = m_InitialTextColor;
            OnDeselect.Invoke(this);
        }
    }

    private void Awake()
    {
        m_InitialColor = m_SelectableRendererComponent.material.color;
        m_InitialTextColor = m_SelectableText.color;
    }

    private void OnMouseEnter()
    {
        if (MouseManager.Instance.IsPointerOverUIElement())
        {
            return;
        }
        m_SelectableRendererComponent.material.color = m_HighlightedColor;
        m_SelectableText.color = m_HighlightedColor;
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseUp()
    {
        if(MouseManager.Instance.IsPointerOverUIElement())
        {
            return;
        }

        if (m_Selected)
        {
            DeselectGameObject();
        }
        else
        {
            SelectGameObject();
        }
    }

    private void OnMouseOver()
    {
        //TODO: could fade over time
        //m_SelectableRendererComponent.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }

    void OnMouseExit()
    {
        if (MouseManager.Instance.IsPointerOverUIElement())
        {
            return;
        }

        if (m_Selected)
        {
            m_SelectableRendererComponent.material.color = m_SelectedColor;
            m_SelectableText.color = m_SelectedColor;
        }
        else
        {
            m_SelectableRendererComponent.material.color = m_InitialColor;
            m_SelectableText.color = m_InitialTextColor;
        }
         
    }
        private void Update()
    {
        if (MouseManager.Instance.IsPointerOverUIElement())
        {
            if(m_Selected)
        {
                m_SelectableRendererComponent.material.color = m_SelectedColor;
                m_SelectableText.color = m_SelectedColor;
            }
        else
            {
                m_SelectableRendererComponent.material.color = m_InitialColor;
                m_SelectableText.color = m_InitialTextColor;
            }
        }
    }
}
