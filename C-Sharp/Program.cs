namespace C_Sharp;

public class Yams
{
    private static Dictionary<string, int?>? _challenges;

    public static void Main()
    {
        _challenges = new Dictionary<string, int?>
        {
            { "Un", null },
            { "Deux", null },
            { "Trois", null },
            { "Quatre", null },
            { "Cinq", null },
            { "Six", null },

            { "Brelan", null },
            { "Carré", null },
            { "House", null },
            { "Petite Suite", null },
            { "Grande Suite", null },
            { "Yams", null },

            { "Chance", null },
        };

        var dés = new Dé[5];

        Tour(ref _challenges, ref dés);
    }

    private static void Tour(ref Dictionary<string, int?> challenges, ref Dé[] dés)
    {
        LancerDes(ref dés);
        AfficherChallenges(challenges, dés);
    }

    private static void LancerDes(ref Dé[] dés)
    {
        for (var index = 0; index < dés.Length; index++)
        {
            dés[index].Val = new Random().Next(1, 7);
            Console.Write(dés[index].Val + "\t");
        }
        Console.Write("\n");
    }

    private static void AfficherChallenges(Dictionary<string, int?> challenges, Dé[]? dés)
    {
        var i = 0; // Permet de gérer l'affichage des challenges
        foreach (var challenge in challenges)
        {
            if (i % 2 == 0) Console.Write("\n"); // Affiche les challenges 2 par lignes
            if (i is 6 or 12) Console.Write("\n"); // Sépare les types de challenges
            var str = $"--) {challenge.Key}: " + (challenge.Value ?? Challenge.Challenges[i](dés!));  // Affichage
            Console.Write(str + "\t");
            if (str.Length / 19 == 0) Console.Write("\t"); // Aligne moins si le premier challenge est trop gros
            // if (str.Length / 4 == 1) Console.Write("\t"); // Aligne plus si le premier challenge est trop petit
            i++;
        }
        Console.Write("\n");
    }

    public struct Dé(int val = 0) : IComparable<Dé>
    {
        // Structure d'un dé.
        private int _val = val;
        private bool _garder = false;

        public int CompareTo(Dé other) => _val.CompareTo(other._val); // Permet d'utiliser les fonctions built-in des Collections

        /*
         * Val:
         * get: Récupère la valeure du dé.
         * set: La valeure du dé doit être compri entre 1 et 6.
         */
        public int Val
        {
            get => _val;
            set => _val = value != 0 ? value % 7 : 1;
        }

        /*
         * Val:
         * get: Récupère si le dé est gardé par l'utilisateur.
         * set: Modifie la valeur du dé.
         */
        public bool Garder
        {
            get => _garder;
            set => _garder = value;
        }
    }
}

public static class Challenge // Contient le test des challenges
{
    public static readonly List<Func<Yams.Dé[], int>> Challenges = [
        Un, Deux, Trois, Quatre, Cinq, Six,
        Brelan, Carré, Full, Petite, Grande, Yams,
        Chance
    ];

    private static int Un(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 1).Sum(dé => dé.Val);
    private static int Deux(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 2).Sum(dé => dé.Val);
    private static int Trois(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 3).Sum(dé => dé.Val);
    private static int Quatre(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 4).Sum(dé => dé.Val);
    private static int Cinq(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 5).Sum(dé => dé.Val);
    private static int Six(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 6).Sum(dé => dé.Val);

    private static int Brelan(Yams.Dé[] dés)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in dés)
        {
            valeurs[dé.Val] += 1;
            if (valeurs[dé.Val] >= 3) return Chance(dés);
        }
        return 0;
    }
    private static int Carré(Yams.Dé[] dés)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in dés)
        {
            valeurs[dé.Val] += 1;
            if (valeurs[dé.Val] >= 4) return Chance(dés);
        }
        return 0;
    }
    private static int Full(Yams.Dé[] dés)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in dés) valeurs[dé.Val] += 1;
        return valeurs.Any(valeur => valeur.Value == 2 && Brelan(dés) != 0) ? 25 : 0;
    }
    private static int Petite(Yams.Dé[] dés)
    {
        var nDés = dés;
        Array.Sort(nDés);
        var mi = nDés[0];
        var ma = 3;
        var i = 0;
        var u = 0;
        foreach (var dé in nDés)
        {
            if (dé.Val == mi.Val + 1)
            {
                i++;
                mi = dé;
            } else if (dé.Val == nDés[^1].Val - ma) {
                u++;
                ma--;
            }
        }
        return i >= 4 || u >= 4 ? 30 : 0;
    }
    private static int Grande(Yams.Dé[] dés)
    {
        var nDés = dés;
        Array.Sort(nDés);
        var mi = nDés[0];
        var i = 0;
        foreach (var dé in nDés)
            if (dé.Val == mi.Val + 1)
            {
                i++;
                mi = dé;
            }
        return i >= 4 ? 40 : 0;
    }
    private static int Yams(Yams.Dé[] dés) => dés.Any(dé => dé.Val != dés[0].Val) ? 0 : 50;

    private static int Chance(Yams.Dé[] dés) => dés.Sum(dé => dé.Val);
}
