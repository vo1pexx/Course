public class Solution {
    public int MyAtoi(string s) {
        int i = 0;
        int n = s.Length;

        // 1. Пропускаємо пробіли на початку
        while (i < n && s[i] == ' ')
            i++;

        // 2. Визначаємо знак
        int sign = 1;
        if (i < n && (s[i] == '-' || s[i] == '+')) {
            if (s[i] == '-')
                sign = -1;
            i++;
        }

        // 3. Читаємо цифри (провідні нулі додаються природно)
        int result = 0;
        while (i < n && s[i] >= '0' && s[i] <= '9') {
            int digit = s[i] - '0';

            // 4. Перевіряємо переповнення ДО множення на 10
            if (result > int.MaxValue / 10 ||
                (result == int.MaxValue / 10 && digit > 7)) {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + digit;
            i++;
        }

        return result * sign;
    }
}