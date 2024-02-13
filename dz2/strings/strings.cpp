#include <iostream>
using namespace std;

int len(const char *s) {
	return sizeof(s) - 2; //Конст + нулевой символ, поэтому -2
}

int compare(const char* s, const char* t) {
	return strcmp(s, t);
}

int main()
{
	char str[] = "Hello!";
	cout << len(str) << endl;
	cout << str << endl;
	cout << strlen(str) << ' ' << sizeof(str) << endl;
	char t[32];
	for (char* pd = t, *ps = str; *pd++ = *ps++;);
	cout << compare(str, t);

}
