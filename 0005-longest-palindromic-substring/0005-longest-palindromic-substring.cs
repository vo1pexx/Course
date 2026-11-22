public class Solution {
    public string LongestPalindrome(string s) {
        int start = 0;
        int maxLen = 1;

        for (int center = 0; center < s.Length; center++) {
            // Непарна довжина: центр в одному символі
            int len1 = Expand(s, center, center);
            // Парна довжина: центр між двома символами
            int len2 = Expand(s, center, center + 1);

            int len = System.Math.Max(len1, len2);
            if (len > maxLen) {
                maxLen = len;
                start = center - (len - 1) / 2;
            }
        }

        return s.Substring(start, maxLen);
    }

    private int Expand(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        // Після виходу з циклу межі вже на один крок за паліндромом
        return right - left - 1;
    }
}