public class yams
{
    public static void Main () {
        
    }

    /*
        Genere un nombre aleatoire entre 1 et 6 compris
    */
    public static int LancerDes(){
        Random rnd = new Random();
        int randInt = rnd.Next(1,7);

        return randInt;

    }

    struct Dé
    {
        // Structure d'un dé.
        private int _val;
        private bool _garder;

        /*
         * Val:
         * get: Récupère la valeure du dé.
         * set: La valeure du dé doit être compri entre 0 et 6.
         */
        public int Val
        {
            get => _val;
            set => value % 6;
        }

        /*
         * Val:
         * get: Récupère si le dé est gardé par l'utilisateur.
         * set: Modifie la valeur du dé.
         */
        public bool Garder
        {
            get => _garder;
            set => value;
        }
    }
}