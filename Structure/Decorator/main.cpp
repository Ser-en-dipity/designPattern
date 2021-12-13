#include <iostream>

class Component{
    public:
        virtual ~Component(){}
        virtual std::string Operation() const =0;
};
class ConcreteComponent:public Component{
    public:
        std::string Operation() const override{
            return "ConcreteComponent";
        }
};
class Decorator:public Component{
    protected:
        Component *component;
    public:
        Decorator(Component *com){
            this->component = com;
        }
 
        std::string Operation() const override{
            return this->component->Operation();
        }
};
class ConcreteDecoratorA:public Decorator{
    public:
        ConcreteDecoratorA(Component *com):Decorator(com){}
        std::string Operation() const override{
            return "ConcreteA"+Decorator::Operation();
        }
};
class ConcreteDecoratorB:public Decorator{
    public:
        ConcreteDecoratorB(Component *com):Decorator(com){}
        std::string Operation() const override{
            return "ConcreteB" + Decorator::Operation();
        }
};
void ClientCode(Component* component) {
  // ...
  std::cout << "RESULT: " << component->Operation();
  // ...
}
int main() {
  /**
   * This way the client code can support both simple components...
   */
  Component* simple = new ConcreteComponent;
  std::cout << "Client: I've got a simple component:\n";
  ClientCode(simple);
  std::cout << "\n\n";
  /**
   * ...as well as decorated ones.
   *
   * Note how decorators can wrap not only simple components but the other
   * decorators as well.
   */
  Component* decorator1 = new ConcreteDecoratorA(simple);
  Component* decorator2 = new ConcreteDecoratorB(decorator1);
  std::cout << "Client: Now I've got a decorated component:\n";
  ClientCode(decorator2);
  std::cout << "\n";

  delete simple;
  delete decorator1;
  delete decorator2;

  return 0;
}