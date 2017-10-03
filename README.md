# What

* [Jenkins](https://jenkins.io/) へビルドリクエストを発行します

# Why

* UnityEditor 上から、簡単に Jenkins にビルドリクエストを発行したかったため

# Requirement

* Unity 2017.1.1p3

# Install

```shell
$ npm install github:umm-projects/jenkins
```

# Usage

1. `Resources/Settings/EnvironmentSetting` の必須項目を設定する
    * Slack User Name
    * Jenkins User Id
    * Jenkins Password
    * Jenkins Job Name
2. UnityEditor のメニューから、ビルドターゲットを選択する
    * iOS の場合は、`Project > Build > Package > iOS` を選択する
    * Android の場合は、`Project > Build > Package > Android` を選択する

# License

Copyright (c) 2017 Yoshinori Hirasawa

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)
