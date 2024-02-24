#pragma once



class Str
{
public:
	char* m_pszText;
public:
	Str()
	{
		m_pszText = new char[1] {0};
	}

	Str(const char* p)
	{
		if (p) {
			m_pszText = new char[strlen(p) + 1];
			strcpy_s(m_pszText, strlen(p) + 1, p);
		}
		else
			m_pszText = new char[1] {0};
	}


	~Str() { delete[]m_pszText; }

	operator const char* ()const { return m_pszText; }


	const Str& operator = (const Str& s)
	{
		if (&s == this) return *this;
		delete[] m_pszText;
		m_pszText = new char[strlen(s.m_pszText) + 1];
		strcpy_s(m_pszText,
			strlen(s.m_pszText) + 1,
			s.m_pszText);
		return *this;
	}

	Str& operator+=(const Str& other) {
		size_t len1 = strlen(m_pszText);
		size_t len2 = strlen(other.m_pszText);

		char* temp = new char[len1 + len2 + 1];

		strcpy_s(temp, len1 + len2 + 1, m_pszText);
		strcat_s(temp, len1 + len2 + 1, other.m_pszText);

		delete[] m_pszText;
		m_pszText = temp;

		return *this;
	}

	Str operator +(const char* other) const {
		size_t len1 = strlen(m_pszText);
		size_t len2 = strlen(other);
		char* temp = new char[len1 + len2 + 1];
		strcpy_s(temp, len1 + len2 + 1, m_pszText);
		strcat_s(temp, len1 + len2 + 1, other);
		Str newLine = Str(temp);
		return newLine;
	}


private:

};
