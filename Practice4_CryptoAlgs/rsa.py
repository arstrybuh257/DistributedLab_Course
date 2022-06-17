import random


# Miller-Rabin primality test.
def is_prime(n):
    if n != int(n):
        return False
    n = int(n)
    if n == 0 or n == 1 or n == 4 or n == 6 or n == 8 or n == 9:
        return False

    if n == 2 or n == 3 or n == 5 or n == 7:
        return True
    s = 0
    d = n - 1
    while d % 2 == 0:
        d >>= 1
        s += 1
    assert (2 ** s * d == n - 1)

    def trial_composite(a):
        if pow(a, d, n) == 1:
            return False
        for i in range(s):
            if pow(a, 2 ** i * d, n) == n - 1:
                return False
        return True

    for i in range(8):  # number of trials
        a = random.randrange(2, n)
        if trial_composite(a):
            return False

    return True


def generate_random_prime():
    while True:
        number = random.randint(10**12, 10**16)
        if is_prime(number):
            return number


def gcd(x, y):
    while y != 0:
        x, y = y, x % y
    return x


def get_e(phi):
    e = random.randint(1, phi)
    while gcd(e, phi) != 1:
        e = random.randint(1, phi)
    return e


def generate_keys():
    p = generate_random_prime()
    q = generate_random_prime()
    n = p * q
    phi = (p - 1) * (q - 1)
    e = get_e(phi)
    d = pow(e, -1, phi)
    return (e, n), (d, n)


def encrypt(plain_text, public_key):
    e, n = public_key
    encrypted_message = []
    for ch in plain_text:
        temp = ord(ch)
        encrypted_message.append(pow(temp, e, n))
    return encrypted_message


def decrypt(cipher_text, private_key):
    d, n = private_key
    plain_text = ''
    for byte in cipher_text:
        temp = pow(byte, d, n)
        plain_text = plain_text + str(chr(temp))
    return plain_text
