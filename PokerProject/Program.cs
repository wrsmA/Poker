using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    /// <summary>
    /// エントリ
    /// </summary>
    public static void Main()
    {
        // 手を作る（テスト）
        Hand hand = new Hand();
        List<Card> c = new List<Card>
        {
            new Card{ number = 1, suite = Suite.Heart },
            new Card{ number = 1, suite = Suite.Clover },
            new Card{ number = 11, suite = Suite.Heart },
            new Card{ number = 12, suite = Suite.Heart },
            new Card{ number = 13, suite = Suite.Heart },
        };

        for (int i = 0; i < 5; i++)
        {
            // カードを追加
            hand.AddCard(c[i]);
        }

        // 役を判定
        var role = RoleChecker.CheckHand(hand);

        // 最終表示
        Console.WriteLine(role);
    }
}