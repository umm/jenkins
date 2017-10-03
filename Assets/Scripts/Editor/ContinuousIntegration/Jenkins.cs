using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityModule.Settings;

namespace ContinuousIntegration {
    public partial class Jenkins {
        /// <summary>
        /// Jenkins URL
        /// </summary>
        private const string JENKINS_URL = "https://jenkins.kidsstar.co.jp/job/{0}/buildWithParameters";

        /// <summary>
        /// git コマンドパス
        /// </summary>
        private const string COMMAND_PATH_GIT = "/usr/local/bin/git";

        /// <summary>
        /// カレントのリポジトリ名称を取得するためのパラメータ
        /// </summary>
        private const string ARGUMENTS_CURRENT_REPOSITORY_NAME = "remote get-url origin";

        /// <summary>
        /// カレントのブランチ名称を取得するためのパラメータ
        /// </summary>
        private const string ARGUMENTS_CURRENT_BRANCH_NAME = "rev-parse --abbrev-ref HEAD";

        /// <summary>
        /// Jenkins に渡す method パラメータ
        /// </summary>
        private static readonly Dictionary<BuildTarget, string> METHODS = new Dictionary<BuildTarget, string>() {
            { BuildTarget.iOS,     "SimpleBuild.BuildPlayer.Run_iOS" },
            { BuildTarget.Android, "SimpleBuild.BuildPlayer.Run_Android" },
        };

        /// <summary>
        /// Jenkins にビルドリクエストを発行する
        /// </summary>
        /// <param name="buildTarget">ビルドターゲット</param>
        public static void SendBuildRequest(BuildTarget buildTarget) {
            ObservableUnityWebRequest.Post(string.Format(JENKINS_URL, EnvironmentSetting.Instance.Path.JenkinsJobName), GenerateParameters(buildTarget), GenerateRequestHeader()).Subscribe(
                (_) => {
                    Debug.Log("Build request sent to Jenkins.");
                },
                (ex) => {
                    Debug.Log("Could not send build request to Jenkins: " + ex.Message);
                }
            );
        }

        /// <summary>
        /// Jenkins に渡すパラメータを生成する
        /// </summary>
        /// <param name="buildTarget">ビルドターゲット</param>
        /// <returns>Jenkins に渡すパラメータ</returns>
        private static Dictionary<string, string> GenerateParameters(BuildTarget buildTarget) {
            return new Dictionary<string, string>() {
                { "requested_user", EnvironmentSetting.Instance.Path.SlackUserName },
                { "repository",     GetCurrentRepositoryName() },
                { "branch",         GetCurrentBranchName() },
                { "platform",       buildTarget.ToString() },
                { "editor_version", Application.unityVersion },
                { "env",            Debug.isDebugBuild ? "development" : "production" },
                { "method",         METHODS[buildTarget] },
            };
        }

        /// <summary>
        /// Jenkins に渡すリクエストヘッダを生成する
        /// </summary>
        /// <returns>Jenkins に渡すリクエストヘッダ</returns>
        private static Dictionary<string, string> GenerateRequestHeader() {
            return new Dictionary<string, string>() {
                { "Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", EnvironmentSetting.Instance.Path.JenkinsUserId, EnvironmentSetting.Instance.Path.JenkinsPassword))) },
            };
        }

        /// <summary>
        /// カレントのリポジトリ名称を取得する
        /// </summary>
        /// <returns>カレントのリポジトリ名称</returns>
        private static string GetCurrentRepositoryName() {
            System.Diagnostics.Process process = new System.Diagnostics.Process {
                StartInfo = {
                    FileName = COMMAND_PATH_GIT,
                    Arguments = ARGUMENTS_CURRENT_REPOSITORY_NAME,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            process.Start();
            process.WaitForExit();
            string remoteURL = process.StandardOutput.ReadToEnd().TrimEnd();
            Match match = Regex.Match(remoteURL, "^[^/]+/([^.]+)\\.git$");
            string currentRepositoryName = match.Groups[1].Value;
            process.Close();
            return currentRepositoryName;
        }

        /// <summary>
        /// カレントのブランチ名称を取得する
        /// </summary>
        /// <returns>カレントのブランチ名称</returns>
        private static string GetCurrentBranchName() {
            System.Diagnostics.Process process = new System.Diagnostics.Process {
                StartInfo = {
                    FileName = COMMAND_PATH_GIT,
                    Arguments = ARGUMENTS_CURRENT_BRANCH_NAME,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                    }
                };
            process.Start();
            process.WaitForExit();
            string currentBranchName = process.StandardOutput.ReadToEnd().TrimEnd();
            process.Close();
            return currentBranchName;
        }
    }
}
