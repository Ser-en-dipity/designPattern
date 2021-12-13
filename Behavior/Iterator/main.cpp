#include <iostream>
#include <string>
#include <vector>

template<typename T,typename U>
class Iterator{
    public: 
        typedef typename std::vector<T>::iterator iter_type;
        Iterator(U *data,bool rev=false):p_data(data){
            m_it = p_data->m_data.begin();
        }
        void First(){
            m_it = p_data->m_data.begin();
        }
        void Next(){
            m_it++;
        }
        bool IsDone(){
            return (m_it==p_data->m_data.end());
        }
        iter_type Current(){
            return m_it;
        }
    private:   
        U *p_data;
        iter_type m_it;
        //std::vector<T> m_data;
};
template<class T>
class Container{
    friend class Iterator<T,Container>;
    private:
        std::vector<T> m_data;
    public :
        void Add(T a){
            m_data.push_back(a);
        }
        Iterator<T,Container> *CreateIterator(){
            return new Iterator<T,Container>(this);
        }
};
class Data{
    private:
        int m_data;
    public:
        Data(int d=0):m_data(d){}
        void SetData(int d){
            m_data=d;
        }
        int GetData(){
            return m_data;
        }
};
void ClientCode(){
    std::cout << "_____________Iterator with int____________" << std::endl;
    Container<int> cont;
    for (int i = 0; i < 10; i++) {
        cont.Add(i);
    }
    Iterator<int, Container<int>> *it = cont.CreateIterator();
        for (it->First(); !it->IsDone(); it->Next()) {
            std::cout << *it->Current() << std::endl;
        }
        Container<Data> cont2;
        Data a(100), b(1000), c(10000);
        cont2.Add(a);
        cont2.Add(b);
        cont2.Add(c);

        std::cout << "________________Iterator with custom Class______________________________" << std::endl;
        Iterator<Data, Container<Data>> *it2 = cont2.CreateIterator();
        for (it2->First(); !it2->IsDone(); it2->Next()) {
            std::cout << it2->Current()->GetData() << std::endl;
        }
        delete it;
        delete it2;
}
int main(){
    ClientCode();
    return 0;
}