#include <iostream>
#include <cmath>
#include "Complex.h"    
using namespace std;

inline ostream& operator << (ostream& o, const Complex& c)
{
    return o << '(' << c.Re << ", " << c.Im << ')';
}

int main()
{
    Complex hello = Complex(1, 2);
   
    cout << hello;
}
