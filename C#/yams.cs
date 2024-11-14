using System;
using System.Collections.Generic;

public class yams
{
    private static Dé[] _des;
    private static Dictionnary<string, int> _challenges;

    public static void Main()
    {
        _challenges = new Dictionary<string, int>
        {
            { "Un", null },
            { "Deux", null },
            { "Trois", null },
            { "Quatres", null },
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

        Tour();
    }

    private static void Tour()
    {
        LancerDes();
    }

    private static void LancerDes()
    {
        foreach (var de in _des)
        {
            de.LancerDe();
            Console.WriteLine(de.Val);
        }
    }

    private struct Dé
    {
        // Structure d'un dé.
        private int _val;
        private bool _garder;

        public Dé(int val = 0) {
            _val = val;
            _garder = false;
        }

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
            Random rnd = new Random();
            int randInt = rnd.Next(1,7);
            Val = randInt;
        }
    }
}