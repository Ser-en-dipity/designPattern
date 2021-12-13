#include <iostream>
#include<vector>
class Iproduct{
    public:
        std::vector<std::string> parts;
        void ListParts() const {
            for(int i=0;i<parts.size();i++){
                if (parts[i]==parts.back()){
                    std::cout<<parts[i];
                }
                else{
                    std::cout<<parts[i]<<',';
                }
            }
            std::cout<<"\n\n";
        }   
};
class Builder{
    public:
    virtual ~Builder(){}
    virtual void SetSeats() const =0;
    virtual void SetEngine() const =0;
    virtual void SetGps() const =0;

};
class Car:public Builder{
    private:
        Iproduct *product;
    public:
        Car(){
            this->Reset();
        }
        ~Car(){
            delete product;
        }
        void Reset(){
            this->product = new Iproduct();
        }
        void SetSeats() const override{
            std::cout<< "four seats \n";
            this->product->parts.push_back("seats");
        }
        void SetEngine() const override{
            std::cout<< "Bmw engine 4 turbo\n ";
            this->product->parts.push_back("engines");
        }
        void SetGps() const override{
            std::cout<< "gps beidou\n ";
            this->product->parts.push_back("gps");
        }
        Iproduct *GetProduct(){
            Iproduct *result = this->product;
            this->Reset();
            return result;
        }
};
class Director{
    private:
    Builder *build;
    public:
    void SetBuilder(Builder *b){
        this->build = b;
    }
    void BuildFull(){
        this->build->SetEngine();
        this->build->SetGps();
        this->build->SetSeats();
    }
};
int main(){
    Car *c = new Car();
    Director *d = new Director();
    d->SetBuilder(c);
    d->BuildFull();
    Iproduct *p = c->GetProduct();
    p->ListParts();
}