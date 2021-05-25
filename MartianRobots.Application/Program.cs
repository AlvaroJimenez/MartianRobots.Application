using MartianRobots.Domain;
using MartianRobots.Domain.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MartianRobots.Application
{
    public class Program
    {
        public static void Main()
        {
            Program p = new Program();
            p.ReadInputs();
        }

        public Program()
        {
            ReadInputs();
        }

        private void ReadInputs()
        {
            StringBuilder output = new StringBuilder();

            //Read surface size
            string command = Console.ReadLine();
            Position point = null;
            IPlanetSurface psurface = null;
            try
            {

                if (!string.IsNullOrEmpty(command))
                {
                    point = GetCoordinates(command);
                }
                if (point != null)
                {
                    psurface = new PlanetSurface(point.X, point.Y);
                }

                do
                {
                    command = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(command))
                    {
                        break;
                    }
                    Robot robot = GetRobotPosition(command);
                    command = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        foreach (var character in command)
                        {
                            IMovement movement = new Movement((Instructions)character, robot, psurface);
                            //Console.WriteLine(character);

                            bool lost = movement.ExecuteMovement();

                            if (lost) break;
                        }

                        output.AppendLine(string.Format("{0} {1} {2} {3}", robot.Position.X, robot.Position.Y, (char)robot.Position.Orientation, (robot.IsLost ? "LOST" : string.Empty)).ToString());
                    }

                } while (!string.IsNullOrWhiteSpace(command));
                Console.Write(output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Position GetCoordinates(string command)
        {
            string[] coordinates = command.Split(' ');

            int.TryParse(coordinates[0], out int pointX);
            int.TryParse(coordinates[1], out int pointY);

            return new Position(pointX, pointY, null, null);
        }

        private Robot GetRobotPosition(string command)
        {
            Robot robot = new Robot();
            Position p = GetCoordinates(command);
            char orientation = command.Split(' ').Last()[0];

            robot.Position = p;
            robot.Position.Orientation = (Orientation)orientation;

            return robot;
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            Debug.WriteLine(e.Exception.Message);
        }
    }
}
