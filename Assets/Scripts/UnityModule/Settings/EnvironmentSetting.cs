using UnityEngine;

namespace UnityModule.Settings {
    public partial class EnvironmentSetting {
        public partial class EnvironmentSetting_Path {
            /// <summary>
            /// 初期値: Slack ユーザ名称
            /// </summary>
            private const string DEFAULT_SLACK_USER_NAME = "";

            /// <summary>
            /// 初期値: Jenkins ユーザ ID
            /// </summary>
            private const string DEFAULT_JENKINS_USER_ID = "";

            /// <summary>
            /// 初期値: Jenkins パスワード
            /// </summary>
            private const string DEFAULT_JENKINS_PASSWORD = "";

            /// <summary>
            /// 初期値: Jenkins ジョブ名称
            /// </summary>
            private const string DEFAULT_JENKINS_JOB_NAME = "";

            /// <summary>
            /// Slack ユーザ名称
            /// </summary>
            [SerializeField]
            private string slackUserName = DEFAULT_SLACK_USER_NAME;
            public string SlackUserName {
                get {
                    return this.slackUserName;
                }
                set {
                    this.slackUserName = value;
                }
            }

            /// <summary>
            /// Jenkins ユーザ ID
            /// </summary>
            [SerializeField]
            private string jenkinsUserId = DEFAULT_JENKINS_USER_ID;
            public string JenkinsUserId {
                get {
                    return this.jenkinsUserId;
                }
                set {
                    this.jenkinsUserId = value;
                }
            }

            /// <summary>
            /// Jenkins パスワード
            /// </summary>
            [SerializeField]
            private string jenkinsPassword = DEFAULT_JENKINS_PASSWORD;
            public string JenkinsPassword {
                get {
                    return this.jenkinsPassword;
                }
                set {
                    this.jenkinsPassword = value;
                }
            }

            /// <summary>
            /// Jenkins ジョブ名称
            /// </summary>
            [SerializeField]
            private string jenkinsJobName = DEFAULT_JENKINS_JOB_NAME;
            public string JenkinsJobName {
                get {
                    return this.jenkinsJobName;
                }
                set {
                    this.jenkinsJobName = value;
                }
            }
        }
    }
}
