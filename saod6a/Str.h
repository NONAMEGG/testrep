#include "_str.h"
class _str;

class Str {
	_str* m_pStr;
public:
	Str(const Str& s)
	{
		m_pStr = s.m_pStr; 	// ��������� �� ��� �� ������
		m_pStr->AddRef(); 	// ��������, ��� ���������
	}

	Str() { m_pStr = new _str; }		//���� �� �����, �� �������
	Str(const char* p) {		// ����� ������
		m_pStr = new _str(p);
	}
	~Str() {
		m_pStr->Release(); 	// �� ���������� ������!
	}				// ��������� ������� ������!

	int len() const {
		return strlen(m_pStr->m_pszData);
	}

	Str& operator = (const Str& s) {
		if (this != &s) {
			s.m_pStr->AddRef(); // ����� �������?!
			m_pStr->Release();
			m_pStr = s.m_pStr;
		}
		return *this;
	}

	Str& operator += (const Str& s) {
		int length = len() + s.len();
		if (s.len() != 0) {		// ���������� ������ �� �������!
			_str* pstrTmp = new _str; 	// ����� ������
			delete[] pstrTmp->m_pszData;

			pstrTmp->m_pszData = new char[length + 1];
			strcpy_s(pstrTmp->m_pszData, length + 1, m_pStr->m_pszData);
			strcat_s(pstrTmp->m_pszData, length + 1, s.m_pStr->m_pszData);

			m_pStr->Release();
			m_pStr = pstrTmp;
		}
		return *this;
	}

	operator const char* () const;

	void reverse() {
		int length = len();
		bool isPalindrome = true;
		for (size_t i = 0; i < length / 2; ++i) {
			if (m_pStr->m_pszData[i] != m_pStr->m_pszData[length - 1 - i]) {
				isPalindrome = false;
				break;
			}
		}

		if (!isPalindrome) {
			char* reversedData = new char[length + 1];
			strcpy_s(reversedData, length + 1, m_pStr->m_pszData);
			for (size_t i = 0; i < length; ++i) {
				m_pStr->m_pszData[i] = reversedData[length - 1 - i];
			}
			delete[] reversedData;
		}
	}
};



Str::operator const char* () const {
	return m_pStr->m_pszData;
}





