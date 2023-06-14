using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Excel导出类型
/// </summary>
enum ExcelExportType
{
    Json,
}

public class ExcelExportToolWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/ExcelExportToolWindow")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<ExcelExportToolWindow>();
        wnd.titleContent = new GUIContent("Excel导出工具");
    }
    
    private readonly Dictionary<ExcelExportType, string> _exportTypeToExtension =
        new Dictionary<ExcelExportType, string>()
        {
            { ExcelExportType.Json, ".json" },
        };

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        var root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FGameEngine/Editor/ExcelExportToolWindow.uxml");
        if (visualTree == null) return;
        visualTree.CloneTree(root);

        var listView = root.Q<VisualElement>("ListView");
        listView.RegisterCallback<DragUpdatedEvent>(evt =>
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Move;
            evt.StopPropagation();
        });
        listView.RegisterCallback<DragExitedEvent>(evt =>
        {
            DragAndDrop.AcceptDrag();
            evt.StopPropagation();
        });

        var excelInfos = root.Q<ListView>("ExcelInfos");
        excelInfos.makeItem = OnMakeItem;
        excelInfos.bindItem = OnBindItem;
        // excelInfos.itemsSource = new[] { "Item 1", "Item 2", "Item 3", "Item 4" };
    }

    private void OnBindItem(VisualElement item, int index)
    {
        
    }

    private VisualElement OnMakeItem()
    {
        return new ExcelInfoCell();
    }

    class ExcelInfo
    {
        public string path;
    }

    class ExcelInfoCell : VisualElement
    {
        public ExcelInfoCell()
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FGameEngine/Editor/ExcelInfoCell.uxml");
            if (visualTree == null) return;
            visualTree.CloneTree(this);
        }
    }
}