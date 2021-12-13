#include <iostream>

class gameAi{
    public:
        void turn() const {
           this->buildUnits();
           this->attack(); 
           this->SendScouts();
        }
    protected:
        virtual void buildUnits()const{}
        void attack()const{
            std :: cout << "this is a attack method";
        }
        virtual void SendScouts() const = 0 ;
    
};
class orc:public gameAi{
    protected:
        void buildUnits() const override{
            std :: cout << "build orc buildings\n"; 
        }
        void SendScouts() const override {
            std :: cout << "orc scouts sent\n";
        }
};
class Ud:public gameAi{
    protected:
        void buildUnits() const override{
            std :: cout << "haunted minerals\n";
        }
        void SendScouts() const override{
            std :: cout << "monks ... \n";
        }
};
void ClientCode(gameAi *game){
    game->turn();
}
int main(){
    orc *o = new orc;
    Ud *u = new Ud;
    o->turn();
    std :: cout << "orc ends ud turn\n";
    u->turn();
}