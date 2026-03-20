# GameJam2025 - Ricochet Arms Race

> 48小时内独立完成双人对战游戏原型。

## 在线试玩

- WebGL Demo: [https://chaosflameme.github.io/GameJam2025/](https://chaosflameme.github.io/GameJam2025/)

## 30 秒演示视频

- 直接观看/下载：[`8_Ricochet_Arms_racesVideo30.mp4`](./8_Ricochet_Arms_racesVideo30.mp4)

## 游戏介绍

`Ricochet Arms Race` 是一款双人同屏对战原型。双方通过移动发射器、弹射球体、击碎障碍与购买技能来建立优势，并在持续对抗中争夺最终胜利。

### 核心机制

- 物理弹射：发射球体后会在场景中持续碰撞反弹。
- 资源运营：玩家会随时间获得金币，击碎方块也会掉落金币。
- 技能释放：可在商店中购买额外球、Freeze Beam、Spinner 等能力。
- 胜负结算：当任一玩家先达到目标分数即获胜。
- 该演示版为了加速演示游戏进程，为双方设置了较高的初始资金。

## 游戏操作方式

### 双人对战键位（同键盘）

| 玩家     | 左移 | 右移 | 发射球 |
| -------- | ---- | ---- | ------ |
| Player 1 | `A`  | `D`  | `S`    |
| Player 2 | `←`  | `→`  | `↓`    |

### 商店与升级

- 商店升级主要通过界面按钮点击触发（使用鼠标）。
- 可购买内容：
  - 属性：`DMG(球对砖块的攻击力)`、`SPD(球的移速)`、`AGI(玩家移速)`
  - 道具/技能：`Add Ball`、`Freeze Beam`、`Spinner`

## 规则速览

- 目标分数：`1000`
- 每次有效得分：`+100`
- 玩家每秒基础金币：`+5`
- 方块被击碎后会额外提供金币（不同等级方块奖励不同）

## 项目结构

- `Build/`：WebGL 构建产物（发布到 GitHub Pages 所需）
- `TemplateData/`：WebGL 模板资源
- `index.html`：WebGL 入口页面
- `Project Files/`：Unity 工程文件（含 `Assets`、`ProjectSettings`、`Packages`）

## 开发环境

- Unity `2022.3.62f2`
