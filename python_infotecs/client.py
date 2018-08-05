import socket


def run_client():
    sock = socket.socket()
    sock.connect(('localhost', 9002))
    number = '34'
    sock.send(number.encode('utf-8'))

    data = sock.recv(1024).decode('utf-8')
    sock.close()

    print(data)
    return data


if __name__ == "__main__":
    run_client()
