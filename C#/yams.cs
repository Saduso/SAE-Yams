using System;

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

    public struct Dé
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

		public void LancerDé(){
        	Random rnd = new Random();
        	int randInt = rnd.Next(1,7);
        	Val = randInt;
		}
    }
}
