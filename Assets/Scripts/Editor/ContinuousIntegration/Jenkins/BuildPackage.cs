using UnityEditor;
using UnityEngine;
using UnityModule.Settings;

namespace ContinuousIntegration {
    public partial class Jenkins {
        public class BuildPackage : EditorWindow {
            [MenuItem("Project/Build/Package/iOS")]
            public static void iOS() {
                if (!IsValid()) {
                    return;
                }

                // iOS のビルドリクエストを発行する
                SendBuildRequest(BuildTarget.iOS);
            }

            [MenuItem("Project/Build/Package/Android")]
            public static void Android() {
                if (!IsValid()) {
                    return;
                }

                // Android のビルドリクエストを発行する
                SendBuildRequest(BuildTarget.Android);
            }

            /// <summary>
            /// Jenkins にビルドリクエストを発行可能かどうか
            /// </summary>
            /// <returns>true: 発行可能 / false: 発行不可能</returns>
            private static bool IsValid() {
                if (string.IsNullOrEmpty(EnvironmentSetting.Instance.Path.SlackUserName)) {
                    Debug.LogError("Slack のユーザ名称を設定してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(EnvironmentSetting.Instance.Path.JenkinsUserId)) {
                    Debug.LogError("Jenkins のユーザ ID を設定してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(EnvironmentSetting.Instance.Path.JenkinsPassword)) {
                    Debug.LogError("Jenkins のパスワードを設定してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(EnvironmentSetting.Instance.Path.JenkinsJobName)) {
                    Debug.LogError("Jenkins のジョブ名称を設定してください。");
                    return false;
                }
                return true;
            }
        }
    }
}
