#include <iostream>
#include <string>
#include <chrono>
#include <fstream>
#include <vector>

size_t naive(const std::string& str, const std::string& sub)
{
    size_t n = str.size(), m = sub.size(), j = 0;
    for (size_t i = 0; i < n - m + 1; i++)
    {
        for (j = 0; j < m; j++)
        {
            if (str[i + j] != sub[j])
                break;
        }
        if (j == m)
            return i;
    }
    return std::string::npos;   
}

std::vector<size_t> computePMT(const std::string& pattern) {
    size_t m = pattern.size();
    std::vector<size_t> pmt(m, 0);
    size_t i = 1, len = 0;
    while (i < m) {
        if (pattern[i] == pattern[len]) {
            len++;
            pmt[i] = len;
            i++;
        }
        else {
            if (len != 0) {
                len = pmt[len - 1];
            }
            else {
                pmt[i] = 0;
                i++;
            }
        }
    }
    return pmt;
}

size_t kmp(const std::string& str, const std::string& sub) {
    size_t n = str.size(), m = sub.size();
    std::vector<size_t> pmt = computePMT(sub);
    size_t i = 0, j = 0;
    while (i < n) {
        if (sub[j] == str[i]) {
            i++;
            j++;
            if (j == m) {
                return i - m;
            }
        }
        else {
            if (j != 0) {
                j = pmt[j - 1];
            }
            else {
                i++;
            }
        }
    }
    return std::string::npos;
}

size_t bm(const std::string& str, const std::string& sub)
{
    size_t n = str.size();
    size_t m = sub.size();

    if (m == 0) {
        return 0;
    }

    std::vector<int> bad_char(256, -1);

    for (size_t i = 0; i < m - 1; ++i) {
        bad_char[static_cast<unsigned char>(sub[i])] = i;
    }

    size_t s = 0;
    while (s <= n - m) {
        int j = m - 1;

        while (j >= 0 && sub[j] == str[s + j]) {
            j--;
        }

        if (j < 0) {
            return s;
        }
        else {
            s += std::max(1, static_cast<int>(j - bad_char[static_cast<unsigned char>(str[s + j])]));
        }
    }

    return std::string::npos;
}

int main()
{
    using namespace std;

    string str, sub = "was born in a small town called Sceptre";
    ifstream fin("engwiki_ascii.txt", ios::binary);
    if (!fin.is_open())
    {
        cout << "not open!" << endl;
        return 0;
    }
    str.append((istreambuf_iterator<char>(fin)), istreambuf_iterator<char>());

    size_t n = 10;
    std::vector<size_t> times(n), indx(n);

    cout << "\nstd::find\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = str.find(sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\nKMP\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = kmp(str, sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\nBoyer-Moore\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = bm(str, sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    cout << "\nnaive\n";
    for (size_t i = 0; i < n; i++)
    {
        auto time_one = chrono::high_resolution_clock::now();
        auto index = naive(str, sub);
        if (index == std::string::npos)
            std::cout << "not found\n";
        else
            indx[i] = index;
        auto time_two = chrono::high_resolution_clock::now();
        times[i] = chrono::duration_cast<chrono::nanoseconds>(time_two - time_one).count();
    }
    for (size_t i = 0; i < n; i++)
    {
        cout << indx[i] << '\t' << times[i] << endl;
    }

    
}