namespace DelegatesAndEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //For delegates

            ////IntegrableFunction del1 = MyFirstMethod;
            //Func<double, double> del1 = MyFirstMethod;

            //var integrator = new Integrator();
            //Console.WriteLine(integrator.Integrate(del1));

            //double cubic(double x) { return x * x * x; }

            //del1 = cubic;
            //Console.WriteLine(integrator.Integrate(del1));

            //Console.WriteLine(integrator.Integrate(x => Math.Sin(x)));


            //For events
            //var elevator = new Elevator();
            ////elevator.NotifyAction = () => Console.WriteLine($"{elevator.CurrentFloor} reached"); //no longer possible with event
            ////elevator.NotifyAction += () => Console.WriteLine($"{elevator.CurrentFloor} reached hahaha");
            ////elevator.NotifyAction = null; //no longer possible with event

            //Console.WriteLine(elevator.CurrentFloor);

            //elevator.Move(5);

            //Console.WriteLine(elevator.CurrentFloor);

            var betterElevator = new BetterElevator();
            Console.WriteLine(betterElevator.CurrentFloor);
            betterElevator.FloorReachedEvent 
                += (sender, eventArgs) => Console.WriteLine($"Floor {eventArgs.CurrentFloor}");
            
            betterElevator.Move(5);

            Console.ReadKey();
        }

        public static double MyFirstMethod(double x) { return x * x; }
    }
}