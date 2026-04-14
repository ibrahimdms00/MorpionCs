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
        // Dans Plateau.cs
        public static void LancerJeu()
        {
            Console.WriteLine("=== INITIALISATION DU MORPION ===");
            System.Threading.Thread.Sleep(2000);
            string j1 = "X";
            string j2 = "O";
            Plateau monJeu = new Plateau(j1, j2, j1);
            monJeu.Menu(j1, j2);
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
                this.T.Id = this.O.Id;
            }
            else 
            { 
                Console.WriteLine("Erreur : Précisez le joueur qui commence ");
            }
        }
        public void Menu(string j1, string j2)
        {
            bool partie = true; int i;
            bool quitter = false;
            while (quitter == false)
            {
                Console.Clear();
                Console.WriteLine("========= MORPION =========");
                Console.WriteLine($"Joueur 1 : {j1}");
                Console.WriteLine($"Joueur 2 : {j2}");
                Console.WriteLine("1/ Jouer une partie en local");
                Console.WriteLine("2/ Jouer une partie contre l'IA (en cours de développement)");
                Console.WriteLine("3/ Paramètres");
                Console.WriteLine("4/ Quitter le jeu");
                Console.WriteLine("Votre choix ? : ");
                string? rep = Console.ReadLine();
                int choix = Convert.ToInt32(rep);
                VerifRep(ref choix);
                switch (choix)
                {
                    case 1:
                        partie = true; i = 1;
                        while (partie == true)
                        {
                            RemplirTableau();
                            this.BouclePartieLocal(ref i);
                            if (i == 0)
                            {
                                partie = false;
                            }
                            else if (i == 1)
                            {
                                partie = true;
                            }
                            else
                            {
                                Console.WriteLine("Erreur : Boucle Menu");
                            }
                        }
                        
                        break;
                    case 2:
                        partie = true; i = 1; int j; 
                        while (partie == true)
                        {
                            RemplirTableau();
                            Ia.DemandeJoueur(out j);
                            this.T.Id = j.ToString();
                            this.BouclePartieLocal(ref i);
                            if (i == 0)
                            {
                                partie = false;
                            }
                            else if (i == 1)
                            {
                                partie = true;
                            }
                            else
                            {
                                Console.WriteLine("Erreur : Boucle Menu");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("En cours de développement...");
                        break;
                    case 4:
                        Console.WriteLine("Merci d'avoir joué !");
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Erreur : Choisissez un chiffre entre 1 et 4.");
                        break;
                }
            }

        }

        private string JoueurSuivant()
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
            
        }

        public bool CaseLibre(int casechoisi)
        {
            CaseToGrille(casechoisi, out int i, out int j);
            if (Grille[i, j] != this.O.Id && Grille[i, j] != this.X.Id)
            {
                return true;
            }
            else
                return false;
        }

        private bool Vide()
        {
            int k = 1;
            bool rep = true;
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
            return rep;
        }
        
        public bool Plein()
        {
            bool rep = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grille[i, j] != "X" && Grille[i, j] != "O")
                    {
                        rep = false;
                    }
                    
                }
            }
            
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
        private void RemplirTableau()
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

        private int VerifVictoire()
        {
            int i = 0; int j = 0;
            int Gagnant = -1;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (Grille[0, j] == Grille[1, j] && Grille[1, j] == Grille[2, j])  // |
                    {
                        if (Grille[0, j] == "X")
                        { Gagnant = 1; }
                        else if (Grille[0, j] == "O")
                        { Gagnant = 0; }

                    }

                    if (Grille[i, 0] == Grille[i, 1] && Grille[i, 1] == Grille[i, 2]) // -
                    {
                        if (Grille[i, 0] == "X")
                        { Gagnant = 1; }
                        else if (Grille[i, 0] == "O")
                        { Gagnant = 0; }

                    }
                }
            }

            if (Grille[0, 0] == Grille[1, 1] && Grille[1, 1] == Grille[2, 2]) // \
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
        private bool VerifFin(ref int g)
        {
            bool f = true;
            g = VerifVictoire(); // g = -1 : pas de gagnant, g = 0 : O gagne, g = 1 : X gagne
            if (this.Plein() == true)
            {
                Console.WriteLine("Match nul !");
                f = false;
            }
            else if (VerifVictoire() == 0 || VerifVictoire() == 1)
            {
                f= false;
            }
            return f;
        }

        private void VerifRep(ref int casechoisi)
        {
            while (casechoisi != 0 &&casechoisi != 1 && casechoisi != 2 && casechoisi != 3 && casechoisi != 4 && casechoisi != 5 && casechoisi != 6 && casechoisi != 7 && casechoisi != 8 && casechoisi != 9)
            {
                Console.Clear();
                Console.WriteLine("Erreur : Choisissez un chiffre entre 1 et 9.");
                Console.WriteLine("Cliquez sur ENTREE pour continuer");
                Console.ReadLine();
                Console.Clear();
                this.Affichage("SansClear");
                this.AffichageChoix();
                casechoisi = Convert.ToInt32(Console.ReadLine());
            }
        }

        #endregion
        #region Affichage Tableau
        private void Affichage(string c)
        {
            
            if (c == "choix")
            {
                Console.Clear();
                Console.WriteLine("========= MORPION =========");
                for (int i = 0; i < 3; i++)
                {
                    // On dessine une ligne
                    Console.WriteLine($" {Grille[i, 0]} | {Grille[i, 1]} | {Grille[i, 2]} ");
                    if (i < 2) Console.WriteLine("-----------");
                }
                this.AffichageChoix();
            }
            if (c == "SansClear")
            {
                Console.WriteLine("========= MORPION =========");
                for (int i = 0; i < 3; i++)
                {
                    // On dessine une ligne
                    Console.WriteLine($" {Grille[i, 0]} | {Grille[i, 1]} | {Grille[i, 2]} ");
                    if (i < 2) Console.WriteLine("-----------");
                }
            }
            if (c == "sanschoix")
            {
                Console.Clear();
                Console.WriteLine("========= MORPION =========");
                for (int i = 0; i < 3; i++)
                {
                    // On dessine une ligne
                    Console.WriteLine($" {Grille[i, 0]} | {Grille[i, 1]} | {Grille[i, 2]} ");
                    if (i < 2) Console.WriteLine("-----------");
                }
            }
        }
        private void AffichageChoix()
        {
            Console.WriteLine("Pour quitter tapez 0");
            Console.WriteLine("C'est au tour de : " + this.T.Id);
            Console.WriteLine(" Votre choix ? : ");
        }
        private void AffichageGagnant(int gagnant)
        {
            if (gagnant == 1)
            {
                Console.WriteLine("Le joueur " + this.X.Id + " a gagné !");
            }
            else if (gagnant == 0)
            {
                Console.WriteLine("Le joueur " + this.O.Id + " a gagné !");
            }
        }


        #endregion
        public void BouclePartieLocal(ref int i)
        {
            // initialisation de la partie
            bool partieEnCours = true;
            int gagnant = -1;
            this.Affichage("choix");
            while (partieEnCours == true) // boucle de la partie
            {
                this.Affichage("choix");
                string? rep = Console.ReadLine();
                int choix = Convert.ToInt32(rep);
                VerifRep(ref choix);
                if (choix == 0)
                {
                    Console.WriteLine("Vous quittez la partie...");
                    Console.WriteLine("Cliquez sur ENTREE pour continuer");
                    Console.ReadLine();
                    partieEnCours = false;
                    i = 0; // retourner au menu
                }
                T.Jouer(choix, this);
                // Verification si fin de la manche
                if (VerifFin(ref gagnant) == false)
                {
                    partieEnCours = false;
                    this.Affichage("sanschoix");
                    AffichageGagnant(gagnant);
                    Console.WriteLine("Pour continuer cliquez sur ENTREE");
                    Console.ReadLine();
                    i = 1; // rejouer une partie
                }
                else
                {
                    JoueurSuivant();
                }

            }

        }

        public void BouclePartieIA(ref int i)
        {
            // initialisation de la partie
            bool partieEnCours = true;
            int gagnant = -1;
            this.Affichage("choix");
            while (partieEnCours == true) // boucle de la partie
            {
                if (this.T.Id == "IA")
                {
                    T.JouerIA(1, this);
                }
                this.Affichage("choix");
                string? rep = Console.ReadLine();
                int choix = Convert.ToInt32(rep);
                VerifRep(ref choix);


                if (choix == 0)
                {
                    Console.WriteLine("Vous quittez la partie...");
                    Console.WriteLine("Cliquez sur ENTREE pour continuer");
                    Console.ReadLine();
                    partieEnCours = false;
                    i = 0; // retourner au menu
                }
                T.Jouer(choix, this);
                // Verification si fin de la manche
                if (VerifFin(ref gagnant) == false)
                {
                    partieEnCours = false;
                    this.Affichage("sanschoix");
                    AffichageGagnant(gagnant);
                    Console.WriteLine("Pour continuer cliquez sur ENTREE");
                    Console.ReadLine();
                    i = 1; // rejouer une partie
                }
                else
                {
                    JoueurSuivant();
                }

            }

        }


    }
}
