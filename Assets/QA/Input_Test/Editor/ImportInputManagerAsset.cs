using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ImportInputManagerAsset
{
    static private string m_inputTestAssetFile = "InputTest_InputManager.asset.backup";
    static private string m_defaultAssetFile = "default_InputManager.asset.backup";
    static private string m_inputAssetFile = "InputManager.asset";

    // Import the Input Manager asset for Input Test and back up the current one for backup
    [MenuItem("QA Tools/Input Test/Import for Input Test")]
    static void ImportInputAssetForTest()
    {
        File.Copy(m_inputAssetFile, m_defaultAssetFile);
        File.Copy(m_inputTestAssetFile, m_inputAssetFile, true);
        //FileUtil.ReplaceFile("ProjectSettings/InputManager.asset", "Assets/QA/Input_Test/Editor/default_InputManager.asset");
        //FileUtil.ReplaceFile("Assets/QA/Input_Test/Editor/InputTest_InputManager.asset", "ProjectSettings/InputManager.asset");
    }

    //[MenuItem("QA Tools/Input Test/Import for Input Test", true)]
    //static bool CheckIfCanImportInputAsset()
    //{
    //    return !File.Exists(m_defaultAssetFile);
    //}

    // Revert the Input Manager asset to the default one for the project
    [MenuItem("QA Tools/Input Test/Revert to Default")]
    static void RevertToDefaultInputAsset()
    {
        File.Copy(m_defaultAssetFile, m_inputAssetFile, true);
        File.Delete(m_defaultAssetFile);
        //FileUtil.ReplaceFile("Assets/QA/Input_Test/Editor/default_InputManager.asset", "ProjectSettings/InputManager.asset");
        //FileUtil.DeleteFileOrDirectory("Assets/QA/Input_Test/Editor/default_InputManager.asset");
    }

    //[MenuItem("QA Tools/Input Test/Revert to Default", false)]
    //static bool CheckIfCanRevertInputAsset()
    //{
    //    return File.Exists(m_defaultAssetFile);
    //}

    // Use this for initialization
    static ImportInputManagerAsset()
    {
        m_inputTestAssetFile = Path.GetFullPath(Application.dataPath + "/QA/Input_Test/Editor/" + m_inputTestAssetFile);
        m_defaultAssetFile = Path.GetFullPath(Application.dataPath + "/QA/Input_Test/Editor/" + m_defaultAssetFile);
        m_inputAssetFile = Path.GetFullPath(Directory.GetCurrentDirectory() + "/ProjectSettings/" + m_inputAssetFile);
    }
}
