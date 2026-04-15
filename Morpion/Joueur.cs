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
        private Ia bot;
        private int couleur;
        private int points;

        public Joueur(string j,int couleur)
        {
            this.id = j;
            this.couleur = couleur;
            this.bot = new Ia(j);
            this.points = 0;
        }

        public int Couleur
        {
            get { return this.couleur; }
            set { this.couleur = value; }
        }
        public Ia Bot
        {
            get { return this.bot; }
            set { this.bot = value; }
        }


        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int Points
            {
            get { return this.points; }
            set { this.points = value; }
        }

        public void Jouer(int casechoisi, Plateau p)
        {
            p.CaseToGrille(casechoisi, out int i, out int j);
            if (p.CaseLibre(i, j))
            {
                if (casechoisi != 0)
                {
                    p.CaseToGrille(casechoisi, out i, out j);
                    p.Grille[i, j] = this.id;
                }
                else                {
                    Console.WriteLine("Case invalide, veuillez choisir une case libre.");
                }
            }
        }
        public void JouerIA(int difficulte, Plateau p)
        {
            int casechoisi = 0;

            if (difficulte >= 2)
            {
                if (this.Bot.StrategieAvancee(p, out casechoisi, difficulte) == false) // Si aucune stratégie ne s'applique
                {
                    this.Bot.JouerAleatoire(p, out casechoisi); // On joue au hasard
                    this.Jouer(casechoisi, p);
                }
                    else
                    {
                        this.Jouer(casechoisi, p);
                }
            }
            else if (difficulte == 1)
            {
                this.Bot.JouerAleatoire(p, out casechoisi); // On joue au hasard
                this.Jouer(casechoisi, p); 
            }
        }




    }
}

