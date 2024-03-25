#include <iostream>
#include "Str.h"
using namespace std;
int main()
{
	Str str = "skdljas";
	Str str1 = str;
	str.reverse();
	cout << str << endl;
	cout << str1;
}