using System;
namespace ObserverConcept{
    public interface Isubject{
        public void attach(Iobserver ob);
        public void detach(Iobserver ob);
        public void notify();

    }
    public class publisher:Isubject{
        public int state { get; set; } = 0;
        private List<Iobserver> ob = new List<Iobserver>();
        public void attach(Iobserver obser){
            this.ob.Add(obser);
        }
        public void detach(Iobserver obser){
            this.ob.Remove(obser);
        }
        public void notify(){
            Console.WriteLine("Subject: Notifying observers...");
            foreach(var observer in this.ob){
                observer.update(this);
            }
        }
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.state = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.state);
            this.notify();
        }
    }
    public interface Iobserver{
        public void update(Isubject sub);
    }
    public class Subscriber:Iobserver
    {   
        public void update(Isubject sub){
            if ((sub as publisher).state < 3 ){
                Console.WriteLine("subsriber: Reacted to the event.");
            }
        }
        
    }
    public class Audience:Iobserver
    {
        public void update(Isubject sub){
            if ((sub as publisher).state > 2 && (sub as publisher).state==0){
                Console.WriteLine("Audience: Reacted to the event.");
            }
        }   
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var pub = new publisher();
            var sub = new Subscriber();
            pub.attach(sub);

            var au = new Audience();
            pub.attach(au);

            pub.SomeBusinessLogic();
            pub.SomeBusinessLogic();

            pub.detach(au);

            pub.SomeBusinessLogic();
        }
    }
}