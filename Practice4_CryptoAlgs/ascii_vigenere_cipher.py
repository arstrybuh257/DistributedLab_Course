alphabet_length = 127


def encode_word(word):
    codes = []
    for ch in word:
        code = ord(ch)
        if code > 127:
            raise Exception("Non ASCII symbol is used")
        codes.append(ord(ch))
    return codes


def decode_word(codes):
    word = ''
    for code in codes:
        word = word + chr(code)
    return word


def encrypt(plain_text, key):
    encoded_value = encode_word(plain_text)
    encoded_key = encode_word(key)
    result_codes = []
    key_index = 0
    for i in range(0, len(encoded_value)):
        result_codes.append((encoded_value[i] + encoded_key[key_index]) % alphabet_length)
        key_index = (key_index + 1) % len(key)
    encrypted_word = decode_word(result_codes)
    return encrypted_word


def decrypt(decrypted_text, key):
    encoded_value = encode_word(decrypted_text)
    encoded_key = encode_word(key)
    result_codes = []
    key_index = 0
    for i in range(0, len(encoded_value)):
        result_codes.append((encoded_value[i] - encoded_key[key_index] + alphabet_length) % alphabet_length)
        key_index = (key_index + 1) % len(key)
    decrypted_word = decode_word(result_codes)
    return decrypted_word
