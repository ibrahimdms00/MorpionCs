using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Joueur
    {
        private string id;

        public Joueur(string j)
        {
            this.id = j;
        }

        public void CaseToGrille(int casechoisi, out int i, out int j)
        {
            i = -1; j = -1;
            if(casechoisi == 1) { i = 0; j = 0; }
            else if (casechoisi == 2) { i = 0; j = 1; }
            else if (casechoisi == 3) { i = 0; j = 2; }
            else if (casechoisi == 4) { i = 1; j = 0; }
            else if (casechoisi == 5) { i = 1; j = 1; }
            else if (casechoisi == 6) { i = 1; j = 2; }
            else if (casechoisi == 7) { i = 2; j = 0; }
            else if (casechoisi == 8) { i = 2; j = 1; }
            else if (casechoisi == 9) { i = 2; j = 2; }
            else if (i == -1 && j == -1)
            {
                Console.WriteLine("Erreur : Valeur invalide ! Choisissez un chiffre entre 1 et 9.");
            }
            else
                Console.WriteLine("erreur100");
        }

        public void Jouer(int casechoisi,Plateau p) 
        {
            int i, j;
            string a = this.id;
            CaseToGrille(casechoisi, out i, out j);
            if (p.Grille[i, j] != "X" && p.Grille[i, j] != "O")
            { p.Grille[i, j] = a; }
            else
            { Console.WriteLine("case occupé!"); }
        }
        














    }
}
