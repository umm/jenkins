using UnityEditor;

namespace ContinuousIntegration {

    public partial class Jenkins {

        public class BuildRequestSender {

            public static class Player {

                // XXX: 将来的に送信先の CI ツールが増えた際には Project/Send Build Request/to Jenkins/Player/iOS とするとヨサソウ
                [MenuItem("Project/Send Build Request/Player/iOS")]
                public static void Send_iOS() {
                    // iOS のビルドリクエストを発行する
                    SendBuildRequest(JobType.Player, BuildTarget.iOS);
                }

                [MenuItem("Project/Send Build Request/Player/Android")]
                public static void Android() {
                    // Android のビルドリクエストを発行する
                    SendBuildRequest(JobType.Player, BuildTarget.Android);
                }

            }

            public static class AssetBundle {

                [MenuItem("Project/Send Build Request/AssetBundle/iOS")]
                public static void Send_iOS() {
                    // iOS のビルドリクエストを発行する
                    SendBuildRequest(JobType.AssetBundle, BuildTarget.iOS);
                }

                [MenuItem("Project/Send Build Request/AssetBundle/Android")]
                public static void Android() {
                    // Android のビルドリクエストを発行する
                    SendBuildRequest(JobType.AssetBundle, BuildTarget.Android);
                }

            }

        }

    }

}