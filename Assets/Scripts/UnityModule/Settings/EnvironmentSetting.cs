using System;
using UnityEngine;

namespace UnityModule.Settings {
    public partial class EnvironmentSetting {

        [Serializable]
        public struct EnvironmentSetting_Jenkins {
            public string SlackUserName;
            public string UserId;
            public string Password;
            [Tooltip("ジョブ名の手前までの URL を設定してください")]
            public string BaseURL;
            public string JobNameForPlayer;
            public string JobNameForAssetBunde;

        }

        [SerializeField]
        private EnvironmentSetting_Jenkins jenkins;
        public EnvironmentSetting_Jenkins Jenkins {
            get {
                return this.jenkins;
            }
            set {
                this.jenkins = value;
            }
        }
    }
}
