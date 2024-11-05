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
        private int _dé;
        private int _val;
        private bool _garder;

        public int Dé
        {
            get => _dé;
            set => value % 5;
        }
        public int Val
        {
            get => _val;
            set => value % 6;
        }

        public bool Garder
        {
            get => _garder;
            set => value || _garder;
        }
    }
}