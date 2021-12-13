#include <iostream>

class Device{
    public: 
        virtual ~Device(){}
        virtual void GetVolumn() const =0;
        virtual void GetChannel() const =0;
};
class Radio:public Device{
    public:
        void GetVolumn() const override{
            std::cout<<"radio volumn";
        }
        void GetChannel() const override{
            std::cout<<"radio channel";
        }
};
class Tv: public Device{
    public:
        void GetVolumn() const override{
            std::cout<< "tv volumn";
        }
        void GetChannel() const override{
            std::cout<< "tv channel";
        }
};
class Remote{
    protected:
        Device *_device;
    public:
        Remote(Device *dev):_device(dev){}
        virtual void VolumnUp() const{
            std::cout<<" ...\n";
        }
        virtual void ChannelUp() const {
            std::cout<<" ...\n";
        }
};
class Implemention:public Remote{
    public:
        Implemention(Device *remote):Remote(remote){

        }
        void VolumnUp() const override{
            this->_device->GetChannel();
            std::cout<< " turn up the volumn";
            
        }
};
void ClientCode(const Remote &remote){
    remote.ChannelUp();
    remote.VolumnUp();
};
int main() {
  Device *device = new Tv();
  Remote *remote = new Implemention(device);
  ClientCode(*remote);
  return 0;
}   