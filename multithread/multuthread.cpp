#include <iostream>
#include <vector>
#include <thread>
#include <queue>
#include <mutex>
#include <chrono>
#include <random>
#include <numeric>

typedef unsigned long long int bigint;
bool isPrime(bigint n)
{
    if (n <= 1)
        return false;
    for (bigint i = 2; i <= n / 2; i++)
        if (n % i == 0)
            return false;
    return true;
}

size_t single(const std::vector<bigint>& v)
{
    return std::count_if(v.begin(), v.end(), [](const auto& el)
        {
            return isPrime(el);
        });
}

size_t block_way(const std::vector<bigint>& v, size_t n_threads)
{
    std::vector<size_t> results(n_threads);
    auto lambda = [&v, &results](size_t a, size_t b, size_t thread_id)
        {
            auto sum = std::count_if(v.begin() + a, v.begin() + b, [](const auto& el)
                {
                    return isPrime(el);
                });
            results[thread_id] = sum;
        };

    std::vector<std::thread> threads(n_threads);
    int part_size = v.size() / n_threads, a = 0, b = 0;
    for (int thread_id = 0; thread_id != n_threads; thread_id++, a = b)
    {
        b = (thread_id == n_threads - 1) ? v.size() : a + part_size;
        threads[thread_id] = std::thread(lambda, a, b, thread_id);
    }

    for (auto& t : threads)
        t.join();

    return std::accumulate(results.begin(), results.end(), 0);
}

void countPrimes(std::queue<bigint>& numbers, std::mutex& mtx, int& primeCount) {
    while (true) {
        int number;

        // Synchronized block to safely access the shared queue
        {
            std::lock_guard<std::mutex> lock(mtx);
            if (numbers.empty()) {
                break; // No more numbers left to process
            }
            number = numbers.front();
            numbers.pop();
        }

        // Check if the number is prime
        if (isPrime(number)) {
            std::lock_guard<std::mutex> lock(mtx);
            primeCount++;
        }
    }
}

size_t mutex_way(const std::vector<bigint>& numbers, size_t n_threads)
{
    std::queue<bigint> numberQueue;
    for (bigint num : numbers) {
        numberQueue.push(num);
    }

    std::mutex mtx;
    int primeCount = 0;

    std::vector<std::thread> threads;

    for (unsigned int i = 0; i < n_threads; i++) {
        threads.emplace_back(countPrimes, std::ref(numberQueue), std::ref(mtx), std::ref(primeCount));
    }

    for (std::thread& t : threads) {
        t.join();
    }

    return primeCount;
}


int main() {
    std::vector<bigint> v(252);
    std::mt19937_64 gen;
    gen.seed(1);
    std::uniform_int_distribution<bigint> dp(1, bigint(std::numeric_limits<int>::max()));
    for (auto& item : v)
        item = dp(gen);

    // однопоточная версия поиска простых чисел
    auto t1 = std::chrono::high_resolution_clock::now();
    auto nsingle = single(v);
    auto t2 = std::chrono::high_resolution_clock::now();
    auto single_time = std::chrono::duration_cast<std::chrono::milliseconds>(t2 - t1).count();
    std::cout << 1 << '\t' << single_time << '\t' << single_time << '\t' << single_time << std::endl;

    // i - число потоков
    for (size_t i = 2; i <= 8; i += 1)
    {
        t1 = std::chrono::high_resolution_clock::now();
        auto nblock = block_way(v, i);
        t2 = std::chrono::high_resolution_clock::now();
        auto block_time = std::chrono::duration_cast<std::chrono::milliseconds>(t2 - t1).count();

        t1 = std::chrono::high_resolution_clock::now();
        auto nmutex = mutex_way(v, i);
        t2 = std::chrono::high_resolution_clock::now();
        auto mutex_time = std::chrono::duration_cast<std::chrono::milliseconds>(t2 - t1).count();

        std::cout << i << '\t' << single_time << '\t' << block_time << '\t' << mutex_time << '\t' << nsingle << '\t' << nblock << '\t' << nmutex << std::endl;
    }

    //results
    //single_time: 1       121277  121277  121277
    //threads single  block   mutex   numofPrimesFound
    //                                single  block   mutex
    //2       121277  102139  87804   14      14      14
    //3       121277  68670   65347   14      14      14
    //4       121277  60458   59828   14      14      14
    //5       121277  64373   60439   14      14      14
    //6       121277  65668   66024   14      14      14
    //7       121277  62885   65246   14      14      14
    //8       121277  69128   58097   14      14      14
}
