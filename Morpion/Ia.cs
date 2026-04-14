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
        public static void DemandeJoueur(out string ia)
        {
            Console.WriteLine("Quelle est le symbole que l'IA va utiliser ? (cliquez ENTREE pour O)");          
            ia = Console.ReadLine() ?? "O";
        }
        public void JouerAleatoire(int diff, Plateau p)
        {
            int casechoisi = aleatoire.Next(1,10);
            bool libre = false;
            while (libre == false && p.Plein() == false)
            {
                libre = p.CaseLibre(casechoisi);
            }
        }

        }
    }

