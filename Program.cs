using System;

namespace jeu_de_maths
{
    class Program
    {
        enum e_Operateur
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
            e_Operateur o = (e_Operateur)rand.Next(1, 4);
            int resultatAttendu = 0;

            int reponseInt = 0;
            while (true)
            {
                //

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
                    reponseInt = int.Parse(reponse);
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
            const int NB_QUESTIONS = 3;

            int points = 0;
            float moyenne = NB_QUESTIONS / 2f;

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
            Console.WriteLine($"Vous avez {points} points sur {NB_QUESTIONS} questions");
            if(points == NB_QUESTIONS)
            {
                Console.WriteLine("Excellent");
            }
            else if(points == 0)
            {
                Console.WriteLine("Passez par le primaire");
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
