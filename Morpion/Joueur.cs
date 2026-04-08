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

        public string Id
        {
           get { return this.id;}
           set { this.id = value; }
        }   

        public void Jouer(int casechoisi,Plateau p) 
        {
            bool a = false;
            while (a == false)
            {
                if (casechoisi < 1 || casechoisi > 9)
                {
                    
                    Console.WriteLine("Case invalide. Veuillez choisir une case entre 1 et 9.");
                    Console.WriteLine("Cliquer sur entrée pour continuer.");
                    Console.ReadLine();
                }
                else
                {
                    p.CaseToGrille(casechoisi, out int i, out int j);
                    if (p.Vide() == false)
                    {
                        Console.WriteLine("Case déjà occupée. Veuillez choisir une autre case.");
                        Console.WriteLine("Cliquer sur entrée pour continuer.");
                        Console.ReadLine();
                    }
                    else
                    {
                        p.Grille[i, j] = this.id;
                        a = true; // passer son tour
                    }
                
                }

            }

            }

        }
       














    }

