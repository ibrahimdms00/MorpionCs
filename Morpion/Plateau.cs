using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Plateau
    {
        private string[,] grille;
        public string[,] Grille
        {
            get { return this.grille; }
            set { grille = value; }
        }
        public Plateau ()
        {
            grille = new string[3, 3];
            Joueur X = new Joueur("X");
            Joueur O = new Joueur("O");
        }

        public void RemplirTableau()
        { 
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    k = k + 1;
                    grille[i,j] = k.ToString();
                }
            }
        }

        public void VerifVictoire(int Gagnant)
        {
            int i = 0; int j = 0;
            Gagnant = -1;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (Grille[0, j] == Grille[1, j] && Grille[1, j] == Grille[2, j])  // |
                    {
                        if (Grille[0, 0] == "X")
                        { Gagnant = 1; }
                        else if (Grille[0, 0] == "O")
                        { Gagnant = 0; }

                    }

                    if (Grille[i, 0] == Grille[i, 1] && Grille[i, 1] == Grille[i, 2]) // -
                    {
                        if (Grille[0, 0] == "X")
                        { Gagnant = 1; }
                        else if (Grille[0, 0] == "O")
                        { Gagnant = 0; }

                    }
                }
            }

            if (Grille[0, 0] == Grille[1, 1] && Grille[1, 1] == Grille[0, 2]) // \
            {
                if (Grille[0, 0] == "X")
                { Gagnant = 1; }
                else if (Grille[0, 0] == "O")
                { Gagnant = 0; }

            }

            if (Grille[2, 0] == Grille[1, 1] && Grille[1, 1] == Grille[0, 0]) // /
            {
                if (Grille[0, 0] == "X")
                { Gagnant = 1; }
                else if (Grille[0, 0] == "O")
                { Gagnant = 0; }

            }

        }



    }
}
