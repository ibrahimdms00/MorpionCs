using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Plateau(string JX, string JO, string commence)
        {
            grille = new string[3, 3];
            this.X = new Joueur(JX,1);
            this.O = new Joueur(JO,2);
            this.T = new Joueur("RAS",1);
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

        public void resetPoints()
        {
            this.X.Points = 0;
            this.O.Points = 0;
        }

        #region Statiques et accesseurs
        public string[,] Grille
        {
            get { return this.grille; }
            set { grille = value; }
        }

        public Joueur JO
        {
            get { return this.O; }
            set { O = value; }
        }
        public Joueur JX
        {
            get { return this.X; }
            set { X = value; }
        }
        public static void LancerJeu()
        {
            Console.WriteLine("=== INITIALISATION DU MORPION ===");
            System.Threading.Thread.Sleep(2000);
            string j1 = "X";
            string j2 = "O";
            Plateau monJeu = new Plateau(j1, j2, j1);
            monJeu.Menu();
        }
        public void ChoisirCouleur(string contenuPion, int codeCouleur)
        {
            switch (codeCouleur)
            {
                case 1: Console.ForegroundColor = ConsoleColor.Red; break;
                case 2: Console.ForegroundColor = ConsoleColor.Blue; break;
                case 3: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 4: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case 5: Console.ForegroundColor = ConsoleColor.Cyan; break;
                default: Console.ResetColor(); break;
            }
        }

        public void Parametres()
        {
            Console.Clear();
            Console.WriteLine("========= PARAMETRES =========");

            Console.WriteLine("1/ Changer le symbole des joueurs");
            Console.WriteLine("2/ Changer la couleur des pions");
            Console.WriteLine("3/ Retour au menu principal");
            Console.WriteLine("Votre choix ? : ");
            string? rep = Console.ReadLine();
            int choix = Convert.ToInt32(rep);
            VerifRep(ref choix);
            switch (choix)
            {
                case 1:
                    Console.WriteLine("Pour quel joueur ?");
                    Console.WriteLine("1/ " + this.X.Id);
                    Console.WriteLine("2/ " + this.O.Id);
                    string choixj1 = Console.ReadLine();
                    if (choixj1 == "1")
                      {
                        Console.Write("Nouveau symbole pour " + this.X.Id + " : ");
                        string jo = Console.ReadLine();
                        this.X.Id = jo;
                       }
                     else if (choixj1 == "2")
                       {
                         Console.Write("Nouveau symbole pour " + this.O.Id + " : ");
                         string jo = Console.ReadLine();
                         this.O.Id = jo;
                        }
                      break;
                case 2:
                    // Choix pour le Joueur X
                    Console.WriteLine($"--- Couleur pour {this.X.Id} ---");
                    Console.WriteLine("1. Rouge | 2. Bleu | 3. Jaune | 4. Magenta | 5. Cyan");
                    Console.Write("Votre choix : ");
                    this.X.Couleur = Convert.ToInt32(Console.ReadLine()); // On stocke dans X

                    // Choix pour le Joueur O
                    Console.WriteLine($"\n--- Couleur pour {this.O.Id} ---");
                    Console.WriteLine("1. Rouge | 2. Bleu | 3. Jaune | 4. Magenta | 5. Cyan");
                    Console.Write("Votre choix : ");
                    this.O.Couleur = Convert.ToInt32(Console.ReadLine()); // On stocke dans O

                    Console.WriteLine("\nCouleurs enregistrées !");
                    System.Threading.Thread.Sleep(1000);
                    break;
                case 3:
                    
                    break;
                default:
                    Console.WriteLine("Erreur : Choisissez un chiffre entre 1 et 3.");
                    break;
            }
        }

        #endregion
        #region Menu et boucle principale
        public void Menu()
        {
            bool partie = true; int i;
            bool quitter = false;
            while (quitter == false)
            {
                Console.Clear();
                Console.WriteLine("========= MORPION =========");

                ChoisirCouleur(this.X.Id, this.X.Couleur);
                Console.WriteLine($"Joueur 1 : " + this.X.Id + " | Score : " + this.X.Points);
                Console.ResetColor();

                ChoisirCouleur(this.O.Id, this.O.Couleur);
                Console.WriteLine($"Joueur 2 : " + this.O.Id + " | Score : " + this.O.Points);
                Console.ResetColor();

                Console.WriteLine("1/ Jouer une partie en local");
                Console.WriteLine("2/ Jouer une partie contre l'IA (en cours de développement)");
                Console.WriteLine("3/ Réinitialiser les points");
                Console.WriteLine("4/ Paramètres");
                Console.WriteLine("5/ Quitter le jeu");
                Console.WriteLine("Votre choix ? : ");
                string? rep = Console.ReadLine();
                int choix = Convert.ToInt32(rep);
                VerifRep(ref choix);
                switch (choix)
                {
                    case 1:
                        QuiCommence();
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
                        QuiCommence();
                        partie = true; i = 1;
                        Ia.DemandeDifficulte(out int difficulte);
                        while (partie == true)
                        {
                            RemplirTableau();
                            this.BouclePartieIA(ref i, difficulte);
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
                        resetPoints();
                        break;
                    case 4:
                        Parametres();
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Erreur : Choisissez un chiffre entre 1 et 5.");
                        break;
                }
            }

        }

        private void JoueurSuivant()
        {
            if (this.T.Id == this.X.Id)
            {
                this.T.Id = this.O.Id;
                this.T.Couleur = this.O.Couleur;
            }
            else if (this.T.Id == this.O.Id)
            { 
                this.T.Id = this.X.Id;
                this.T.Couleur = this.X.Couleur;
            }

        }

        private void QuiCommence()
        {
            bool sortie = false;
            while (sortie == false)
            {
                sortie = true;
                Console.WriteLine("Qui commence ? : ");
                Console.WriteLine("1/ " + this.X.Id);
                Console.WriteLine("2/ " + this.O.Id);
                Console.WriteLine("3/ Aléatoire");
                string choix = Console.ReadLine();
                if (choix == "1")
                {
                    this.T.Id = this.X.Id;
                    this.T.Couleur = this.X.Couleur;
                }
                else if (choix == "2")
                {
                    this.T.Id = this.O.Id;
                    this.T.Couleur = this.O.Couleur;
                }
                else if (choix == "3")
                {
                    Random rand = new Random();
                    int randomNum = rand.Next(1, 3); // Génère un nombre aléatoire entre 1 et 2
                    if (randomNum == 1)
                    {
                        this.T.Id = this.X.Id;
                        this.T.Couleur = this.X.Couleur;
                    }
                    else
                    {
                        this.T.Id = this.O.Id;
                        this.T.Couleur = this.O.Couleur;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur : Précisez le joueur qui commence ");
                    sortie = false;
                }
            }
        }

        #endregion
        #region Gestion du plateau
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
                    if (Grille[i, j] != this.O.Id && Grille[i, j] != this.X.Id)
                    {
                        rep = false;
                    }
                    
                }
            }
            
            return rep;
        }
        #endregion
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

        public void GrilleToCase(int i, int j, out int casechoisi)
        {
            casechoisi = -1;
            if (i == 0 && j == 0) { casechoisi = 1; }
            else if (i == 0 && j == 1) { casechoisi = 2; }
            else if (i == 0 && j == 2) { casechoisi = 3; }
            else if (i == 1 && j == 0) { casechoisi = 4; }
            else if (i == 1 && j == 1) { casechoisi = 5; }
            else if (i == 1 && j == 2) { casechoisi = 6; }
            else if (i == 2 && j == 0) { casechoisi = 7; }
            else if (i == 2 && j == 1) { casechoisi = 8; }
            else if (i == 2 && j == 2) { casechoisi = 9; }
            else if (casechoisi == -1)
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

        public bool CaseLibre(int i, int j)
        {
            if (Grille[i, j] != this.O.Id && Grille[i, j] != this.X.Id)
            {
                return true;
            }
            else
                return false;
        }

        public int VerifVictoire()
        {
            // Vérification Verticale | et Horizontale -
            for (int i = 0; i < 3; i++)
            {
                if (Grille[0, i] == Grille[1, i] && Grille[1, i] == Grille[2, i]) // Colonnes
                {
                    if (Grille[0, i] == this.X.Id) return 1;
                    if (Grille[0, i] == this.O.Id) return 0;
                }
                if (Grille[i, 0] == Grille[i, 1] && Grille[i, 1] == Grille[i, 2]) // Lignes
                {
                    if (Grille[i, 0] == this.X.Id) return 1;
                    if (Grille[i, 0] == this.O.Id) return 0;
                }
            }

            // Diagonale \
            if (Grille[0, 0] == Grille[1, 1] && Grille[1, 1] == Grille[2, 2])
            {
                if (Grille[1, 1] == this.X.Id) return 1;
                if (Grille[1, 1] == this.O.Id) return 0;
            }

            // Diagonale / 
            if (Grille[0, 2] == Grille[1, 1] && Grille[1, 1] == Grille[2, 0])
            {
                if (Grille[1, 1] == this.X.Id) return 1;
                if (Grille[1, 1] == this.O.Id) return 0;
            }

            return -1; // Pas de gagnant
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
                if (VerifVictoire() == 0)
                {
                    this.O.Points = this.O.Points + 1;
                }
                else if (VerifVictoire() == 1)
                {
                    this.X.Points = this.X.Points + 1;
                }
                f = false;
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
                    for (int j = 0; j < 3; j++)
                    {
                        string contenu = Grille[i, j];
                        if (contenu == this.X.Id) ChoisirCouleur(contenu, this.X.Couleur); 
                        else if (contenu == this.O.Id) ChoisirCouleur(contenu,this.O.Couleur);
                        else Console.ForegroundColor = ConsoleColor.Gray; 
                        Console.Write($" {contenu} ");
                        Console.ResetColor();
                        if (j < 2) Console.Write("|");
                    }
                    Console.WriteLine();
                    if (i < 2) Console.WriteLine("-----------");
                }
                this.AffichageChoix();
             } 
                if (c == "SansClear")
                {
                    Console.WriteLine("========= MORPION =========");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            string contenu = Grille[i, j];
                            if (contenu == this.X.Id) ChoisirCouleur(contenu, this.X.Couleur);
                            else if (contenu == this.O.Id) ChoisirCouleur(contenu, this.O.Couleur);
                            else Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($" {contenu} ");
                            Console.ResetColor();
                            if (j < 2) Console.Write("|");
                        }
                        Console.WriteLine();
                        if (i < 2) Console.WriteLine("-----------");
                    }
            }
                if (c == "sanschoix")
                {
                    Console.Clear();
                    Console.WriteLine("========= MORPION =========");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            string contenu = Grille[i, j];
                            if (contenu == this.X.Id) ChoisirCouleur(contenu, this.X.Couleur);
                            else if (contenu == this.O.Id) ChoisirCouleur(contenu, this.O.Couleur);
                            else Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($" {contenu} ");
                            Console.ResetColor();
                            if (j < 2) Console.Write("|");
                        }
                        Console.WriteLine();
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
                Console.WriteLine("Score  " + this.X.Id + " : " + this.X.Points + " | " + this.O.Points + " : " + this.O.Id);
            }
            else if (gagnant == 0)
            {
                Console.WriteLine("Le joueur " + this.O.Id + " a gagné !");
                Console.WriteLine("Score  " + this.X.Id + " : " + this.X.Points + " | " + this.O.Points + " : " + this.O.Id);
            }
        }


        #endregion
        #region Boucle de jeu
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

        public void BouclePartieIA(ref int i,int d)
        {
            // initialisation de la partie
            bool partieEnCours = true;
            int gagnant = -1;
            this.Affichage("choix");
            while (partieEnCours == true) // boucle de la partie
            {
                if (this.T.Id == this.O.Id)
                {
                    this.Affichage("sanschoix");
                    System.Threading.Thread.Sleep(1000);

                    T.JouerIA(d, this);
                    Console.WriteLine("selem");

                }
                else
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
                }
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
            JoueurSuivant();


        }
        #endregion
    }
}
