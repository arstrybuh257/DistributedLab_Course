hex_digits = {
    '0': 0, '1': 1, '2': 2, '3': 3, '4': 4,
    '5': 5, '6': 6, '7': 7, '8': 8, '9': 9,
    'a': 10, 'b': 11, 'c': 12, 'd': 13, 'e': 14, 'f': 15,
    'A': 10, 'B': 11, 'C': 12, 'D': 13, 'E': 14, 'F': 15
}

hex_digits_reversed = {
    0: '0', 1: '1', 2: '2', 3: '3', 4: '4',
    5: '5', 6: '6', 7: '7', 8: '8', 9: '9',
    10: 'A', 11: 'B', 12: 'C', 13: 'D', 14: 'E', 15: 'F'
}


def hex_to_int_custom(hex_string):
    int_value = 0
    counter = 0
    while counter < len(hex_string):
        int_value += int(hex_digits[hex_string[counter]]) * pow(16, counter)
        counter += 1
    return int_value


def int_to_hex_custom(int_value):
    hex_string = ""
    while int_value > 15:
        mod = int_value % 16
        hex_string += hex_digits_reversed[mod]
        int_value = int_value // 16
    else:
        hex_string += hex_digits_reversed[int_value]
    return hex_string[::-1]


def hex_to_big_endian_custom(hex_string):
    return hex_to_int_custom(hex_string[::-1])


def hex_to_little_endian_custom(hex_string):
    return hex_to_int_custom(hex_string)


def big_endian_to_hex_custom(big_endian_int):
    return int_to_hex_custom(big_endian_int)


def little_endian_to_hex_custom(big_endian_int):
    return int_to_hex_custom(big_endian_int)
