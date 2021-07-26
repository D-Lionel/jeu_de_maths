using System;

namespace jeu_de_maths
{
    class Program
    {
        enum e_Operateur //Permet de mettre des mots sur des choix, plus clair
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3
        }

        static bool PoserQuestion(int min, int max)
        {
            var rand = new Random();
            int a = rand.Next(min, max+1);
            int b = rand.Next(min, max+1);
            e_Operateur o = (e_Operateur)rand.Next(1, 4); //Choisit aléatoirement si la prochaine question sera une addition, soustraction, ou multiplication
            int resultatAttendu = 0;

            int reponseInt = 0;
            while (true)
            {
                // Fait la même chose que les "if" suivants, mais en utilisant le switch case

                /*switch (o)
                {
                    case e_Operateur.ADDITION:
                        Console.WriteLine($"{a} + {b} = ");
                        resultatAttendu = a + b;
                        break;
                    case e_Operateur.MULTIPLICATION:
                        Console.WriteLine($"{a} * {b} = ");
                        resultatAttendu = a * b;
                        break;
                    case e_Operateur.SOUSTRACTION:
                        Console.WriteLine($"{a} - {b} = ");
                        resultatAttendu = a - b;
                        break;
                    default:
                        Console.WriteLine("Erreur : opérateur inconnu");
                        return false;
                }*/

                //En fonction de l'opérateur choisit aléatoirement, on fait le calcul associé
                if (o == e_Operateur.ADDITION)
                {
                    Console.WriteLine($"{a} + {b} = ");
                    resultatAttendu = a + b;
                }
                else if (o == e_Operateur.MULTIPLICATION)
                {
                    Console.WriteLine($"{a} * {b} = ");
                    resultatAttendu = a * b;
                }
                else if (o == e_Operateur.SOUSTRACTION)
                {
                    Console.WriteLine($"{a} - {b} = ");
                    resultatAttendu = a - b;
                }
                else
                {
                    Console.WriteLine("Erreur : opérateur inconnu");
                    return false;
                }

                string reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse); // On vérifie que le user a bien rentré un int
                    if(reponseInt == resultatAttendu)
                    {
                        return true;
                    }
                    return false;                    
                }
                catch
                {
                    Console.WriteLine("Entrez un nombre svp");
                }
            }

            

            
        }

        static void Main(string[] args)
        {
            const int NB_MIN = 1;
            const int NB_MAX = 10;
            const int NB_QUESTIONS = 6;

            int points = 0;
            float moyenne = NB_QUESTIONS / 2f;

            //On lance le jeu et on compte les points
            for (int i =0; i<NB_QUESTIONS; i++) 
            {
                Console.WriteLine($"Question {(i+1)} sur {NB_QUESTIONS}");
                bool bonneReponse = PoserQuestion(NB_MIN, NB_MAX);

                if (bonneReponse)
                {
                    Console.WriteLine("Bonne réponse");
                    points++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse");
                }
                Console.WriteLine();
            }

            //En fonction des points, on affiche un commentaire sur la performance
            Console.WriteLine($"Vous avez {points} points sur {NB_QUESTIONS} questions");
            if(points == NB_QUESTIONS)
            {
                Console.WriteLine("Excellent");
            }
            else if(points == 0)
            {
                Console.WriteLine("Veuillez repassez l'école primaire svp");
            }
            else if(points < moyenne)
            {
                Console.WriteLine("Peut mieux faire");
            }
            else if (points >= moyenne)
            {
                Console.WriteLine("Pas mal");
            }
        }
    }
}
