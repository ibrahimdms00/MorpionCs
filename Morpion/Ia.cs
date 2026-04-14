using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Ia
    {
        private string id;

        Random aleatoire = new Random();
        public Ia(string j)
        {
            this.id = j;
        }
        public static void DemandeJoueur(out string ia, Plateau p)
        {
            Console.Write("Choisissez le symbole de l'IA (ou Entrée pour 'O') : ");
            string saisie = Console.ReadLine();

            ia = string.IsNullOrWhiteSpace(saisie) ? "O" : saisie;
            if (ia == p.JX.Id)
            {
                Console.WriteLine("Symbole invalide. Vous jouez deja avec" + p.JX.Id + " alors le symbole sera O");
                ia = "O";
            }
            p.JO.Id = ia;
        }

        public static void DemandeDifficulte(out int difficulte)
        {
            Console.WriteLine("Choisissez la difficulté de l'IA :");
            Console.WriteLine("1. Facile");
            Console.WriteLine("2. Moyen");
            Console.WriteLine("3. Difficile");
            Console.WriteLine("4. Impossible");
            Console.Write("Votre choix : ");
            while (!int.TryParse(Console.ReadLine(), out difficulte) || difficulte < 1 || difficulte > 4)
            {
                Console.WriteLine("Choix invalide. Veuillez entrer un nombre entre 1 et 4.");
                Console.Write("Votre choix : ");
            }
        }
        public void JouerAleatoire(int diff, Plateau p,out int casechoisi)
        {
            casechoisi = aleatoire.Next(1, 10);
            bool libre = false;
            while (libre == false && p.Plein() == false)
            {
                libre = p.CaseLibre(casechoisi);
                if (libre == false)
                {
                    casechoisi = aleatoire.Next(1, 10);
                }
            }
        }
    }
}

