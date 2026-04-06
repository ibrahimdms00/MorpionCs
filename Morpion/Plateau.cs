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

        #region Logique de conversion 
        public void CaseToGrille(int casechoisi, out int i, out int j)
        {
            i = -1; j = -1;
            if (casechoisi == 1) { i = 0; j = 0; }
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

        public void VerifVictoire(out int Gagnant)
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
        #endregion
        #region Affichage Tableau
        public void AffichageSeule()
        {
            Console.Clear();
            Console.WriteLine("========= MORPION =========");
            for (int i = 0; i < 3; i++)
            {
                // On dessine une ligne
                Console.WriteLine($" {Grille[i, 0]} | {Grille[i, 1]} | {Grille[i, 2]} ");
                if (i < 2) Console.WriteLine("-----------");
            }
            Console.WriteLine(" Votre choix ? : ");
        }

        public void AffichageComplet()
        {
            this.AffichageComplet();
            string rep = Console.ReadLine();
            CaseToGrille(Convert.ToInt32(rep), out int i, out int j);
            VerifVictoire(out int Gagnant);
            if (Gagnant == 1)
            {
                Console.WriteLine("Le joueur X a gagné !");
            }
            else if (Gagnant == 0)
            {
                Console.WriteLine("Le joueur O a gagné !");
            }

        }


        #endregion

    }
}
