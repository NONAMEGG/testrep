#include <iostream>
#include "Str.h"
using namespace std;

int main()
{
	Str s;
	Str t;
	t = "888";
	s = "123";
	s += t;
	Str m = s + t;
	cout << m;
	return 0;
}