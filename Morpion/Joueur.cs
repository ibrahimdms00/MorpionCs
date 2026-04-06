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
