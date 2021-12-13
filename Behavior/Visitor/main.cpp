#include <iostream>
#include<array>
class Component1;
class Component2;
class Visitor{
    public:
        virtual void VisitCom1(const Component1 *com1) const =0;
        virtual void VisitCom2(const Component2 *com2) const =0;
};
class BaseComponent{
    public:
        ~BaseComponent(){}
        virtual void accept(Visitor *visit) const =0;
};
class Component1:public BaseComponent{
    public:
    void accept(Visitor *visit)const override{
        visit->VisitCom1(this);
    }
     std::string ExclusiveMethodOfConcreteComponentA() const {
        return "A";
    }
};
class Component2:public BaseComponent{
    public:
    void accept(Visitor *visit)const override{
        visit->VisitCom2(this);
    }
    std::string SpecialMethodOfConcreteComponentB() const {
        return "B";
    }
};
class ConcreteVisitor:public Visitor{
    public:
    void VisitCom1(const Component1 *com1)const override{
        std::cout << com1->ExclusiveMethodOfConcreteComponentA() << " + ConcreteVisitor1\n";
    }
    void VisitCom2(const Component2 *element) const override {
        std::cout << element->SpecialMethodOfConcreteComponentB() << " + ConcreteVisitor1\n";
  }
};
class ConcreteVisitor2 : public Visitor {
 public:
  void VisitCom1(const Component1 *element) const override {
    std::cout << element->ExclusiveMethodOfConcreteComponentA() << " + ConcreteVisitor2\n";
  }
  void VisitCom2(const Component2 *element) const override {
    std::cout << element->SpecialMethodOfConcreteComponentB() << " + ConcreteVisitor2\n";
  }
};
void ClientCode(std::array<const BaseComponent *, 2> components, Visitor *visitor) {
  // ...
  for (const BaseComponent *comp : components) {
    comp->accept(visitor);
  }
  // ...
}
int main() {
  std::array<const BaseComponent *, 2> components = {new Component1, new Component2};
  std::cout << "The client code works with all visitors via the base Visitor interface:\n";
  ConcreteVisitor *visitor1 = new ConcreteVisitor;
  ClientCode(components, visitor1);
  std::cout << "\n";
  std::cout << "It allows the same client code to work with different types of visitors:\n";
  ConcreteVisitor2 *visitor2 = new ConcreteVisitor2;
  ClientCode(components, visitor2);

  for (const BaseComponent *comp : components) {
    delete comp;
  }
  delete visitor1;
  delete visitor2;

  return 0;
}