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
}