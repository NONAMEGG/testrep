#pragma once
#define _USE_MATH_DEFINES
#include <cmath>

class Complex
{
public:
	double Re, Im;
	Complex(double Re = 0, double Im = 0);

    double getReal() { return Re; }
    double getImag() { return Im; }

	Complex operator +(const Complex& c)const
	{
		return Complex(Re + c.Re, Im + c.Im);
	}
    Complex operator -(const Complex& c) const {
        return Complex(Re - c.Re, Im - c.Im);
    }

    Complex operator *(const Complex& c) const {
        double newRe = Re * c.Re - Im * c.Im;
        double newIm = Re * c.Im + Im * c.Re;
        return Complex(newRe, newIm);
    }

    Complex operator /(const Complex& c) const {
        if (c.Re == 0 && c.Im == 0) {
            throw "Division by zero is not allowed";
        }

        double newRe = (Re * c.Re + Im * c.Im) / (c.Re * c.Re + c.Im * c.Im);
        double newIm = (Im * c.Re - Re * c.Im) / (c.Re * c.Re + c.Im * c.Im);

        return Complex(newRe, newIm);
    }

    Complex Conjugate() const {
        return Complex(Re, -Im);
    }

    double Mod() const {
        return std::sqrt(Re * Re + Im * Im);
    }

    double Arg() const {
        if (Mod() == 0) {
            return 0;
        }
        else if (Re > 0) {
            return std::atan(Im / Re);
        }
        else if (Re < 0) {
            if (Im >= 0) {
                return M_PI + std::atan(Im / Re);
            }
            else {
                return -M_PI + std::atan(Im / Re);
            }
        }
        else {
            if (Im > 0) {
                return M_PI / 2;
            }
            else {
                return -M_PI / 2;
            }
        }
    }
};

Complex::Complex(double re, double im) 
{
	Re = re;
	Im = im;
}

