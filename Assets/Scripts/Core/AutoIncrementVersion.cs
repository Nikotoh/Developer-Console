using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class AutoIncrementVersion : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        // Get the current version
        var version = Application.version;

        // Split into parts
        var parts = version.Split('.');

        // Increment the last part
        var lastPart = int.Parse(parts[parts.Length - 1]);
        lastPart++;

        // Combine back into a string
        parts[parts.Length - 1] = lastPart.ToString();
        version = string.Join(".", parts);

        // Set the version back
        PlayerSettings.bundleVersion = version;
    }
}
