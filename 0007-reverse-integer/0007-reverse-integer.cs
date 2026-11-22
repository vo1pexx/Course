public class Solution {
    public int Reverse(int x) {
        int result = 0;

        while (x != 0) {
            int digit = x % 10; // у C# для від'ємних x остача теж від'ємна
            x /= 10;

            // Перевіряємо переповнення ДО множення на 10
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                return 0;
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                return 0;

            result = result * 10 + digit;
        }

        return result;
    }
}