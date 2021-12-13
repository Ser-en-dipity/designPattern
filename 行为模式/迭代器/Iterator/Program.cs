using System;
using System.Collections;
using System.Collections.Generic;
namespace IteratorConcept{
    public abstract class Iterator:IEnumerator{
        object IEnumerator.Current => Current();

        public abstract int Key();
        public abstract object Current();
        public abstract bool MoveNext();
        public abstract void Reset();
    }
    public abstract class IteratorAggregate:IEnumerable{
        public abstract IEnumerator GetEnumerator();
    }
    public class AlphaIterator : Iterator{
        private Words collection;
        private int position=-1;
        private bool reverse=false;
        public AlphaIterator(Words word,bool rev){
            this.collection = word;
            this.reverse = rev;
            if (this.reverse){
                this.position = collection.GetItem().Count;
            }
        }
        public override object Current()
        {
            return this.collection.GetItem()[position];
        }
        public override int Key()
        {
            return this.position;
        }
        public override bool MoveNext()
        {
            int updatePosition = this.position + (this.reverse?-1:1);
            if (updatePosition>=0 && updatePosition <this.collection.GetItem().Count){
                this.position = updatePosition;
                return true;
            }
            else {
                return false;
            }
        }
        public override void Reset()
        {
            this.position = this.reverse ? this.collection.GetItem().Count-1 : 0;
        }
    }
    public class Words:IteratorAggregate
    {
        public List<string> collection = new List<string>();
        public bool Direction;
        
        public void ReverseDirection(){
            this.Direction = !Direction;
        }
        public List<string> GetItem(){
            return this.collection;
        } 
        public void AddItem(string item){
            this.collection.Add(item);
        }
        public override IEnumerator GetEnumerator()
        {
            return new AlphaIterator(this,Direction);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The client code may or may not know about the Concrete Iterator
            // or Collection classes, depending on the level of indirection you
            // want to keep in your program.
            var collection = new Words();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}