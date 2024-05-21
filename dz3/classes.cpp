#include <iostream>
#include "complex.h"
using namespace std;

inline ostream& operator << (ostream& o, const Complex& c)
{
	return o << '(' << c.Re << ", " << c.Im << ')';
}

int main()
{
	Complex a(1, 2), b = 3;
	cout << a << ", " << b << endl;
	cout << a + b << " a + b" << endl;

	Complex v[4] = { 1, 2, Complex(2, 3) };

	for (int i = 0; i < 4; ++i) {
		cout << v[i];
	}
	cout << endl;

    Complex* pc;

    pc = new Complex(1);
    cout << "Real: " << pc->getReal() << ", Imaginary: " << pc->getImag() << endl;
    delete pc;
    pc = new Complex;
    cout << "                        " << pc->getReal() << ",                 " << pc->getImag() << endl;

    delete pc;
    pc = new Complex(1, 2);
    cout << "                        " << pc->getReal() << ",                 " << pc->getImag() << endl;
    cout << "Real from -> " << pc->getReal() << endl;
    cout << "Imaginary from ->: " << pc->getImag() << endl;
    delete pc;
    Complex* pcArray = new Complex[3];
    cout << pc[1].getReal() << endl;
    delete[] pcArray;
}


