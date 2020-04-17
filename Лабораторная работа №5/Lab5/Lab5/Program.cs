using System;

namespace Chain_of_responsibility
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Chain of Responsibility Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Setup Chain of Responsibility
            Handler h1 = new AdministratorHandler();
            Handler h2 = new ModeratorHandler();
            Handler h3 = new UserHandler();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = { 1, 2, 2, 1, 3, 3, 1, 2};
            try
            {
                foreach (int request in requests)
                {
                    h1.HandleRequest(request);
                }
            }
            catch
            {
                Console.WriteLine("Error in privilege level");
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Абстрактный класс Handler
    /// </summary>
    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    /// <summary>
    /// Класс AdministratorHandler
    /// </summary>
    class AdministratorHandler : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 1)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                throw new Exception();
            }
        }
    }

    /// <summary>
    /// Класс ModeratorHandler
    /// </summary>
    class ModeratorHandler : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 2)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                throw new Exception();
            }
        }
    }

    /// <summary>
    /// Класс UserHandler
    /// </summary>
    class UserHandler : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 3)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (successor != null)
            {
                //successor.HandleRequest(request);
                successor.HandleRequest(request);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}