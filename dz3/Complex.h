#pragma once


class Complex
{

public:
	double Re, Im;
	Complex(double real = 0, double im = 0) {
		Re = real, Im = im;
	}

	Complex operator +(const Complex& c)const
	{
		return Complex(Re + c.Re, Im + c.Im);
	}

	Complex operator -(const Complex& c)const
	{
		return Complex(Re - c.Re, Im - c.Im);
	}

	Complex operator *(const Complex& c)const
	{
		return Complex(Re*c.Re - Im*c.Im, Re*c.Im + c.Re*Im);
	}

	Complex operator /(const Complex& c)const
	{
		return Complex((Re * c.Re + Im * c.Im)/(c.Re * c.Re + c.Im * c.Im), ((-Re) * c.Im + c.Re * Im)/(c.Re * c.Re + c.Im * c.Im));
	}

	Complex Conjugate()
	{
		return Complex(Re, -Im);
	}

private:



};



