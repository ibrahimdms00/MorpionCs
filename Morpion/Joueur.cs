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

        public Joueur(string j)
        {
            this.id = j;
            this.Bot = new Ia(j);
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
            this.Bot.JouerAleatoire(difficulte ,p);
        }




    }
}

