/// <summary>
/// 役定義
/// </summary>
[Flags]
public enum Role
{
    FiveCard        = 1 << 0,   // ありえん
    RoyalFlash      = 1 << 1,   // ロイヤルフラッシュ
    StraightFlash   = 1 << 2,   // ストレートフラッシュ
    FourCard        = 1 << 3,   // フォーカード
    FullHouse       = 1 << 4,   // フルハウス
    Flash           = 1 << 5,   // フラッシュ
    Straight        = 1 << 6,   // ストレート
    ThreeCard       = 1 << 7,   // スリーカード
    TwoPair         = 1 << 8,   // ツーカード
    OnePair         = 1 << 9,   // ワンペア
    HighCard        = 1 << 10,  // ハイカード（役無し）
}

/// <summary>
/// スーツ定義
/// </summary>
public enum Suite
{
    Heart    = 0,  // ハート
    Diamond  = 1,  // ダイアモンド
    Spade    = 2,  // スペード
    Clover   = 3,  // クローバー
}