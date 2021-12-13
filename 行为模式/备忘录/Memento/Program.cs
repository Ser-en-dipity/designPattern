using System;
namespace MementoConcept{
    public class Originator{
        private string state;
        public Originator(string st){
            this.state = st ;
            Console.WriteLine("Originator: My initial state is: " + state);
        }
        public void DoSomething()
        {
            Console.WriteLine("Originator: I'm doing something important.");
            this.state = this.GenerateRandomString(30);
            Console.WriteLine($"Originator: and my state has changed to: {state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }
        public Imemento Save(){
            return new Mementor(this.state);
        }
        public void Restore(Imemento mento){
            if (!(mento is Imemento)){
                throw new Exception("Unknown memento class " + mento.ToString());
            }
            else{
                this.state = mento.GetState();
                Console.Write($"Originator: My state has changed to: {state}");
            }
        }
    }
    public interface Imemento{
        string GetName();

        string GetState();

        DateTime GetDate(); 
    }
    public class Mementor:Imemento{
        private string state;
        private DateTime date;
        public Mementor(string st){
            this.state = st;
            this.date = DateTime.Now;
        }
        public string GetName(){
            return $"{this.date} / ({this.state.Substring(0, 9)})...";
        }
        public string GetState(){
            return this.state;
        }
        public DateTime GetDate(){
            return this.date;
        }
    }
    public class CareTaker{
        private List<Imemento> mementos = new List<Imemento>();
        private Originator orig;

        public CareTaker(Originator org){
            this.orig = org;
        }
        public void Backup(){
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this.mementos.Add(this.orig.Save());
        }
        public void Undo(){
            if (this.mementos.Count==0){
                return ;
            }
            var m = this.mementos.Last();
            this.mementos.Remove(m);
            Console.WriteLine("Caretaker: Restoring state to: " + m.GetName());
            try{  
                this.orig.Restore(m);
            }
            catch{
                this.Undo();
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this.mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Client code.
            Originator originator = new Originator("Super-duper-super-puper-super.");
            CareTaker caretaker = new CareTaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            caretaker.Undo();

            Console.WriteLine();
        }
    }
    
}