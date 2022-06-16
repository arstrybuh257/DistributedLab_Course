from ascii_vigenere_cipher import encrypt, decrypt

if __name__ == '__main__':
    ew = encrypt('Hello world_meow_meow', 'superduperkey')
    print(ew)
    dw = decrypt(ew, 'superduperkey')
    print(dw)
