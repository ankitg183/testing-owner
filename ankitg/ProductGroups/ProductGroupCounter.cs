namespace ProductGroups;

public class ProductGroupCounter
{
    public int CountGroups(int n, IEnumerable<(int, int)> constraints)
    {
        if (n == 0)
            return 0;

        var parent = new int[n + 1];
        var rank = new int[n + 1];
        for (int i = 1; i <= n; i++)
            parent[i] = i;

        foreach (var (a, b) in constraints)
        {
            if (a < 1 || a > n || b < 1 || b > n)
                throw new ArgumentException(
                    $"Constraint ({a}, {b}) contains a product ID outside the valid range [1, {n}].");

            if (a == b)
                continue;

            Union(parent, rank, a, b);
        }

        int groups = 0;
        for (int i = 1; i <= n; i++)
            if (Find(parent, i) == i)
                groups++;

        return groups;
    }

    private static int Find(int[] parent, int x)
    {
        while (parent[x] != x)
            x = parent[x];
        return x;
    }

    private static void Union(int[] parent, int[] rank, int a, int b)
    {
        int rootA = Find(parent, a);
        int rootB = Find(parent, b);

        if (rootA == rootB)
            return;

        // union by rank
        if (rank[rootA] < rank[rootB])
            parent[rootA] = rootB;
        else if (rank[rootA] > rank[rootB])
            parent[rootB] = rootA;
        else
        {
            parent[rootB] = rootA;
            rank[rootA]++;
        }
    }
}
