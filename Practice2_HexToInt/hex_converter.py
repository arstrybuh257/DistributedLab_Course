def hex_to_big_endian(hex_string):
    return int(hex_string, 16)


def hex_to_little_endian(hex_string):
    little_hex = bytearray.fromhex(hex_string)
    little_hex.reverse()
    str_little = ''
    for x in little_hex:
        str_little += format(x, 'x')
    return int(str_little, 16)


def big_endian_to_hex(big_endian_int):
    return hex(big_endian_int)


def little_endian_to_hex(big_endian_int):
    return hex(big_endian_int)
