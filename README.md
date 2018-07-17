# What

* [Jenkins](https://jenkins.io/) へビルドリクエストを発行します

# Why

* UnityEditor 上から、簡単に Jenkins にビルドリクエストを発行したかったため

# Requirement

* Unity 2017.1.1p3

# Install

```shell
$ npm install github:umm/jenkins
```

# Usage

1. メニューから `Assets > Create > Setting > EnvironmentSetting` を選択する
1. 生成された `Resources/Settings/EnvironmentSetting` の必須項目を設定する<br /><img width="526" alt="screenshot 2018-01-18 16 33 58" src="https://user-images.githubusercontent.com/838945/35085879-d1731a20-fc6d-11e7-8bb4-9ebce5abc1dc.png">
    * Slack User Name
    * Jenkins User Id
    * Jenkins Password
    * Jenkins Job Name
    * BaseURL
        * ジョブ名の手前までの URL を指定してください。
        * `https://jenkins.example.com/job/` など。
1. UnityEditor のメニューから、ビルドターゲットを選択する<br /><img width="477" alt="screenshot 2018-01-18 16 39 06" src="https://user-images.githubusercontent.com/838945/35085964-20867436-fc6e-11e7-9197-5dc1b6fee1dd.png">
    * iOS の Player の場合は、`Project > Send Build Request > Player > iOS` など。
    * Android の AssetBundle の場合は、`Project > Send Build Request > AssetBundle > Android` など。

# License

Copyright (c) 2017 Yoshinori Hirasawa

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)
