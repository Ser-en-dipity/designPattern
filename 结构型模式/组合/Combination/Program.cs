using System;
namespace CombineConcept{
    abstract class Component{
        public Component(){}

        public abstract string operation();

        public virtual void Add(Component com){throw new NotImplementedException();}

        public virtual void Remove(Component com){throw new NotImplementedException();}

        public virtual bool isNode(){
            return true;
        }
    }
    class Leaf:Component{
        public override string operation()
        {
            return "leaf";
        }
        public override bool isNode()
        {
            return false;
        }
    }
    class Node : Component{
        protected List<Component> children = new List<Component>();

        public override void Add(Component c)
        {
            children.Add(c);
        }
        public override void Remove(Component com)
        {
            children.Remove(com);
        }
        public override string operation()
        {
            string result="branch(";
            foreach (Component c in this.children){
                
                result += c.operation();
                result += "+";
            }
            return result+")";
        }
    }
    class Client{
        public void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.operation()}\n");
        }
        public void ClientCode2(Component tree, Component leaf){
            if (tree.isNode()){
                tree.Add(leaf);
            }
            Console.WriteLine($"RESULT: {tree.operation()}");
        }
    }
    class Program{
        static void Main(){
            Client client = new Client();

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(leaf);

            // ...as well as the complex Nodes.
            Node tree = new Node();
            Node branch1 = new Node();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Node branch2 = new Node();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a Node tree:");
            client.ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.ClientCode2(tree, leaf);
        }
    }

}