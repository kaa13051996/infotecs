import timeit


def mn(n):
    if n == 1: return [1]
    if n < 1 or not isinstance(n, int):
        raise TypeError
    lst = []
    i = 2
    while n != 1:
        if n % i == 0:
            n = n // i
            lst.append(i)
            continue
        i += 1
    return lst


if __name__ == "__main__":
    a = timeit.default_timer()
    print(mn(54))
    print(timeit.default_timer() - a)
