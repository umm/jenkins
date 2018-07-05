using UnityEngine;

namespace UnityModule.Settings
{
    public class JenkinsSetting : Setting<JenkinsSetting>, IEnvironmentSetting
    {
        [SerializeField] private string slackUserName;
        public string SlackUserName => this.slackUserName;

        [SerializeField] private string userId;
        public string UserId => this.userId;

        [SerializeField] private string password;
        public string Password => this.password;

        [SerializeField] private string baseURL;
        public string BaseURL => this.baseURL;

        [SerializeField] private string jobNameForPlayer;
        public string JobNameForPlayer => this.jobNameForPlayer;

        [SerializeField] private string jobNameForAssetBunde;
        public string JobNameForAssetBunde => this.jobNameForAssetBunde;

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Settings/Jenkins Setting")]
        public static void CreateSettingAsset()
        {
            CreateAsset();
        }
#endif
    }
}
