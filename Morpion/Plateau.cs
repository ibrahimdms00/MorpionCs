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
        private Joueur X;
        private Joueur O;
        private Joueur T;
        public string[,] Grille
        {
            get { return this.grille; }
            set { grille = value; }
        }
        public Plateau (string JX, string JO,string commence)
        {
            grille = new string[3, 3];
            this.X = new Joueur(JX);
            this.O = new Joueur(JO);
            this.T = new Joueur("RAS");
            if (commence == JX)
            {
                this.T.Id = this.X.Id;
            }
            else if (commence == JO) 
            {
                this.T.Id = this.X.Id;
            }
            else 
            { 
                Console.WriteLine("Erreur : Précisez le joueur qui commence ");
            }
        }
        
        public string JoueurSuivant()
        {
            string rep;
            if (this.T.Id == this.X.Id)
            {
                this.T.Id = this.O.Id;
                rep = "J1";
            }
            else if (this.T.Id == this.O.Id)
            { 
                this.T.Id = this.X.Id;
                rep = "J2";
            }
            else
            {
                rep = "Erreur methode JoueurSuivant";
            }
            return rep;
            ;
        }
       
        public bool Vide()
        {
            int k = 1;
            bool rep;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grille[i, j] != k.ToString())
                    {
                        rep = false;
                    }
                    k++; // k= k+1
                }
            }
            rep = true;
            return rep;
        }
        
        public bool Plein()
        {
            bool rep;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grille[i, j] != "X" || Grille[i, j] != "O")
                    {
                        rep = false;
                    }
                }
            }
            rep = true;
            return rep;
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
        public int VerifVictoire()
        {
            int i = 0; int j = 0;
            int Gagnant = -1;
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
            return Gagnant;
        }
        public void VerifFin(int g, bool f)
        {
            if (Plein() == true)
            {
                Console.WriteLine("Match nul !");
                f = false;
            }
            else if (VerifVictoire() != -1)
            {
                AffichageVictoire(g, f);
            }
            else if (VerifVictoire() == -1)
            {
                Console.WriteLine("Partie en cours...");
            }
        }

        #endregion
        #region Affichage Tableau
        public void Affichage(string c)
        {
            Console.Clear();
            Console.WriteLine("========= MORPION =========");
            for (int i = 0; i < 3; i++)
            {
                // On dessine une ligne
                Console.WriteLine($" {Grille[i, 0]} | {Grille[i, 1]} | {Grille[i, 2]} ");
                if (i < 2) Console.WriteLine("-----------");
            }
            if (c == "choix")
            {
              this.AffichageChoix();
            }
        }
        
        public void AffichageChoix()
        {
            Console.WriteLine("C'est au tour de : " + this.T.Id);
            Console.WriteLine(" Votre choix ? : ");
        }
        public void AffichageVictoire(int Gagnant,bool a )
        {
            if (Gagnant == 1)
            {
                Console.WriteLine("Le joueur X a gagné !");
                a = false;
            }
            else if (Gagnant == 0)
            {
                Console.WriteLine("Le joueur O a gagné !");
                a = false;
            }
            else
            {
                Console.WriteLine("Partie en cours...");
            }
        }

        public void AffichageComplet()
        {
            // initialisation de la partie
            bool partieEnCours = true;
            int gagnant = -1;
            while (partieEnCours == true)
            {
                this.Affichage("choix");
                string rep = Console.ReadLine();
                T.Jouer(Convert.ToInt32(rep), this);

                // Affichage si fin de la manche
                VerifFin(gagnant,partieEnCours);
                if (gagnant != -1)
                {
                    partieEnCours = false;
                }


                this.Affichage(" ");
                JoueurSuivant();
            }
        }
        #endregion

    }
}
