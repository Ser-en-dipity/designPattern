#include <iostream>

class IProduct{
    public:
        virtual ~IProduct(){}
        virtual std::string Declare() const =0;

};
class Ship:public IProduct{
    public:
        std::string Declare() const override{
            return "this is a ship\n";
        }
};
class Truck : public IProduct{
    public:
        std::string Declare() const override{
            return "this is a truck\n";
        }
};
class Icreator{
    public:
        virtual ~Icreator(){}
        virtual IProduct *FactoryMethod() const =0;
    
    std::string Transportation() const {
        IProduct *product = this->FactoryMethod();
        std::string result="the creator class tranport with " + product->Declare();
        return result;
    }
};
class RoadLogic : public Icreator{
    public:
        IProduct* FactoryMethod() const override{
            return new Truck();
        }
};
class SeaLogic : public Icreator{
    public :    
        IProduct* FactoryMethod() const override{
            return new Ship();
        }
};
void ClientCode(const Icreator& creator) {
  // ...
  std::cout << "Client: I'm not aware of the creator's class, but it still works.\n"
  << creator.Transportation();
};
int main() {
  std::cout << "App: Launched with the ConcreteCreator1.\n";
  Icreator* Road = new RoadLogic();
  ClientCode(*Road);
  std::cout << std::endl;
  std::cout << "App: Launched with the ConcreteCreator2.\n";
  Icreator* Sea = new SeaLogic();
  ClientCode(*Sea);


  return 0;
}