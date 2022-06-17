def rsa_test():
    print('RSA TEST')
    from rsa import generate_keys, encrypt, decrypt
    public_key, private_key = generate_keys()
    print('Public key:  ', public_key)
    print('Private key:  ', private_key)
    plain_text = 'This is a cipher text'
    print('Plain text:  ', plain_text)
    encrypted_text = encrypt(plain_text, private_key)
    print('Encrypted text:  ', encrypted_text)
    decrypted_text = decrypt(encrypted_text, public_key)
    print('Decrypted text:  ', decrypted_text)


def vigenere_test():
    print('VIGENERE CIPHER TEXT')
    from ascii_vigenere_cipher import encrypt, decrypt
    plain_text = 'This is a cipher text'
    key = 'ilovepython'
    print('Plain text:  ', plain_text)
    print('Key:   ', key)
    encrypted_text = encrypt(plain_text, key)
    print('Encrypted text:  ', encrypted_text)
    decrypted_text = decrypt(encrypted_text, key)
    print('Decrypted text:  ', decrypted_text)


if __name__ == '__main__':
    rsa_test()
    vigenere_test()
