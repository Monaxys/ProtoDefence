using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

[InitializeOnLoad]
public static class BuildApk {
    private const string ANDROID_BUILD = "ANDROID_BUILD";


    [MenuItem("Build/Build Android")]
    public static void BuildAndroid() {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        var options = GetGenericBuildOptions("build/Android.apk", BuildTarget.Android);
        options.extraScriptingDefines = new string[] {ANDROID_BUILD};

        Build(options);
    }

    private static BuildPlayerOptions GetGenericBuildOptions(string buildPath, BuildTarget target) {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = new[] { "Assets/Scenes/MainScene.unity", "Assets/Scenes/GameScene.unity" };
        options.locationPathName = buildPath;
        options.target = target;
        
        options.options = BuildOptions.None;

        return options;
    }

    private static void Build(BuildPlayerOptions options) {
        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded) {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed) {
            Debug.Log("Build failed");
        }
    }
}
