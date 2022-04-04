//Author: Mehdi Syed
//File Name: MainProgram.cs
//Project Name: A1Q2
//Creation Date: Oct. 9, 2019
//Modified Date: Oct. 15, 2019
//Description: This program is designed to tell the user the distance their laser travelled. 
//The parameters of this laser, such as angle, original distance till object, and distance to mirror(which shall be deflected).
//The program uses cosine law to calculate such distances, and displays them as a result.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1Q2
{
    class MainProgram
    {
        //Variables that will be used to calculate the total score

        //User-input and converison variables
        static double initialAngle;
        static double initialRadians;
        static double bLength;
        static double cLength;

        //Result variables
        static double aLength;
        static double totalScore;
        static void Main(string[] args)
        {
            //Title of the program in a user-friendly way.
            Console.WriteLine("MIRROR MIRROR: Shoot a laser to get your SCORE!");
            Console.WriteLine("-----------------------------------------------");

            //Explains the game and what the user needs to do.
            Console.WriteLine("\nIn this game, the goal is to hit a target with a laser.");
            Console.WriteLine("You cannot shoot directly at the target because there is a tree in front of you.");
            Console.WriteLine("What you do is that you shoot off a mirror, that deflects the laser and hits the target.");
            Console.WriteLine("To get your score, we will calculate how far your laser went.");

            //Asks the user for key information, such as the angle, distances to the object and the mirror.
            Console.WriteLine("\nWhat was the angle from where the target is to where the mirror is(DO NOT PUT DEGREES IN ANSWER):");
            initialAngle = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nHow far away from the target are you shooting from(DO NOT PUT METERS IN ANSWER):");
            bLength = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nHow far away from the mirror are you shooting from(DO NOT PUT METERS IN ANSWER):");
            cLength = Convert.ToDouble(Console.ReadLine());

            //Calculate distance by implication cosine law, as well as converting degrees into radians(for the angle).
            initialRadians = initialAngle * (Math.PI / 180.0);
            aLength = (Math.Pow(bLength, 2)) + (Math.Pow(cLength, 2)) - (2 * cLength * bLength * Math.Cos(initialRadians));
            aLength = Math.Sqrt(aLength);
            totalScore = cLength + aLength;

            //Display results.
            Console.WriteLine("\nYour total score is: " + Math.Round(totalScore, 2) + " meters");
            Console.WriteLine("GOOD JOB!");

            Console.ReadLine();
        }
    }
}
