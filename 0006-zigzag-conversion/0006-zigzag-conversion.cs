using System.Text;

public class Solution {
    public string Convert(string s, int numRows) {
        // Якщо рядок один або рядків не менше, ніж символів, зигзаг нічого не змінює
        if (numRows == 1 || numRows >= s.Length)
            return s;

        var rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new StringBuilder();

        int row = 0;
        int step = 1; // 1 - рухаємось вниз, -1 - вгору

        foreach (char c in s) {
            rows[row].Append(c);

            // На верхньому й нижньому рядках змінюємо напрямок
            if (row == 0)
                step = 1;
            else if (row == numRows - 1)
                step = -1;

            row += step;
        }

        var result = new StringBuilder(s.Length);
        foreach (var sb in rows)
            result.Append(sb);

        return result.ToString();
    }
}