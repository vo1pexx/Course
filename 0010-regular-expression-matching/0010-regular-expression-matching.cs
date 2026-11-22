public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length;
        int n = p.Length;

        // dp[i, j] - чи збігається префікс s довжини i з префіксом p довжини j
        var dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;

        // Порожній рядок може збігатися з шаблоном виду a*b*c*
        for (int j = 2; j <= n; j++) {
            if (p[j - 1] == '*')
                dp[0, j] = dp[0, j - 2];
        }

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (p[j - 1] == '*') {
                    // Варіант 1: зірка вживається нуль разів (відкидаємо "x*")
                    dp[i, j] = dp[i, j - 2];

                    // Варіант 2: зірка поглинає ще один символ s,
                    // якщо попередній елемент шаблону підходить до s[i - 1]
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        dp[i, j] = dp[i, j] || dp[i - 1, j];
                } else if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) {
                    // Звичайний символ або '.', збіг з одним символом s
                    dp[i, j] = dp[i - 1, j - 1];
                }
            }
        }

        return dp[m, n];
    }
}