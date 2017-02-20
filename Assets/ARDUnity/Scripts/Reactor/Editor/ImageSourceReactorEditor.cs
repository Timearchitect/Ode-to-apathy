using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Ardunity;


[CustomEditor(typeof(ImageSourceReactor))]
public class ImageSourceReactorEditor : ArdunityObjectEditor
{
    SerializedProperty script;
    
	void OnEnable()
	{
        script = serializedObject.FindProperty("m_Script");
	}
	
	public override void OnInspectorGUI()
	{
		this.serializedObject.Update();
		
		//AudioSourceReactor reactor = (AudioSourceReactor)target;
        
        GUI.enabled = false;
        EditorGUILayout.PropertyField(script, true, new GUILayoutOption[0]);
        GUI.enabled = true;

		this.serializedObject.ApplyModifiedProperties();
	}
	
	static public void AddMenuItem(GenericMenu menu, GenericMenu.MenuFunction2 func)
	{
		string menuName = "Unity/Add Reactor/Effect/ImageSourceReactor";
		
		if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Image>() != null)
			menu.AddItem(new GUIContent(menuName), false, func, typeof(ImageSourceReactor));
		else
			menu.AddDisabledItem(new GUIContent(menuName));
	}
}