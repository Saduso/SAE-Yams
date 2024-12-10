namespace C_Sharp;

public class Yams
{
    private static readonly Dictionary<string, string> Raccourcis = new()
    {
        { "Un", "un" }, { "Deux", "de" }, { "Trois", "tr" }, { "Quatre", "qt" }, { "Cinq", "cq" }, { "Six", "si" },
        { "Brelan", "br" }, { "Carré", "cr" }, { "Full", "fl" }, { "Petite Suite", "ps" }, { "Grande Suite", "gs" },
        { "Yams", "ym" },
        { "Chance", "ch" },
    };

    public static void Main()
    {
        var joueurs = new Joueur[2];
        for (var i = 0; i < 2; i++)
        {
            Console.Write($"\nEntrez le nom du joueur {i+1} : ");
            joueurs[i] = new Joueur(Console.ReadLine() ?? $"Joueur {i+1}");
        }

        Tour(ref joueurs[0]);
    }

    private static void Tour(ref Joueur joueur)
    {
        Console.WriteLine($"Tour de {joueur.Nom}");
        var des = new Dé[5];
        for (var i = 0; i < 3; i++)
        {
            Console.Write((des[0].Garder ? "-" : 1) + "\t" + (des[1].Garder ? "-" : 2) + "\t" + (des[2].Garder ? "-" : 3) + "\t" + (des[3].Garder ? "-" : 4) + "\t" + (des[4].Garder ? "-" : 5) + "\n" +
                          "INDICE POUR CONSERVER UN DÉ\n");
            LancerDes(ref des);
            AfficherDes(des);
            Console.WriteLine("rl) Relance les dés");
            AfficherChallenges(joueur.Challenges, des);
            Console.Write("\nVotre choix : ");
            var raccourcis = RaccourcisValides(joueur.Challenges, des);
            var res = "1";
            var truc = new string[5]; // Liste permet de comparer une chaîne de character potentiellement nombre à des nombre entre 1 et 5.
            for (var j = 0; j < 5; j++) truc[j] = j + 1 + "";
            while (int.TryParse(res, out _) && truc[int.Parse(res!) - 1] == res) { // Tant que le dernier nombre est entre 1 et 5 (permet de garder plusieurs dés).
                res = Console.ReadLine();
                if (!int.TryParse(res, out _)) continue;
                if (truc[int.Parse(res!) - 1] != res) continue;
                des[int.Parse(res) - 1].Garder = !des[int.Parse(res) - 1].Garder;
                Console.Write("\n" + (des[0].Garder ? "-" : 1) + "\t" + (des[1].Garder ? "-" : 2) + "\t" +
                              (des[2].Garder ? "-" : 3) + "\t" + (des[3].Garder ? "-" : 4) + "\t" +
                              (des[4].Garder ? "-" : 5) + "\n" +
                              "INDICE POUR CONSERVER UN DÉ\n");
                AfficherDes(des);
                Console.WriteLine("rl) Relance les dés");
                Console.Write("\nVotre choix : ");
            }
            if (res == "rl") continue;
            if (raccourcis.ContainsKey(res!))
            {
                joueur.Challenges[raccourcis[res!]] =
                    Challenge.Challenges[joueur.Challenges.Keys.ToList().IndexOf(raccourcis[res!])](des);
                return;
            }
            // else
            Console.WriteLine("Ce challenge n'est pas disponible");
            i++;
        }
    }

    private static Dictionary<string, string> RaccourcisValides(Dictionary<string, int?> challenges, Dé[] des)
    {
        var correctChallenge = new Dictionary<string, string>();
        var i = 0;
        foreach (var challenge in challenges)
        {
            var challengeResult = Challenge.Challenges[i](des);
            var challengesRacc = challengeResult == 0 || challenge.Value is not null;
            if (!challengesRacc) correctChallenge[Raccourcis[challenge.Key]] = challenge.Key;
            i++;
        }
        return correctChallenge;
    }

    private static void LancerDes(ref Dé[] des)
    {
        for (var index = 0; index < des.Length; index++)
            if (!des[index].Garder) des[index].Val = new Random().Next(1, 7);
    }

    private static void AfficherDes(Dé[] des)
    {
        foreach (var de in des) Console.Write(de.Val + "\t");
        Console.Write("\n");
    }

    private static void AfficherChallenges(Dictionary<string, int?> challenges, Dé[]? des)
    {
        var i = 0; // Permet de gérer l'affichage des challenges
        foreach (var challenge in challenges)
        {
            if (i % 2 == 0) Console.Write("\n"); // Affiche les challenges 2 par lignes
            if (i is 6 or 12) Console.Write("\n"); // Sépare les types de challenges
            var challengeResult = Challenge.Challenges[i](des!);
            var challengesRacc = challengeResult == 0 || challenge.Value is not null ? "--" : Raccourcis[challenge.Key];
            var str = $"{challengesRacc}) {challenge.Key}: " + (challenge.Value ?? challengeResult);  // Affichage
            Console.Write(str + "\t");
            if (str.Length / 19 == 0) Console.Write("\t"); // Aligne moins si le premier challenge est trop gros
            // if (str.Length / 4 == 1) Console.Write("\t"); // Aligne plus si le premier challenge est trop petit
            i++;
        }
        Console.Write("\n");
    }

    public struct Joueur(string nom)
    {
        public string? Nom { get; set; } = nom;

        public Dictionary<string, int?> Challenges { get; set; } = new()
        {
            { "Un", null }, { "Deux", null }, { "Trois", null }, { "Quatre", null }, { "Cinq", null }, { "Six", null },
            { "Brelan", null }, { "Carré", null }, { "Full", null }, { "Petite Suite", null }, { "Grande Suite", null },
            { "Yams", null },
            { "Chance", null },
        };
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
            set => _val = value;
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

    private static int Brelan(Yams.Dé[] des)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in des)
        {
            valeurs[dé.Val] += 1;
            if (valeurs[dé.Val] >= 3) return Chance(des);
        }
        return 0;
    }
    private static int Carré(Yams.Dé[] des)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in des)
        {
            valeurs[dé.Val] += 1;
            if (valeurs[dé.Val] >= 4) return Chance(des);
        }
        return 0;
    }
    private static int Full(Yams.Dé[] des)
    {
        var valeurs = new Dictionary<int, int> { {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0} };
        foreach (var dé in des) valeurs[dé.Val] += 1;
        return valeurs.Any(valeur => valeur.Value == 2 && Brelan(des) != 0) ? 25 : 0;
    }
    private static int Petite(Yams.Dé[] dés)
    {
        var nDes = dés.ToArray();
        Array.Sort(nDes);
        var mi = nDes[0];
        var ma = 3;
        var i = 0;
        var u = 0;
        foreach (var de in nDes)
        {
            if (de.Val == mi.Val + 1)
            {
                i++;
                mi = de;
            } else if (de.Val == nDes[^1].Val - ma) {
                u++;
                ma--;
            }
        }
        return i >= 4 || u >= 4 ? 30 : 0;
    }
    private static int Grande(Yams.Dé[] dés)
    {
        var nDes = dés.ToArray();
        Array.Sort(nDes);
        var mi = nDes[0];
        var i = 0;
        foreach (var de in nDes)
            if (de.Val == mi.Val + 1)
            {
                i++;
                mi = de;
            }
        return i >= 4 ? 40 : 0;
    }
    private static int Yams(Yams.Dé[] dés) => dés.Any(dé => dé.Val != dés[0].Val) ? 0 : 50;

    private static int Chance(Yams.Dé[] dés) => dés.Sum(dé => dé.Val);
}
