#include <iostream>
class BaseComponent;
class Mediator{
    public:
        virtual void notify(BaseComponent *com,std::string a) const =0;
};
class BaseComponent{
    protected:
        Mediator *medium;
    public:
        BaseComponent(Mediator *m=nullptr):medium(m){}
        void SetMedium(Mediator *m){
            this->medium = m;
        }
};
class component1:public BaseComponent{
    public:
        void DoA(){
            std::cout << "Component 1 does A.\n";
            this->medium->notify(this,"A");
        }
        void DoB(){
            std::cout << "Component 1 does B.\n";
            this->medium->notify(this, "B");
        }
};
class component2:public BaseComponent{
    public:
        void DoC() {
            std::cout << "Component 2 does C.\n";
            this->medium->notify(this, "C");
        }
        void DoD() {
            std::cout << "Component 2 does D.\n";
            this->medium->notify(this, "D");
        }
};
class ConcreteMediator:public Mediator{
    private:   
        component1 *c1;
        component2 *c2;
    public:
        ConcreteMediator(component1 *com1,component2 *com2):c1(com1),c2(com2){
            this->c1->SetMedium(this);
            this->c2->SetMedium(this);
        }
        void notify(BaseComponent *base,std::string letter)const override{
            if (letter=="A"){
                std::cout << "Mediator reacts on A and triggers following operations:\n";
                this->c2->DoC();
            }
            if (letter=="D"){
                std::cout << "Mediator reacts on D and triggers following operations:\n";
                this->c1->DoB();
                this->c2->DoC();
            }
        }
};
int main(){
    component1 *c1 = new component1;
    component2 *c2 = new component2;
    ConcreteMediator *mediator = new ConcreteMediator(c1, c2);
    std::cout << "Client triggers operation A.\n";
    c1->DoA();
    std::cout << "\n";
    std::cout << "Client triggers operation D.\n";
    c2->DoD();

    delete c1;
    delete c2;
    delete mediator;
}