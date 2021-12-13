using System;
namespace StrategyConcept{
    class context{
        private Istrategy _strategy;
        public context(){}
        public context(Istrategy sta){
            this._strategy = sta;
        }
        public void SetStrategy(Istrategy sta){
            this._strategy = sta;
        }
        public void DoLogics(){
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            var result = this._strategy.DoAlgorithm(new List<string>{"a","b","c","d"});
            string ResultStr = string.Empty;
            foreach(var s in result as List<string>){
                ResultStr += s + ',';
            }
            Console.WriteLine(ResultStr);
        }
    }
    interface Istrategy{
        public object DoAlgorithm(object data);
    }
    class SortStra:Istrategy{
        public object DoAlgorithm(object data){
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }
    class ReverseList:Istrategy{
        public object DoAlgorithm(object data){
            var list = data as List<string>;
            list.Sort();
            list.Reverse();
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var ctx = new context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            ctx.SetStrategy(new SortStra());
            ctx.DoLogics();
            
            Console.WriteLine();
            
            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            ctx.SetStrategy(new ReverseList());
            ctx.DoLogics();
        }
    }
}