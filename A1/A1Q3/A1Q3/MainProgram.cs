//Author: Mehdi Syed
//File Name: MainProgram.cs
//Project Name: A1Q3
//Creation Date: Oct. 9, 2019
//Modified Date: Oct. 15, 2019
//Description: This program is to calculate how far the bird travelled due to the slingshot.
//Calculate the distance of this projectile motion, then display the results in a user-friendly way
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1Q3
{
    class MainProgram
    {
        //Variables needed to calculate distance.

        //User-input and conversion variables
        static double pullDistance;
        static double initialAngle;
        static double initialRadians;

        //Speed/ speed equation variables
        static double xVelocity;
        static double yVelocity;
        static double initialVelocity;
        static double timeInAir;
        static double totalDistance;

        //Contants
        const double GRAVITY = -9.81;
        static void Main(string[] args)
        {
            //Title of program in user-freindly way.
            Console.WriteLine("SO ANGRY: How far did the bird go?");
            Console.WriteLine("----------------------------------");

            //Ask user for important information, such as the pullback distance and angle.
            //These variables are essential for calculation.
            Console.WriteLine("\nHow far did you pull the slingshot in Milimeters(DO NOT PUT UNITS!): ");
            pullDistance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWhat was the angle from the ground: ");
            initialAngle = Convert.ToDouble(Console.ReadLine());

            //Converting the pullback distance and angle(degrees) to correct measurments.
            initialVelocity = pullDistance * 5.0;
            initialRadians = initialAngle + (Math.PI / 180.0);

            //Calculate according to equations that must be used for projectile motion.
            xVelocity = initialVelocity * Math.Cos(initialRadians);
            yVelocity = initialVelocity * Math.Sin(initialRadians);
            timeInAir = (-2 * yVelocity) / GRAVITY;

            //Calculate the total distance the bird went.
            totalDistance = xVelocity * timeInAir;

            //Display result.
            Console.WriteLine("\nThe distance the bird is from the sling is: " + Math.Round(totalDistance, 2) + " meters");

            Console.ReadLine();
        }
    }
}
