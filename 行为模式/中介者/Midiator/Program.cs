using System;
namespace MediatorConcept{
    public interface Imediator{
        public void notify(object sender,string s);
    }
    public class ConcreteMediator : Imediator{
        private Acom acom;
        private Dcom dcom;
        public ConcreteMediator(Acom a,Dcom d){
            this.acom = a;
            this.acom.SetMediator(this);
            this.dcom = d;
            this.dcom.SetMediator(this);
        }
        public void notify(object sender,string s){
            if (s=="C"){
                this.acom.DoA();
                this.acom.DoB();
            }
            else if (s=="D"){
                this.acom.DoB();
                this.dcom.DoC();
            }
        }

    }
    public class BaseComponent{
        protected Imediator media;
        public BaseComponent(Imediator m = null){
            this.media = m;
        }
        public void SetMediator(Imediator m){
            this.media = m;
        }
    }
    public class Acom:BaseComponent{
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");

            this.media.notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            this.media.notify(this, "B");
        }
    }
    public class Dcom:BaseComponent{
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this.media.notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this.media.notify(this, "D");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            Acom component1 = new Acom();
            Dcom component2 = new Dcom();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggets operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
    }
}