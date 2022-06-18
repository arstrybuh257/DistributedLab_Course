def get_sha1_hash(input_value):
    h0 = 0x67452301
    h1 = 0xEFCDAB89
    h2 = 0x98BADCFE
    h3 = 0x10325476
    h4 = 0xC3D2E1F0

    data = bytearray(input_value, encoding='ascii')
    print(data)
    len_in_bits = (8 * len(data)) & 0xFFFFFFFFFFFFFFFF
    print(len_in_bits)
    data.append(0x80)
    while len(data) % 64 != 56:
        data.append(0)
    data += len_in_bits.to_bytes(8, byteorder='big')
    assert len(data) % 64 == 0, "Error in padding"

    for offset in range(0, len(data), 64):
        # 2.a. 512-bits = 64-bytes chunks
        chunks = data[offset: offset + 64]
        w = [0 for i in range(80)]
        # 2.b. Break chunk into sixteen 32-bit = 4-bytes words w[i], 0 ≤ i ≤ 15
        for i in range(16):
            w[i] = int.from_bytes(chunks[4 * i: 4 * i + 4], byteorder='big')


def ascii_to_binary(text):
    codes = []
    binary_string = ''
    for c in text:
        codes.append(format(ord(c), '08b'))
    return binary_string.join(codes)


def preprocess_input(input_value):
    binary_input = ascii_to_binary(input_value)
    input_length = len(binary_input)

    preprocessed_string = binary_input + '1'

    while len(preprocessed_string) % 512 != 448:
        preprocessed_string += '0'

    preprocessed_string += format(input_length, '064b')
    return preprocessed_string


def split_string(input_string, num):
    return [input_string[i:i+num] for i in range(0, len(input_string), num)]


def left_rot(data, nth_shifts):
    s = ""
    for i in range(nth_shifts):
        for j in range(1, len(data)):
            s = s + data[j]
        s = s + data[0]
        data = s
        s = ""
    return data


def xor(a, b):
    ans = ""
    for i in range(len(a)):
        if a[i] == b[i]:
            ans = ans + "0"
        else:
            ans = ans + "1"
    return ans


def get_sha1_hash1(input_value):
    preprocessed_input = preprocess_input(input_value)
    chunks_512 = split_string(preprocessed_input, 512)
    for chunk_512 in chunks_512:
        chunks_32 = split_string(chunk_512, 32)
        words = [0] * 80
        for chunk_32 in chunks_32:

            for i in range(16, 79):
                word = xor(xor(chunk_32[i - 3], chunk_32[i - 8]), xor(chunk_32[i - 14], chunk_32[i - 16]))
                word = left_rot(word, 5)

        print(chunk_80)


if __name__ == '__main__':
    get_sha1_hash1('A Test')
