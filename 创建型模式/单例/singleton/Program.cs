using System;
namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
{
    public sealed class Singleton{
        private Singleton(){}

        private static Singleton instance;

        public static Singleton Getinstance(){
            if (instance==null){
                return new Singleton();
            }
            else return instance;
        }
        

    }
    class Program{
        static void Main(){
            Singleton s1 = Singleton.Getinstance();

            Singleton s2 = Singleton.Getinstance();
            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
        }
    }

}