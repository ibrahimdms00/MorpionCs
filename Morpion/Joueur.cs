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
        private Ia Bot;
        private int couleur;

        public Joueur(string j,int couleur)
        {
            this.id = j;
            this.couleur = couleur;
            this.Bot = new Ia(j);
        }

        public int Couleur
        {
            get { return this.couleur; }
            set { this.couleur = value; }
        }


        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public void Jouer(int casechoisi, Plateau p)
        {
            if (casechoisi != 0)
            {
                p.CaseToGrille(casechoisi, out int i, out int j);
                p.Grille[i, j] = this.id;
            }
        }
        public void JouerIA(int difficulte, Plateau p)
        {
            int casechoisi = 0;
            this.Bot.JouerAleatoire(difficulte ,p,out casechoisi);
            this.Jouer(casechoisi, p);
        }




    }
}

