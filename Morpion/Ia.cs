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


        public bool StrategieAvancee(Plateau p, out int caseTrouvee, int difficulte)
        {
            caseTrouvee = 0;
            // ÉTAPE 1 : CHERCHER À GAGNER (Priorité absolue)
            if (AnalyserEtJouer(p, p.JO.Id, out caseTrouvee)) return true;

            // ÉTAPE 2 : CHERCHER À BLOQUER L'ADVERSAIRE (JX)
            if (AnalyserEtJouer(p, p.JX.Id, out caseTrouvee)) return true;

            if (difficulte == 3)
            {
                if (p.CaseLibre(5)) { caseTrouvee = 5; return true; }

                // ÉTAPE 4 : PRENDRE UN COIN (1, 3, 7 ou 9)
                // Les coins permettent de créer des "fourchettes" (deux lignes de victoire en même temps)
                int[] coins = { 1, 3, 7, 9 };
                // On mélange un peu les coins pour ne pas que l'IA soit prévisible
                foreach (int coin in coins.OrderBy(x => aleatoire.Next()))
                {
                    if (p.CaseLibre(coin)) { caseTrouvee = coin; return true; }
                }
            }

            if (difficulte == 4)
            {
                // L'IA teste chaque case vide pour voir si elle crée deux lignes de 2 pions
                if (DetecterFourchette(p, p.JO.Id, out caseTrouvee)) return true;

                // L'IA bloque aussi les fourchettes potentielles de l'adversaire
                if (DetecterFourchette(p, p.JX.Id, out caseTrouvee)) return true;
            }
            return false;
        }

        private bool AnalyserEtJouer(Plateau p, string symboleATester, out int caseTrouvee)
        {
            caseTrouvee = 0;
            for (int j = 0; j < 3; j++)
            {
                // --- LIGNES ---
                if (p.Grille[j, 0] == symboleATester && p.Grille[j, 1] == symboleATester && p.CaseLibre(j, 2))
                { p.GrilleToCase(j, 2, out caseTrouvee); return true; }
                if (p.Grille[j, 1] == symboleATester && p.Grille[j, 2] == symboleATester && p.CaseLibre(j, 0))
                { p.GrilleToCase(j, 0, out caseTrouvee); return true; }
                if (p.Grille[j, 0] == symboleATester && p.Grille[j, 2] == symboleATester && p.CaseLibre(j, 1))
                { p.GrilleToCase(j, 1, out caseTrouvee); return true; }

                // --- COLONNES ---
                if (p.Grille[0, j] == symboleATester && p.Grille[1, j] == symboleATester && p.CaseLibre(2, j))
                { p.GrilleToCase(2, j, out caseTrouvee); return true; }
                if (p.Grille[1, j] == symboleATester && p.Grille[2, j] == symboleATester && p.CaseLibre(0, j))
                { p.GrilleToCase(0, j, out caseTrouvee); return true; }
                if (p.Grille[0, j] == symboleATester && p.Grille[2, j] == symboleATester && p.CaseLibre(1, j))
                { p.GrilleToCase(1, j, out caseTrouvee); return true; }

                // --- DIAGONALE \ ---
                if (p.Grille[0, 0] == symboleATester && p.Grille[1, 1] == symboleATester && p.CaseLibre(2, 2))
                { p.GrilleToCase(2, 2, out caseTrouvee); return true; }

                if (p.Grille[1, 1] == symboleATester && p.Grille[2, 2] == symboleATester && p.CaseLibre(0, 0))
                { p.GrilleToCase(0, 0, out caseTrouvee); return true; }

                if (p.Grille[0, 0] == symboleATester && p.Grille[2, 2] == symboleATester && p.CaseLibre(1, 1))
                { p.GrilleToCase(1, 1, out caseTrouvee); return true; }

                // --- DIAGONALE / ---
                if (p.Grille[0, 2] == symboleATester && p.Grille[1, 1] == symboleATester && p.CaseLibre(2, 0))
                { p.GrilleToCase(2, 0, out caseTrouvee); return true; }

                if (p.Grille[1, 1] == symboleATester && p.Grille[2, 0] == symboleATester && p.CaseLibre(0, 2))
                { p.GrilleToCase(0, 2, out caseTrouvee); return true; }

                if (p.Grille[0, 2] == symboleATester && p.Grille[2, 0] == symboleATester && p.CaseLibre(1, 1))
                { p.GrilleToCase(1, 1, out caseTrouvee); return true; }

            }
            return false;
        }
        public void JouerAleatoire(Plateau p, out int casechoisi)
        {
            casechoisi = 0;
            if (p.Plein()) return;
            do
            {
                casechoisi = aleatoire.Next(1, 10);
            } while (p.CaseLibre(casechoisi) == false);
        }

        private bool DetecterFourchette(Plateau p, string symbole, out int caseTrouvee)
        {
            caseTrouvee = 0;
            for (int c = 1; c <= 9; c++)
            {
                if (p.CaseLibre(c))
                {
                    // Simulation : on pose temporairement le pion
                    p.CaseToGrille(c, out int i, out int j);
                    string ancienneValeur = p.Grille[i, j];
                    p.Grille[i, j] = symbole;

                    // On compte combien d'opportunités de victoire ce coup crée
                    int opportunites = CompterOpportunitesVictoire(p, symbole);

                    // Annulation de la simulation
                    p.Grille[i, j] = ancienneValeur;

                    if (opportunites >= 2)
                    {
                        caseTrouvee = c;
                        return true;
                    }
                }
            }
            return false;
        }

        private int CompterOpportunitesVictoire(Plateau p, string s)
        {
            int count = 0;
            // On réutilise ta logique de AnalyserEtJouer mais sans le "out" 
            // pour compter les lignes où il manque 1 pion pour gagner

            // (Exemple simplifié pour les lignes)
            for (int j = 0; j < 3; j++)
            {
                if (p.Grille[j, 0] == s && p.Grille[j, 1] == s && p.CaseLibre(j, 2)) count++;
                if (p.Grille[j, 1] == s && p.Grille[j, 2] == s && p.CaseLibre(j, 0)) count++;
                // ... faire de même pour colonnes et diagonales
            }
            return count;
        }

    }
       

    }


        
    


