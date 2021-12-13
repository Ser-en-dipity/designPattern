#include <iostream>
#include<unordered_map>
using std::string;
enum Type{
    proto1=0,
    proto2
};
class Proto
{
protected:
    string name;
    float field;
public:
    Proto(/* args */);
    Proto(string n):name(n){}
    virtual ~Proto();
    virtual Proto *Clone() const =0;
    virtual Method(float f){
        this->field = f;
        std::cout << "Call Method from " << name
         << " with field : " << field << std::endl;
    }
};
class Proto1:public Proto{
    private:
    float field1;
    public:
        Proto1(string n,float f):Proto(n),field1(f){}
        Proto *Clone() const override{
            return new Proto1(*this);
        }
};
class Proto2:public Proto{
    private:
        float field2;
    public:
        Proto2(string n,float f):Proto(n),field2(f){}
        Proto *Clone() const override{
            return new Proto2(*this);
        }
};
class ProtoFactory{
    private:
        std::unordered_map<Type, Proto*, std::hash<int>> prototypes_;
    public:
        ProtoFactory(){
            prototypes_[Type::proto1] = new Proto1("PROTOTYPE_1 ", 50.f);
            prototypes_[Type::proto2] = new Proto2("PROTOTYPE_2 ", 60.f);
        }

        Proto *createProto(Type type){

    }
};