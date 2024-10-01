using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        var notifications = new List<(int, int, double, int)>
        {
            (1, 0, 15.4, 50),
            (2, 0, 15.5, 50),
            (2, 2, 0, 0),
            (2, 0, 15.4, 10),
            (3, 0, 15.9, 30),
            (3, 1, 0, 20),
            (4, 0, 16.50, 200),
            (5, 0, 17.00, 100),
            (5, 0, 16.59, 20),
            (6, 2, 0, 0),
            (1, 2, 0, 0),
            (2, 1, 15.6, 0)
        };

        var orderBook = new Dictionary<int, (double, int)>();

        foreach (var notification in notifications)
        {
            int pos = notification.Item1;
            int action = notification.Item2;
            double value = notification.Item3;
            int quantity = notification.Item4;

            if (action == 0) // INSERIR
            {
                orderBook[pos] = (value, quantity);
            }
            else if (action == 1 && orderBook.ContainsKey(pos)) // MODIFICAR
            {
                orderBook[pos] = (value, quantity != 0 ? quantity : orderBook[pos].Item2);
            }
            else if (action == 2) // DELETAR
            {
                orderBook.Remove(pos);
            }
        }

        foreach (var entry in orderBook)
        {
            Console.WriteLine($"{entry.Key},{entry.Value.Item1},{entry.Value.Item2}");
        }
    }
}
