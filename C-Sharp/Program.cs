namespace C_Sharp;

public class Yams
{
    private static Dé[]? _des;
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

        _des = new Dé[5];
        for (int i = 0; i < 5; i++) _des[0] = new Dé();

        AfficherChallenges(_challenges);
        Tour();
    }

    private static void Tour()
    {
        LancerDes();
    }

    private static void LancerDes()
    {
        foreach (var de in _des!)
        {
            de.LancerDe();
            Console.Write(de.Val + "\t");
        }
        Console.Write("\n");
    }

    private static void AfficherChallenges(Dictionary<string, int?> challenges)
    {
        var i = 0; // Permet de gérer l'affichage des challenges
        foreach (var challenge in challenges)
        {
            if (i % 2 == 0) Console.Write("\n"); // Affiche les challenges 2 par lignes
            if (i is 6 or 12) Console.Write("\n"); // Sépare les types de challenges
            var str = $"--) {challenge.Key}: " + (challenge.Value is null ? "__" : challenge.Value);  // Affichage
            Console.Write(str + "\t\t");
            if (str.Length / 20 == 0) Console.Write("\t"); // Aligne moins si le premier challenge est trop gros
            // if (str.Length / 4 == 1) Console.Write("\t"); // Aligne plus si le premier challenge est trop petit
            i++;
        }
        Console.Write("\n");
    }

    public struct Dé(int val = 0)
    {
        // Structure d'un dé.
        private int _val = val;
        private bool _garder = false;

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

        public void LancerDe(){
            var rnd = new Random();
            var randInt = rnd.Next(1,7);
            Val = randInt;
        }
    }
}

public static class Challenge // Contient le test des challenges
{
    public static int Un(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 1).Sum(dé => dé.Val);
    public static int Deux(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 2).Sum(dé => dé.Val);
    public static int Trois(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 3).Sum(dé => dé.Val);
    public static int Quatre(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 4).Sum(dé => dé.Val);
    public static int Cinq(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 5).Sum(dé => dé.Val);
    public static int Six(Yams.Dé[] dés) => dés.Where(dé => dé.Val == 6).Sum(dé => dé.Val);
}
